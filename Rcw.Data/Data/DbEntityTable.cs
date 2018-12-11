using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Rcw.Data
{
    //public class BindingList<T> : Collection<T>, IBindingList, IList, ICollection, IEnumerable, ICancelAddNew, IRaiseItemChangedEvents
    public class DbEntityTable<T> : BindingList<T>, IFilter, INotifyPropertyChanged where T : DbEntity,new()
    {
        /// <summary>
        /// 隐藏的数据
        /// </summary>
        protected List<T> hideList = new List<T>();

       
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected bool initTableData = false;

        public void BeginInit()
        {
            initTableData = true;
        }

        public void EndInit()
        {
            initTableData = false;
            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
            this.OnListChanged(arg);
        }
        /// <summary>
        /// 保存数据，整个table是一个事务
        /// </summary>
        public virtual void Save()
        {
            string mainTable = DbContext.GetDbEnityInfo(typeof(T)).MainTableName;
            try
            {
                IDbConnection con = DbContext.GetConnection(typeof(T));
                con.Open();
                IDbTransaction trans = con.BeginTransaction();
                Save(trans);
               // SaveOther(trans);
                trans.Commit();
                con.Close();
                // ExeOther(con);             
            }

            catch (Exception ex)
            {              
                throw new Exception("DbEntiryTable save()出现异常"+ex.ToString());
            }
           
        }

        /// <summary>
        /// 事务保存，需要在程序中，先添加一个trans，最后提交commit
        /// IDbConnection con = DbContext.GetConnection(typeof(T)); con.Open();
        /// IDbTransaction trans = con.BeginTransaction(); 最后 trans.Commit(); con.Close();
        /// </summary>
        /// <param name="trans"> </param>
        public void Save(IDbTransaction trans)
        {         

            string mainTable = DbContext.GetDbEnityInfo(typeof(T)).MainTableName;
            try
            {
                List<T> deleteList = new List<T>();
                IDbConnection con = trans.Connection;
                foreach (T item in hideList)
                {
                    if (item.DataState == DataRowState.Deleted)
                        deleteList.Add(item);
                    item.Save(trans);
                }
                foreach (T item in deleteList)
                {
                    hideList.Remove(item);
                }

               
            }

            catch (Exception ex)
            {
               
                throw new Exception("DbEntiryTable save()出现异常" + ex.ToString());
            }
        }

  
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (!initTableData)
            {
                if (item.DataState == DataRowState.Deleted && hideList.Contains(item))
                {
                    item.DataState = DataRowState.Unchanged;
                }
                else
                {
                     hideList.Add(item);
                }
            }
        }

        protected override void RemoveItem(int index)
        {
            if (!initTableData)
            {
                T delObj = this[index];
                if (delObj.DataState == DataRowState.Added)
                {
                    hideList.Remove(delObj);
                }
                else
                {
                    delObj.Delete();
                }
            }
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            if (!initTableData)
            {
                foreach (T delObj in this)
                {
                    if (delObj.DataState == DataRowState.Added)
                    {
                        hideList.Remove(delObj);
                    }
                    delObj.Delete();
                }
            }
            base.ClearItems();  
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        public void Empty()
        {
            BeginInit();
            hideList.Clear();
            this.Clear();
            EndInit();
            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
            this.OnListChanged(arg);
        }


        public void Sort(Comparison<T> compa)
        {
            (base.Items as List<T>).Sort(compa);
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            propertyDescriptor = prop;
            sortDirection = direction;
            _IsSortedCore = true;
            List<T> list = this.Items as List<T>;
            list.Sort(Compare);
            _IsSortedCore = true;
            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, propertyDescriptor);
            this.OnListChanged(arg);

        }

        private PropertyDescriptor propertyDescriptor = null;
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return propertyDescriptor;
            }
        }

        private ListSortDirection sortDirection = ListSortDirection.Ascending;
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return sortDirection;
            }
        }

        private int Compare(T x, T y)
        {
            if (sortDirection == ListSortDirection.Descending)
                return CompareValue(propertyDescriptor.GetValue(y), propertyDescriptor.GetValue(x));
            else
                return CompareValue(propertyDescriptor.GetValue(x), propertyDescriptor.GetValue(y));
        }

        private int Compare2(T x, T y)
        {
            return hideList.IndexOf(x).CompareTo(hideList.IndexOf(y));
        }

        static int CompareValue(object o1, object o2)
        {
            if (o1 == null) return o2 == null ? 0 : -1;
            else if (o2 == null) return 1;
            else if (o1 is IComparable) return ((IComparable)o1).CompareTo(o2);
            else if (o2 is IComparable) return ((IComparable)o2).CompareTo(o1);
            else return o1.ToString().CompareTo(o2.ToString());
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        private bool _IsSortedCore = false;
        protected override bool IsSortedCore
        {
            get
            {
                return _IsSortedCore;
            }
        }

        protected override void RemoveSortCore()
        {
            _IsSortedCore = false;
            List<T> list = this.Items as List<T>;
            list.Sort(Compare2);
            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
            this.OnListChanged(arg);
        }

        public void RemoveSort()
        {
            RemoveSortCore();
        }

        public void CancelFilter()
        {         
            initTableData = true;  
            this.Clear();
            foreach (T item in hideList)
            {
                if (item.DataState != DataRowState.Deleted)
                {
                    this.Add(item);
                }
            }
            initTableData = false;

            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
            this.OnListChanged(arg);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!initTableData)
                base.OnListChanged(e);
        }

         /// <summary>
        /// 回滚修改
        /// </summary>
        public void RejectChanges()
        {
            this.BeginInit();
            this.Clear();
            for (int i = hideList.Count - 1; i >= 0; i--)
            {
                T item = hideList[i];
                if (item.DataState == DataRowState.Added)
                {
                    hideList.RemoveAt(i);
                }
                else
                {
                    item.RejectChanges();
                    this.Add(item);
                }
            }
            this.EndInit();

        }

        #region IFilter 成员

        public void Filter(Dictionary<string, string> para)
        {
            initTableData = true;
            this.Clear();
            foreach (T hideItem in hideList)
            {
                bool shouldAdd = true;
                shouldAdd &= (hideItem.DataState != DataRowState.Deleted);

                foreach (KeyValuePair<string, string> item in para)
                {
                    PropertyInfo p = typeof(T).GetProperty(item.Key);
                    if (p == null) continue;
                    if (p.PropertyType == typeof(string))
                    {
                        string val = Convert.ToString(p.GetValue(hideItem, null));
                        shouldAdd &= val.StartsWith(item.Value);
                    }
                    if (p.PropertyType == typeof(double))
                    {
                        double? val = Convert.ToDouble(p.GetValue(hideItem, null));
                        shouldAdd &= (val == Convert.ToDouble(item.Value));
                    }
                    if (p.PropertyType == typeof(int))
                    {
                        int val = Convert.ToInt32(p.GetValue(hideItem, null));
                        shouldAdd &= (val == Convert.ToInt32(item.Value));
                    }
                    if (p.PropertyType == typeof(long))
                    {
                        long val = Convert.ToInt64(p.GetValue(hideItem, null));
                        shouldAdd &= (val == Convert.ToInt64(item.Value));
                    }
                }
                if (shouldAdd)
                    this.Add(hideItem);
            }
            List<T> list = this.Items as List<T>;
            if (IsSortedCore)
                list.Sort(Compare);
            else
                list.Sort(Compare2);

            initTableData = false;
            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
            this.OnListChanged(arg);
        }

        public void Filter(Predicate<T> predicate)
        {
            initTableData = true;
            this.Clear();
            foreach (T hideItem in hideList)
            {
                if (hideItem.DataState != DataRowState.Deleted && predicate(hideItem))
                    this.Add(hideItem);
            }
            List<T> list = this.Items as List<T>;
            if (IsSortedCore)
                list.Sort(Compare);
            else
                list.Sort(Compare2);

            initTableData = false;
            ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
            this.OnListChanged(arg);
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _LoadInfo="";

        public string LoadInfo
        {
            get { return _LoadInfo; }
            set
            {
                if (_LoadInfo != value)
                {
                    _LoadInfo = value;
                    RaisePropertyChanged("LoadInfo");
                }
            }
        }

       

        /// <summary>
        /// 加载所有数据
        /// </summary>
        public void LoadData()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string loadSql = info.SelectSql + info.SqlOrder;
            try
            {

                RaiseListChangedEvents = false;
                initTableData = true;
                this.Clear();
                hideList.Clear();
                hideList = info.DataSource.LoadData<T>(loadSql);

                if (hideList == null) hideList = new List<T>();

                foreach (var item in hideList)
                {
                    item.BeginInit();
                    this.Add(item);
                    item.AfterLoad(LoadInfo);
                    item.EndInit();
                }

                initTableData = false;
                RaiseListChangedEvents = true;
                this.ResetBindings();
             
                ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
                this.OnListChanged(arg);

            }
            catch (Exception ex)
            {
               
                throw new Exception(string.Format("加载错误：{0} 异常:{1}", loadSql, ex.Message));
            }
        }

        internal List<T> LoadDataList()
        {
            DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
            string loadSql = info.SelectSql + info.SqlOrder;
            try
            { 
                var data = info.DataSource.LoadData<T>(loadSql);
                return data;
               
            }
            catch
            {
                return null;
            }    
        }

        /// <summary>
        /// 通过条件加载数据
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="args"></param>
        public void LoadDataByWhere(string whereSql="1=1", params object[] args)
        {

            string mainTable = DbContext.GetDbEnityInfo(typeof(T)).MainTableName;
            try
            {
               
                RaiseListChangedEvents = false;
                initTableData = true;
                this.Clear();
                hideList.Clear();

                hideList = DbContext.LoadDataByWhere<T>(whereSql, args);

                if (hideList == null) hideList = new List<T>();

                foreach (var item in hideList)
                {
                    item.BeginInit();
                    this.Add(item);
                    item.AfterLoad(LoadInfo);
                    item.EndInit();
                }

                initTableData = false;
                RaiseListChangedEvents = true;
                ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
                this.OnListChanged(arg);

            }
            catch (Exception ex)
            {
               
                throw new Exception(string.Format("LoadDataByWhere加载错误：{0} 异常", ex.Message));
            }

        }


        public void LoadPage(string whereSql,Page page, params object[] args)
        {


            string mainTable = DbContext.GetDbEnityInfo(typeof(T)).MainTableName;
            try
            {

                RaiseListChangedEvents = false;
                initTableData = true;
                this.Clear();
                hideList.Clear();

                hideList = DbContext.LoadDataByPage<T>(whereSql,page, args);

                if (hideList == null) hideList = new List<T>();

                foreach (var item in hideList)
                {
                    item.BeginInit();
                    this.Add(item);
                    item.AfterLoad(LoadInfo);
                    item.EndInit();
                }

                initTableData = false;
                RaiseListChangedEvents = true;
                ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
                this.OnListChanged(arg);

            }
            catch (Exception ex)
            {              
                throw new Exception(string.Format("加载错误：{0} 异常", ex.Message));
            }

        }



        /// <summary>
        /// 通过Sql语句加载数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        public void LoadDataBySql(string sql, params object[] args)
        {

            string mainTable = DbContext.GetDbEnityInfo(typeof(T)).MainTableName;
            try
            {

                RaiseListChangedEvents = false;
                initTableData = true;
                this.Clear();
                hideList.Clear();

                //DbEntityInfo info = DbContext.GetDbEnityInfo(typeof(T));
                hideList = DbContext.LoadDataBySql<T>(sql, args);

                if (hideList == null) hideList = new List<T>();
                foreach (var item in hideList)
                {
                    item.BeginInit();
                    this.Add(item);
                    item.AfterLoad(LoadInfo);
                    item.EndInit();
                }

                initTableData = false;
                RaiseListChangedEvents = true;
                ListChangedEventArgs arg = new ListChangedEventArgs(ListChangedType.Reset, -1);
                this.OnListChanged(arg);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("加载错误：{0} 异常", ex.Message));
            }


        }


    }

}
