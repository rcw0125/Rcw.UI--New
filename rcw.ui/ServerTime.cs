using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rcw.Data;


namespace Rcw.UI
{
    public class ServerTime
    {
        public static  DateTime timeNow()
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sysdate from dual");
            object obj = DbContext.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return DateTime.Now;
            }
            else
            {
                return Convert.ToDateTime(obj.ToString());
            }
        }
    }
}
