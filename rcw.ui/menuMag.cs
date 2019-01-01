using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rcw.Model;
using Rcw.Data;
using System.Windows.Forms;
using System.Data;

namespace Rcw.UI
{
    public class PrivilegeMag
    {

        public static void initSystem()
        {
            Rcw.Data.DbContext.AddDataSource("lg", DbContext.DbType.Oracle, "192.168.36.151", "XGMES", "XGMES", "XGMES");
            DbContext.DefaultDataSourceName = "lg";
            Rcw.Data.DbContext.Create<Rcw.Model.TS_EQUIPMENT>();
            DbContext.Create<TS_USER>();
            DbContext.Create<TS_ROLE>();
            DbContext.Create<TS_USER_ROLE>();
            DbContext.Create<TS_ROLE_FUN>();
            DbContext.Create<TS_USER_FUN>();
            DbContext.Create<TS_Dept>();
            DbContext.Create<TS_MODULE>();

            TS_USER user = new TS_USER();
            user.C_NAME = "管理员";
            user.C_ACCOUNT = "system";
            user.C_PASSWORD = Common.MD5("123456");//密码
            user.N_TYPE = 3;//用户类型（1内部，2新用户,3PCI用户）
            user.N_STATUS = TS_USER.userStatus.正常;//状态(1正常，2，3，4冻结)
            user.C_EMP_ID = "";//系统操作人编号        
            user.C_DEPT = "1";
            user.C_LASTLOGINTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            user.Save();

            var sysUser = TS_USER.GetModel("C_ACCOUNT=@C_ACCOUNT", "system");
            sysUser.C_EMP_ID = sysUser.C_ID;
            sysUser.Save();

            TS_MODULE modNew = new TS_MODULE();
            modNew.C_NAME = "系统管理";
            modNew.C_PARENT_ID = "0";
            modNew.C_ASSEMBLYNAME = "";
            modNew.C_MODULECLASS = "";
            //modNew.C_DISABLE ="1" ;
            modNew.N_IMAGEINDEX = 1;
            //modNew.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew.C_PARENT_ID) + 1;
            modNew.N_ORDER = 1;
            modNew.C_EMP_ID = sysUser.C_ID;
            modNew.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew.C_QUERY_STR = "";
            modNew.Save();

            var sysModule = TS_MODULE.GetModel("main.C_NAME=@C_NAME", "系统管理");

            TS_MODULE modNew1 = new TS_MODULE();
            modNew1.C_NAME = "用户管理";
            modNew1.C_PARENT_ID = sysModule.C_ID;
            modNew1.C_ASSEMBLYNAME = "Rcw.UI.dll";
            modNew1.C_MODULECLASS = "Rcw.UI.FrmDeptUser";
            //modNew1.C_DISABLE = "1";
            modNew1.N_IMAGEINDEX =2;
            modNew1.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew1.C_PARENT_ID) + 1;          
            modNew1.C_EMP_ID = sysUser.C_ID;
            modNew1.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew1.C_QUERY_STR = "";
            modNew1.Save();

            TS_MODULE modNew2 = new TS_MODULE();
            modNew2.C_NAME = "角色管理";
            modNew2.C_PARENT_ID = sysModule.C_ID;
            modNew2.C_ASSEMBLYNAME = "Rcw.UI.dll";
            modNew2.C_MODULECLASS = "Rcw.UI.FrmRole";
            //modNew2.C_DISABLE = "1";
            modNew2.N_IMAGEINDEX = 2;
            modNew2.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew2.C_PARENT_ID) + 1;
            modNew2.C_EMP_ID = sysUser.C_ID;
            modNew2.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew2.C_QUERY_STR = "";
            modNew2.Save();

