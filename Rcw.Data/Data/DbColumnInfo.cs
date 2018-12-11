namespace Rcw.Data
{
    using System;
    using System.Reflection;

    public class DbColumnInfo
    {
        private bool _AutoIncrement;
        private string _ColName = "";
        private Rcw.Data.ColOperation _ColOperation;
        private PropertyInfo _ColPropertyInfo;
        private string _Description;
        private bool _IsCalcColumn;
        private bool _IsDeleteConditionColumn;
        private bool _IsInsertColumn;
        private bool _IsMainTableColumn = true;
        private bool _IsPrimaryColumn;
        private bool _IsUpdateColumn;
        private bool _IsUpdateConditionColumn;
        private Rcw.Data.SortDirection _SortDirection;
        private int _SortOrder;
        private string _TableAlias;
        private string _TableName = "";
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


        public bool AutoIncrement
        {
            get
            {
                return (this.IsPrimaryColumn && this._AutoIncrement);
            }
            set
            {
                this._AutoIncrement = value;
            }
        }

        public string ColName
        {
            get
            {
                return this._ColName;
            }
            set
            {
                this._ColName = value;
            }
        }

        public Rcw.Data.ColOperation ColOperation
        {
            get
            {
                return this._ColOperation;
            }
            set
            {
                this._ColOperation = value;
            }
        }

        public PropertyInfo ColPropertyInfo
        {
            get
            {
                return this._ColPropertyInfo;
            }
            set
            {
                this._ColPropertyInfo = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public string FullColName
        {
            get
            {
                if (this.IsCalcColumn)
                {
                    return this.ColName;
                }
                if (string.IsNullOrEmpty(this.TableAlias))
                {
                    return (this.TableName + "." + this.ColName);
                }
                return (this.TableAlias + "." + this.ColName);
            }
        }

        public bool IsCalcColumn
        {
            get
            {
                return this._IsCalcColumn;
            }
            set
            {
                this._IsCalcColumn = value;
            }
        }

        public bool IsDeleteConditionColumn
        {
            get
            {
                return this.IsPrimaryColumn;
            }
            set
            {
                this._IsDeleteConditionColumn = value;
            }
        }
        //20181113 修改
        public bool IsInsertColumn
        {
            get
            {
                //return ((this.IsMainTableColumn && !this.AutoIncrement) && !this.IsCalcColumn);
                return this._IsInsertColumn;
            }
            set
            {
                this._IsInsertColumn = value;
            }
        }

        public bool IsMainTableColumn
        {
            get
            {
                return this._IsMainTableColumn;
            }
            set
            {
                this._IsMainTableColumn = value;
            }
        }

        public bool IsPrimaryColumn
        {
            get
            {
                return (this.IsMainTableColumn && this._IsPrimaryColumn);
            }
            set
            {
                this._IsPrimaryColumn = value;
            }
        }
        //20181113 修改
        public bool IsUpdateColumn
        {
            get
            {
                //return ((this.IsMainTableColumn && !this.AutoIncrement) && !this.IsCalcColumn);
                return this._IsUpdateColumn;
            }
            set
            {
                this._IsUpdateColumn = value;
            }
        }

        public bool IsUpdateConditionColumn
        {
            get
            {
                return this.IsPrimaryColumn;
            }
            set
            {
                this._IsUpdateConditionColumn = value;
            }
        }

        public Rcw.Data.SortDirection SortDirection
        {
            get
            {
                return this._SortDirection;
            }
            set
            {
                this._SortDirection = value;
            }
        }

        public int SortOrder
        {
            get
            {
                return this._SortOrder;
            }
            set
            {
                this._SortOrder = value;
            }
        }

        public string TableAlias
        {
            get
            {
                return this._TableAlias;
            }
            set
            {
                this._TableAlias = value;
            }
        }

        public string TableName
        {
            get
            {
                return this._TableName;
            }
            set
            {
                this._TableName = value;
            }
        }
    }
}

