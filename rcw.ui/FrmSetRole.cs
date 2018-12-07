using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rcw.Model;

namespace Rcw.UI
{
    public partial class FrmSetRole : Form
    {
        //private BllTS_ROLE bllRole = new BllTS_ROLE();
        //private BllTS_USER_ROLE bllUserRole = new BllTS_USER_ROLE();

        private string strUserID = "0";
        public FrmSetRole(string str)
        {
            InitializeComponent();

            strUserID = str;
        }

        private void FrmSetRole_Load(object sender, EventArgs e)
        {
            BindRole();
        }

        /// <summary>
        /// 绑定角色列表
        /// </summary>
        private void BindRole()
        {
            try
            {
                DataTable dt = TS_ROLE.GetUserRoleList(strUserID);
                gc_Role.DataSource = dt;
                gv_Role.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = gc_Role.DataSource as DataTable;

                string strRoleID = string.Empty;

                if (dt.Rows.Count > 0)
                {                                                       
                    List<TS_USER_ROLE> userRoleList = new List<TS_USER_ROLE>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["C_CHECKSTATE"].ToString() == "1")
                        {
                            string strID = dt.Rows[i]["C_ID"].ToString();
                            TS_USER_ROLE mod = new TS_USER_ROLE();
                            mod.C_ROLE_ID = strID;
                            mod.C_USER_ID = strUserID;
                            mod.N_STATUS = 1;
                            mod.C_EMP_ID = UserInfo.UserID;
                            userRoleList.Add(mod);
                           // strRoleID += "'" + strID + "',";
                        }
                    }
                    if (userRoleList.Count > 0)
                    {
                        PrivilegeMag.SetUserRole(strUserID, userRoleList);
                        MessageBox.Show("角色分配成功！");
                    }
                    else
                    {
                        PrivilegeMag.SetUserRole(strUserID, null);
                        MessageBox.Show("当前用户的角色已删除");
                    }                 
                }
                else
                {                 
                    MessageBox.Show("没有角色可选");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("角色分配失败，请重新分配！"+ ex.ToString());
            }
        }
    }
}
