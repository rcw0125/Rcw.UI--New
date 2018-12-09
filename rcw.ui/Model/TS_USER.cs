using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Rcw.Data;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Linq;

namespace Rcw.Model
{
    //TS_USER

    public class TS_USER : DbEntity
    {
        public DateTime ts
        { get; set; }
       
   		#region  属性    
      			
		private string _c_id;	
		/// <summary>
		/// 主键
        /// </summary>		
		[DbTableColumn(IsPrimaryKey = true,IsGuid =true)]		
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

        private string _c_dept;
        /// <summary>
        /// 部门
        /// </summary>		

        [DisplayName("部门")]
        public string C_DEPT
        {
            get
            {
                return _c_dept;
            }
            set
            {
                if (_c_dept != value)
                {
                    _c_dept = value;
                    RaisePropertyChanged("C_DEPT", true);
                }
            }
        }

        private string _c_account;	
		/// <summary>
		/// 用户名
        /// </summary>		
				
		[DisplayName("用户名")]
        public string C_ACCOUNT
        {
            get
            {
            	return _c_account; 
            }
            set
            {
                if (_c_account != value)
                {
                   _c_account = value;
                   RaisePropertyChanged("C_ACCOUNT", true);	                   
                }
            }
        }        
				
		private string _c_password;	
		/// <summary>
		/// 密码
        /// </summary>		
				
		[DisplayName("密码")]
        public string C_PASSWORD
        {
            get
            {
            	return _c_password; 
            }
            set
            {
                if (_c_password != value)
                {
                   _c_password = value;
                   RaisePropertyChanged("C_PASSWORD", true);	                   
                }
            }
        }        
				
		private string _c_email;	
		/// <summary>
		/// 邮箱
        /// </summary>		
				
		[DisplayName("邮箱")]
        public string C_EMAIL
        {
            get
            {
            	return _c_email; 
            }
            set
            {
                if (_c_email != value)
                {
                   _c_email = value;
                   RaisePropertyChanged("C_EMAIL", true);	                   
                }
            }
        }        
				
		private string _c_mobile;	
		/// <summary>
		/// 手机
        /// </summary>		
				
		[DisplayName("手机")]
        public string C_MOBILE
        {
            get
            {
            	return _c_mobile; 
            }
            set
            {
                if (_c_mobile != value)
                {
                   _c_mobile = value;
                   RaisePropertyChanged("C_MOBILE", true);	                   
                }
            }
        }        
				
		private decimal _n_type;	
		/// <summary>
		/// 用户类型（1内部，2新用户,3PCI用户）
        /// </summary>		
				
		[DisplayName("用户类型（1内部，2新用户,3PCI用户）")]
        public decimal N_TYPE
        {
            get
            {
            	return _n_type; 
            }
            set
            {
                if (_n_type != value)
                {
                   _n_type = value;
                   RaisePropertyChanged("N_TYPE", true);	                   
                }
            }
        }        
				
		private userStatus _n_status;	
		/// <summary>
		/// 状态(1正常，2，3，4冻结)
        /// </summary>		
				
		[DisplayName("状态(1正常，2，3，4冻结)")]
        public userStatus N_STATUS
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
				
		private string _c_desc;	
		/// <summary>
		/// 描述
        /// </summary>		
				
		[DisplayName("描述")]
        public string C_DESC
        {
            get
            {
            	return _c_desc; 
            }
            set
            {
                if (_c_desc != value)
                {
                   _c_desc = value;
                   RaisePropertyChanged("C_DESC", true);	                   
                }
            }


        }        
				
		private string _c_lastlogintime;	
		/// <summary>
		/// 最后登陆时间
        /// </summary>		
				
		[DisplayName("最后登陆时间")]
        public string C_LASTLOGINTIME
        {
            get
            {
            	return _c_lastlogintime; 
            }
            set
            {
                if (_c_lastlogintime != value)
                {
                    _c_lastlogintime = value;
                   RaisePropertyChanged("C_LASTLOGINTIME", true);	                   
                }
            }
        }        
				
		private string _c_emp_id;	
		/// <summary>
		/// 系统操作人编号
        /// </summary>		
				
		[DisplayName("系统操作人编号")]
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

        private string _c_mobile2;	
		/// <summary>
		/// 手机2
        /// </summary>		
				
		[DisplayName("手机2")]
        public string C_MOBILE2
        {
            get
            {
            	return _c_mobile2; 
            }
            set
            {
                if (_c_mobile2 != value)
                {
                   _c_mobile2 = value;
                   RaisePropertyChanged("C_MOBILE2", true);	                   
                }
            }
        }        
				
		private string _c_phone;	
		/// <summary>
		/// 座机
        /// </summary>		
				
		[DisplayName("座机")]
        public string C_PHONE
        {
            get
            {
            	return _c_phone; 
            }
            set
            {
                if (_c_phone != value)
                {
                   _c_phone = value;
                   RaisePropertyChanged("C_PHONE", true);	                   
                }
            }
        }        
				
		private string _c_shortname;	
		/// <summary>
		/// 短名称
        /// </summary>		
				
