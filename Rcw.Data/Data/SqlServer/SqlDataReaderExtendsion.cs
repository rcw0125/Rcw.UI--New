using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rcw.Data.SqlServer
{
    static class SqlDataReaderExtendsion
    {
        public static string GetMyString(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? "" : dr.GetString(ordinal);
        }

        public static short? GetMyShort(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (short?)dr.GetInt16(ordinal);
        }

        public static int? GetMyInt(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt32(ordinal);
        }

        public static long? GetMyLong(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt64(ordinal);
        }

        public static float? GetMyFloat(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (float?)dr.GetFloat(ordinal);
        }

        public static double? GetMyDouble(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (double?)dr.GetDouble(ordinal);
        }

        public static decimal? GetMyDecimal(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (decimal?)dr.GetDecimal(ordinal);
        }

        public static double? GetMyStringDouble(this SqlDataReader dr, int ordinal)
        {
            double? result = null;
            if (!dr.IsDBNull(ordinal))
            {
                double temp;
                if (double.TryParse(dr.GetString(ordinal), out temp))
                {
                    result = temp;
                }
            }
            return result;
        }

        public static bool? GetMyBoolean(this SqlDataReader dr, int ordinal)
        {
            if (dr.IsDBNull(ordinal)) return null;
            Type typ = dr.GetFieldType(ordinal);
            if (typ == typeof(bool)) return dr.GetBoolean(ordinal);
            int colVal = dr.GetInt32(ordinal);
            if (colVal > 0)
                return true;
            else
                return false;

            //  return dr.IsDBNull(ordinal) ? false : dr.GetBoolean(ordinal);
        }

        public static DateTime? GetMyDateTime(this SqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (DateTime?)dr.GetDateTime(ordinal);
        }

        public static ISetterValue GetColumnSetter<T>(this SqlDataReader dr, int col) where T : DbEntity, new()
        {
            string colName = dr.GetName(col);

            var prop = typeof(T).GetProperty(colName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            if (prop != null)
            {
                if (DbEntityInfo.SupportType(prop))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        return new SqlStringSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        return new SqlDoubleSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(double?))
                    {
                        return new SqlNullableDoubleSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(int))
                    {
                        return new SqlIntSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(int?))
                    {
                        return new SqlNullableIntSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        return new SqlDateTimeSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(DateTime?))
                    {
                        return new SqlNullableDateTimeSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(short))
                    {
                        return new SqlShortSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(short?))
                    {
                        return new SqlNullableShortSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(long))
                    {
                        return new SqlLongSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(long?))
                    {
                        return new SqlNullableLongSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(float))
                    {
                        return new SqlFloatSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(float?))
                    {
                        return new SqlNullableFloatSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        return new SqlDecimalSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(decimal?))
                    {
                        return new SqlNullableDecimalSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        return new SqlBooleanSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(bool?))
                    {
                        return new SqlNullableBooleanSetter(prop, dr);
                    }
                    else if (prop.PropertyType.IsEnum)
                    {
                        return new SqlIntSetter(prop, dr);
                    }
                }
            }
            return null;
        }
 
    }

    class SqlStringSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlStringSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyString(col), null);
        }
    }

    class SqlShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlShortSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col) ?? 0, null);
        }
    }

    class SqlNullableShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableShortSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col), null);
        }
    }

    class SqlIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlIntSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col) ?? 0, null);
        }
    }

    class SqlNullableIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableIntSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col), null);
        }
    }

    class SqlLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlLongSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col) ?? 0, null);
        }
    }

    class SqlNullableLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableLongSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col), null);
        }
    }

    class SqlBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlBooleanSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col) ?? false, null);
        }
    }

    class SqlNullableBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableBooleanSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col), null);
        }
    }

    class SqlFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlFloatSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col) ?? 0, null);
        }
    }

    class SqlNullableFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableFloatSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col), null);
        }
    }


    class SqlDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlDoubleSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col) ?? 0, null);
        }
    }

    class SqlNullableDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableDoubleSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col), null);
        }
    }

    class SqlDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlDecimalSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col) ?? 0, null);
        }
    }

    class SqlNullableDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableDecimalSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col), null);
        }
    }

    class SqlDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlDateTimeSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDateTime(col) ?? DateTime.MinValue, null);
        }
    }

    class SqlNullableDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private SqlDataReader dr = null;

        public SqlNullableDateTimeSetter(PropertyInfo prop, SqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDateTime(col), null);
        }
    }
    
}
