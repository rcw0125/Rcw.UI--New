using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Rcw.Data
{
   // save 方法模板
    public class SaveTemplate
    {
        public DataSource DataSource { get; set; }

        public IDbTransaction Transaction { get; set; }

        private DbSql _SqlInsert = new DbSql();

        public DbSql SqlInsert
        {
            get { return _SqlInsert; }
            set { _SqlInsert = value; }
        }

        private DbSql _SqlUpdate = new DbSql();

        public DbSql SqlUpdate
        {
            get { return _SqlUpdate; }
            set { _SqlUpdate = value; }
        }

        private DbSql _SqlDelete = new DbSql();

        public DbSql SqlDelete
        {
            get { return _SqlDelete; }
            set { _SqlDelete = value; }
        }
    }
}