		[DisplayName("短名称")]
        public string C_SHORTNAME
        {
            get
            {
            	return _c_shortname; 
            }
            set
            {
                if (_c_shortname != value)
                {
                   _c_shortname = value;
                   RaisePropertyChanged("C_SHORTNAME", true);	                   
                }
            }
        }        
				
		private string _c_cust_id;	
		/// <summary>
		/// 客户档案ID -NC
        /// </summary>		
				
		[DisplayName("客户档案ID -NC")]
        public string C_CUST_ID
        {
            get
            {
            	return _c_cust_id; 
            }
            set
            {
                if (_c_cust_id != value)
                {
                   _c_cust_id = value;
                   RaisePropertyChanged("C_CUST_ID", true);	                   
                }
            }
        }        
				
		private string _c_token_id;	
		/// <summary>
		/// TOKEN_ID
        /// </summary>		
				
		[DisplayName("TOKEN_ID")]
        public string C_TOKEN_ID
        {
            get
            {
            	return _c_token_id; 
            }
            set
            {
                if (_c_token_id != value)
                {
                   _c_token_id = value;
                   RaisePropertyChanged("C_TOKEN_ID", true);	                   
                }
            }
        }        
				
		private string _c_cjname;	
		/// <summary>
		/// 厂家名称
        /// </summary>		
				
		[DisplayName("厂家名称")]
        public string C_CJNAME
        {
            get
            {
            	return _c_cjname; 
            }
            set
            {
                if (_c_cjname != value)
                {
                   _c_cjname = value;
                   RaisePropertyChanged("C_CJNAME", true);	                   
                }
            }
        }        
				
		private string _c_cjintro;	
		/// <summary>
		/// 厂家简介
        /// </summary>		
				
		[DisplayName("厂家简介")]
        public string C_CJINTRO
        {
            get
            {
            	return _c_cjintro; 
            }
            set
            {
                if (_c_cjintro != value)
                {
                   _c_cjintro = value;
                   RaisePropertyChanged("C_CJINTRO", true);	                   
                }
            }
        }        
				
		private string _c_stl_grd;	
		/// <summary>
		/// 使用钢种
        /// </summary>		
				
		[DisplayName("使用钢种")]
        public string C_STL_GRD
        {
            get
            {
            	return _c_stl_grd; 
            }
            set
            {
                if (_c_stl_grd != value)
                {
                   _c_stl_grd = value;
                   RaisePropertyChanged("C_STL_GRD", true);	                   
                }
            }
        }        
				
		private string _c_legalrepres;	
		/// <summary>
		/// 法人代表
        /// </summary>		
				
		[DisplayName("法人代表")]
        public string C_LEGALREPRES
        {
            get
            {
            	return _c_legalrepres; 
            }
            set
            {
                if (_c_legalrepres != value)
                {
                   _c_legalrepres = value;
                   RaisePropertyChanged("C_LEGALREPRES", true);	                   
                }
            }
        }        
				
		private string _c_cgjcr;	
		/// <summary>
		/// 采购决策人员姓名
        /// </summary>		
				
		[DisplayName("采购决策人员姓名")]
        public string C_CGJCR
        {
            get
            {
            	return _c_cgjcr; 
            }
            set
            {
                if (_c_cgjcr != value)
                {
                   _c_cgjcr = value;
                   RaisePropertyChanged("C_CGJCR", true);	                   
                }
            }
        }        
				
		private string _c_job;	
		/// <summary>
		/// 采购决策人员姓名职务
        /// </summary>		
				
		[DisplayName("采购决策人员姓名职务")]
        public string C_JOB
        {
            get
            {
            	return _c_job; 
            }
            set
            {
                if (_c_job != value)
                {
                   _c_job = value;
                   RaisePropertyChanged("C_JOB", true);	                   
                }
            }
        }        
				
		private string _c_jctel;	
		/// <summary>
		/// 采购决策人员电话
        /// </summary>		
				
		[DisplayName("采购决策人员电话")]
        public string C_JCTEL
        {
            get
            {
            	return _c_jctel; 
            }
            set
            {
                if (_c_jctel != value)
                {
                   _c_jctel = value;
                   RaisePropertyChanged("C_JCTEL", true);	                   
                }
            }
        }        
				
		private string _c_address;	
		/// <summary>
		/// 具体地址
        /// </summary>		
				
		[DisplayName("具体地址")]
        public string C_ADDRESS
        {
            get
            {
            	return _c_address; 
            }
            set
            {
                if (_c_address != value)
                {
                   _c_address = value;
                   RaisePropertyChanged("C_ADDRESS", true);	                   
                }
            }
        }        
				
		private string _c_area;	
		/// <summary>
		/// 区域
        /// </summary>		
				
		[DisplayName("区域")]
        public string C_AREA
        {
            get
            {
            	return _c_area; 
            }
            set
            {
                if (_c_area != value)
                {
                   _c_area = value;
                   RaisePropertyChanged("C_AREA", true);	                   
                }
            }
        }        
				
		private string _c_manager;	
		/// <summary>
		/// 客户经理
        /// </summary>		
				
