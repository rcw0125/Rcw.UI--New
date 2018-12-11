using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Reflection;
using System.Data;
using System.Text.RegularExpressions;

namespace Rcw.Data.Oracle
{
    class OracleDataSource : DataSource
    {
        public OracleDataSource()
        {

        }

        //数据源名称  连接字符串
        public OracleDataSource(string dsName, string ConnectionString)
        {
            this.SourceName = dsName;
            this.ConnectionString = ConnectionString;

        }

        //初始化数据源
        public OracleDataSource(string dsName, string host, string db, string user, string password)
        {
            this.SourceName = dsName;
            this.ConnectionString = string.Format("Data Source={0}/{1};User ID={2};Password={3};", host, db, user, password);
        }

        //数据源类型
        public override string SourceType
        {
            get { return "Oracle"; }
        }
        /// <summary>
        /// 执行sql语句，修改删除，trans事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        public override void ExeSql(string sql, params object[] args)
        {
            OracleConnection conn = (OracleConnection)this.GetDbConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            InnerExeSql(sql, args, trans);
            trans.Commit();
            conn.Close();
        }


        //ExecuteNonQuery()方法主要用户更新数据，通常它使用Update,Insert,Delete语句来操作数据库，其方法返回值意义：对于 Update, Insert, Delete  语句
        //执行成功是返回值为该命令所影响的行数，如果影响的行数为0时返回的值为0，如果数据操作回滚得话返回值为-1，对于这种更新操作 
        //    用我们平时所用的是否大于0的判断操作应该没有问题而且比较好，但是对于其他的操作如对数据库结构的操作，如果操作成功时返回的却是-1,
        //    这种情况跟我们平时的思维方式有点差距所以应该好好的注意了，例如对数据库共添加一个数据表的Create操作，当创建数据表成功时返回-1,
        //    如果操作失败的话（如数据表已经存在）往往会发生异常，所以执行这种操作时最好用try--catch--语句来容错。

        private static void InnerExeSql(string sql, object[] args, OracleTransaction trans)
        {
            OracleConnection conn = trans.Connection as OracleConnection;
            OracleCommand cmd = conn.CreateCommand();
            //sql=sql.Replace("=@","=:");
            //sql = sql.Replace("=@", "=:").Replace(">@", ">:").Replace("<@", "<:");
            sql = sql.Replace("=@", "=:").Replace(">@", ">:").Replace("<@", "<:").Replace("like@", "like:");
            sql = sql.Replace("= @", "=:").Replace("> @", ">:").Replace("< @", "<:").Replace("like @", "like:");
            sql = sql.Replace("=  @", "=:").Replace(">  @", ">:").Replace("<  @", "<:").Replace("like  @", "like:");
            cmd.CommandText = sql;
            cmd.Transaction = trans;
            //防止有类似邮箱@符号出现
            sql = sql.Replace("@", "");
            List<string> paras = paras = ParseParameters(sql);

            int i = 0;
            foreach (var item in paras)
            {
                OracleParameter para = cmd.CreateParameter();
                para.ParameterName = item;
                para.Value = args[i++];
                cmd.Parameters.Add(para);
            }
            cmd.ExecuteNonQuery();
        }

        public override void ExeSql(System.Data.IDbTransaction trans, string sql, params object[] args)
        {
            InnerExeSql(sql, args, (OracleTransaction)trans);
        }


