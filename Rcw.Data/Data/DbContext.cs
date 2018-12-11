using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Rcw.Data;
using Rcw.Data.Oracle;
using Rcw.Data.SqlServer;
using System.Collections;
using Rcw.Oracle;

namespace Rcw.Data
{
    //扩展方法必须在非泛型静态类中定义
    public static class DbContext 
    {
        #region 属性
        
      

        //private static Dictionary<string, string> dsConnectionString = new Dictionary<string, string>();
        //private static Dictionary<string, string> dsDbType = new Dictionary<string, string>();
        private static Dictionary<string, DataSource> dsSources = new Dictionary<string, DataSource>();

        internal static string defaultDS = "VehIC";
        /// <summary>
        /// 默认数据源
        /// </summary>
        public static string DefaultDataSourceName
        {
            get { return defaultDS; }
            set
            {
                if (defaultDS != value)
                {
                    //if (!dsConnectionString.ContainsKey(value)) throw new Exception("找不到数据源" + value);
                    if (!dsSources.ContainsKey(value)) throw new Exception("找不到数据源" + value);
                    defaultDS = value;
                }
            }
        }
        private static string webService = "192.168.2.122";
        public static string WebService
        {
            get
            {
                return webService;
            }
        }
        #endregion

        /// <summary>
        /// 默认数据库名的列表
        /// </summary>
        public enum DbName
        {
            VehIC,
            tm,
            ncdb,
            xgmes,
            iuapdb,
            mysql,
            capdb,
            sfy,
            ltzn38,
            ltzn39,
            Access

        }
        public enum DbType
        {
            Oracle,
            SqlServer,
            MySql,
            Access
        }
        