		[DisplayName("客户经理")]
        public string C_MANAGER
        {
            get
            {
            	return _c_manager; 
            }
            set
            {
                if (_c_manager != value)
                {
                   _c_manager = value;
                   RaisePropertyChanged("C_MANAGER", true);	                   
                }
            }
        }

        #endregion 属性


        //状态(1正常，2，3，4冻结)
        public enum userStatus
        {
            正常=0,
            冻结=1           
        }

        public static IQueryable<TS_USER> IQueryable = null;
        public static Rcw.Data.Queryable<TS_USER> Queryable = null;

        public static void Where( IQueryable<TS_USER> queryable, Expression<Func<TS_USER, bool>> expression)
        {
            string whereSql = expression.Body.ToString();          
            string para = expression.Parameters[0].Name+".";
            whereSql=whereSql.Replace(para, "").Replace("==","=");
            whereSql = whereSql.Replace("AndAlso", "And").Replace("\"", "'");
            whereSql = whereSql.Replace("OrElse", "Or").Replace("\"", "'");
            whereSql = whereSql.Replace("Convert", "");
            whereSql =CheckSql(whereSql);
            whereSql = CheckSql(whereSql);

            var data= DbContext.LoadDataByWhere<TS_USER>(whereSql);

        }

        /// <summary>
        /// lambda表达式中出现字符串比较时（CompareTo），的处理方法
        /// </summary>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        public static string CheckSql(string whereSql)
        {
            if (whereSql.Contains("CompareTo"))
            {
                string subComPare = whereSql.Substring(whereSql.IndexOf(".CompareTo"));
                string subExp = subComPare.Substring(0, subComPare.IndexOf("))"));
                if (subExp.Contains(">="))
                {
                    string temp = subExp.Replace(".CompareTo", ">=");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains("<="))
                {
                    string temp = subExp.Replace(".CompareTo", "<=");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains(">"))
                {
                    string temp = subExp.Replace(".CompareTo", ">");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
                else if (subExp.Contains("<"))
                {
                    string temp = subExp.Replace(".CompareTo", "<");
                    temp = temp.Substring(0, temp.IndexOf(")") + 1);
                    whereSql = whereSql.Replace(subExp, temp);
                }
            }
            return whereSql;
        }

        #region  扩展方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string C_ID)
		{
		    #region  方法
			var List=DbContext.LoadDataByWhere<TS_USER>("C_ID=@C_ID", C_ID);
		    if(List.Count>0)
		    {
		         return true;
		    }
		    else
		    {
		         return false;
		    }
			#endregion 方法
		}

        /// <summary>
		/// 是否存在该账号
		/// </summary>
		public static bool ExistsAccount(string C_ACCOUNT)
        {
            #region  方法
            var List = DbContext.LoadDataByWhere<TS_USER>("C_ACCOUNT=@C_ACCOUNT", C_ACCOUNT);
            if (List.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion 方法
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(string C_ID)
		{
		    
		    #region  方法
			try
		    {
		        DbContext.ExeSql("delete from TS_USER where  C_ID=@C_ID", C_ID);			
		    }
		    catch
		    {
		        return false;
		    }
		    return true;
			#endregion 方法
		    
		}
		/// <summary>
		/// 获取数据列表
		/// </summary>
		public static List<TS_USER> GetList(string whereSql="1=1", params object[] args)
		{
		    return DbContext.LoadDataByWhere<TS_USER>(whereSql, args);
		}
		/// <summary>
		/// 使用LoadDataByWhere（）获取单表DbEntityTable
		/// </summary>
		public static DbEntityTable<TS_USER> DbEntityTable(string whereSql="1=1", params object[] args)
		{			
		    #region  方法
			DbEntityTable<TS_USER>  dbEntityTable=new DbEntityTable<TS_USER>();
			try
			{
			    dbEntityTable.LoadDataByWhere(whereSql,args);				
			}
			catch
			{
				return null;
			}				
		    return dbEntityTable;
			#endregion 方法
		}
		/// <summary>
		/// 根据主键ID获取实体模型
		/// </summary>
		public static TS_USER GetModel(string C_ID)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_USER>("C_ID=@C_ID", C_ID);
		    if(list.Count>0)
		    {
		        return list[0];
		    }
		    else
		    {
		        return null;
		    }
			#endregion 方法
		    
		}
		/// <summary>
		/// 根据条件获取实体模型
		/// </summary>
		public static TS_USER GetModel(string whereSql="1=1", params object[] args)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_USER>(whereSql,args);
		    if(list.Count>0)
		    {
		        return list[0];
		    }
		    else
		    {
		        return null;
		    }
			#endregion 方法
		    
		}
		     

        public static List<TS_USER> GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView gv) 
        {
            List<TS_USER> userList = new List<TS_USER>();
            int[] row = gv.GetSelectedRows();

            foreach (var item in row)
            {
                var da = gv.GetRow(item) as TS_USER;
                userList.Add(da);
            }
            return userList;
        }

        #endregion 扩展方法   
    }
}