        private string transSql(string sql)
        {
            sql = sql.Replace("=@", "=:").Replace(">@", ">:").Replace("<@", "<:").Replace("like@", "like:");
            sql = sql.Replace("= @", "=:").Replace("> @", ">:").Replace("< @", "<:").Replace("like @", "like:");
            sql = sql.Replace("=  @", "=:").Replace(">  @", ">:").Replace("<  @", "<:").Replace("like  @", "like:");
            return sql;
        }
        /// <summary>
        /// ExecuteScalar这个方法是返回结果的第一行第一列的值。如果第一行第一列值不为空则返回对应的值(object类型)，比如数据是nchar类型值为 "123" 就可以用(int)ExecuteScalar()，
        ///如果数据是nchar类型值为 "abc"就不能用(int)ExecuteScalar(),就得写string result = ExecuteScalar().ToString；
        ///如果第一行存在但是第一列的值为空，返回DBNull；
        ///如果不存在第一行，返回null
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public override object ExecuteScalar(string sql, params object[] args)
        {
            OracleConnection conn = (OracleConnection)this.GetDbConnection();
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            //sql = sql.Replace("=@", "=:");
            //sql = sql.Replace("=:", "=@").Replace(">:", ">@").Replace("<:", "<@").Replace("like:", "like@");
            sql = transSql(sql);
            cmd.CommandText = sql;
            //防止有类似邮箱@符号出现
            sql = sql.Replace("@", "");
            List<string> paras = ParseParameters(sql);

            int i = 0;
            foreach (var item in paras)
            {
                OracleParameter para = cmd.CreateParameter();
                para.ParameterName = item;
                para.Value = args[i++];
                cmd.Parameters.Add(para);
            }
            object result = cmd.ExecuteScalar();
            conn.Close();

            return result;
        }

        public override int GetSeqNum(string prefix)
        {
            OracleConnection conn = (OracleConnection)this.GetDbConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            string sql = string.Format("insert into QC_Seq(prefix,curseq) select  '{0}',0 from dual  where not exists (select * from qc_seq where prefix='{0}')", prefix);

            OracleCommand cmd = new OracleCommand(sql);
            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.ExecuteNonQuery();

            OracleCommand cmd1 = new OracleCommand(string.Format("update qc_seq set curseq=curseq+1 where prefix='{0}'", prefix));
            cmd1.Connection = conn;
            cmd1.Transaction = trans;
            cmd1.ExecuteNonQuery();

            OracleCommand cmd2 = new OracleCommand(string.Format("select curseq from qc_seq where prefix='{0}'", prefix));
            cmd2.Connection = conn;
            cmd2.Transaction = trans;

            int key = 0;
            OracleDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                key = dr.GetInt32(0);
            }
            else
                throw new Exception("找不到顺序编号数据");
            dr.Close();

            trans.Commit();
            conn.Close();

            return key;
        }

        public override System.Data.IDbConnection GetDbConnection()
        {
            OracleConnection conn = new OracleConnection(this.ConnectionString);
            return conn;
        }

        public override void Insert(System.Data.IDbTransaction trans, DbEntity item, DbSql dbSql)
        {
            try
            {
                // DbSql dbSql = entityInfo.SqlInsert;
                if (dbSql == null) return;
                if (dbSql.Sql == "") return;

                OracleTransaction ora_trans = trans as OracleTransaction;
                //OracleConnection con = trans.Connection;
                OracleCommand insertCmd = ora_trans.Connection.CreateCommand();
                //insertCmd.Connection = con;
                insertCmd.Transaction = ora_trans;
                insertCmd.BindByName = true;
                insertCmd.CommandText = dbSql.Sql;
                foreach (var para in dbSql.Paras)
                {
                    if (para.Key.ToString() != ":RID")
                    {
                        OracleParameter cmdPara = AddCommandParameter(insertCmd, para.Value);
                        if (cmdPara != null)
                        {
                            object pvalue = para.Value.GetValue(item, null);
                            if (pvalue == null) pvalue = DBNull.Value;
                            cmdPara.Value = pvalue;
                        }

                    }
                }

                OracleParameter rid = insertCmd.Parameters.Add(":RID", OracleDbType.Varchar2);
                rid.Size = 18;
                rid.Direction = ParameterDirection.Output;               
                insertCmd.ExecuteNonQuery();
                item.RowId = rid.Value.ToString();


                if (item.entityInfo.hasAutoCol)
                {
                    if (!dbSql.Sql.Contains("_S.NextVal"))
                    {
                        return;
                    }

                    string sql = string.Format("select "+item.entityInfo.MainTableName+"_S.CurrVal from dual");
                    OracleCommand cmd = ora_trans.Connection.CreateCommand();
                    cmd.BindByName = true;
                    cmd.Transaction = ora_trans;
                    cmd.CommandText = sql;
                    var obj = cmd.ExecuteScalar();

                    var Typed = item.GetType();

                    foreach (var p in item.GetType().GetProperties())
                    {
                        if (p.Name == item.entityInfo.AutoColName)
                        {
                            p.SetValue(item, Convert.ToInt32(obj), null);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入错误：{0} 异常:{1}", dbSql.Sql, ex.Message));
            }
        }


        //添加 各种类型参数
        public static OracleParameter AddCommandParameter(OracleCommand cmd, PropertyInfo prop)
        {
            OracleParameter result = null;
            if (prop.PropertyType == typeof(string))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Varchar2);
            else if (prop.PropertyType == typeof(double))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Double);
            else if (prop.PropertyType == typeof(double?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Double);
            else if (prop.PropertyType == typeof(int))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Int32);
            else if (prop.PropertyType == typeof(int?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Int32);
            else if (prop.PropertyType == typeof(DateTime))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Date);
            else if (prop.PropertyType == typeof(DateTime?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Date);
            else if (prop.PropertyType == typeof(long))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Long);
            else if (prop.PropertyType == typeof(long?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Long);
            else if (prop.PropertyType == typeof(decimal))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Decimal);
            else if (prop.PropertyType == typeof(decimal?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Decimal);
            else if (prop.PropertyType == typeof(bool))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Int16);
            else if (prop.PropertyType == typeof(bool?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Int16);
            else if (prop.PropertyType == typeof(byte))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Byte);
            else if (prop.PropertyType == typeof(byte?))
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Byte);
            else if (prop.PropertyType.IsEnum)
                result = cmd.Parameters.Add(":" + prop.Name, OracleDbType.Int32);
            return result;
        }