        /// <summary>
        /// 设置默认数据源
        /// </summary>
        /// <param name="dbname"></param>
        public static void SetDbName(DbName dbname)
        {
            DefaultDataSourceName = dbname.ToString();
        }
        public static SqlRcwClient GetInstance()
        {           
            var ConnectionString = dsSources[DefaultDataSourceName].ConnectionString;
            var db = new SqlRcwClient(ConnectionString);           
            return db;
        }
        static DbContext()
        {   //SqlServer数据库
            dsSources.Add("VehIC", new SqlServer.SqlServerDataSource("VehIC", "Data Source=192.168.2.34;Initial Catalog=VehIc;Persist Security Info=True;User ID=sa;Password=vehic0901"));
            //SqlServer数据库 条码正式库
            dsSources.Add("tm", new SqlServer.SqlServerDataSource("tm_test", "Data Source=192.168.2.10;Initial Catalog=Acctrue_WMS;Persist Security Info=True;User ID=sa;Password=xgbarcodewms"));
            //Oracle数据库
            dsSources.Add("ncdb", new Oracle.OracleDataSource("ncdb", "Data Source=192.168.2.12/ncv5;User ID=xgerp50;Password=xgerp204212350;"));
            //< add name = "xgcap" connectionString = "Data Source=192.168.2.164/ORCL;User Id=xgcap;Password=Admin2018;enlist=dynamic" providerName = "Oracle.ManagedDataAccess.Client" />
            dsSources.Add("capdb", new Oracle.OracleDataSource("capdb", "Data Source = 192.168.2.94/orclpdb; User Id = xgcap; Password = Admin2018;"));
            dsSources.Add("xgmes", new Oracle.OracleDataSource("xgmes", "Data Source=192.168.36.153/XGMES;User ID=XGMES;Password=XGMES;"));
            dsSources.Add("iuapdb", new Oracle.OracleDataSource("iuapdb", "Data Source=192.168.2.202/orcl;User ID=xgmes;Password=xgmes;"));
            dsSources.Add("ltzn39", new Oracle.OracleDataSource("ltzn39", "Data Source=192.168.39.201/liantie;User ID=LF;Password=LF;"));
            dsSources.Add("ltzn38", new Oracle.OracleDataSource("ltzn38", "Data Source=192.168.38.28/liantie;User ID=LF;Password=LF;"));
            //mysql数据库
            dsSources.Add("mysql", new MySql.MySqlDataSource("mysql", "server=127.0.0.1;user id=root;password=root;persist security info=True;database=test"));
            //大水分仪
            dsSources.Add("sfy", new MySql.MySqlDataSource("mysql", "server=127.0.0.1;user id=root;password=cb123456;persist security info=True;database=autoanylistwater"));
            //Access数据库
            string host = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"data\goldbelldb.mdb";
            dsSources.Add("Access", new Access.AccessDataSource("Access", string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=true;Data Source={0};Jet OLEDB:Database Password='gold'", host)));
            defaultDS = "VehIC";
            webService = "192.168.2.33";

        }
        #region 内部方法 添加数据源等

        /// <summary>
        /// 获取当前默认数据库的连接
        /// </summary>
        /// <param name="dsName">数据源的名称，参数默认为空，不为空时，指定数据源的名称</param>
        /// <returns></returns>
        public static IDbConnection GetDefaultConnection(string dsName = "")
        {
            if (dsName == "")
            {
                return dsSources[defaultDS].GetDbConnection();
            }
            else
            {
                return dsSources[dsName].GetDbConnection();
            }
        }

        /// <summary>
        /// 添加数据源，并将当前数据源设置为默认数据源
        /// </summary>
        /// <param name="dsName">自定义数据源名称</param>
        /// <param name="dbtype">数据源类型</param>
        /// <param name="host">数据库主机IP</param>
        /// <param name="db">数据库名称（实例）</param>
        /// <param name="user">用户名</param>
        /// <param name="password">密码</param>
        public static void AddDataSource(string dsName, DbType dbtype, string host, string db, string user, string password)
        {
            DataSource ds = null;
            //string connstr = "";
            switch (dbtype)
            {
                case DbType.Oracle:
                    ds = new Oracle.OracleDataSource(dsName, host, db, user, password);
                    //connstr = string.Format("Data Source={0}/{1};User ID={2};Password={3};", host, db, user, password);
                    break;
                case DbType.SqlServer:
                    ds = new SqlServer.SqlServerDataSource(dsName, host, db, user, password);
                    // connstr = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", host, db, user, password);
                    break;
                case DbType.MySql:
                    ds = new MySql.MySqlDataSource(dsName, host, db, user, password);
                    // connstr = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", host, db, user, password);
                    break;
                case DbType.Access:
                    ds = new Access.AccessDataSource(dsName, host, password);
                    // connstr = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", host, db, user, password);
                    break;
                default:
                    throw new Exception("不支持数据库类型" + dbtype);
            }
            // AddDataSource(dsName, dbtype, connstr);
            if (ds != null)
            {
                if (dsSources.ContainsKey(dsName))
                    dsSources[dsName] = ds;
                else
                    dsSources.Add(dsName, ds);
                //设置默认数据源
                DefaultDataSourceName = dsName;
            }
        }

      

        internal static DataSource GetDataSource(string dsName)
        {
            return dsSources[dsName];
        }

        internal static string GetConnectionString(string dsName)
        {
            //return dsConnectionString[dsName];
            return dsSources[dsName].ConnectionString;
        }

        internal static string GetDbType(string dsName)
        {
            //return dsDbType[dsName];
            return dsSources[dsName].SourceType;
        }
       


        internal static IDbConnection GetConnection(Type typ)
        {
            DbEntityInfo info = GetDbEnityInfo(typ);
            return GetDefaultConnection(info.DataSourceName);
        }

        private static Dictionary<Type, DbEntityInfo> entityInfos = new Dictionary<Type, DbEntityInfo>();
        /// <summary>
        /// 获取实体类的信息
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static DbEntityInfo GetDbEnityInfo(Type entityType)
        {
            if (!entityInfos.ContainsKey(entityType))
            {
                DbEntityInfo info = new DbEntityInfo(entityType);
                entityInfos.Add(entityType, info);
            }
            return entityInfos[entityType];
        }

        #endregion

        #region 方法 增删改查

        #region 创建表
        /// <summary>
        /// 创建表,(数据库中不存在，则创建新表)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Create<T>() where T : DbEntity, new()
        {
            DbEntityInfo info = GetDbEnityInfo(typeof(T));
            try
            {
                info.DataSource.Create(info, false);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        /// <summary>
        /// 将sqlserver 数据库的数据查出来，导入到Oracle
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dsName"></param>
        public static void TransData<T>(string dsName,bool mode=true) where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            

            string loadSql = info.SelectSql + " Where 1=1";
            loadSql += info.SqlOrder;
            try
            {
                dsSources[dsName].Create(info, false);
                if (mode)
                {
                    var list = info.DataSource.LoadData<T>(loadSql);
                    info.SqlInsert.Sql = info.SqlInsert.Sql.Replace(";select @@IDENTITY", "").Replace("@", ":") + " RETURNING ROWID INTO :RID";
                    
                    if (info.SqlInsert.ReturnVals.Count > 0)
                    {
                        info.SqlInsert.ReturnVals.Clear();                    
                    }

                    info.SqlInsert.ReturnVals.Add(":RID", typeof(DbEntity).GetProperty("RowId"));

                    foreach (var item in list)
                    {
                        item.DataState = DataRowState.Added;
                        item.Save(dsSources[dsName]);
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("TransDate错误：{0} 异常:{1}", loadSql, ex.Message));
            }
        }
        #endregion

        #region sql语句查询，返回DataTable
        /// <summary>
        /// sql语句查询，返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params object[] args)
        {
            return dsSources[DefaultDataSourceName].Query(sql, args);
        }
        /// <summary>
        ///  sql语句查询，返回DataTable
        /// </summary>
        /// <param name="dsName">指定数据源名称</param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string dsName, string sql, params object[] args)
        {
            return dsSources[dsName].Query(sql, args);
        }
        #endregion

        #region 执行sql语句，修改删除，使用默认的trans事务，一次修改，自动提交事务

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static bool ExecuteSqlTran(List<string> SQLStringList)
        {
            using (var conn = GetDefaultConnection())
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                                      
                    foreach (var item in SQLStringList)
                    {
                        if (item.Trim().Length > 1)
                        {
                            ExeSql(trans, item);
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (OracleException E)
                {
                    trans.Rollback();
                    conn.Close();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行sql语句，修改删除，使用默认的trans事务，一次修改，自动提交事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        public static void ExeSql(string sql, params object[] args)
        {
            dsSources[DefaultDataSourceName].ExeSql(sql, args);
        }
        /// <summary>
        /// 指定数据源的执行sql语句修改删除等操作
        /// </summary>
        /// <param name="dsName">数据源</param>
        /// <param name="sql">sql语句</param>
        /// <param name="args">参数</param>
        public static void ExeSql(string dsName, string sql, params object[] args)
        {
            dsSources[dsName].ExeSql(sql, args);

        }


        /// <summary>
        /// 执行sql语句，修改删除，在程序中使用自己定义的trans事务，使用场景，在多次的数据修改访问中
        /// 使用该方法，使用自定义的同一个事务，最终提交事务（commit）
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        public static void ExeSql(IDbTransaction trans, string sql, params object[] args)
        {

            dsSources[DefaultDataSourceName].ExeSql(trans, sql, args);
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
        public static object ExecuteScalar(string sql, params object[] args)
        {
            return dsSources[DefaultDataSourceName].ExecuteScalar(sql, args);

        }

        public static object DsExecuteScalar(string ds,string sql, params object[] args)
        {
            return dsSources[ds].ExecuteScalar(sql, args);

        }

        /// <summary>
        /// ExecuteScalar这个方法是返回结果的第一行第一列的值。如果第一行第一列值不为空则返回对应的值(object类型)，比如数据是nchar类型值为 "123" 就可以用(int)ExecuteScalar()，
        ///如果数据是nchar类型值为 "abc"就不能用(int)ExecuteScalar(),就得写string result = ExecuteScalar().ToString；
        ///如果第一行存在但是第一列的值为空，返回DBNull；
        ///如果不存在第一行，返回null 
        /// </summary>
        /// <param name="dsName">数据源</param>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static object ExecuteScalar(string dsName, string sql, params object[] args)
        {
            return dsSources[dsName].ExecuteScalar(sql, args);
        }
        #endregion

        #region 扩展方法 获取、更新list，分页
        /// <summary>
        /// 查询最大值，返回整数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colName">列字段</param>
        /// <param name="whereSql">查询条件</param>
        /// <returns>整型</returns>
        public static int Max<T>(string colName, string whereSql = "1=1") where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string strSql = "select Max("+colName+") from " + info.MainTableName+" where "+whereSql;
            var obj=ExecuteScalar(strSql);
            if (obj == null || Convert.IsDBNull(obj))
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 查询最大值,返回字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colName">列字段</param>
        /// <param name="whereSql">查询条件</param>
        /// <returns></returns>
        public static string MaxString<T>(string colName, string whereSql = "1=1") where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string strSql = "select Max(" + colName + ") from " + info.MainTableName + " where " + whereSql;
            var obj = ExecuteScalar(strSql);
            if (obj == null || Convert.IsDBNull(obj))
            {
                return "0";
            }
            return obj.ToString();
        }
        /// <summary>
        /// 查询最小值，返回整数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colName">列字段</param>
        /// <param name="whereSql">查询条件</param>
        /// <returns></returns>
        public static int Min<T>(string colName, string whereSql = "1=1") where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string strSql = "select Min(" + colName + ") from " + info.MainTableName + " where " + whereSql;
            var obj = ExecuteScalar(strSql);
            if (obj == null || Convert.IsDBNull(obj))
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 查询最小值,返回字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colName">列字段</param>
        /// <param name="whereSql">查询条件</param>
        /// <returns></returns>
        public static string MinString<T>(string colName, string whereSql = "1=1") where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string strSql = "select Min(" + colName + ") from " + info.MainTableName + " where " + whereSql;
            var obj = ExecuteScalar(strSql);
            if (obj == null || Convert.IsDBNull(obj))
            {
                return "0";
            }
            return obj.ToString();
        }

        /// <summary>
        /// DbEntityTable调用此方法，返回List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereSql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static List<T> LoadDataByWhere<T>(string whereSql = "1=1", params object[] args) where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));

            string loadSql = info.SelectSql + " Where " + whereSql;
            // where 语句里是否包含
            if (!whereSql.ToLower().Contains("order"))
            {
                loadSql += info.SqlOrder;
            }
            try
            {

                var list = info.DataSource.LoadData<T>(loadSql, args);             
                return list;
            }
            catch (Exception ex)
            {             
                throw new Exception(string.Format("LoadDataByWhere加载错误：{0} 异常:{1}", loadSql, ex.Message));
            }
        }

       



        /// <summary>
        /// 获取首条实体模型，空为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereSql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T GetModel<T>(string whereSql = "1=1", params object[] args) where T : DbEntity, new()
        {
            
            try
            {
                var list = LoadDataByWhere<T>(whereSql, args);
                if (list.Count > 0)
                {
                    return list[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GetModel出现异常:{0}", ex.Message));
            }
        }

        /// <summary>
        /// IQueryable<T>的拉姆达表达式写法，支持字符串、数字、枚举类、字符串的大小比较写法，不支持时间类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="expression"></param>
        public static T GetModel<T>(this IQueryable<T> queryable, System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : DbEntity, new()
        {
            

            try
            {
                string whereSql = expression.Body.ToString();
                string para = expression.Parameters[0].Name + ".";
                whereSql = whereSql.Replace(para, "").Replace("==", "=");
                whereSql = whereSql.Replace("AndAlso", "And").Replace("\"", "'");
                whereSql = whereSql.Replace("OrElse", "Or").Replace("\"", "'");
                whereSql = whereSql.Replace("Convert", "");
                whereSql = CheckSql(whereSql);
                whereSql = CheckSql(whereSql);
                whereSql = CheckSql(whereSql);
                whereSql = CheckSql(whereSql);
                var list = LoadDataByWhere<T>(whereSql);
                if (list.Count > 0)
                {
                    return list[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GetModel出现异常:{0}", ex.Message));
            }


        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereSql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool Exist<T>(string whereSql = "1=1", params object[] args) where T : DbEntity, new()
        {
            var list = LoadDataByWhere<T>(whereSql, args);
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static List<T> LoadDataByPage<T>(string whereSql, Page page, params object[] args) where T : DbEntity, new()
        {
            DbEntityInfo info = GetDbEnityInfo(typeof(T));
            string loadSql;

            if (whereSql.ToLower().Contains("order"))
            {
                string where = whereSql.ToLower();
                int index = where.IndexOf("order");
                string wherestr = where.Substring(0, index);

                if (wherestr.Trim() == "")
                {
                    wherestr = " 1=1 ";
                }

                string orderstr = where.Substring(index);
                orderstr = orderstr.Replace("order", "").Replace("by", "");
                string selectstr = info.SelectSql;
                selectstr = selectstr.Insert(6, string.Format(" row_number() OVER (ORDER BY {0}) AS RowNumber,", orderstr));
                loadSql = selectstr + " Where " + wherestr;
            }
            else
            {
                if (whereSql.Trim() == "")
                {
                    whereSql = " 1=1 ";
                }
                loadSql = info.SelectSql + " Where " + whereSql;
                string orderstr = info.SqlOrder;
                if (orderstr.Length > 5)
                {
                    orderstr = orderstr.Replace("order", "").Replace("by", "");
                    loadSql = loadSql.Insert(6, string.Format(" row_number() OVER (ORDER BY {0}) AS RowNumber,", orderstr));
                }
                else
                {
                    string mainkey = info.MainKey;
                    loadSql = loadSql.Insert(6, string.Format(" row_number() OVER (ORDER BY {0}) AS RowNumber,", mainkey));
                }

            }


            string totalstr = loadSql.Substring(loadSql.IndexOf("FROM"));
            totalstr = " ( select count(0) " + totalstr + " ) as rowtotal, ";
            loadSql = loadSql.Insert(6, totalstr);
            int start = (page.offset - 1) * page.limit + 1;
            int end = page.offset * page.limit;
            string pagestr = string.Format("with tempdb as  ( {0} ) select * from tempdb where RowNumber between {1} and  {2} ", loadSql, start, end);

            //string loadSql = info.SelectSql + " Where " + whereSql;

            //// where 语句里是否包含
            //if (!whereSql.ToLower().Contains("order")) loadSql += info.SqlOrder;

            try
            {

                var list = info.DataSource.LoadData<T>(pagestr, args);
               
                return list;
            }
            catch (Exception ex)
            {
               
                throw new Exception(string.Format("LoadDataByPage加载错误：{0} 异常:{1}", loadSql, ex.Message));
            }
        }
        /// <summary>
        ///  DbEntityTable调用此方法，返回List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static List<T> LoadDataBySql<T>(string sql, params object[] args) where T : DbEntity, new()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string loadSql = sql;
            try
            {
                var list = info.DataSource.LoadData<T>(loadSql, args);             
                return list;
            }
            catch (Exception ex)
            {             
                throw new Exception(string.Format("LoadDataBySql加载错误：{0} 异常:{1}", loadSql, ex.Message));
            }
        }

        /// <summary>
        /// 更新多条数据，使用事务trans,
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelList">继承自dbEntity的List类</param>
        /// <param name="trans">事务，默认为null，整个list更新使用一个事务，使用外部事务时，注意最终提交</param>
        /// <returns></returns>
        public static bool Update<T>(this List<T> modelList, IDbTransaction trans = null) where T : DbEntity, new()
        {
            if (trans == null)
            {
                #region  不使用外部的trans
                IDbConnection conn = DbContext.GetDefaultConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                try
                {
                    foreach (var item in modelList)
                    {
                        item.Save(trans);
                    }
                    trans.Commit();
                    conn.Close();
                    return true;

                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    conn.Close();
                    throw new Exception(string.Format("Update 错误：{0} ", ex.Message));
                    
                }
                #endregion 不使用外部的trans
            }
            else
            {
                #region  使用外部的trans
                try
                {
                    foreach (var item in modelList)
                    {
                        item.Save(trans);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Update 错误：{0} ", ex.Message));
                    
                }
                #endregion 使用外部的trans			
            }
        }
        /// <summary>
        /// 获取DbEntityTable，使用LoadDataByWhere方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static DbEntityTable<T> getDbEntityTable<T>(string sql="1=1", params object[] args) where T : DbEntity, new()
        {
            DbEntityTable<T> entity = new DbEntityTable<T>();
            try
            {
                entity.LoadDataByWhere(sql, args);
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception("getDbEntityTable方法出现异常：" + ex.ToString());
            }
           
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelList"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static bool DelList<T>(this List<T> modelList, IDbTransaction trans = null) where T : DbEntity, new()
        {           
            if (trans == null)
            {
                #region  不使用外部的trans
                IDbConnection conn = DbContext.GetDefaultConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                try
                {
                    foreach (var item in modelList)
                    {
                        item.DataState = DataRowState.Deleted;
                        item.Save(trans);
                    }
                    trans.Commit();
                    conn.Close();
                    return true;

                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    conn.Close();
                    throw new Exception(string.Format("DelList错误：{0} ", ex.Message));
                 
                }
                #endregion 不使用外部的trans
            }
            else
            {
                #region  使用外部的trans
                try
                {
                    foreach (var item in modelList)
                    {
                        item.DataState = DataRowState.Deleted;
                        item.Save(trans);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(string.Format("DelList错误：{0} ", ex.Message));
                }
                #endregion 使用外部的trans			
            }
           
        }

        /// <summary>
        /// IQueryable<T>的拉姆达表达式写法，支持字符串、数字、枚举类、字符串的大小比较写法，不支持时间类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="expression"></param>
        public static List<T> GetList<T>(this IQueryable<T> queryable, System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : DbEntity, new()
        {
            string whereSql = expression.Body.ToString();
            string para = expression.Parameters[0].Name + ".";
            whereSql = whereSql.Replace(para, "").Replace("==", "=");
            whereSql = whereSql.Replace("AndAlso", "And").Replace("\"", "'");
            whereSql = whereSql.Replace("OrElse", "Or").Replace("\"", "'");
            whereSql = whereSql.Replace("Convert", "");
            whereSql = CheckSql(whereSql);
            whereSql = CheckSql(whereSql);
            whereSql = CheckSql(whereSql);
            whereSql = CheckSql(whereSql);
            return LoadDataByWhere<T>(whereSql);

        }

        /// <summary>
        /// lambda表达式中出现字符串比较时（CompareTo），的处理方法
        /// </summary>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        public static string CheckSql(string whereSql)
        {
            if (whereSql.Contains("CompareTo"))
            {
                string subComPare = whereSql.Substring(whereSql.IndexOf(".CompareTo"));
                string subExp = subComPare.Substring(0, subComPare.IndexOf("))"));
                if (subExp.Contains(">="))
                {
                    string temp = subExp.Replace(".CompareTo", ">=");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains("<="))
                {
                    string temp = subExp.Replace(".CompareTo", "<=");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains(">"))
                {
                    string temp = subExp.Replace(".CompareTo", ">");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains("<"))
                {
                    string temp = subExp.Replace(".CompareTo", "<");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
            }
            return whereSql;
        }

        #endregion

        /// <summary>
        /// 获得指定前缀的流水号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="seqLen">流水号字符长度</param>
        /// <returns></returns>
        public static string GetSeq(string prefix, int seqLen=2)
        {
            return GetSeq(DefaultDataSourceName, prefix, seqLen);
        }

        public static string GetSeq(string dsName, string prefix, int seqLen)
        {
            int seq = GetSeqNum(dsName, prefix);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < seqLen; i++)
            {
                sb.Append("0");
            }
            return prefix + seq.ToString(sb.ToString());
        }

        /// <summary>
        /// 得到指定前缀的顺序号
        /// </summary>
        /// <param name="dsName">数据源名</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        internal static int GetSeqNum(string dsName, string prefix)
        {
            return dsSources[dsName].GetSeqNum(prefix);
            //switch (GetDbType(dsName))
            //{
            //    case DbType_SqlServer:
            //        return SqlDb.GetSeq(dsName, prefix);
            //    default:
            //        throw new Exception("GetSeq 不支持此数据库");
            //}
        }

        #endregion

        #region 注释掉的代码






        /// <summary>
        /// 在默认数得到指定前缀的顺序号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        //public static int GetSeqNum(string prefix)
        //{
        //    return dsSources[DefaultDataSourceName].GetSeqNum(prefix);
        //   // return GetSeqNum(DefaultDataSourceName, prefix);
        //}

        ////保存实体类表  序列表 需改进
        //public static void Save(List<DbEntity> entities)
        //{
        //    IDbConnection conn = DbContext.GetDefaultConnection();
        //    conn.Open();
        //    IDbTransaction trans = conn.BeginTransaction();
        //    foreach (var item in entities)
        //    {
        //        item.Save(trans);
        //    }
        //    trans.Commit();
        //    conn.Close();
        //}



        //public static List<T> LoadData<T>() where T : DbEntity, new()
        //{
        //    DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
        //    string loadSql = info.SelectSql + info.SqlOrder;
        //    try
        //    {
        //        return info.DataSource.LoadData<T>(loadSql);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Format("加载错误：{0} 异常:{1}", loadSql, ex.Message));
        //    }
        //}



        // "shangchuan=0 order by date desc" o
        #endregion

    }
}
