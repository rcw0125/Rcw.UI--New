using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Rcw.Data;
using System.ComponentModel;
using System.Collections;

namespace Rcw.Model
{
	 	//TS_USER_FUN
		
	public class TS_USER_FUN : DbEntity
	{
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
				
		private string _c_module_id;	
		/// <summary>
		/// 菜单表主键
        /// </summary>		
				
		[DisplayName("菜单表主键")]
        public string C_MODULE_ID
        {
            get
            {
            	return _c_module_id; 
            }
            set
            {
                if (_c_module_id != value)
                {
                   _c_module_id = value;
                   RaisePropertyChanged("C_MODULE_ID", true);	                   
                }
            }
        }        
				
		private string _c_user_id;	
		/// <summary>
		/// 用户ID
        /// </summary>		
				
		[DisplayName("用户ID")]
        public string C_USER_ID
        {
            get
            {
            	return _c_user_id; 
            }
            set
            {
                if (_c_user_id != value)
                {
                   _c_user_id = value;
                   RaisePropertyChanged("C_USER_ID", true);	                   
                }
            }
        }


        private string _c_role_id;
        /// <summary>
        /// 角色ID
        /// </summary>		

        [DisplayName("角色ID")]
        public string C_ROLE_ID
        {
            get
            {
                return _c_role_id;
            }
            set
            {
                if (_c_role_id != value)
                {
                    _c_role_id = value;
                    RaisePropertyChanged("C_ROLE_ID", true);
                }
            }
        }


        public enum ADD_TYPE
        {
            角色添加=0,
            用户添加=1

        }
        private ADD_TYPE _n_add_type;
        /// <summary>
        /// 权限添加方式；0-角色添加；1-用户添加
        /// </summary>		

        [DisplayName("权限添加方式；0-角色添加；1-用户添加")]
        public ADD_TYPE N_ADD_TYPE
        {
            get
            {
                return _n_add_type;
            }
            set
            {
                if (_n_add_type != value)
                {
                    _n_add_type = value;
                    RaisePropertyChanged("N_ADD_TYPE", true);
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
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string C_ID)
		{
		    #region  方法
			var List=DbContext.LoadDataByWhere<TS_USER_FUN>("C_ID=@C_ID", C_ID);
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
		        DbContext.ExeSql("delete from TS_USER_FUN where  C_ID=@C_ID", C_ID);			
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
		public static List<TS_USER_FUN> GetList(string whereSql="1=1", params object[] args)
		{
		    return DbContext.LoadDataByWhere<TS_USER_FUN>(whereSql, args);
		}
		/// <summary>
		/// 使用LoadDataByWhere（）获取单表DbEntityTable
		/// </summary>
		public static DbEntityTable<TS_USER_FUN> DbEntityTable(string whereSql="1=1", params object[] args)
		{			
		    #region  方法
			DbEntityTable<TS_USER_FUN>  dbEntityTable=new DbEntityTable<TS_USER_FUN>();
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
		public static TS_USER_FUN GetModel(string C_ID)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_USER_FUN>("C_ID=@C_ID", C_ID);
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
		public static TS_USER_FUN GetModel(string whereSql="1=1", params object[] args)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_USER_FUN>(whereSql,args);
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
		
        
		
		#endregion 扩展方法   
	}
}