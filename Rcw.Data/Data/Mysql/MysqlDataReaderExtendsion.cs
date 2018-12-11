
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;


namespace Rcw.Data.MySql

{
    static class MySqlDataReaderExtendsion
    {
        public static string GetMyString(this MySqlDataReader dr, int ordinal)
        {
            if (dr.IsDBNull(ordinal)) return "";
            Type typ = dr.GetFieldType(ordinal);
            if (typ == typeof(string)) return dr.GetString(ordinal);
            else return dr.GetMyString(ordinal).ToString();
           
          
            //return "";
        }

        public static short? GetMyShort(this MySqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (short?)dr.GetInt16(ordinal);
        }

        public static int? GetMyInt(this MySqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt32(ordinal);
        }

        public static long? GetMyLong(this MySqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt64(ordinal);
        }

        public static float? GetMyFloat(this MySqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (float?)dr.GetFloat(ordinal);
        }

        public static double? GetMyDouble(this MySqlDataReader dr, int ordinal)
        {
            if (dr.IsDBNull(ordinal)) return null;
            Type typ = dr.GetFieldType(ordinal);
            if (typ == typeof(double)) return dr.GetDouble(ordinal);
            else if (typ == typeof(decimal)) return Convert.ToDouble(dr.GetDecimal(ordinal));
            else if (typ == typeof(string))
            {
                double result;
                string valStr = dr.GetString(ordinal);
                if (double.TryParse(valStr, out result))
                    return result;
            }
            return dr.GetDouble(ordinal);

          //  return dr.IsDBNull(ordinal) ? null : (double?)dr.GetDouble(ordinal);
        }

        public static decimal? GetMyDecimal(this MySqlDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (decimal?)dr.GetDecimal(ordinal);
        }

        public static double? GetMyStringDouble(this MySqlDataReader dr, int ordinal)
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

        public static bool? GetMyBoolean(this MySqlDataReader dr, int ordinal)
        {
            if (dr.IsDBNull(ordinal)) return null;
            Type typ = dr.GetFieldType(ordinal);
            if (typ == typeof(bool)) return dr.GetBoolean(ordinal);

            int colVal = dr.GetInt32(ordinal);
            if (colVal > 0)
                return true;
            else
                return false;
           // return dr.IsDBNull(ordinal) ? false : dr.GetBoolean(ordinal);
        }

        public static DateTime? GetMyDateTime(this MySqlDataReader dr, int ordinal)
        {
            if (dr.IsDBNull(ordinal)) return null;
            Type typ = dr.GetFieldType(ordinal);
            if (typ == typeof(DateTime)) return dr.GetDateTime(ordinal);
            else if (typ == typeof(string))
            {
                DateTime result;
                string valStr = dr.GetString(ordinal);
                if (DateTime.TryParse(valStr,out result))
                    return result;
            }
            return null;
            //return dr.IsDBNull(ordinal) ? null : (DateTime?)dr.GetDateTime(ordinal);
        }

        public static ISetterValue GetColumnSetter<T>(this MySqlDataReader dr, int col) where T : DbEntity, new()
        {
            string colName = dr.GetName(col);
            if (colName.ToUpper() == "ROWID")
            {
                return  new MySqlRowIdSetter(null, dr);
            }
            else
            {
                var prop = typeof(T).GetProperty(colName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
                if (prop != null)
                {
                    if (DbEntityInfo.SupportType(prop))
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            return new MySqlStringSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(double))
                        {
                            return new MySqlDoubleSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(double?))
                        {
                            return new MySqlNullableDoubleSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(int))
                        {
                            return new MySqlIntSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(int?))
                        {
                            return new MySqlNullableIntSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {
                            return new MySqlDateTimeSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(DateTime?))
                        {
                            return new MySqlNullableDateTimeSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(short))
                        {
                            return new MySqlShortSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(short?))
                        {
                            return new MySqlNullableShortSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(long))
                        {
                            return new MySqlLongSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(long?))
                        {
                            return new MySqlNullableLongSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(float))
                        {
                            return new MySqlFloatSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(float?))
                        {
                            return new MySqlNullableFloatSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(decimal))
                        {
                            return new MySqlDecimalSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(decimal?))
                        {
                            return new MySqlNullableDecimalSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(bool))
                        {
                            return new MySqlBooleanSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(bool?))
                        {
                            return new MySqlNullableBooleanSetter(prop, dr);
                        }
                        else if (prop.PropertyType.IsEnum)
                        {
                            return new MySqlIntSetter(prop, dr);
                        }
                    }
                }
            }
            return null;
        }
    }

    class MySqlRowIdSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlRowIdSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            item.RowId = dr.GetString(col);
           // prop.SetValue(item, dr.GetMyString(col), null);
        }
    }

    class MySqlStringSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlStringSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyString(col), null);
        }
    }

    class MySqlShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlShortSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col) ?? 0, null);
        }
    }

    class MySqlNullableShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableShortSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col), null);
        }
    }

    class MySqlIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlIntSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col) ?? 0, null);
        }
    }

    class MySqlNullableIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableIntSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col), null);
        }
    }

    class MySqlLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlLongSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col) ?? 0, null);
        }
    }

    class MySqlNullableLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableLongSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col), null);
        }
    }

    class MySqlBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlBooleanSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col) ?? false, null);
        }
    }

    class MySqlNullableBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableBooleanSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col), null);
        }
    }
   
    class MySqlFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlFloatSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col) ?? 0, null);
        }
    }

    class MySqlNullableFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableFloatSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col), null);
        }
    }

    class MySqlDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlDoubleSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col) ?? 0, null);
        }
    }

    class MySqlNullableDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableDoubleSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col), null);
        }
    }

    class MySqlDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlDecimalSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col) ?? 0, null);
        }
    }

    class MySqlNullableDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableDecimalSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col), null);
        }
    }

    class MySqlDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlDateTimeSetter(PropertyInfo prop, MySqlDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDateTime(col) ?? DateTime.MinValue, null);
        }
    }

    class MySqlNullableDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private MySqlDataReader dr = null;

        public MySqlNullableDateTimeSetter(PropertyInfo prop, MySqlDataReader dr)
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
