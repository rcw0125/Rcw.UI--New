using Rcw.Data;
using SQLiteSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.UI
{
    public static class test
    {
        public static T Where<T>(this IQueryable<T> queryable, System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : DbEntity, new()
        {
            
            ResolveExpress re = new ResolveExpress();
            re.ResolveExpression(re, expression);
            var sql = re.SqlWhere;
            var paras = re.Paras;
            object[] obj=new  object[paras.Count];
            if (paras.Count > 0)
            {
                for (int i = 0; i <paras.Count; i++)
                {
                    obj[i] = paras[i];
                }
            }
            sql = CheckSql(sql);
            //string whereSql = expression.Body.ToString();
            //string para = expression.Parameters[0].Name + ".";
            //whereSql = whereSql.Replace(para, "").Replace("==", "=");
            //whereSql = whereSql.Replace("AndAlso", "And").Replace("\"", "'");
            //whereSql = whereSql.Replace("OrElse", "Or").Replace("\"", "'");
            //whereSql = whereSql.Replace("Convert", "");
            //whereSql = CheckSql(whereSql);
            //whereSql = CheckSql(whereSql);

            var data = DbContext.LoadDataByWhere<T>(sql,obj);
            return data[0];

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
                string subComPare = whereSql.Substring(whereSql.IndexOf("CompareTo"));
                string subExp = subComPare.Substring(0, subComPare.IndexOf("0")+1);
                if (subExp.Contains(">="))
                {
                    string temp = subExp.Replace("CompareTo", ">=");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains("<="))
                {
                    string temp = subExp.Replace("CompareTo", "<=");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains(">"))
                {
                    string temp = subExp.Replace("CompareTo", ">");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains("<"))
                {
                    string temp = subExp.Replace("CompareTo", "<");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
            }
            return whereSql;
        }

    }
}
