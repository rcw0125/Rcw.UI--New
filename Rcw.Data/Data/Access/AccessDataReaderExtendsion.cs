using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rcw.Data.Access
{
    static class AccessDataReaderExtendsion
    {
        public static string GetMyString(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? "" : dr.GetString(ordinal);
        }

        public static short? GetMyShort(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (short?)dr.GetInt16(ordinal);
        }

        public static int? GetMyInt(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt32(ordinal);
        }

        public static long? GetMyLong(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt64(ordinal);
        }

        public static float? GetMyFloat(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (float?)dr.GetFloat(ordinal);
        }

        public static double? GetMyDouble(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (double?)dr.GetDouble(ordinal);
        }

        public static decimal? GetMyDecimal(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (decimal?)dr.GetDecimal(ordinal);
        }

        public static double? GetMyStringDouble(this OleDbDataReader dr, int ordinal)
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

        public static bool? GetMyBoolean(this OleDbDataReader dr, int ordinal)
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

        public static DateTime? GetMyDateTime(this OleDbDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (DateTime?)dr.GetDateTime(ordinal);
        }

        public static ISetterValue GetColumnSetter<T>(this OleDbDataReader dr, int col) where T : DbEntity, new()
        {
            string colName = dr.GetName(col);

            var prop = typeof(T).GetProperty(colName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            if (prop != null)
            {
                if (DbEntityInfo.SupportType(prop))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        return new OleDbStringSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        return new OleDbDoubleSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(double?))
                    {
                        return new OleDbNullableDoubleSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(int))
                    {
                        return new OleDbIntSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(int?))
                    {
                        return new OleDbNullableIntSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        return new OleDbDateTimeSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(DateTime?))
                    {
                        return new OleDbNullableDateTimeSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(short))
                    {
                        return new OleDbShortSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(short?))
                    {
                        return new OleDbNullableShortSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(long))
                    {
                        return new OleDbLongSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(long?))
                    {
                        return new OleDbNullableLongSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(float))
                    {
                        return new OleDbFloatSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(float?))
                    {
                        return new OleDbNullableFloatSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        return new OleDbDecimalSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(decimal?))
                    {
                        return new OleDbNullableDecimalSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        return new OleDbBooleanSetter(prop, dr);
                    }
                    else if (prop.PropertyType == typeof(bool?))
                    {
                        return new OleDbNullableBooleanSetter(prop, dr);
                    }
                    else if (prop.PropertyType.IsEnum)
                    {
                        return new OleDbIntSetter(prop, dr);
                    }
                }
            }
            return null;
        }
 
    }

    class OleDbStringSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbStringSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyString(col), null);
        }
    }

    class OleDbShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbShortSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col) ?? 0, null);
        }
    }

    class OleDbNullableShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableShortSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col), null);
        }
    }

    class OleDbIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbIntSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col) ?? 0, null);
        }
    }

    class OleDbNullableIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableIntSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col), null);
        }
    }

    class OleDbLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbLongSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col) ?? 0, null);
        }
    }

    class OleDbNullableLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableLongSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col), null);
        }
    }

    class OleDbBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbBooleanSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col) ?? false, null);
        }
    }

    class OleDbNullableBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableBooleanSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col), null);
        }
    }

    class OleDbFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbFloatSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col) ?? 0, null);
        }
    }

    class OleDbNullableFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableFloatSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col), null);
        }
    }


    class OleDbDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbDoubleSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col) ?? 0, null);
        }
    }

    class OleDbNullableDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableDoubleSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col), null);
        }
    }

    class OleDbDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbDecimalSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col) ?? 0, null);
        }
    }

    class OleDbNullableDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableDecimalSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col), null);
        }
    }

    class OleDbDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbDateTimeSetter(PropertyInfo prop, OleDbDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDateTime(col) ?? DateTime.MinValue, null);
        }
    }

    class OleDbNullableDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OleDbDataReader dr = null;

        public OleDbNullableDateTimeSetter(PropertyInfo prop, OleDbDataReader dr)
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
