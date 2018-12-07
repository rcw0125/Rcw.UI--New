using Rcw.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Rcw.Model
{
    public class TS_Dept : DbEntity
    {
        #region  属性    

        private string _c_id;
        /// <summary>
        /// 主键
        /// </summary>		
        [DbTableColumn(IsPrimaryKey = true)]
        [DisplayName("主键")]
        public string C_ID
        {
            get
            {
                return _c_id;
            }
            set
            {
                if (_c_id != value)
                {
                    _c_id = value;
                    RaisePropertyChanged("C_ID", true);
                }
            }
        }
 
        private string _c_parent_id;
        /// <summary>
        /// 父级编号
        /// </summary>		
        [DisplayName("父级编号")]
        public string C_PARENT_ID
        {
            get
            {
                return _c_parent_id;
            }
            set
            {
                if (_c_parent_id != value)
                {
                    _c_parent_id = value;
                    RaisePropertyChanged("C_PARENT_ID", true);
                }
            }
        }

     

        private string _c_code;
        /// <summary>
        /// 编码
        /// </summary>		

        [DisplayName("编码")]
        public string C_CODE
        {
            get
            {
                return _c_code;
            }
            set
            {
                if (_c_code != value)
                {
                    _c_code = value;
                    RaisePropertyChanged("C_CODE", true);
                }
            }
        }

       


        private string _c_name;
        /// <summary>
        /// 名称
        /// </summary>		
        [DisplayName("名称")]
        public string C_NAME
        {
            get
            {
                return _c_name;
            }
            set
            {
                if (_c_name != value)
                {
                    _c_name = value;
                    RaisePropertyChanged("C_NAME", true);
                }
            }
        }
        private decimal _n_status;
        /// <summary>
        /// 使用状态   1-可用；0-停用
        /// </summary>		

        [DisplayName("使用状态   1-可用；0-停用")]
        public decimal N_STATUS
        {
            get
            {
                return _n_status;
            }
            set
            {
                if (_n_status != value)
                {
                    _n_status = value;
                    RaisePropertyChanged("N_STATUS", true);
                }
            }
        }


        private string _c_emp_id;
        /// <summary>
        /// 维护人
        /// </summary>		
        [DisplayName("维护人")]
        public string C_EMP_ID
        {
            get
            {
                return _c_emp_id;
            }
            set
            {
                if (_c_emp_id != value)
                {
                    _c_emp_id = value;
                    RaisePropertyChanged("C_EMP_ID", true);
                }
            }
        }



        private string _c_ts;
        /// <summary>
        /// 维护时间
        /// </summary>		
        [DbTableColumn(IsSysDateString =true)]
        [DisplayName("录入时间")]
        public string C_TS
        {
            get
            {
                return _c_ts;
            }
            set
            {
                if (_c_ts != value)
                {
                    _c_ts = value;
                    RaisePropertyChanged("C_TS", true);
                }
            }
        }

        #endregion 属性


        /// <summary>
		/// 获取数据列表
		/// </summary>
		public static List<TS_Dept> GetList(string whereSql = "1=1", params object[] args)
        {
            return DbContext.LoadDataByWhere<TS_Dept>(whereSql, args);
        }

      
    }
}
