using Rcw.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Rcw.Model
{
    public class TS_EQUIPMENT_ITEM:DbEntity
    {
        #region  属性    

        private string _c_id;
        /// <summary>
        /// 主键
        /// </summary>		
        [DbTableColumn(IsPrimaryKey = true,IsGuid =true)]
        [DisplayName("编码")]
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

        private string _c_equipment_id;
        /// <summary>
        /// 设备区域主键
        /// </summary>		
        [DisplayName("设备区域主键")]
        public string C_EQUIPMENT_ID
        {
            get
            {
                return _c_equipment_id;
            }
            set
            {
                if (_c_equipment_id != value)
                {
                    _c_equipment_id = value;
                    RaisePropertyChanged("C_EQUIPMENT_ID", true);
                }
            }
        }

        //private string _c_equipment_name;
        ///// <summary>
        ///// 设备区域主键
        ///// </summary>		
        //[DisplayName("设备区域名称")]
        //public string C_EQUIPMENT_NAME
        //{
        //    get
        //    {
        //        return _c_equipment_name;
        //    }
        //    set
        //    {
        //        if (_c_equipment_name != value)
        //        {
        //            _c_equipment_name = value;
        //            RaisePropertyChanged("C_EQUIPMENT_NAME", true);
        //        }
        //    }
        //}

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

        private string _c_nc_code;
        /// <summary>
        /// NC编码
        /// </summary>		
        [DisplayName("NC 编码")]
        public string C_NC_CODE
        {
            get
            {
                return _c_nc_code;
            }
            set
            {
                if (_c_nc_code != value)
                {
                    _c_nc_code = value;
                    RaisePropertyChanged("C_NC_CODE", true);
                }
            }
        }

        //private string _c_fullname;
        ///// <summary>
        ///// 全名
        ///// </summary>		
        //[DisplayName("全名")]
        //public string C_FULLNAME
        //{
        //    get
        //    {
        //        return _c_fullname;
        //    }
        //    set
        //    {
        //        if (_c_fullname != value)
        //        {
        //            _c_fullname = value;
        //            RaisePropertyChanged("C_FULLNAME", true);
        //        }
        //    }
        //}
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

        public enum sbfj
        {
            全部=0,
            A级=1,
            B级 = 2,
            C级 = 3
        }
        public sbfj _grade;
        /// <summary>
        /// 设备等级
        /// </summary>
        [DisplayName("设备等级：全部=0,A级=1,B级 = 2, C级 = 3")]
        public sbfj GRADE
        {
            get
            {
                return _grade;
            }
            set
            {
                if (_grade != value)
                {
                    _grade = value;
                    RaisePropertyChanged("GRADE", true);
                }
            }
        }

        public enum bigclass
        {
            全部=0,
            机械 = 1,
            电气 = 2,
            液压 = 3,
            仪表 = 4,
            消防 = 5,
            网络 = 6,
            空调 = 7,
            视频 = 8,
            软件 = 9
        }

        public bigclass _bigclass;

        /// <summary>
        /// 设备等级
        /// </summary>
        [DisplayName("设备大类：全部=0,机械 = 1,电气 = 2, 液压 = 3,仪表 = 4,消防 = 5,网络 = 6,空调 = 7,视频 = 8,软件 = 9")]
        public bigclass BIGCLASS
        {
            get
            {
                return _bigclass;
            }
            set
            {
                if (_bigclass != value)
                {
                    _bigclass = value;
                    RaisePropertyChanged("BIGCLASS", true);
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
        [DbTableColumn(IsSysDateString = true)]
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

        public static List<TS_EQUIPMENT_ITEM> GetList(string whereSql = "1=1", params object[] args)
        {
            return DbContext.LoadDataByWhere<TS_EQUIPMENT_ITEM>(whereSql, args);
        }

    }
}
