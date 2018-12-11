using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Rcw.Data.SqlServer
{
    class SqlServerDataSource : DataSource
    {
        public SqlServerDataSource()
        {

        }

        public SqlServerDataSource(string dsName, string ConnectionString)
        {
            this.SourceName = dsName;
            this.ConnectionString = ConnectionString;
        }

        public SqlServerDataSource(string dsName, string host, string db, string user, string password)
        {
            this.SourceName = dsName;
            this.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", host, db, user, password);
        }

        public override string SourceType
        {
            get { return "SqlServer"; }
        }

        public override void ExeSql(string sql, params object[] args)
        {
            SqlConnection conn = (SqlConnection)this.GetDbConnection();
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            InnerExeSql(sql, args, trans);
            trans.Commit();
            conn.Close();
        }

        private static void InnerExeSql(string sql, object[] args, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection as SqlConnection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            List<string> paras = paras = ParseParameters(sql);

            int i = 0;
            foreach (var item in paras)
            {
                SqlParameter para = cmd.CreateParameter();
                para.ParameterName = item;
                para.Value = args[i++];
                cmd.Parameters.Add(para);
            }
            cmd.ExecuteNonQuery();
        }

        public override void ExeSql(System.Data.IDbTransaction trans, string sql, params object[] args)
        {
            InnerExeSql(sql, args, (SqlTransaction)trans);
        }

        public override object ExecuteScalar(string sql, params object[] args)
        {
            SqlConnection conn = (SqlConnection)this.GetDbConnection();
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            List<string> paras = ParseParameters(sql);

            int i = 0;
            foreach (var item in paras)
            {
                SqlParameter para = cmd.CreateParameter();
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
            SqlConnection conn = (SqlConnection)this.GetDbConnection();
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            string sql = string.Format("insert into QC_Seq(prefix,curseq) select top 1 '{0}',0 from sysobjects  where not exists (select * from qc_seq where prefix='{0}')", prefix);

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand(string.Format("update qc_seq set curseq=curseq+1 where prefix='{0}'", prefix));
            cmd1.Connection = conn;
            cmd1.Transaction = trans;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(string.Format("select curseq from qc_seq where prefix='{0}'", prefix));
            cmd2.Connection = conn;
            cmd2.Transaction = trans;

            int key = 0;
            SqlDataReader dr = cmd2.ExecuteReader();
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

        private static int InnerGetSeqNum(string prefix, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection;

            string sql = string.Format("insert into QC_Seq(prefix,curseq) select top 1 '{0}',0 from sysobjects  where not exists (select * from qc_seq where prefix='{0}')", prefix);

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand(string.Format("update qc_seq set curseq=curseq+1 where prefix='{0}'", prefix));
            cmd1.Connection = conn;
            cmd1.Transaction = trans;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(string.Format("select curseq from qc_seq where prefix='{0}'", prefix));
            cmd2.Connection = conn;
            cmd2.Transaction = trans;

            int key = 0;
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                key = dr.GetInt32(0);
            }
            else
                throw new Exception("找不到顺序编号数据");
            dr.Close();
            return key;
        }

        public override System.Data.IDbConnection GetDbConnection()
        {
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            return conn;
        }

        public override void Insert(System.Data.IDbTransaction trans, DbEntity item, DbSql dbSql)
        {
            try
            {
                //DbSql dbSql = entityInfo.SqlInsert;
                if (dbSql == null) return;
                if (dbSql.Sql == "") return;

                SqlTransaction sql_trans = trans as SqlTransaction;
                SqlCommand insertCmd = sql_trans.Connection.CreateCommand();
                insertCmd.Transaction = sql_trans;
                insertCmd.CommandText = dbSql.Sql;

                foreach (var para in dbSql.Paras)
                {
                    SqlParameter cmdPara = AddCommandParameter(insertCmd, para.Value);
                    if (cmdPara != null)
                    {
                        object pvalue = para.Value.GetValue(item, null);
                        if (pvalue == null) pvalue = DBNull.Value;
                        cmdPara.Value = pvalue;
                    }
                }


                PropertyInfo autoIncrementProperty = null;

                if (dbSql.ReturnVals != null && dbSql.ReturnVals.Count > 0)
                {
                    foreach (var rv in dbSql.ReturnVals)
                    {
                        autoIncrementProperty = rv.Value;
                    }
                }
              
                //foreach (var colInfo in entityInfo.Columns)
                //{
                //    if (colInfo.AutoIncrement)
                //    {
                //        autoIncrementProperty = colInfo.ColPropertyInfo;
                //    }
                //    if (colInfo.IsInsertColumn)
                //    {
                //        SqlParameter cmdPara = AddCommandParameter(insertCmd, colInfo.ColPropertyInfo);
                //        if (cmdPara != null)
                //        {
                //            object pvalue = colInfo.ColPropertyInfo.GetValue(item, null);
                //            if (pvalue == null) pvalue = DBNull.Value;
                //            //if (colInfo.ColPropertyInfo.PropertyType.IsEnum)
                //            //{
                //            //    int tempVal = Convert.ToInt32(pvalue);
                //            //    cmdPara.Value = tempVal;
                //            //}
                //            //else
                //            cmdPara.Value = pvalue;
                //        }
                //    }
                //}

                if (autoIncrementProperty != null)
                {
                    int id = Convert.ToInt32(insertCmd.ExecuteScalar());
                    autoIncrementProperty.SetValue(item, id, null);
                }
                else
                {
                    insertCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入错误：{0} 异常:{1}", dbSql.Sql, ex.Message));
            }
        }

        public override void Update(System.Data.IDbTransaction trans, DbEntity item, DbSql dbSql)
        {
            //DbSql dbSql = entityInfo.SqlUpdate;
            if (dbSql == null) return;
            if (dbSql.Sql == "") return;
            try
            {
                SqlTransaction sql_trans = trans as SqlTransaction;
                SqlConnection con = sql_trans.Connection;
                SqlCommand updateCmd = con.CreateCommand();
                updateCmd.Transaction = sql_trans;
                updateCmd.CommandText = dbSql.Sql;

                foreach (var para in dbSql.Paras)
                {
                    SqlParameter cmdPara = AddCommandParameter(updateCmd, para.Key, para.Value);
                    if (cmdPara != null)
                    {
                        object pvalue = para.Value.GetValue(item, null);
                        if (pvalue == null) pvalue = DBNull.Value;
                        cmdPara.Value = pvalue;
                    }
                }

                //foreach (var colInfo in entityInfo.Columns)
                //{
                //    if (colInfo.IsUpdateColumn && !colInfo.IsUpdateConditionColumn)
                //    {
                //        SqlParameter cmdPara = AddCommandParameter(updateCmd, colInfo.ColPropertyInfo);
                //        if (cmdPara != null)
                //        {
                //            object pvalue = colInfo.ColPropertyInfo.GetValue(item, null);
                //            if (pvalue == null) pvalue = DBNull.Value;
                //            cmdPara.Value = pvalue;
                //        }
                //    }
                //}
                //foreach (var colInfo in entityInfo.Columns)
                //{
                //    if (colInfo.IsUpdateConditionColumn)
                //    {
                //        SqlParameter cmdPara = AddCommandParameter(updateCmd, colInfo.ColPropertyInfo, "@UPD_");
                //        if (cmdPara != null)
                //        {
                //            object pvalue = colInfo.ColPropertyInfo.GetValue(item, null);
                //            if (pvalue == null) pvalue = DBNull.Value;
                //            cmdPara.Value = pvalue;
                //        }
                //    }
                //}

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入错误：{0} 异常:{1}", dbSql.Sql, ex.Message));
            }
        }

        public override void Delete(System.Data.IDbTransaction trans, DbEntity item, DbSql dbSql)
        {
            //DbSql dbSql = entityInfo.SqlDelete;
            if (dbSql == null) return;
            if (dbSql.Sql == "") return;
            try
            {
                SqlTransaction sql_trans = trans as SqlTransaction;
                SqlConnection con = sql_trans.Connection;
                SqlCommand deleteCmd = con.CreateCommand();
                deleteCmd.Transaction = sql_trans;
                deleteCmd.CommandText = dbSql.Sql;

                foreach (var para in dbSql.Paras)
                {
                    SqlParameter cmdPara = AddCommandParameter(deleteCmd, para.Key, para.Value);
                    if (cmdPara != null)
                    {
                        object pvalue = para.Value.GetValue(item, null);
                        if (pvalue == null) pvalue = DBNull.Value;
                        cmdPara.Value = pvalue;
                    }
                }

                //foreach (var colInfo in entityInfo.Columns)
                //{
                //    if (colInfo.IsDeleteConditionColumn)
                //    {
                //        SqlParameter cmdPara = AddCommandParameter(deleteCmd, colInfo.ColPropertyInfo, "@DEL_");
                //        if (cmdPara != null)
                //        {
                //            object pvalue = colInfo.ColPropertyInfo.GetValue(item, null);
                //            if (pvalue == null) pvalue = DBNull.Value;
                //            cmdPara.Value = pvalue;
                //        }
                //    }
                //}
                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("删除错误：{0} 异常:{1}", dbSql.Sql, ex.Message));
            }
        }

        public override List<T> LoadData<T>(string loadSql, params object[] args)
        {
            SqlConnection conn = this.GetDbConnection() as SqlConnection;
            conn.Open();
            SqlCommand selectCmd = conn.CreateCommand();
            List<T> result = LoadData<T>(loadSql, args, selectCmd);
            conn.Close();
            return result;
        }
        public override void Create(DbEntityInfo entityInfo, bool recreate)
        {
            if (entityInfo.IsView) throw new Exception("查询不能创建表");
            SqlConnection con = this.GetDbConnection() as SqlConnection;
            //string tableName =Chinese2Spell.Convert( type.Name);
            string tableName = entityInfo.MainTableName;
            string tableDisplayName = entityInfo.DisplayName;
            bool hasTable = false;
            con.Open();
            SqlCommand cmdTest = new SqlCommand("SELECT name FROM sysobjects WHERE xtype='U' and name=@tablename", con);
            cmdTest.Parameters.Add("@tablename", SqlDbType.VarChar).Value = tableName;
            SqlDataReader dr = cmdTest.ExecuteReader();
            if (dr.Read())
            {
                hasTable = true;
            }
            dr.Close();

            if (hasTable)
            {
                if (recreate)
                {
                    SqlCommand dropCmd = new SqlCommand("drop table " + tableName, con);
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
            comment.Add(string.Format(" sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}'", tableDisplayName, tableName));

            List<string> colNames = new List<string>();
            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.IsMainTableColumn)
                {
                    if (colNames.Contains(colInfo.ColName)) continue;

                    colNames.Add(colInfo.ColName);

                    allCols.AppendLine(colInfo.ColName);
                    //sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'driver_info', @level2type=N'COLUMN',@level2name=N'code'
                    //comment.Add(string.Format("comment on column {0}.{1} is '{2}'", tableName, colInfo.ColName, colInfo.Description));
                    comment.Add(string.Format(" sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}', @level2type=N'COLUMN',@level2name=N'{2}'", colInfo.Description, tableName, colInfo.ColName));
               
                    PropertyInfo prop = colInfo.ColPropertyInfo;
                    allCols.Append(" ");
                    if (prop.PropertyType == typeof(string))
                        allCols.Append("varchar(400)");
                    else if (prop.PropertyType == typeof(double))
                        allCols.Append("float");
                    else if (prop.PropertyType == typeof(double?))
                        allCols.Append("float");
                    else if (prop.PropertyType == typeof(int) || prop.PropertyType.IsEnum)
                        allCols.Append("int");
                    else if (prop.PropertyType == typeof(int?))
                        allCols.Append("int");
                    else if (prop.PropertyType == typeof(DateTime))
                        allCols.Append("DateTime");// allCols.Append("CHAR(19)"); // 
                    else if (prop.PropertyType == typeof(DateTime?))
                        allCols.Append("DateTime");//  allCols.Append("CHAR(19)");//
                    else if (prop.PropertyType == typeof(long))
                        allCols.Append("bigint");
                    else if (prop.PropertyType == typeof(long?))
                        allCols.Append("bigint");
                    else if (prop.PropertyType == typeof(decimal))
                        allCols.Append("decimal");
                    else if (prop.PropertyType == typeof(decimal?))
                        allCols.Append("decimal");
                    else if (prop.PropertyType == typeof(bool))
                        allCols.Append("bit");
                    else if (prop.PropertyType == typeof(bool?))
                        allCols.Append("bit");
                    else if (prop.PropertyType == typeof(byte))
                        allCols.Append("char");
                    else if (prop.PropertyType == typeof(byte?))
                        allCols.Append("char");

                    if (colInfo.AutoIncrement)
                    {
                        allCols.Append(" identity(1,1) ");
                    }
                       
                    if (colInfo.IsPrimaryColumn)
                    {
                        allCols.Append(" primary key");
                        //colPrimaryKey += colInfo.ColName + ",";
                    }

                    if (colInfo.IsGuid)
                    {
                        allCols.Append("     DEFAULT (newid())     ");
                    }
                    if (colInfo.IsSysDate)
                    {
                        allCols.Append("     DEFAULT (getdate())           ");
                    }
                    if (colInfo.IsSysDateString)
                    {
                        allCols.Append("     DEFAULT convert(varchar(20),GETDATE(),120)          ");
                    }

                    allCols.Append(",");
                }
            }
            //if (colPrimaryKey != "")
            //{
            //    string sqlPrimaryKey = string.Format("constraint PK_{0} primary key ({1})", tableName, colPrimaryKey.Substring(0, colPrimaryKey.Length - 1));
            //}
            //else
            //{
               
            //}
            allCols.Remove(allCols.Length - 1, 1);


            sql.Append(allCols.ToString());
            sql.Append(")");

            //建表
            SqlCommand cmd = new SqlCommand(sql.ToString(), con);
            cmd.ExecuteNonQuery();
            //向数据库添加字段描述信息
            foreach (var item in comment)
            {
                SqlCommand cmd1 = new SqlCommand(item, con);

                cmd1.ExecuteNonQuery();
            }
           

            //if (colPrimaryKey != "")
            //{
            //    string sqlPrimaryKey = string.Format("alter table {0} add constraint PK_{0} primary key ({1})", tableName, colPrimaryKey.Substring(0, colPrimaryKey.Length - 1));
            //    SqlCommand cmdPrimaryKey = new SqlCommand(sqlPrimaryKey, con);
            //    cmdPrimaryKey.ExecuteNonQuery();
            //}

            con.Close();
        }
     
        public override void InitSql(DbEntityInfo entityInfo)
        {
            if (!entityInfo.HasPrimaryKey && !entityInfo.IsView)
                throw new Exception("无主键异常" + entityInfo.MainTableName);

            if (!entityInfo.IsView)
            {
                entityInfo.SqlInsert = BuildInsertSql(entityInfo);
                entityInfo.SqlUpdate = BuildUpdateSql(entityInfo);
                entityInfo.SqlDelete = BuildDeleteSql(entityInfo);
            }
            entityInfo.SelectSql = BuildSelectSql(entityInfo);


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
                //sqlOrder = string.Format("row_number() OVER (ORDER BY {0}) AS RowNumber", sqlOrder.Substring(0, sqlOrder.Length - 1));
                entityInfo.SqlOrder = sqlOrder;
            }
          
        }

        public static SqlParameter AddCommandParameter(SqlCommand cmd, PropertyInfo prop)
        {
            return AddCommandParameter(cmd, prop, "@");
        }
      
        //添加命令参数
        public static SqlParameter AddCommandParameter(SqlCommand cmd, PropertyInfo prop, string preChar)
        {
            return AddCommandParameter(cmd, preChar + prop.Name, prop);
        }

        public static SqlParameter AddCommandParameter(SqlCommand cmd,string paraName, PropertyInfo prop)
        {
            SqlParameter result = null;
            if (prop.PropertyType == typeof(string))
                result = cmd.Parameters.Add(paraName, SqlDbType.VarChar);
            else if (prop.PropertyType == typeof(double))
                result = cmd.Parameters.Add(paraName, SqlDbType.Float);
            else if (prop.PropertyType == typeof(double?))
                result = cmd.Parameters.Add(paraName, SqlDbType.Float);
            else if (prop.PropertyType == typeof(int))
                result = cmd.Parameters.Add(paraName, SqlDbType.Int);
            else if (prop.PropertyType == typeof(int?))
                result = cmd.Parameters.Add(paraName, SqlDbType.Int);
            else if (prop.PropertyType == typeof(DateTime))
                result = cmd.Parameters.Add(paraName, SqlDbType.DateTime);
            else if (prop.PropertyType == typeof(DateTime?))
                result = cmd.Parameters.Add(paraName, SqlDbType.DateTime);
            else if (prop.PropertyType == typeof(long))
                result = cmd.Parameters.Add(paraName, SqlDbType.BigInt);
            else if (prop.PropertyType == typeof(long?))
                result = cmd.Parameters.Add(paraName, SqlDbType.BigInt);
            else if (prop.PropertyType == typeof(decimal))
                result = cmd.Parameters.Add(paraName, SqlDbType.Decimal);
            else if (prop.PropertyType == typeof(decimal?))
                result = cmd.Parameters.Add(paraName, SqlDbType.Decimal);
            else if (prop.PropertyType == typeof(bool))
                result = cmd.Parameters.Add(paraName, SqlDbType.Bit);
            else if (prop.PropertyType == typeof(bool?))
                result = cmd.Parameters.Add(paraName, SqlDbType.Bit);
            else if (prop.PropertyType == typeof(byte))
                result = cmd.Parameters.Add(paraName, SqlDbType.Bit);
            else if (prop.PropertyType == typeof(byte?))
                result = cmd.Parameters.Add(paraName, SqlDbType.Bit);
            else if (prop.PropertyType.IsEnum)
                result = cmd.Parameters.Add(paraName, SqlDbType.Int);
            return result;
        }

        public static DbSql BuildInsertSql(DbEntityInfo entityInfo)
        {
            DbSql dbSql = new DbSql();

            string prefix = "@";
            StringBuilder sql_part1 = new StringBuilder();
            StringBuilder sql_part2 = new StringBuilder();

            bool hasAutoIncrement = false;
            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.AutoIncrement)
                {
                    hasAutoIncrement = true;
                    dbSql.ReturnVals.Add(prefix + colInfo.ColPropertyInfo.Name, colInfo.ColPropertyInfo);
                }
                //是guid列 或是系统时间，时间字符串，则跳过
                if (colInfo.IsGuid||colInfo.IsSysDate||colInfo.IsSysDateString)
                {
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
            if (hasAutoIncrement)
            {
                sql.Append(";select @@IDENTITY");
            }

            dbSql.Sql = sql.ToString();
            return dbSql;

        }

        public static DbSql BuildUpdateSql(DbEntityInfo entityInfo)
        {
            DbSql dbSql = new DbSql();

            string prefix = "@";
            string mainTableName = entityInfo.MainTableName;

            StringBuilder sql = new StringBuilder();
            sql.Append("update ");
            sql.Append(mainTableName);
            sql.Append(" set ");

            StringBuilder allCols = new StringBuilder();
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.IsUpdateColumn && !colInfo.IsUpdateConditionColumn)
                {
                    allCols.Append(",");
                    allCols.Append(colInfo.ColName);
                    allCols.Append("=" + prefix);
                    allCols.Append(colInfo.ColPropertyInfo.Name);

                    dbSql.Paras.Add(prefix + colInfo.ColPropertyInfo.Name, colInfo.ColPropertyInfo);
                }
            }
            if (allCols.Length == 0) return dbSql;
            allCols.Remove(0, 1);

            sql.Append(allCols.ToString());

            bool fristWhereCol = true;
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.IsUpdateConditionColumn)
                {
                    if (fristWhereCol)
                    {
                        sql.Append(" where ");
                        sql.Append(colInfo.ColName + string.Format("={0}UPD_", prefix) + colInfo.ColPropertyInfo.Name);
                        fristWhereCol = false;
                    }
                    else
                    {
                        sql.Append(" and ");
                        sql.Append(colInfo.ColName + string.Format("={0}UPD_", prefix) + colInfo.ColPropertyInfo.Name);
                    }

                    dbSql.Paras.Add(prefix + "UPD_" + colInfo.ColPropertyInfo.Name, colInfo.ColPropertyInfo);
                }
            }

            dbSql.Sql = sql.ToString();
            return dbSql;
        }

        public static DbSql BuildDeleteSql(DbEntityInfo entityInfo)
        {
            DbSql dbSql = new DbSql();
            string prefix = "@";
            string mainTableName = entityInfo.MainTableName;
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from ");
            sql.Append(mainTableName);
            int col = 0;
            foreach (var colInfo in entityInfo.Columns)
            {
                if (colInfo.IsDeleteConditionColumn)
                {
                    if (col == 0)
                    {
                        sql.Append(" where ");
                        sql.Append(colInfo.ColName + string.Format("={0}DEL_", prefix) + colInfo.ColPropertyInfo.Name);
                    }
                    else
                    {
                        sql.Append(" and ");
                        sql.Append(colInfo.ColName + string.Format("={0}DEL_", prefix) + colInfo.ColPropertyInfo.Name);
                    }
                    col++;

                    dbSql.Paras.Add(prefix + "DEL_" + colInfo.ColPropertyInfo.Name, colInfo.ColPropertyInfo);
                }
            }
            dbSql.Sql = sql.ToString();
            return dbSql;
        }

        public static string BuildSelectSql(DbEntityInfo entityInfo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            if (entityInfo.IsDistinct) sql.Append("Distinct ");
            if (entityInfo.otherTables.Count > 0)
            {
                foreach (var colInfo in entityInfo.Columns)
                {
                    string colName = colInfo.FullColName + " as " + colInfo.ColPropertyInfo.Name;
                    sql.Append(colName);
                    sql.Append(",");
                }
            }
            else
            {
                foreach (var colInfo in entityInfo.Columns)
                {
                    string colName = colInfo.ColName + " as " + colInfo.ColPropertyInfo.Name;
                    sql.Append(colName);
                    sql.Append(",");
                }
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

            sql.Remove(sql.Length - 1, 1);

            sql.Append(" FROM ");

            sql.Append(entityInfo.MainTableName + " " + entityInfo.MainTableAlias + " ");
            foreach (var tbInfo in entityInfo.otherTables)
            {
                sql.Append(string.Format(" {0} join {1} {2} on {3} ", tbInfo.JoinType, tbInfo.JoinTableName, tbInfo.JoinTableAlias, tbInfo.JoinCondition));
            }

            return sql.ToString();
        }

        public static List<string> ParseParameters(string sql)
        {
            List<string> result = new List<string>();
            Regex paramReg = new Regex(@"[^@@](?<p>@\w+)\W");
            MatchCollection matches = paramReg.Matches(String.Concat(sql, " "));
            foreach (Match m in matches)
            {
                string paraName = m.Groups["p"].Value;
                if (!result.Contains(paraName))
                    result.Add(paraName);
            }
            return result;
        }

        private static List<T> LoadData<T>(string sql, object[] args, SqlCommand selectCmd) where T : DbEntity, new()
        {
            selectCmd.CommandText = sql;
            List<T> result = new List<T>();
            int i = 0;
            foreach (var item in ParseParameters(sql))
            {
                selectCmd.Parameters.AddWithValue(item, args[i++]);
            }
            Dictionary<int, ISetterValue> setters = null;

            SqlDataReader dr = selectCmd.ExecuteReader();
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
                T item = new T();
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

        public static List<T> LoadData<T>(SqlTransaction trans, string sql, params object[] args) where T : DbEntity, new()
        {
            SqlCommand selectCmd = trans.Connection.CreateCommand();
            selectCmd.Transaction = trans;

            return LoadData<T>(sql, args, selectCmd);
        }

        public override DataTable Query(string loadSql, params object[] args)
        {
            try
            {
                SqlConnection conn = this.GetDbConnection() as SqlConnection;
                conn.Open();
                SqlCommand selectCmd = conn.CreateCommand();
                //loadSql = loadSql.Replace("@", ":");
                selectCmd.CommandText = loadSql;
                //selectCmd.BindByName = true;
                int i = 0;
                foreach (var item in ParseParameters(loadSql))
                {
                    selectCmd.Parameters.Add(item, args[i++]);
                }
                SqlDataAdapter oradap = new SqlDataAdapter(selectCmd);
                DataSet ds = new DataSet();
                oradap.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }

        }

    }
}
