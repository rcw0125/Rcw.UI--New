using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Rcw.Data
{
    public abstract class DataSource 
    {

        public DataContext DataContext
        {
            get
            {
                return new DataContext(GetDbConnection(), new AttributeMappingSource());
            }
        }

        private string _SourceName = "";

        public string SourceName
        {
            get { return _SourceName; }
            set
            {
                if (_SourceName != value)
                {
                    _SourceName = value;
                }
            }
        }

        private string _ConnectionString = "";

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                if (_ConnectionString != value)
                {
                    _ConnectionString = value;
                }
            }
        }

        public abstract string SourceType
        {
            get;
        }

        public abstract IDbConnection GetDbConnection();
        /// <summary>
        /// 执行sql语句，修改删除，trans事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        public abstract void ExeSql(string sql, params object[] args);
        public abstract void ExeSql(IDbTransaction trans, string sql, params object[] args);

        /// <summary>
        /// ExecuteScalar这个方法是返回结果的第一行第一列的值。如果第一行第一列值不为空则返回对应的值(object类型)，比如数据是nchar类型值为 "123" 就可以用(int)ExecuteScalar()，
        ///如果数据是nchar类型值为 "abc"就不能用(int)ExecuteScalar(),就得写string result = ExecuteScalar().ToString；
        ///如果第一行存在但是第一列的值为空，返回DBNull；
        ///如果不存在第一行，返回null
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract object ExecuteScalar(string sql, params object[] args);
        public abstract int GetSeqNum(string prefix);

        public abstract void Insert(IDbTransaction trans, DbEntity item, DbSql dbSql);
        public abstract void Update(IDbTransaction trans, DbEntity item, DbSql dbSql);
        public abstract void Delete(IDbTransaction trans, DbEntity item, DbSql dbSql);
        public abstract void Create(DbEntityInfo entityInfo, bool recreate);
        public abstract List<T> LoadData<T>(string loadSql, params object[] args) where T : DbEntity, new();
   
        /// <summary>
        /// 初始化增删改查sql语句
        /// </summary>
        /// <param name="entityInfo"></param>
        public abstract void InitSql(DbEntityInfo entityInfo);

        public abstract DataTable Query(string loadSql, params object[] args);
    }
}
