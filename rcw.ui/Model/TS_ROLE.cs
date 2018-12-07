using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Rcw.Data;
using System.ComponentModel;
namespace Rcw.Model
{
	 	//TS_ROLE
		
	public class TS_ROLE : DbEntity
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
				
		private string _c_role_name;	
		/// <summary>
		/// 角色名称
        /// </summary>		
				
		[DisplayName("角色名称")]
        public string C_ROLE_NAME
        {
            get
            {
            	return _c_role_name; 
            }
            set
            {
                if (_c_role_name != value)
                {
                   _c_role_name = value;
                   RaisePropertyChanged("C_ROLE_NAME", true);	                   
                }
            }
        }        
				
		private N_Status _n_status;	
		/// <summary>
		/// 使用状态   1-可用；0-停用
        /// </summary>		
				
		[DisplayName("使用状态   1-可用；0-停用")]
        public N_Status N_STATUS
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

        public enum N_Status
        {
            停用=0,
            正常=1
        }


        #region  扩展方法

        /// <summary>
        /// 获得角色列表
        /// </summary>
        public static DataTable GetUserRoleList(string strUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TA.C_ID,TA.C_ROLE_NAME,decode((select tb.c_role_id from TS_USER_ROLE tb where tb.n_status=1 and tb.c_user_id='" + strUserID + "' and tb.c_role_id=ta.c_id),'','0','1')as c_checkstate FROM TS_ROLE TA where ta.N_STATUS=1 ");

            return DbContext.GetDataTable(strSql.ToString());
        }

       

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string C_ID)
		{
		    #region  方法
			var List=DbContext.LoadDataByWhere<TS_ROLE>("C_ID=@C_ID", C_ID);
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
		        DbContext.ExeSql("delete from TS_ROLE where  C_ID=@C_ID", C_ID);			
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
		public static List<TS_ROLE> GetList(string whereSql="1=1", params object[] args)
		{
		    return DbContext.LoadDataByWhere<TS_ROLE>(whereSql, args);
		}
		/// <summary>
		/// 使用LoadDataByWhere（）获取单表DbEntityTable
		/// </summary>
		public static DbEntityTable<TS_ROLE> DbEntityTable(string whereSql="1=1", params object[] args)
		{			
		    #region  方法
			DbEntityTable<TS_ROLE>  dbEntityTable=new DbEntityTable<TS_ROLE>();
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
		public static TS_ROLE GetModel(string C_ID)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_ROLE>("C_ID=@C_ID", C_ID);
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
		public static TS_ROLE GetModel(string whereSql="1=1", params object[] args)
		{
		    #region  方法
			var list =DbContext.LoadDataByWhere<TS_ROLE>(whereSql,args);
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
        public static List<TS_ROLE> GetSelectedRow(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            List<TS_ROLE> userList = new List<TS_ROLE>();
            int[] row = gv.GetSelectedRows();

            foreach (var item in row)
            {
                var da = gv.GetRow(item) as TS_ROLE;
                userList.Add(da);
            }
            return userList;
        }


        #endregion 扩展方法   
    }
}