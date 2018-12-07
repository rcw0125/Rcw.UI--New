using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Rcw.Data;
using System.ComponentModel;
namespace Rcw.Model
{
	 	//TS_MODULE
		
        
        [DbTable("TS_USER_FUN","userfun", "userfun.C_MODULE_ID=main.C_ID", JoinType.Left)]
        [DbTable(TableAlias ="main",IsDistinct =true)]
        
	public class TS_MODULE : DbEntity
	{
   		#region  属性    
      			
		private string _c_id;	
		/// <summary>
		/// 模块编码
        /// </summary>		
		[DbTableColumn(IsPrimaryKey = true,IsGuid =true)]		
		[DisplayName("模块编码")]
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
		/// 父模块编码
        /// </summary>		
				
		[DisplayName("父模块编码")]
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
				
		private string _c_name;	
		/// <summary>
		/// 模块名称
        /// </summary>		
				
		[DisplayName("模块名称")]
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
				
		private string _c_assemblyname;
        /// <summary>
        /// 程序集或按钮所在的窗体的名称
        /// </summary>		

        [DisplayName("程序集或按钮所在的窗体的名称")]
        public string C_ASSEMBLYNAME
        {
            get
            {
            	return _c_assemblyname; 
            }
            set
            {
                if (_c_assemblyname != value)
                {
                   _c_assemblyname = value;
                   RaisePropertyChanged("C_ASSEMBLYNAME", true);	                   
                }
            }
        }        
				
		private string _c_moduleclass;
        /// <summary>
        /// 窗体或按钮
        /// </summary>		

        [DisplayName("窗体或按钮")]
        public string C_MODULECLASS
        {
            get
            {
            	return _c_moduleclass; 
            }
            set
            {
                if (_c_moduleclass != value)
                {
                   _c_moduleclass = value;
                   RaisePropertyChanged("C_MODULECLASS", true);	                   
                }
            }
        }        
				
		private string _c_disable;	
		/// <summary>
		/// 是否禁用，0-禁用；1-启用
        /// </summary>		
				
		[DisplayName("是否禁用，0-禁用；1-启用")]
        public string C_DISABLE
        {
            get
            {
            	return _c_disable; 
            }
            set
            {
                if (_c_disable != value)
                {
                   _c_disable = value;
                   RaisePropertyChanged("C_DISABLE", true);	                   
                }
            }
        }        
				
		private decimal _n_order;	
		/// <summary>
		/// 顺序号
        /// </summary>		
				
		[DisplayName("顺序号")]
        public decimal N_ORDER
        {
            get
            {
            	return _n_order; 
            }
            set
            {
                if (_n_order != value)
                {
                   _n_order = value;
                   RaisePropertyChanged("N_ORDER", true);	                   
                }
            }
        }        
				
		private decimal _n_imageindex;	
		/// <summary>
		/// 图片索引
        /// </summary>		
				
		[DisplayName("图片索引")]
        public decimal N_IMAGEINDEX
        {
            get
            {
            	return _n_imageindex; 
            }
            set
            {
                if (_n_imageindex != value)
                {
                   _n_imageindex = value;
                   RaisePropertyChanged("N_IMAGEINDEX", true);	                   
                }
            }
        }

        public enum MODULE_TYPE
        {
            系统模块=0,
            按钮模块=1
        }

        private MODULE_TYPE _n_module_type;
        /// <summary>
        /// 模块类型：0-系统模块;1-按钮模块
        /// </summary>		

        [DisplayName("模块类型：0-系统模块;1-按钮模块")]
        public MODULE_TYPE N_MODULE_TYPE
        {
            get
            {
            	return _n_module_type; 
            }
            set
            {
                if (_n_module_type != value)
                {
                    _n_module_type = value;
                   RaisePropertyChanged("N_MODULE_TYPE", true);	                   
                }
            }
        }        
				
		private string _c_query_str;	
		/// <summary>
		/// 注入参数
        /// </summary>		
				
		[DisplayName("注入参数")]
        public string C_QUERY_STR
        {
            get
            {
            	return _c_query_str; 
            }
            set
            {
                if (_c_query_str != value)
                {
                   _c_query_str = value;
                   RaisePropertyChanged("C_QUERY_STR", true);	                   
                }
            }
        }        
				
		private string _c_remark;	
		/// <summary>
		/// 备注
        /// </summary>		
				
		[DisplayName("备注")]
        public string C_REMARK
        {
            get
            {
            	return _c_remark; 
            }
            set
            {
                if (_c_remark != value)
                {
                   _c_remark = value;
                   RaisePropertyChanged("C_REMARK", true);	                   
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

        #region  扩展方法
        /// <summary>
		/// 获取最大主键
		/// </summary>
        public static int GetMaxID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(C_ID) FROM TS_MODULE where N_MODULE_TYPE <> '3' ");
            object obj = DbContext.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获取最大排序号
        /// </summary>
        public static int GetOrder(string strID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(N_ORDER) FROM TS_MODULE  where C_PARENT_ID=" + strID);
            object obj = DbContext.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string C_ID)
		{
		    #region  方法
			var List=DbContext.LoadDataByWhere<TS_MODULE>("C_ID=@C_ID", C_ID);
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
		/// 删除一条数据
		/// </summary>
		public static bool Delete(string C_ID)
		{
		    
		    #region  方法
			try
		    {
		        DbContext.ExeSql("delete from TS_MODULE where  C_ID=@C_ID", C_ID);			
		    }
		    catch
		    {
		        return false;
		    }
		    return true;
			#endregion 方法
		    
		}

        /// <summary>
		/// 获取用户分配的权限列表
		/// </summary>
		public static DataTable GetUserFunList(string strID)
        {
            string strWhere = " N_FUNCTION_TYPE='2' and C_ROLE_ID='" + strID + "' ";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ta.C_ID,ta.C_MODULE_ID,ta.C_USER_ID,ta.N_FUNCTION_TYPE,ta.D_MOD_DT ");
            strSql.Append(" FROM TS_USER_FUN ta inner join TS_MODULE tb on ta.c_module_id=tb.c_id where tb.c_disable='1' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbContext.GetDataTable(strSql.ToString());
            
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public static List<TS_MODULE> GetList(string whereSql="1=1", params object[] args)
		{
		    return DbContext.LoadDataByWhere<TS_MODULE>(whereSql, args);
		}
		/// <summary>
		/// 使用LoadDataByWhere（）获取单表DbEntityTable
		/// </summary>
		public static DbEntityTable<TS_MODULE> DbEntityTable(string whereSql="1=1", params object[] args)
		{			
		    #region  方法
			DbEntityTable<TS_MODULE>  dbEntityTable=new DbEntityTable<TS_MODULE>();
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
		public static TS_MODULE GetModel(string C_ID)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_MODULE>("main.C_ID=@C_ID", C_ID);
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
		public static TS_MODULE GetModel(string whereSql="1=1", params object[] args)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_MODULE>(whereSql,args);
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

        public static List<TS_MODULE> GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            List<TS_MODULE> userList = new List<TS_MODULE>();
            int[] row = gv.GetSelectedRows();

            foreach (var item in row)
            {
                var da = gv.GetRow(item) as TS_MODULE;
                userList.Add(da);
            }
            return userList;
        }


        #endregion 扩展方法   
    }
}