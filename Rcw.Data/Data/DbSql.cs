namespace Rcw.Data
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class DbSql
    {
        private string _Sql = "";
        private Dictionary<string, PropertyInfo> paras = new Dictionary<string, PropertyInfo>();
        private Dictionary<string, PropertyInfo> returnVals = new Dictionary<string, PropertyInfo>();

        public Dictionary<string, PropertyInfo> Paras
        {
            get
            {
                return this.paras;
            }
        }

        public Dictionary<string, PropertyInfo> ReturnVals
        {
            get
            {
                return this.returnVals;
            }
        }

        public string Sql
        {
            get
            {
                return this._Sql;
            }
            set
            {
                this._Sql = value;
            }
        }
    }
}

