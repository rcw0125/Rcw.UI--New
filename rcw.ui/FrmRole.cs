using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rcw.Model;
using Rcw.Data;
using Rcw.Method;

namespace Rcw.UI
{
    public partial class FrmRole : Form
    {
        private List<TS_ROLE> roleList = null;
        public FrmRole()
        {
            InitializeComponent();
        }

        private void FrmRole_Load(object sender, EventArgs e)
        {
            UserButtonRight.GetBtnFun(this);
            tSUSERBindingSource.DataSource = TS_USER.GetList();        
            //PrivilegeMag.SetGvUnEditable(gv_Role);
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                string strSql = "1=1";
                if (txt_RoleName.Text.Trim() != "")
                {
                    strSql = "C_ROLE_NAME='"+txt_RoleName.Text.Trim()+"'";
                }
                roleList = TS_ROLE.GetList(strSql);
                gc_Role.DataSource = roleList;
                gv_Role.RefreshData();
                //gv_Role.SetRowColor();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                TS_ROLE newRole = new TS_ROLE();
                newRole.C_EMP_ID = UserInfo.UserID;               
                newRole.N_STATUS = TS_ROLE.N_Status.正常;
                roleList.Add(newRole);
                gv_Role.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Query_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// 权限设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Right_Click(object sender, EventArgs e)
        {
            try
            {
               
                TS_ROLE curRole = gv_Role.GetFocusedRow() as TS_ROLE;

                if (curRole != null)
                {
                    FrmRight frm = new FrmRight(curRole.C_ID, "2");
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var data = TS_ROLE.GetSelectedRow(gv_Role);
            //data.Update();
            roleList.Update();
            Message.Show("成功");
            Message.Show();

            RefreshData();
        }

        private void gv_Role_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var curRole = gv_Role.GetFocusedRow() as TS_ROLE;
            if (curRole.DataState == DataRowState.Added)
            {
                return;
            }
            //var userList = TS_USER.GetList("c_id in (select c_user_id from ts_user_role where c_role_id=@c_role_id) ",curRole.C_ID);
            var userList = TS_USER.Queryable().JoinTable<TS_USER_ROLE>((s1, s2) => s1.C_ID == s2.C_USER_ID, JoinType.Inner)
                           .Where<TS_USER_ROLE>((s1, s2) => s2.C_ROLE_ID == curRole.C_ID).ToList();
            gc_user.DataSource = userList;

        }
    }
}
