using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rcw.Data;
using Rcw.Model;

namespace Rcw.UI
{
    public partial class FrmUserEdit : Form
    {
        private string strUserID = "0";//用户ID   
        private string strDeptID = "0";
        private string strDeptName = "";

        public FrmUserEdit(string str)
        {
            InitializeComponent();

            strUserID = str;
        }

        private void FrmUserEdit_Load(object sender, EventArgs e)
        {
            BindInfo();
        }
        TS_USER mod;
        private void BindInfo()
        {
            try
            {
                mod = TS_USER.GetModel("N_TYPE=3 and  C_ACCOUNT=@C_ACCOUNT", strUserID);
                if (mod != null)
                {
                    txt_UserName.Text = mod.C_NAME;//姓名
                    txt_LoginName.Text = mod.C_ACCOUNT;//登录名
                    txt_Email.Text = mod.C_EMAIL;//邮箱
                    txt_Tel.Text = mod.C_MOBILE;//电话

                    icbo_State.EditValue = mod.N_STATUS.ToString();//状态
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_UserName.Text.Trim()))
                {
                    MessageBox.Show("姓名不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(txt_LoginName.Text.Trim()))
                {
                    MessageBox.Show("账号不能为空！");
                    return;
                }

                //if (string.IsNullOrEmpty(txt_Email.Text.Trim()))
                //{
                //    MessageBox.Show("邮箱不能为空！");
                //    return;
                //}

                //if (string.IsNullOrEmpty(txt_Tel.Text.Trim()))
                //{
                //    MessageBox.Show("电话不能为空！");
                //    return;
                //}

               
                if (mod != null)
                {
                   
                    //mod.N_STATUS = Convert.ToInt32(icbo_State.EditValue);//状态(1正常，2，3，4冻结)
                    mod.C_EMP_ID = UserInfo.UserID;//系统操作人编号
                 
                    mod.Save();

                    if (!string.IsNullOrEmpty(btnEdit_Dept.Text.Trim()))
                    {
                        //BllTS_USER_DEPT bllUserDept = new BllTS_USER_DEPT();

                        //ModTS_USER_DEPT model = bllUserDept.Get_Model(strUserID);
                        //if (model != null)
                        //{
                        //    model.C_DEPT_ID = strDeptID;
                        //    bllUserDept.Update(model);
                        //}
                        //else
                        //{
                        //    model = new ModTS_USER_DEPT();
                        //    model.C_DEPT_ID = strDeptID;
                        //    model.C_USER_ID = strUserID;

                        //    bllUserDept.Add(model);
                        //}
                    }

                    MessageBox.Show("修改成功!");
                    this.Close();

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try
            {

                if (mod != null)
                {
                    mod.C_PASSWORD = Common.MD5("123456");//密码
                    mod.C_EMP_ID = UserInfo.UserID;//系统操作人编号                   
                    mod.Save();
                    MessageBox.Show("密码重置成功!");
                    this.Close();
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Dept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //FrmSetDept frm = new FrmSetDept(strUserID);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    strDeptID = frm.strDeptID;
                //    strDeptName = frm.strDeptName;

                //    btnEdit_Dept.Text = frm.strDeptName;

                //    frm.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
