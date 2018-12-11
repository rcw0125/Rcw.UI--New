namespace Rcw.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    ///  实体类信息
    /// </summary>
    public class DbEntityInfo
    {
        private string _DataSourceName = "";  //数据源名称
        private bool _IsDistinct;              //是否消除重复数据
        private bool _IsView;               // 是否视图
        private string _MainTableAlias = "";  // 主表别名
        private string _MainTableName = "";   // 主表名称
        private DbSql _SqlDelete = new DbSql();    // 删除
        private DbSql _SqlInsert = new DbSql(); // 插入
        private DbSql _SqlUpdate = new DbSql();// 更新
        public List<DbColumnInfo> Columns = new List<DbColumnInfo>();
        private bool hasPrimaryKey; // 是否含有主键
        internal List<JoinTableInfo> otherTables = new List<JoinTableInfo>();   // 含有其他表
        private Dictionary<string, List<string>> refProperties = new Dictionary<string, List<string>>();
        private string sqlOrder = "";  // order 排序
        private string sqlSelect = ""; // 查询        
        private string _MainKey;//主键
        public bool hasAutoCol = false;
        public string AutoColName { get; set; }
        public string DisplayName { get; set; }

        public DbEntityInfo(Type entityType)
        {
            this.InitMeta(entityType);
        }

        /// <summary>
        /// 初始化该表的表注解，列注解，然后初始化sql语句
        /// </summary>
        /// <param name="entityType"></param>
        private void InitMeta(Type entityType)
        {
            #region 获取该表的DbSource数据源注解，设置该表的数据源，为空时，为默认数据源
            string dataSourceName = "";
            DbSourceAttribute customAttribute = entityType.GetCustomAttribute<DbSourceAttribute>();
            if (customAttribute != null)
            {
                dataSourceName = customAttribute.DataSourceName;
            }
            if (string.IsNullOrEmpty(dataSourceName))
            {
                this.DataSourceName = DbContext.DefaultDataSourceName;
            }
            else
            {
                this.DataSourceName = dataSourceName;
            }
            #endregion

            #region 获取该表的DbTable注解，得到主表和关联表
            DbTableAttribute[] customAttributes = (DbTableAttribute[])entityType.GetCustomAttributes(typeof(DbTableAttribute), false);
            this.MainTableName = entityType.Name;
            if (customAttributes != null)
            {
                foreach (DbTableAttribute attribute2 in customAttributes)
                {
                    //没有关联条件的表，为主表
                    if (string.IsNullOrEmpty(attribute2.JoinCondition))
                    {
                        if (!string.IsNullOrEmpty(attribute2.TableName.Trim()))
                        {
                            this.MainTableName = attribute2.TableName.Trim();
                        }
                        this.MainTableAlias = attribute2.TableAlias;
                        this.IsView = attribute2.IsView;
                        this.IsDistinct = attribute2.IsDistinct;
                    }
                    else
                    {
                        JoinTableInfo item = new JoinTableInfo
                        {
                            JoinTableName = attribute2.TableName,
                            JoinTableAlias = attribute2.TableAlias,
                            JoinCondition = attribute2.JoinCondition,
                            JoinType = attribute2.JoinType.ToString().ToUpper()
                        };
                        //将关联表的信息加入到管理表列表中
                        this.otherTables.Add(item);
                    }
                }
                //如果主表别名为空，则设置为表名的小写 rcw 20181210
                if (MainTableAlias == "")
                {
                    MainTableAlias = MainTableName.ToLower();
                }
            }
            #endregion
            //添加表的displayName属性
            DisplayNameAttribute tableDisplayName = entityType.GetCustomAttribute<DisplayNameAttribute>();
            if (tableDisplayName != null)
            {
                DisplayName = tableDisplayName.DisplayName;
            }
            else
            {
                DisplayName = this.MainTableName;
            }


            #region 计算otherTables，看不出这段代码的意义
            List<JoinTableInfo> collection = new List<JoinTableInfo>();
            List<JoinTableInfo> list2 = new List<JoinTableInfo>();
            List<JoinTableInfo> list3 = new List<JoinTableInfo>();
            int num = 0;
            while (num < this.otherTables.Count)
            {
                if (this.otherTables[num].Visited)
                {
                    collection.Add(this.otherTables[num]);
                    num++;
                }
                else
                {
                    JoinTableInfo info2 = this.otherTables[num];
                    list2.Clear();
                    list3.Clear();
                    for (int i = num + 1; i < this.otherTables.Count; i++)
                    {
                        if (info2.CompareTo(this.otherTables[i]) == 1)
                        {
                            list2.Add(this.otherTables[i]);
                        }
                        else
                        {
                            list3.Add(this.otherTables[i]);
                        }
                    }
                    this.otherTables.Clear();
                    this.otherTables.AddRange(collection);
                    this.otherTables.AddRange(list2);
                    this.otherTables.Add(info2);
                    this.otherTables.AddRange(list3);
                    info2.Visited = true;
                }
            }
            #endregion 

            //info3 遍历列属性
            foreach (PropertyInfo info3 in entityType.GetProperties())
            {
                #region 检查该列属性是否有RefPropertyAttribute注解
                RefPropertyAttribute[] attributeArray2 = (RefPropertyAttribute[])info3.GetCustomAttributes(typeof(RefPropertyAttribute), false);
                if ((attributeArray2 != null) && (attributeArray2.Length > 0))
                {
                    if (!this.refProperties.ContainsKey(info3.Name))
                    {
                        this.refProperties.Add(info3.Name, new List<string>());
                    }
                    List<string> list4 = this.refProperties[info3.Name];
                    foreach (RefPropertyAttribute attribute3 in attributeArray2)
                    {
                        if (!string.IsNullOrEmpty(attribute3.PropertyName) && !list4.Contains(attribute3.PropertyName))
                        {
                            list4.Add(attribute3.PropertyName);
                        }
                    }
                }
                #endregion

                #region 检查该列属性是否有NonTableFieldAttribute注解，并完成该列的属性初始化，添加该列到该表
                object[] objArray = info3.GetCustomAttributes(typeof(NonTableFieldAttribute), false);
                if (((objArray == null) || (objArray.Length == 0)) && SupportType(info3))
                {
                    DbColumnInfo info4 = new DbColumnInfo
                    {
                        ColPropertyInfo = info3
                    };
                    //获取Description注解
                    DescriptionAttribute attribute4 = info3.GetCustomAttribute<DescriptionAttribute>();
                    if (attribute4 != null)
                    {
                        info4.Description = attribute4.Description;
                    }
                    else
                    {
                        //获取DisplayName注解
                        DisplayNameAttribute attribute5 = info3.GetCustomAttribute<DisplayNameAttribute>();
                        if (attribute5 != null)
                        {
                            info4.Description = attribute5.DisplayName;
                        }
                        else
                        {
                            info4.Description = info3.Name;
                        }
                    }
                    //获取DbTableColumn注解
                    DbTableColumnAttribute attribute6 = info3.GetCustomAttribute<DbTableColumnAttribute>();
                    if (attribute6 != null)
                    {
                        //20181123添加自动列属性
                        if (attribute6.AutoIncrement)
                        {
                            hasAutoCol = true;
                            AutoColName = info3.Name;
                        }
                        // 是主键
                        if (attribute6.IsPrimaryKey)
                        {
                            info4.AutoIncrement = attribute6.AutoIncrement;
                            info4.IsPrimaryColumn = true;
                            info4.IsUpdateConditionColumn = true;
                            info4.IsDeleteConditionColumn = true;
                        }
                        if (attribute6.IsGuid)
                        {
                            info4.IsGuid = attribute6.IsGuid;
                        }

                        if (attribute6.IsSysDate)
                        {
                            info4.IsSysDate = attribute6.IsSysDate;
                        }
                        if (attribute6.IsSysDateString)
                        {
                            info4.IsSysDateString = attribute6.IsSysDateString;
                        }

                        info4.SortDirection = attribute6.SortDirection;
                        info4.SortOrder = attribute6.SortOrder;
                        
                        // 列名为空时，它必然是主表列 
                        if (string.IsNullOrEmpty(attribute6.ColName))
                        {
                            //20181113 xiugai
                            if (attribute6.IsCalcColumn)
                            {
                                info4.ColName = info3.Name.ToUpper();
                                info4.IsCalcColumn = true;
                                info4.IsMainTableColumn = true;
                                info4.TableName = this.MainTableName;
                                info4.TableAlias = this.MainTableAlias;
                                info4.IsInsertColumn = false;
                                info4.IsUpdateColumn = false;
                            }
                            else
                            {
                                info4.ColName = info3.Name.ToUpper();
                                info4.IsMainTableColumn = true;
                                info4.TableName = this.MainTableName;
                                info4.TableAlias = this.MainTableAlias;
                                info4.IsInsertColumn = true;
                                info4.IsUpdateColumn = true;
                            }

                           
                        }
                        // 是计算列时，不是主表列
                        //else if (attribute6.IsCalcColumn)
                        //{
                        //    info4.ColName = attribute6.ColName;
                        //    info4.IsCalcColumn = true;
                        //    info4.IsMainTableColumn = false;
                        //    info4.TableName = this.MainTableName;
                        //    info4.TableAlias = this.MainTableAlias;
                        //    info4.IsInsertColumn = false;
                        //    info4.IsUpdateColumn = false;
                        //}
                        // 列名不包含.,是主表列
                        else if (!attribute6.ColName.Contains("."))
                        {
                            info4.ColName = attribute6.ColName.ToUpper();
                            info4.IsMainTableColumn = true;
                            info4.TableName = this.MainTableName;
                            info4.TableAlias = this.MainTableAlias;
                            info4.IsInsertColumn = true;
                            info4.IsUpdateColumn = true;
                        }// 列名包含.,是关联表列
                        else
                        {
                            string[] strArray = attribute6.ColName.Split(new char[] { '.' });
                            info4.TableAlias = strArray[0];
                            info4.TableName = this.getTableName(info4.TableAlias);
                            info4.ColName = strArray[1].ToUpper();
                            if ((info4.TableAlias == this.MainTableAlias) || (info4.TableAlias == this.MainTableName))
                            {
                                info4.IsMainTableColumn = true;
                                info4.IsInsertColumn = true;
                                info4.IsUpdateColumn = true;
                            }
                            else
                            {
                                info4.IsMainTableColumn = false;
                                info4.IsUpdateConditionColumn = false;
                                info4.IsDeleteConditionColumn = false;
                            }
                        }
                    }
                    else  //获取DbTableColumn注解，没有DbTableColumn注解时，其为主表
                    {
                        info4.ColName = info3.Name.ToUpper();
                        info4.IsMainTableColumn = true;
                        info4.TableName = this.MainTableName;
                        info4.TableAlias = this.MainTableAlias;
                        info4.IsInsertColumn = true;
                        info4.IsUpdateColumn = true;
                    }
                    #region 如果有重名列时，重名列不插入和更新
                    foreach (DbColumnInfo info5 in this.Columns)
                    {
                        //20181120 修改 主表 与他自己关联时 可能会出现重名
                        // if (info5.ColName == info4.ColName)
                        if (info5.ColName == info4.ColName && info5.FullColName == info4.FullColName)
                        {
                            info4.IsInsertColumn = false;
                            info4.IsUpdateColumn = false;
                            break;
                        }
                    }
                    #endregion

                    #region  已经初始化完列的属性信息，添加此列的信息到DbEntityInfo
                    this.Columns.Add(info4);
                    #endregion


                }
                #endregion

            }
            #region  检查是否含有主键
            this.hasPrimaryKey = false;
            foreach (DbColumnInfo info6 in this.Columns)
            {
                if (info6.IsPrimaryColumn)
                {
                    this.hasPrimaryKey = true;
                    this.MainKey = info6.ColName;
                    break;
                }
            }
            #endregion


            //列信息初始化结束后，初始化sql语句
            this.DataSource.InitSql(this);
        }


        //获取列信息
        public DbColumnInfo GetColumnInfo(string propName)
        {
            foreach (DbColumnInfo info in this.Columns)
            {
                if (info.ColPropertyInfo.Name == propName)
                {
                    return info;
                }
            }
            return null;
        }

        //获取表名
        internal string getTableName(string key)
        {
            if (this.MainTableKey == key)
            {
                return this.MainTableName;
            }
            foreach (JoinTableInfo info in this.otherTables)
            {
                if (info.JoinTableKey == key)
                {
                    return info.JoinTableName;
                }
            }
            throw new Exception("找不到表:" + key);
        }



        public bool IsUpdateProperty(string propName)
        {
            foreach (DbColumnInfo info in this.Columns)
            {
                if (info.IsUpdateColumn && (info.ColPropertyInfo.Name == propName))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SupportType(PropertyInfo prop)
        {
            if (!prop.CanWrite)
            {
                return false;
            }
            if (!prop.CanRead)
            {
                return false;
            }
            return ((prop.PropertyType == typeof(string)) || ((prop.PropertyType == typeof(double)) || ((prop.PropertyType == typeof(double?)) || ((prop.PropertyType == typeof(int)) || ((prop.PropertyType == typeof(int?)) || ((prop.PropertyType == typeof(DateTime)) || ((prop.PropertyType == typeof(DateTime?)) || ((prop.PropertyType == typeof(long)) || ((prop.PropertyType == typeof(long?)) || ((prop.PropertyType == typeof(decimal)) || ((prop.PropertyType == typeof(decimal?)) || ((prop.PropertyType == typeof(bool)) || ((prop.PropertyType == typeof(bool?)) || ((prop.PropertyType == typeof(byte)) || ((prop.PropertyType == typeof(byte?)) || prop.PropertyType.IsEnum)))))))))))))));
        }

        public Rcw.Data.DataSource DataSource
        {
            get
            {
                return DbContext.GetDataSource(this.DataSourceName);
            }
        }

        public string DataSourceName
        {
            get
            {
                return this._DataSourceName;
            }
            set
            {
                this._DataSourceName = value;
            }
        }

        public string MainKey
        {
            get
            {
                return this._MainKey;
            }
            set
            {
                this._MainKey = value;
            }
        }
        /// <summary>
        /// 是否含有主键
        /// </summary>
        public bool HasPrimaryKey
        {
            get
            {
                return this.hasPrimaryKey;
            }
            set
            {
                this.hasPrimaryKey = value;
            }
        }

        public bool IsDistinct
        {
            get
            {
                return this._IsDistinct;
            }
            set
            {
                this._IsDistinct = value;
            }
        }
        /// <summary>
        /// 是视图  是否？
        /// </summary>
        public bool IsView
        {
            get
            {
                return this._IsView;
            }
            set
            {
                this._IsView = value;
            }
        }
        /// <summary>
        /// 主表别名
        /// </summary>
        public string MainTableAlias
        {
            get
            {
                return this._MainTableAlias;
            }
            set
            {
                this._MainTableAlias = value;
            }
        }
        /// <summary>
        /// 主表名key， 主表有别名时，是别名，没有时，默认值
        /// </summary>
        private string MainTableKey
        {
            get
            {
                if (!string.IsNullOrEmpty(this.MainTableAlias))
                {
                    return this.MainTableAlias;
                }
                return this.MainTableName;
            }
        }
        /// <summary>
        /// 主表名
        /// </summary>
        public string MainTableName
        {
            get
            {
                return this._MainTableName;
            }
            set
            {
                this._MainTableName = value;
            }
        }

        public Dictionary<string, List<string>> RefProperties
        {
            get
            {
                return this.refProperties;
            }
        }
        /// <summary>
        /// 查询sql
        /// </summary>
        public string SelectSql
        {
            get
            {
                return this.sqlSelect;
            }
            set
            {
                this.sqlSelect = value;
            }
        }
        /// <summary>
        /// 删除sql
        /// </summary>
        public DbSql SqlDelete
        {
            get
            {
                return this._SqlDelete;
            }
            set
            {
                this._SqlDelete = value;
            }
        }

        /// <summary>
        /// 插入sql
        /// </summary>

        public DbSql SqlInsert
        {
            get
            {
                return this._SqlInsert;
            }
            set
            {
                this._SqlInsert = value;
            }
        }
        /// <summary>
        /// 更新sql
        /// </summary>
        public DbSql SqlUpdate
        {
            get
            {
                return this._SqlUpdate;
            }
            set
            {
                this._SqlUpdate = value;
            }
        }
        /// <summary>
        /// 排序sql
        /// </summary>
        public string SqlOrder
        {
            get
            {
                return this.sqlOrder;
            }
            set
            {
                this.sqlOrder = value;
            }
        }

     
    }
}