        public override void Update(System.Data.IDbTransaction trans, DbEntity item, DbSql dbSql)
        {
            //DbSql dbSql = entityInfo.SqlUpdate;
            if (dbSql == null) return;
            if (dbSql.Sql == "") return;

          
            try
            {
                OracleTransaction ora_trans = trans as OracleTransaction;
                OracleConnection con = ora_trans.Connection;
                OracleCommand updateCmd = con.CreateCommand();
                updateCmd.Transaction = ora_trans;
                updateCmd.BindByName = true;
                updateCmd.CommandText = dbSql.Sql;
                foreach (var para in dbSql.Paras)
                {
                                     
                    if (para.Key.ToString() != ":RID")
                    {
                        OracleParameter cmdPara = AddCommandParameter(updateCmd, para.Value);                     
                        if (cmdPara != null)
                        {                           
                            object pvalue = para.Value.GetValue(item, null);                           
                            if (pvalue == null) pvalue = DBNull.Value;  
                            cmdPara.Value = pvalue;
                           
                        }
                    }                          
                }
                updateCmd.Parameters.Add(":RID", OracleDbType.Varchar2);
                updateCmd.Parameters[":RID"].Value = item.RowId;              
                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("update更新错误：{0} 异常:{1}", dbSql.Sql+"*****", ex.Message));
            }
        }

        public override void Delete(System.Data.IDbTransaction trans, DbEntity item, DbSql dbSql)
        {
            //DbSql dbSql = entityInfo.SqlDelete;
            if (dbSql == null) return;
            if (dbSql.Sql == "") return;
            try
            {
                OracleTransaction ora_trans = trans as OracleTransaction;
                OracleConnection con = ora_trans.Connection;
                OracleCommand deleteCmd = con.CreateCommand();
                deleteCmd.Transaction = ora_trans;
                deleteCmd.BindByName = true;
                deleteCmd.CommandText = dbSql.Sql;

                deleteCmd.Parameters.Add(":RID", OracleDbType.Varchar2).Value = item.RowId;
                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("删除错误：{0} 异常:{1}", dbSql.Sql, ex.Message));
            }
        }

        public override List<T> LoadData<T>(string loadSql, params object[] args)
        {
            OracleConnection conn = this.GetDbConnection() as OracleConnection;
            conn.Open();
            OracleCommand selectCmd = conn.CreateCommand();
            selectCmd.BindByName = true;

            List<T> result = LoadData<T>(loadSql, args, selectCmd);

            conn.Close();
            return result;
        }




        // 1. select table_name from user_tables where table_name=:tablename 在数据库中查询是否存在该表
        // 自动创建表 recreate TRUE  删除重建， false 存在就不重建
        public override void Create(DbEntityInfo entityInfo, bool recreate)
        {
            if (entityInfo.IsView) throw new Exception("查询不能创建表");
            OracleConnection con = this.GetDbConnection() as OracleConnection;
            //string tableName =Chinese2Spell.Convert( type.Name);
            string tableName = entityInfo.MainTableName;
            string tableDisplayName = entityInfo.DisplayName;
            bool hasTable = false;
            con.Open();
            OracleCommand cmdTest = new OracleCommand("select table_name from user_tables where table_name=:tablename", con);
            cmdTest.Parameters.Add(":tablename", OracleDbType.Varchar2).Value = tableName.ToUpper();
            OracleDataReader dr = cmdTest.ExecuteReader();
            if (dr.Read())
            {
                hasTable = true;
            }
            dr.Close();

            if (hasTable)
            {
                if (recreate)
                {
                    // 存在该表  删除
                    OracleCommand dropCmd = new OracleCommand("drop table " + tableName, con);
                    dropCmd.ExecuteNonQuery();
                }
                else
                {
                    con.Close();
                    return;
                }
            }

            StringBuilder sql = new StringBuilder();

            sql.Append("create table ");
            sql.Append(tableName);
            sql.Append("(");
            List<string> comment = new List<string>();
            string colPrimaryKey = "";
            comment.Add(string.Format("comment on table {0} is '{1}'", tableName, tableDisplayName));
            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in entityInfo.Columns)
            {
                //是主表列
                if (colInfo.IsMainTableColumn)
                {
                    //shi自动增长
                    if (colInfo.AutoIncrement)
                    {
                        string seqName =  colInfo.TableName+"_S";
                        try
                        {
                            OracleCommand cmdDropSeq = new OracleCommand("DROP SEQUENCE " + seqName, con);
                            cmdDropSeq.ExecuteNonQuery();
                        }
                        catch
                        {
                        }         
                        // 创建序列 增加1 开始1 没有最大值 没有到最大值后从头开始 缓存10
                        string sqlSeq = "CREATE  SEQUENCE " + seqName + " INCREMENT BY 1 START WITH 1 NOMAXVALUE NOCYCLE CACHE 10";
                        OracleCommand cmdSeq = new OracleCommand(sqlSeq, con);
                        cmdSeq.ExecuteNonQuery();
                    }
                    // 是否主键
                    if (colInfo.IsPrimaryColumn)
                    {
                        if (string.IsNullOrEmpty(colPrimaryKey))
                        {
                            colPrimaryKey = colInfo.ColName;
                        }
                        else
                        {
                            colPrimaryKey += "," + colInfo.ColName;
                        }
                    }

                    allCols.AppendLine(colInfo.ColName);
                    // 列的备注说明
                    comment.Add(string.Format("comment on column {0}.{1} is '{2}'", tableName, colInfo.ColName, colInfo.Description));


                    PropertyInfo prop = colInfo.ColPropertyInfo;
                    allCols.Append(" ");
                    if (prop.PropertyType == typeof(string))
                        allCols.Append("VARCHAR2(400)");
                    else if (prop.PropertyType == typeof(double))
                        allCols.Append("NUMBER(20,6)");
                    else if (prop.PropertyType == typeof(double?))
                        allCols.Append("NUMBER(20,6)");
                    else if (prop.PropertyType == typeof(int) || prop.PropertyType.IsEnum)
                        allCols.Append("NUMBER(8)");
                    else if (prop.PropertyType == typeof(int?))
                        allCols.Append("NUMBER(8)");
                    else if (prop.PropertyType == typeof(DateTime))
                        allCols.Append("DATE");// allCols.Append("CHAR(19)"); // 
                    else if (prop.PropertyType == typeof(DateTime?))
                        allCols.Append("DATE");//  allCols.Append("CHAR(19)");//
                    else if (prop.PropertyType == typeof(long))
                        allCols.Append("NUMBER(20)");
                    else if (prop.PropertyType == typeof(long?))
                        allCols.Append("NUMBER(20)");
                    else if (prop.PropertyType == typeof(decimal))
                        allCols.Append("NUMBER(20,6)");
                    else if (prop.PropertyType == typeof(decimal?))
                        allCols.Append("NUMBER(20,6)");
                    else if (prop.PropertyType == typeof(bool))
                        allCols.Append("NUMBER(1)");
                    else if (prop.PropertyType == typeof(bool?))
                        allCols.Append("NUMBER(1)");
                    else if (prop.PropertyType == typeof(byte))
                        allCols.Append("NUMBER(3)");
                    else if (prop.PropertyType == typeof(byte?))
                        allCols.Append("NUMBER(3)");
                    if (colInfo.IsGuid)
                    {
                        allCols.Append("     DEFAULT sys_guid()     ");
                    }
                    if (colInfo.IsSysDate)
                    {
                        allCols.Append("     DEFAULT SYSDATE           ");
                    }
                    if (colInfo.IsSysDateString)
                    {
                        allCols.Append("     DEFAULT to_char(sysdate,'yyyy-mm-dd hh24:mi:ss')          ");
                    }
                    allCols.Append(",");
                }
            }
            allCols.Remove(allCols.Length - 1, 1);
            sql.Append(allCols.ToString());
            sql.Append(")");

            //添加表字段
            OracleCommand cmd = new OracleCommand(sql.ToString(), con);
            cmd.ExecuteNonQuery();

            //添加表的列的备注说明
            foreach (var item in comment)
            {
                OracleCommand cmd1 = new OracleCommand(item, con);

                cmd1.ExecuteNonQuery();
            }

            //添加主键
            if (colPrimaryKey != "")
            {
                string sqlPrimaryKey = string.Format("alter table {0} add constraint PK_{0} primary key ({1})", tableName, colPrimaryKey);
                OracleCommand cmdPrimaryKey = new OracleCommand(sqlPrimaryKey, con);
                cmdPrimaryKey.ExecuteNonQuery();
            }


            con.Close();
        }

        public override void InitSql(DbEntityInfo entityInfo)
        {
            #region 当表是视图时，只初始化SelectSql，不是视图时，初始化增删改查
            if (!entityInfo.IsView)
            {          
                entityInfo.SqlInsert = BuildInsertSql(entityInfo);
                entityInfo.SqlUpdate = BuildUpdateSql(entityInfo);
                entityInfo.SqlDelete = BuildDeleteSql(entityInfo);
            }          
            entityInfo.SelectSql = BuildSelectSql(entityInfo);
            #endregion


            #region 初始化sqlOrder 排序条件
            // order by  字段
            List<string> orderLst = new List<string>();
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.SortDirection != SortDirection.None)
                {
                    orderLst.Add(string.Format("{0}_{1} {2}", colInfo.SortOrder, colInfo.FullColName, colInfo.SortDirection == SortDirection.Ascending ? "asc" : "desc"));
                }
            }
            if (orderLst.Count > 0)
            {
                orderLst.Sort();
                string sqlOrder = "";
                foreach (var item in orderLst)
                {
                    sqlOrder += item.Substring(item.IndexOf('_') + 1) + ",";
                }
                sqlOrder = " order by " + sqlOrder.Substring(0, sqlOrder.Length - 1);
                entityInfo.SqlOrder = sqlOrder;
            }
            #endregion

        }

        

  
        //建立插入sql
        public static DbSql BuildInsertSql(DbEntityInfo entityInfo)
        {
            DbSql dbSql = new DbSql();

            string prefix = ":";
            StringBuilder sql_part1 = new StringBuilder();
            StringBuilder sql_part2 = new StringBuilder();

            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in entityInfo.Columns)
            {
                //如果是guid列，则跳过此列
                if (colInfo.IsGuid || colInfo.IsSysDate || colInfo.IsSysDateString)
                {
                    continue;
                }
                //如果是自动增长列，查询序列的下一个值
                if (colInfo.AutoIncrement)
                {
                    sql_part1.Append(",");
                    sql_part1.Append(colInfo.ColName);
                    sql_part2.Append("," + colInfo.TableName + "_S.NextVal");
                    continue;
                }
                if (colInfo.IsInsertColumn)
                {
                    sql_part1.Append(",");
                    sql_part1.Append(colInfo.ColName);
                    sql_part2.Append("," + prefix);
                    sql_part2.Append(colInfo.ColPropertyInfo.Name);
                    dbSql.Paras.Add(prefix + colInfo.ColPropertyInfo.Name, colInfo.ColPropertyInfo);
                }
            }

            StringBuilder sql = new StringBuilder();

            sql.Append("insert into ");
            sql.Append(entityInfo.MainTableName + "(");
            sql.Append(sql_part1.ToString().Substring(1));
            sql.Append(") values(");
            sql.Append(sql_part2.ToString().Substring(1));
            sql.Append(")");
            sql.Append(" RETURNING ROWID INTO :RID");

            dbSql.ReturnVals.Add(":RID", typeof(DbEntity).GetProperty("RowId"));
            dbSql.Sql = sql.ToString();

            return dbSql;

        }

        public static DbSql BuildUpdateSql(DbEntityInfo entityInfo)
        {
            DbSql result = new DbSql();

            string mainTableName = entityInfo.MainTableName;

            StringBuilder sql = new StringBuilder();
            sql.Append("update ");
            sql.Append(mainTableName);
            sql.Append(" set ");

            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.IsPrimaryColumn)
                {
                    continue;
                }
                if (colInfo.IsUpdateColumn)
                {
                    allCols.Append(",");
                    allCols.Append(colInfo.ColName);
                    allCols.Append("=:");
                    allCols.Append(colInfo.ColPropertyInfo.Name);
                    result.Paras.Add(":" + colInfo.ColPropertyInfo.Name, colInfo.ColPropertyInfo);
                }
            }
            allCols.Remove(0, 1);
            sql.Append(allCols.ToString());
            sql.Append(" where ROWID=:RID");
            result.Paras.Add(":RID",typeof(DbEntity).GetProperty("RowId"));

            result.Sql = sql.ToString();
            return result;
        }

        public static DbSql BuildUpdateSql(DbEntityInfo entityInfo, List<string> upd_paras)
        {
            DbSql result = new DbSql();

            string mainTableName = entityInfo.MainTableName;

            StringBuilder sql = new StringBuilder();
            sql.Append("update ");
            sql.Append(mainTableName);
            sql.Append(" set ");

            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in upd_paras)
            {
                allCols.Append(",");
                allCols.Append(entityInfo.GetColumnInfo(colInfo).ColName);
                allCols.Append("=:");
                allCols.Append(colInfo);
            }
            allCols.Remove(0, 1);
            sql.Append(allCols.ToString());
            sql.Append(" where ROWID=:RID");
            result.Paras.Add(":RID", typeof(DbEntity).GetProperty("RowId"));

            result.Sql = sql.ToString();
            return result;
        }


        public static DbSql BuildDeleteSql(DbEntityInfo entityInfo)
        {
            DbSql result = new DbSql();
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from ");
            sql.Append(entityInfo.MainTableName);
            sql.Append(" where ROWID=:RID");

            result.Paras.Add(":RID", typeof(DbEntity).GetProperty("RowId"));
            result.Sql = sql.ToString();
            return result;
        }

        public static string BuildSelectSql(DbEntityInfo entityInfo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            if (entityInfo.IsDistinct) sql.Append("Distinct ");

            //if (entityInfo.otherTables.Count > 0)
            //{
            //    foreach (var colInfo in entityInfo.Columns)
            //    {
            //        string colName = colInfo.FullColName + " as " + colInfo.ColPropertyInfo.Name;
            //        sql.Append(colName);
            //        sql.Append(",");
            //    }
            //}
            //else
            //{
            //    foreach (var colInfo in entityInfo.Columns)
            //    {
            //        string colName = colInfo.ColName + " as " + colInfo.ColPropertyInfo.Name;
            //        sql.Append(colName);
            //        sql.Append(",");
            //    }
            //}
            //20181210 rcw  修改 查询时，列全部使用全名， 主表别名 为空时，为表名的小写
            foreach (var colInfo in entityInfo.Columns)
            {
                string colName = colInfo.FullColName + " as " + colInfo.ColPropertyInfo.Name;
                sql.Append(colName);
                sql.Append(",");
            }

            //foreach (var colInfo in entityInfo.Columns)
            //{
            //    string colName = colInfo.ColName + " as " + colInfo.ColPropertyInfo.Name;
            //    if (entityInfo.otherTables.Count > 0)
            //    {
            //        if (string.IsNullOrEmpty(colInfo.TableAlias))
            //        {
            //            colName = colInfo.TableName + "." + colName;
            //        }
            //        else
            //        {
            //            colName = colInfo.TableAlias + "." + colName;
            //        }
            //    }
            //    sql.Append(colName);
            //    sql.Append(",");
            //}
            //sql.Remove(sql.Length - 1, 1);
            //20181115 不是视图时，才可以使用ROWID
            if (!entityInfo.IsView)
            {
                if (string.IsNullOrEmpty(entityInfo.MainTableAlias))
                    sql.Append(entityInfo.MainTableName + ".ROWID");
                else
                    sql.Append(entityInfo.MainTableAlias + ".ROWID");

            }
            else
            {
                //将最后一个逗号，移除
                sql.Remove(sql.Length - 1, 1);
            }

            sql.Append(" FROM ");

            sql.Append(entityInfo.MainTableName + " " + entityInfo.MainTableAlias + " ");
            foreach (var tbInfo in entityInfo.otherTables)
            {
                sql.Append(string.Format(" {0} join {1} {2} on {3} ", tbInfo.JoinType, tbInfo.JoinTableName, tbInfo.JoinTableAlias, tbInfo.JoinCondition));
            }

            return sql.ToString();
        }
        /// <summary>
        /// 提取sql语句中的参数,查询的sql里带有时间（2018-11-20 10:41:42）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<string> ParseParameters(string sql)
        {
            //Regex paramReg = new Regex(@"[^@@](?<p>@\w+)\W");
            //MatchCollection matches = paramReg.Matches(String.Concat(sql, " "));

            //Regex paramReg = new Regex(@"\W[^::](?<p>:\w+)\W");
            //\w并不完全等于[A-Za-z0-9] 包括了英文字母以及俄文字母等
            //sql = sql.Replace("=:", "=@");
            sql = sql.Replace("=:", "=@").Replace(">:", ">@").Replace("<:", "<@").Replace("like:","like@");
            List<string> result = new List<string>();
            //Regex paramReg = new Regex(@"\W[^::](?<p>:\w+)\W");
            Regex paramReg = new Regex(@"[^@@](?<p>@\w+)\W");
            MatchCollection matches = paramReg.Matches(String.Concat(sql, " "));
            foreach (Match m in matches)
            {
                string paraName = m.Groups["p"].Value;
                paraName = paraName.Replace("@",":");
                if (!result.Contains(paraName))
                    result.Add(paraName);
            }
            return result;
        }

        /// <summary>
        /// 提取sql语句中的参数,查询的sql里带有时间（2018-11-20 10:41:42）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<string> ParseParametersNew(string sql)
        {
            //Regex paramReg = new Regex(@"[^@@](?<p>@\w+)\W");
            //MatchCollection matches = paramReg.Matches(String.Concat(sql, " "));

            //Regex paramReg = new Regex(@"\W[^::](?<p>:\w+)\W");
            //\w并不完全等于[A-Za-z0-9] 包括了英文字母以及俄文字母等
            //sql = sql.Replace("=:", "=@");
            sql = sql.Replace("=:", "=@").Replace(">:", ">@").Replace("<:", "<@").Replace("like:", "like@");
            sql = sql.Replace("= :", "=@").Replace("> :", ">@").Replace("< :", "<@").Replace("like :", "like@");
            sql = sql.Replace("=  :", "=@").Replace(">  :", ">@").Replace("<  :", "<@").Replace("like  :", "like@");
            List<string> result = new List<string>();
            //Regex paramReg = new Regex(@"\W[^::](?<p>:\w+)\W");
            Regex paramReg = new Regex(@"[^@@](?<p>@\w+)\W");
            MatchCollection matches = paramReg.Matches(String.Concat(sql, " "));
            foreach (Match m in matches)
            {
                string paraName = m.Groups["p"].Value;
                paraName = paraName.Replace("@", ":");
                if (!result.Contains(paraName))
                    result.Add(paraName);
            }
            return result;
        }

        public override DataTable Query(string loadSql, params object[] args)
        {
            try
            {
                OracleConnection conn = this.GetDbConnection() as OracleConnection;
                conn.Open();
                OracleCommand selectCmd = conn.CreateCommand();
                //loadSql=loadSql.Replace("=@", "=:");
                //loadSql = loadSql.Replace("=@", "=:").Replace(">@", ">:").Replace("<@", "<:");
                loadSql = transSql(loadSql);
                //  sql = sql.Replace("=@", "=:").Replace(">@", ">:").Replace("<@", "<:");
                selectCmd.CommandText = loadSql;
                selectCmd.BindByName = true;
                loadSql = loadSql.Replace("@","");
                int i = 0;
                foreach (var item in ParseParameters(loadSql))
                {
                   selectCmd.Parameters.Add(item, args[i++]);
                }
                OracleDataAdapter oradap = new OracleDataAdapter(selectCmd);
                DataSet ds = new DataSet();
                oradap.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                throw new Exception("oracle数据查询Query（）出现异常" + ex.ToString());
               
            }


        }

        /// <summary>
        /// 匹配参数@，只要有@，就会被当做是参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <param name="selectCmd"></param>
        /// <returns></returns>
        private static List<T> LoadData<T>(string sql, object[] args, OracleCommand selectCmd) where T : DbEntity, new()
        {
            //sql = sql.Replace("=@", "=:");
            //sql = sql.Replace("@", ":");
            sql = sql.Replace("=@", "=:").Replace(">@", ">:").Replace("<@", "<:").Replace("like@", "like:");
            sql = sql.Replace("= @", "=:").Replace("> @", ">:").Replace("< @", "<:").Replace("like @", "like:");
            sql = sql.Replace("=  @", "=:").Replace(">  @", ">:").Replace("<  @", "<:").Replace("like  @", "like:");
            selectCmd.CommandText = sql;
            sql = sql.Replace("@", "");
            List<T> result = new List<T>();
            int i = 0;
            foreach (var item in ParseParameters(sql))
            {
               // selectCmd.Parameters.Add(item, args[i++]);
               //2018-11-19修改 当传入的参数是枚举类型时，报错，值不在预期的范围内
               //加入判断 先校验是否是枚举类型，是的话，先转为int类型
                if (args[i].GetType().BaseType.FullName == "System.Enum")
                {
                    selectCmd.Parameters.Add(item, (int)args[i++]);
                }
                else
                {
                    selectCmd.Parameters.Add(item, args[i++]);
                }
            }

            Dictionary<int, ISetterValue> setters = null;
            OracleDataReader dr = selectCmd.ExecuteReader();
            while (dr.Read())
            {
                if (setters == null)
                {
                    setters = new Dictionary<int, ISetterValue>();
                    for (int col = 0; col < dr.FieldCount; col++)
                    {
                        setters.Add(col, dr.GetColumnSetter<T>(col));
                    }
                }
                T item = new T();// Activator.CreateInstance<T>();
                item.BeginInit();
                for (int col = 0; col < dr.FieldCount; col++)
                {
                    ISetterValue setter = setters[col];
                    if (setter != null)
                    {
                        setter.SetValue(item, col);
                    }
                }
                item.AcceptChanges();
                item.EndInit();
                result.Add(item);
            }
            dr.Close();
            return result;
        }

        public static List<T> LoadData<T>(OracleTransaction trans, string sql, params object[] args) where T : DbEntity, new()
        {
            OracleCommand selectCmd = trans.Connection.CreateCommand();
            selectCmd.BindByName = true;
            selectCmd.Transaction = trans;

            return LoadData<T>(sql, args, selectCmd);
        }

    }
}
