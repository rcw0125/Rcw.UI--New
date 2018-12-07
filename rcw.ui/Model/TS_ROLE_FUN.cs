using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Rcw.Data;
using System.ComponentModel;
using System.Collections;
using static Rcw.Model.TS_MODULE;

namespace Rcw.Model
{
	 	//TS_ROLE_FUN
		
	public class TS_ROLE_FUN : DbEntity
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
        /// 获取权限菜单ID
        /// </summary>
        /// <param name="strID">子节点ID</param>
        /// <returns></returns>
        public static DataTable Get_MenuID(string strID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct t.C_ID,t.n_order FROM TS_MODULE t where t.N_MODULE_TYPE<>'3' START WITH C_ID in (" + strID + ") CONNECT BY PRIOR C_PARENT_ID = C_ID order by t.n_order");

            return DbContext.GetDataTable(strSql.ToString());
        }

      

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string C_ID)
		{
		    #region  方法
			var List=DbContext.LoadDataByWhere<TS_ROLE_FUN>("C_ID=@C_ID", C_ID);
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
		        DbContext.ExeSql("delete from TS_ROLE_FUN where  C_ID=@C_ID", C_ID);			
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
		public static List<TS_ROLE_FUN> GetList(string whereSql="1=1", params object[] args)
		{
		    return DbContext.LoadDataByWhere<TS_ROLE_FUN>(whereSql, args);
		}
		/// <summary>
		/// 使用LoadDataByWhere（）获取单表DbEntityTable
		/// </summary>
		public static DbEntityTable<TS_ROLE_FUN> DbEntityTable(string whereSql="1=1", params object[] args)
		{			
		    #region  方法
			DbEntityTable<TS_ROLE_FUN>  dbEntityTable=new DbEntityTable<TS_ROLE_FUN>();
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
		public static TS_ROLE_FUN GetModel(string C_ID)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_ROLE_FUN>("C_ID=@C_ID", C_ID);
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
		public static TS_ROLE_FUN GetModel(string whereSql="1=1", params object[] args)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_ROLE_FUN>(whereSql,args);
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