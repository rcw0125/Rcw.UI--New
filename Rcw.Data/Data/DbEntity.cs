using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rcw.Data.SqlServer;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace Rcw.Data
{
    public delegate void DbSaveEventHandler(DbEntity entity,IDbTransaction trans);

    public abstract class DbEntity : INotifyPropertyChanged
    {
        internal event DbSaveEventHandler BeforeSaveEvent;
        internal event DbSaveEventHandler AfterSaveEvent;

        public event PropertyChangedEventHandler PropertyChanged;


        internal Type entityType = null;
        /// <summary>
        /// 实体信息
        /// </summary>
        public DbEntityInfo entityInfo = null;
        /// <summary>
        /// 初始化实体类信息
        /// </summary>
        public DbEntity()
        {
            var method = new StackFrame(1).GetMethod();
            this.entityType = method.DeclaringType;
            this.entityInfo = DbContext.GetDbEnityInfo(entityType);
        }
        private void RaisePropChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            if (this.entityInfo != null)
            {
                if (this.entityInfo.RefProperties.ContainsKey(propertyName))
                {
                    foreach (var item in this.entityInfo.RefProperties[propertyName])
                    {
                        RaisePropChanged(item);
                    }
                }
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (!Initing) RaisePropChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName, bool induceChanged)
        {
            if (!Initing)
            {
                RaisePropChanged(propertyName);

                if (induceChanged)
                {
                    if (this.DataState == DataRowState.Unchanged)
                        this.DataState = DataRowState.Modified;
                }
            }
        }

        protected void RaisePropertyChanged()
        {
            if (!Initing)
            {
                StackTrace frames = new StackTrace();
                for (int i = 1; i < frames.FrameCount; i++)
                {
                    var frame = frames.GetFrame(i).GetMethod() as MethodInfo;
                    if (frame != null)
                    {
                        if (frame.IsSpecialName && frame.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase))
                        {
                            string propertyName = frame.Name.Substring(4);
                            RaisePropChanged(propertyName);

                            if (this.DataState == DataRowState.Unchanged)
                            {
                                if (this.entityInfo.IsUpdateProperty(propertyName))
                                {
                                    this.DataState = DataRowState.Modified;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 回滚修改
        /// </summary>
        public virtual void RejectChanges()
        {
            foreach (var oriField in entityType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (oriField.Name.StartsWith("_Ori"))
                {
                   string curFieldName= oriField.Name.Substring(4);
                   FieldInfo curField = entityType.GetField(curFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (curField != null)
                    {
                       object oriVal= oriField.GetValue(this);
                       object curVal = curField.GetValue(this);
                       if (curVal != oriVal)
                       {
                           curField.SetValue(this, oriField.GetValue(this));
                           string propertyName = oriField.Name.Substring(5);
                           RaisePropertyChanged(propertyName);
                       }
                    }
                }
            }
            DataState = DataRowState.Unchanged;
        }

        /// <summary>
        /// 接受更改
        /// </summary>
        public virtual void AcceptChanges()
        {
            foreach (var oriField in entityType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (oriField.Name.StartsWith("_Ori"))
                {
                    string curFieldName = oriField.Name.Substring(4);
                    FieldInfo curField = entityType.GetField(curFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (curField != null)
                    {
                        oriField.SetValue(this, curField.GetValue(this));
                    }
                }
            }
            DataState = DataRowState.Unchanged;
        }

        private bool _SaveEnable = true;
        /// <summary>
        /// 将saveenable属性从public改为internal
        /// </summary>
        [NonTableField]
        //[Browsable(false)]
       
        public bool SaveEnable
        {
            get { return _SaveEnable; }
            set
            {
                if (_SaveEnable != value)
                {
                    _SaveEnable = value;
                    if (!IsIniting)
                        RaisePropertyChanged("Enable");
                }
            }
        }
        //row_index
        private int _row_index;
        [NonTableField]
        [Browsable(false)]
        public int row_index
        {
            get { return _row_index; }
            set
            {
                _row_index = value;
            }
        }
        private int _rowtotal;
        [NonTableField]
        [Browsable(false)]
        public int rowtotal
        {
            get { return _rowtotal; }
            set
            {
                _rowtotal = value;
            }
        }


        private DataRowState _DataState = DataRowState.Added;
       
        [NonTableField]
        [Browsable(false)]
        public DataRowState DataState
        {
            get { return _DataState; }
            set
            {
                if (_DataState != value)
                {
                    _DataState = value;
                }

                if (_DataState == DataRowState.Unchanged)
                    this.SaveEnable = false;
                else
                    this.SaveEnable = true;
            }
        }

        /// <summary>
        /// 设置数据没有修改
        /// </summary>
        public void SetDataStateAsUnchanged()
        {
            SaveEnable = false;
            DataState = DataRowState.Unchanged;
        }
        internal void SetDataStateAsAdded()
        {
            DataState = DataRowState.Added;
        }
        internal void SetDataStateAsUpdated()
        {
            DataState = DataRowState.Modified;
        }
        internal void SetDataStateAsDeleted()
        {
            DataState = DataRowState.Deleted;
        }

        private bool Initing = false;

        /// <summary>
        /// 是否在初始化
        /// </summary>
        [Browsable(false)]
        [NonTableField]
        public bool IsIniting
        {
            get
            {
                return Initing;
            }
        }
        /// <summary>
        /// 开始初始化
        /// </summary>
        public void BeginInit()
        {
            Initing = true;
            DataState = DataRowState.Unchanged;
        }
        /// <summary>
        /// 结束初始化
        /// </summary>
        public void EndInit()
        {
            Initing = false;
        }
        /// <summary>
        /// 数据保存
        /// </summary>
        public void Save(DataSource ds=null)
        {
            IDbConnection con = null;
            if (ds == null)
            {
                con = DbContext.GetConnection(this.entityType);
            }
            else
            {
                con = DbContext.GetDefaultConnection(ds.SourceName);
            }
            
            con.Open();
            IDbTransaction trans = con.BeginTransaction();
            Save(trans,ds);
            trans.Commit();
            con.Close();
        }     
        /// <summary>
        /// 同一个事务内，数据保存
        /// </summary>
        /// <param name="trans"></param>
        public void Save(IDbTransaction trans,DataSource ds=null)
        {

            try
            {
                SaveTemplate saveTemplate = new SaveTemplate();
                if (ds == null)
                {
                    saveTemplate.DataSource = entityInfo.DataSource;
                }
                else
                {
                    saveTemplate.DataSource = ds;
                }
                
                saveTemplate.Transaction = trans;
                saveTemplate.SqlInsert = entityInfo.SqlInsert;
                saveTemplate.SqlUpdate = entityInfo.SqlUpdate;
                saveTemplate.SqlDelete = entityInfo.SqlDelete;

                IDbConnection con = trans.Connection;
                //20181115  指定数据源，传输数据时，不执行此方法
                if (ds == null)
                {
                    BeforeSave(trans);  // 可能没有执行操作,需要在实体类中重写该方法
                }
               
                if (DataState == DataRowState.Deleted)
                {
                    DbDelete(saveTemplate);
                }
                else if (DataState == DataRowState.Added)
                {
                    DbInsert(saveTemplate);
                }
                else if (DataState == DataRowState.Modified)
                {
                    DbUpdate(saveTemplate);
                }
                //20181115  指定数据源，传输数据时，不执行此方法
                if (ds == null)
                {
                    AfterSave(trans);  // 可能没有执行操作,需要在实体类中重写该方法
                }
               
                AcceptChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("DbEntiry save(trans)出现异常"+ex.ToString());
            }
           
        }

        internal virtual void Save(SaveTemplate saveTemplate)
        {
            BeforeSave(saveTemplate.Transaction);
            if (DataState == DataRowState.Deleted)
            {
                DbDelete(saveTemplate);
            }
            else if (DataState == DataRowState.Added)
            {
                DbInsert(saveTemplate);
            }
            else if (DataState == DataRowState.Modified)
            {
                DbUpdate(saveTemplate);
            }
            AfterSave(saveTemplate.Transaction);
            AcceptChanges();
        }

        internal void Delete()
        {
            if (this.DataState == DataRowState.Added)
                this.DataState = DataRowState.Unchanged;
            else
                this.DataState = DataRowState.Deleted;
        }

        internal void DbInsert()
        {
            DataState = DataRowState.Added;
            Save();
        }

        internal void DbUpdate()
        {
            DataState = DataRowState.Modified;
            Save();
        }

        internal void DbDelete()
        {
            DataState = DataRowState.Deleted;
            Save();
        }

        protected virtual void DbInsert(SaveTemplate saveTemplate)
        {
            if (saveTemplate.DataSource == null) throw new Exception("数据源为空");
            saveTemplate.DataSource.Insert(saveTemplate.Transaction, this, saveTemplate.SqlInsert);

            //DbContext.DbInsert(saveTemplate, this);
        }

        protected virtual void DbUpdate(SaveTemplate saveTemplate)
        {
            if (saveTemplate.DataSource == null) throw new Exception("数据源为空");
            saveTemplate.DataSource.Update(saveTemplate.Transaction, this, saveTemplate.SqlUpdate);
           
            //DbContext.DbUpdate(saveTemplate, this);
        }

        protected virtual void DbDelete(SaveTemplate saveTemplate)
        {
            if (saveTemplate.DataSource == null) throw new Exception("数据源为空");
            saveTemplate.DataSource.Delete(saveTemplate.Transaction, this, saveTemplate.SqlDelete);
           // DbContext.DbDelete(saveTemplate, this);
        }

        protected virtual void BeforeSave(IDbTransaction trans)
        {
            if (BeforeSaveEvent != null)
            {
                BeforeSaveEvent(this, trans);
            }
        }

        protected virtual void AfterSave(IDbTransaction trans)
        {
            if (AfterSaveEvent != null)
            {
                AfterSaveEvent(this, trans);
            }
        }

        public virtual void AfterLoad(string loadInfo)
        {

        }

        internal string _RowId = "";

        [Browsable(false)]
        [NonTableField]
        internal string RowId
        {
            get { return _RowId; }
            set
            {
                _RowId = value;
            }
        }

        

    }

}
