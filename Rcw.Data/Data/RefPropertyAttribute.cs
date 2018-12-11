using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.Data
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple=true)]
    public class RefPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public RefPropertyAttribute(string propertyName)
        {
            this.PropertyName = propertyName;
        }
    }
}
