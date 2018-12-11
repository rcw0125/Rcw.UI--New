using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Rcw.Data
{
    /// <summary>
    /// ** 描述：SqlSugar工具类
    /// ** 创始时间：2015-7-13
    /// ** 修改时间：-
    /// ** 作者：sunkaixuan
    /// ** 使用说明：
    /// </summary>
    public partial class SqlSugarTool
    {
        internal static Type StringType = typeof(string);
        internal static Type IntType = typeof(int);
        internal static Type DecType = typeof(decimal);
        internal static Type GuidType = typeof(Guid);
        internal static Type DateType = typeof(DateTime);
        internal static Type ByteType = typeof(Byte);
        internal static Type BoolType = typeof(bool);
        internal static Type ObjType = typeof(object);
        internal static Type Dob = typeof(double);
        internal static Type DicSS = typeof(KeyValuePair<string, string>);
        internal static Type DicSi = typeof(KeyValuePair<string, int>);
        internal static Type Dicii = typeof(KeyValuePair<int, int>);
        internal static Type DicOO = typeof(KeyValuePair<object, object>);
        internal static Type DicSo = typeof(KeyValuePair<string, object>);
        internal static Type DicIS = typeof(KeyValuePair<int, string>);
        internal static Type DicArraySS = typeof(Dictionary<string, string>);
        internal static Type DicArraySO = typeof(Dictionary<string, object>);

   
        private static void FillValueTypeToDr<T>(Type type, IDataReader dr, List<T> strReval)
        {
            using (IDataReader re = dr)
            {
                while (re.Read())
                {
                    strReval.Add((T)Convert.ChangeType(re.GetValue(0), type));
                }
            }
        }



        /// <summary>
        /// 将实体对象转换成 Dictionary《string, string》
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static Dictionary<string, object> GetObjectToDictionary(object obj)
        {

            Dictionary<string, object> reval = new Dictionary<string, object>();
            if (obj == null) return reval;
            var type = obj.GetType();
            var isDic = type.IsIn(SqlSugarTool.DicArraySO, SqlSugarTool.DicArraySS);
            if (isDic)
            {
                if (type == SqlSugarTool.DicArraySO)
                {
                    return (Dictionary<string, object>)obj;
                }
                else
                {
                    var newObj = (Dictionary<string, string>)obj;
                    foreach (var item in newObj)
                    {
                        reval.Add(item.Key, item.Value);
                    }
                    return reval;
                }
            }
            else
            {
                var propertiesObj = type.GetProperties();
                string replaceGuid = Guid.NewGuid().ToString();
                foreach (PropertyInfo r in propertiesObj)
                {
                    var val = r.GetValue(obj, null);
                    if (r.PropertyType.IsEnum)
                    {
                        val =Convert.ToInt64(val);
                    }
                    reval.Add(r.Name, val == null ? DBNull.Value : val);
                }

                return reval;
            }
        }

      



        /// <summary>
        /// 处理like条件的通配符
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string SqlLikeWordEncode(string word)
        {
            if (word == null) return word;
            return Regex.Replace(word, @"(\[|\%)", "[$1]");
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        internal static Guid GetPropertyValue(object obj, string property)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return (Guid)propertyInfo.GetValue(obj, null);
        }
  
        /// <summary>
        /// 使用页面自动填充sqlParameter时 Request.Form出现特殊字符时可以重写Request.Form方法，使用时注意加锁并且用到将该值设为null
        /// </summary>
        public static Func<string, string> SpecialRequestForm = null;


        /// <summary>
        /// 获取最底层类型
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="isNullable"></param>
        /// <returns></returns>
        internal static Type GetUnderType(PropertyInfo propertyInfo, ref bool isNullable)
        {
            Type unType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
            isNullable = unType != null;
            unType = unType ?? propertyInfo.PropertyType;
            return unType;
        }
    }
}
