using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Rcw.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbTableColumnAttribute : Attribute
    {
        private bool _isGuid = false;

        /// <summary>
        /// true 数据库自动生成guid
        /// </summary>
        public bool IsGuid
        {
            get
            {
                return this._isGuid;
            }
            set
            {
                this._isGuid = value;
            }
        }

        private bool _isSysDate = false;

        /// <summary>
        /// true 数据库时间，日期格式
        /// </summary>
        public bool IsSysDate
        {
            get
            {
                return this._isSysDate;
            }
            set
            {
                this._isSysDate = value;
            }
        }

        private bool _isSysDateString = false;

        /// <summary>
        /// true 数据库时间字符串格式
        /// </summary>
        public bool IsSysDateString
        {
            get
            {
                return this._isSysDateString;
            }
            set
            {
                this._isSysDateString = value;
            }
        }
        private bool _IsPrimaryKey = false;
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return _IsPrimaryKey; }
            set { _IsPrimaryKey = value; }
        }
        
        /// <summary>
        /// 自增列
        /// </summary>
        public bool AutoIncrement { get; set; }
        
        private string _ColName = "";
        /// <summary>
        /// 列名
        /// </summary>
        public string ColName
        {
            get { return _ColName; }
            set { _ColName = value; }
        }


        private bool _IsCalcColumn=false;
        /// <summary>
        /// 是否计算列
        /// </summary>
        public bool IsCalcColumn
        {
            get { return _IsCalcColumn; }
            set { _IsCalcColumn = value; }
        }

        private SortDirection _SortDirection = SortDirection.None;
        /// <summary>
        /// 排序方式
        /// </summary>
        public SortDirection SortDirection
        {
            get { return _SortDirection; }
            set { _SortDirection = value; }
        }

        private int _SortOrder = 0;
        /// <summary>
        /// 排序序号
        /// </summary>
        public int SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        public DbTableColumnAttribute()
        {

        }

        public DbTableColumnAttribute(string colName)
        {
            this.ColName = colName;
        }

    }

  

    public enum SortDirection
    {
        None,
        Ascending,
        Descending
    }
}
