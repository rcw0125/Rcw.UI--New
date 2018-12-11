using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.Data
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DbSourceAttribute : Attribute
    {
        private string _DataSourceName = "";

        public string DataSourceName
        {
            get { return _DataSourceName; }
            set { _DataSourceName = value; }
        }

        public DbSourceAttribute()
        {

        }

        public DbSourceAttribute(string DataSourceName)
        {
            this.DataSourceName = DataSourceName;
        }

    }
}
