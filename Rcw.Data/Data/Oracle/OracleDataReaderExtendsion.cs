using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rcw.Data.Oracle
{
    static class OracleDataReaderExtendsion
    {
        public static string GetMyString(this OracleDataReader dr, int ordinal)
        {
            if (dr.IsDBNull(ordinal)) return "";
            Type typ = dr.GetFieldType(ordinal);
            if (typ == typeof(string)) return dr.GetString(ordinal);
            else return dr.GetOracleValue(ordinal).ToString();
            //return "";
        }

        public static short? GetMyShort(this OracleDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (short?)dr.GetInt16(ordinal);
        }

        public static int? GetMyInt(this OracleDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt32(ordinal);
        }

        public static long? GetMyLong(this OracleDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt64(ordinal);
        }

        public static float? GetMyFloat(this OracleDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (float?)dr.GetFloat(ordinal);
        }

        public static double? GetMyDouble(this OracleDataReader dr, int ordinal)
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

        public static decimal? GetMyDecimal(this OracleDataReader dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (decimal?)dr.GetDecimal(ordinal);
        }

        public static double? GetMyStringDouble(this OracleDataReader dr, int ordinal)
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

        public static bool? GetMyBoolean(this OracleDataReader dr, int ordinal)
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

        public static DateTime? GetMyDateTime(this OracleDataReader dr, int ordinal)
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

        public static ISetterValue GetColumnSetter<T>(this OracleDataReader dr, int col) where T : DbEntity, new()
        {
            string colName = dr.GetName(col);
            if (colName.ToUpper() == "ROWID")
            {
                return  new OracleRowIdSetter(null, dr);
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
                            return new OracleStringSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(double))
                        {
                            return new OracleDoubleSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(double?))
                        {
                            return new OracleNullableDoubleSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(int))
                        {
                            return new OracleIntSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(int?))
                        {
                            return new OracleNullableIntSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(DateTime))
                        {
                            return new OracleDateTimeSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(DateTime?))
                        {
                            return new OracleNullableDateTimeSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(short))
                        {
                            return new OracleShortSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(short?))
                        {
                            return new OracleNullableShortSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(long))
                        {
                            return new OracleLongSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(long?))
                        {
                            return new OracleNullableLongSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(float))
                        {
                            return new OracleFloatSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(float?))
                        {
                            return new OracleNullableFloatSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(decimal))
                        {
                            return new OracleDecimalSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(decimal?))
                        {
                            return new OracleNullableDecimalSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(bool))
                        {
                            return new OracleBooleanSetter(prop, dr);
                        }
                        else if (prop.PropertyType == typeof(bool?))
                        {
                            return new OracleNullableBooleanSetter(prop, dr);
                        }
                        else if (prop.PropertyType.IsEnum)
                        {
                            return new OracleIntSetter(prop, dr);
                        }
                    }
                }
            }
            return null;
        }
    }

    class OracleRowIdSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleRowIdSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            //20181114 修改 主表数据不为空时，主表的rowid就不为空
            //在主表右连接另一个表时，有时，主表可能就会为空
            //不建议使用右连接
            //item.RowId = dr.GetString(col);
            item.RowId = dr.IsDBNull(col) ? "" : dr.GetString(col);
           // prop.SetValue(item, dr.GetMyString(col), null);
        }
    }

    class OracleStringSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleStringSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyString(col), null);
        }
    }

    class OracleShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleShortSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col) ?? 0, null);
        }
    }

    class OracleNullableShortSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableShortSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyShort(col), null);
        }
    }

    class OracleIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleIntSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col) ?? 0, null);
        }
    }

    class OracleNullableIntSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableIntSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyInt(col), null);
        }
    }

    class OracleLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleLongSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col) ?? 0, null);
        }
    }

    class OracleNullableLongSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableLongSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyLong(col), null);
        }
    }

    class OracleBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleBooleanSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col) ?? false, null);
        }
    }

    class OracleNullableBooleanSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableBooleanSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyBoolean(col), null);
        }
    }
   
    class OracleFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleFloatSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col) ?? 0, null);
        }
    }

    class OracleNullableFloatSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableFloatSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyFloat(col), null);
        }
    }

    class OracleDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleDoubleSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col) ?? 0, null);
        }
    }

    class OracleNullableDoubleSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableDoubleSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDouble(col), null);
        }
    }

    class OracleDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleDecimalSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col) ?? 0, null);
        }
    }

    class OracleNullableDecimalSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableDecimalSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDecimal(col), null);
        }
    }

    class OracleDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleDateTimeSetter(PropertyInfo prop, OracleDataReader dr)
        {
            this.prop = prop;
            this.dr = dr;
        }

        public void SetValue(DbEntity item, int col)
        {
            prop.SetValue(item, dr.GetMyDateTime(col) ?? DateTime.MinValue, null);
        }
    }

    class OracleNullableDateTimeSetter : ISetterValue
    {
        private PropertyInfo prop = null;
        private OracleDataReader dr = null;

        public OracleNullableDateTimeSetter(PropertyInfo prop, OracleDataReader dr)
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
