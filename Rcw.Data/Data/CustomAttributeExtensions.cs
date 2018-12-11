using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rcw.Data
{
    static class CustomAttributeExtensions
    {
        public static T GetCustomAttribute<T>(this Type mytype) where T : Attribute
        {
            T[] customAttributes = (T[])mytype.GetCustomAttributes(typeof(T), false);
            if (customAttributes != null && customAttributes.Length > 0)
                return customAttributes[0];
            else
                return null;
        }

        public static T GetCustomAttribute<T>(this PropertyInfo myProp) where T : Attribute
        {
            T[] customAttributes = (T[])myProp.GetCustomAttributes(typeof(T), false);
            if (customAttributes != null && customAttributes.Length > 0)
                return customAttributes[0];
            else
                return null;
        }

    }
}