            TS_MODULE modNew3 = new TS_MODULE();
            modNew3.C_NAME = "模块管理";
            modNew3.C_PARENT_ID = sysModule.C_ID;
            modNew3.C_ASSEMBLYNAME = "Rcw.UI.dll";
            modNew3.C_MODULECLASS = "Rcw.UI.FrmPrivilegeMag";
            //modNew3.C_DISABLE = "1";
            modNew3.N_IMAGEINDEX = 2;
            modNew3.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew3.C_PARENT_ID) + 1;
            modNew3.C_EMP_ID = sysUser.C_ID;
            modNew3.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew3.C_QUERY_STR = "";
            modNew3.Save();

            TS_MODULE modNew4 = new TS_MODULE();
            modNew4.C_NAME = "按钮权限";
            modNew4.C_PARENT_ID = sysModule.C_ID;
            modNew4.C_ASSEMBLYNAME = "Rcw.UI.dll";
            modNew4.C_MODULECLASS = "Rcw.UI.FrmBtnMag";
            //modNew4.C_DISABLE = "1";
            modNew4.N_IMAGEINDEX = 2;
            modNew4.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew4.C_PARENT_ID) + 1;
            modNew4.C_EMP_ID = sysUser.C_ID;
            modNew4.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew4.C_QUERY_STR = "";
            modNew4.Save();

            TS_MODULE modNew5 = new TS_MODULE();
            modNew5.C_NAME = "部门档案";
            modNew5.C_PARENT_ID = sysModule.C_ID;
            modNew5.C_ASSEMBLYNAME = "Rcw.UI.dll";
            modNew5.C_MODULECLASS = "Rcw.UI.FrmDEPT";
            //modNew5.C_DISABLE = "1";
            modNew5.N_IMAGEINDEX = 2;
            modNew5.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew5.C_PARENT_ID) + 1;
            modNew5.C_EMP_ID = sysUser.C_ID;
            modNew5.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew5.C_QUERY_STR = "";
            modNew5.Save();

            TS_MODULE modNew6 = new TS_MODULE();
            modNew6.C_NAME = "设备档案";
            modNew6.C_PARENT_ID = sysModule.C_ID;
            modNew6.C_ASSEMBLYNAME = "Rcw.UI.dll";
            modNew6.C_MODULECLASS = "Rcw.UI.FrmEquip";
            //modNew5.C_DISABLE = "1";
            modNew6.N_IMAGEINDEX = 2;
            modNew6.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew5.C_PARENT_ID) + 1;
            modNew6.C_EMP_ID = sysUser.C_ID;
            modNew6.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
            modNew6.C_QUERY_STR = "";
            modNew6.Save();

            TS_Dept tsDept = new TS_Dept();
            tsDept.C_ID = "1";
            tsDept.C_PARENT_ID = "-1";
            tsDept.C_NAME = "炼钢厂";
            tsDept.C_EMP_ID = sysUser.C_ID;
            tsDept.N_STATUS = 1;
            tsDept.Save();

            TS_EQUIPMENT tsEquip = new TS_EQUIPMENT();
            tsEquip.C_ID = "11";
            tsEquip.C_PARENT_ID = "-1";
            tsEquip.C_PARENT_NAME = "";
            tsEquip.C_FULLNAME = "1#转炉";
            tsEquip.C_NAME = "1#转炉";

            tsEquip.C_EMP_ID = sysUser.C_ID;
            tsEquip.N_STATUS = 1;
            tsEquip.Save();
        }

        /// <summary>
        /// 根据用户ID查询所有权限
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public static List<TS_MODULE> GetPriviledgeByUserID(string userID)
        {
            if (UserInfo.UserAccount == "system")
            {
                return DbContext.LoadDataByWhere<TS_MODULE>();
            }
            return DbContext.LoadDataByWhere<TS_MODULE>("userfun.C_USER_ID=@C_USER_ID", userID);
        }

        /// <summary>
        /// 获得部门根节点数据列表
        /// </summary>
        public static List<TS_Dept> GetDeptRootList()
        {          
            return TS_Dept.GetList("N_STATUS=1 and C_PARENT_ID='-1' order by c_code");
        }

        /// <summary>
		/// 获得部门子节点数据列表
		/// </summary>
		public static List<TS_Dept> GetDeptList()
        {          
            return TS_Dept.GetList("N_STATUS=1  order by c_code");
        }

        /// <summary>
        /// 获得部门根节点数据列表
        /// </summary>
        public static List<TS_EQUIPMENT> GetEquipRootList()
        {
            return TS_EQUIPMENT.GetList("N_STATUS=1 and C_PARENT_ID='-1' order by c_code");
        }

        /// <summary>
		/// 获得部门子节点数据列表
		/// </summary>
		public static List<TS_EQUIPMENT> GetEquipList()
        {
            return TS_EQUIPMENT.GetList("N_STATUS=1  order by c_code");
        }


        /// <summary>
        /// 获取最大部门id
        /// </summary>
        public static string GetMaxId(string c_parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(t.c_id) from ts_dept t where t.c_parent_id='" + c_parent_id + "' ");
            object obj = DbContext.ExecuteScalar(strSql.ToString());

            if (obj == null || Convert.IsDBNull(obj))
            {
                return c_parent_id+"01";
            }
            else
            {
                return (Convert.ToInt64(obj.ToString())+1).ToString();
            }
        }

        /// <summary>
        /// 获取最大部门id
        /// </summary>
        public static string GetEquipMaxId(string c_parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(t.c_id) from ts_equipment t where t.c_parent_id='" + c_parent_id + "' ");
            object obj = DbContext.ExecuteScalar(strSql.ToString());

            if (obj == null || Convert.IsDBNull(obj))
            {
                return c_parent_id + "01";
            }
            else
            {
                return (Convert.ToInt64(obj.ToString()) + 1).ToString();
            }
        }

        /// <summary>
        /// 获取最大部门id
        /// </summary>
        public static string GetEquipParentFullName(string c_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(t.c_fullname) from ts_equipment t where t.c_id='" + c_id + "' ");
            object obj = DbContext.ExecuteScalar(strSql.ToString());

            if (obj == null || Convert.IsDBNull(obj))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 获取部门代码
        /// </summary>
        public static string GetCode(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_code from ts_dept t where t.C_ID='" + C_ID + "' ");

            object obj = DbContext.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 获取子模块的最大顺序号
        /// </summary>
        public static int GetModuleMaxOrder(string c_parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(t.n_order) from TS_MODULE t where t.c_parent_id='" + c_parent_id + "' ");
            object obj = DbContext.ExecuteScalar(strSql.ToString());
            if (obj == null||Convert.IsDBNull(obj))
            {
                return 0;
            }
            return Convert.ToInt16(obj);
        }

        /// <summary>
        /// 获取子部门的最大顺序号
        /// </summary>
        public static int GetDeptMaxOrder(string c_parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(t.n_order) from ts_dept t where t.c_parent_id='" + c_parent_id + "' ");

            object obj = DbContext.ExecuteScalar(strSql.ToString());
            if (obj == null || Convert.IsDBNull(obj))
            {
                return 0;
            }
            return Convert.ToInt16(obj);
        }

        /// <summary>
        /// 设置用户角色  1.删除已有的用户角色关系
        ///2.添加现有的用户角色关系
        /// 3.删除已存在的用户角色权限（用户权限表）
        /// 4.添加新的用户角色权限（用户权限表）
        /// </summary>
        public static void SetUserRole(string strUserID, List<TS_USER_ROLE> userRoleList)
        {
           
            var conn = DbContext.GetDefaultConnection();
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            try
            {
                //删除原有的用户角色
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from TS_USER_ROLE ");
                strSql.Append(" where C_USER_ID=@C_USER_ID ");
                DbContext.ExeSql(trans, strSql.ToString(), strUserID);
                //添加用户角色
                if (userRoleList != null && userRoleList.Count > 0)
                {
                    userRoleList.Update(trans);
                }

                var userFunlist = TS_USER_FUN.GetList("C_USER_ID=@C_USER_ID and N_ADD_TYPE=@N_ADD_TYPE", strUserID, TS_USER_FUN.ADD_TYPE.角色添加);
                //删除原有的通过角色添加的权限
                foreach (var item in userFunlist)
                {
                    item.DataState = DataRowState.Deleted;
                }
                if (userRoleList != null && userRoleList.Count > 0)
                {
                    //将现有的角色的权限赋给当前用户
                    foreach (var item in userRoleList)
                    {
                        var funList = TS_MODULE.GetList("rolefun.C_ROLE_ID=@C_ROLE_ID", item.C_ROLE_ID);
                        foreach (var funItem in funList)
                        {
                            TS_USER_FUN userFun = new TS_USER_FUN();
                            userFun.C_USER_ID = strUserID;
                            userFun.C_MODULE_ID = funItem.C_ID;
                            userFun.C_ROLE_ID = item.C_ROLE_ID;
                            userFun.N_ADD_TYPE = TS_USER_FUN.ADD_TYPE.角色添加;
                            userFunlist.Add(userFun);
                        }
                    }
                }           
                userFunlist.Update(trans);
                trans.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
                throw new Exception(ex.ToString());
            }

        }


        /// <summary>
        /// 保存角色权限
        /// 1.删除原有的角色权限 
        /// 2、插入角色按钮权限
        /// 3.插入角色菜单权限
        /// </summary>
        /// <param name="lstCheckedID">按钮ID集合</param>
        /// <param name="dt">菜单ID集合</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public static void SaveRoleFun(List<string> lstCheckedID, string RoleID)
        {
            var conn = DbContext.GetDefaultConnection();
            conn.Open();
            IDbTransaction trans = conn.BeginTransaction();
            try
            {

                var roleFunList = TS_ROLE_FUN.GetList("C_ROLE_ID=@C_ROLE_ID", RoleID);
                //删除角色的所有权限
                foreach (var item in roleFunList)
                {
                    item.DataState = DataRowState.Deleted;
                }
                //添加角色权限
                foreach (string id in lstCheckedID)
                {
                    TS_ROLE_FUN roleFun = new TS_ROLE_FUN();
                    roleFun.C_MODULE_ID = id;
                    roleFun.C_ROLE_ID = RoleID;              
                    roleFunList.Add(roleFun);                 
                }
                roleFunList.Update(trans);
                //删除用户权限表中，该角色的权限
                DbContext.ExeSql(trans, "delete from TS_USER_FUN where C_ROLE_ID=@C_ROLE_ID", RoleID);
                //查询拥有该角色的用户，为用户添加权限
                List<TS_USER_FUN> userFunList = new List<TS_USER_FUN>();
                var userRoleList = TS_USER_ROLE.GetList("C_ROLE_ID=@C_ROLE_ID", RoleID);
                foreach (var item in userRoleList)
                {
                    foreach (var checkedItem in lstCheckedID)
                    {
                        TS_USER_FUN userFun = new TS_USER_FUN();
                        userFun.C_MODULE_ID = checkedItem;
                        userFun.C_USER_ID = item.C_USER_ID;
                        userFun.C_ROLE_ID = item.C_ROLE_ID;
                        userFun.N_ADD_TYPE = TS_USER_FUN.ADD_TYPE.角色添加;
                        userFunList.Add(userFun);
                    }
                }
                userFunList.Update(trans);
                trans.Commit();
                conn.Close();
               

            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
                throw new Exception(ex.ToString());
            }       
        
        }


        /// <summary>
        /// 保存用户权限
        /// 1.删除原有的用户权限 
        /// 2、插入新的用户权限
        /// </summary>
        /// <param name="lstCheckedID">按钮ID集合</param>
        /// <param name="dt">菜单ID集合</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public static void SaveUserFun(List<string> lstCheckedID, string UserID)
        {
           
            try
            {
                var userFunList = TS_USER_FUN.GetList("C_USER_ID=@C_USER_ID and N_ADD_TYPE=@N_ADD_TYPE", UserID, TS_USER_FUN.ADD_TYPE.用户添加);
                foreach (var item in userFunList)
                {
                    if (lstCheckedID != null)
                    {
                        if (lstCheckedID.Contains(item.C_MODULE_ID))
                        {
                            continue;
                        }
                        else
                        {
                            item.DataState = DataRowState.Deleted;
                        }
                    }
                    else
                    {
                        item.DataState = DataRowState.Deleted;
                    }
                    
                }
                if (lstCheckedID != null)
                {
                    foreach (var item in lstCheckedID)
                    {
                        var data = userFunList.Where(o => o.C_MODULE_ID == item).FirstOrDefault();
                        if (data == null)
                        {
                            TS_USER_FUN userFun = new TS_USER_FUN();
                            userFun.C_MODULE_ID = item;
                            userFun.C_USER_ID = UserID;
                            userFun.N_ADD_TYPE = TS_USER_FUN.ADD_TYPE.用户添加;
                            userFunList.Add(userFun);
                        }
                    }
                }
                                                      
                userFunList.Update();                        

            }
            catch (Exception ex)
            {             
                throw new Exception(ex.ToString());
            }

        }



    }
}
