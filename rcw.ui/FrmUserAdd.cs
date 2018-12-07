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
    public partial class FrmUserAdd : Form
    {

        public string strDeptID = "1";
        public TS_USER user = null;
        public FrmUserAdd()
        {
            InitializeComponent();
        }

        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                user = new TS_USER();
                user.C_PASSWORD = Common.MD5("123456");//密码              
                //user.N_TYPE = 3;//用户类型（1内部，2新用户,3PCI用户）
                user.N_STATUS = TS_USER.userStatus.正常;//状态(1正常，2，3，4冻结)               
                radioGroup1.SelectedIndex = (int)user.N_STATUS;
                user.C_EMP_ID = UserInfo.UserID;//系统操作人编号              
                user.C_LASTLOGINTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                user.C_DEPT = strDeptID;
            }
            else
            {
                this.Text = "编辑用户";
                txt_LoginName.Enabled = false;
                txt_UserName.Text = user.C_NAME;
                txt_LoginName.Text = user.C_ACCOUNT;
                txt_Tel.Text = user.C_MOBILE;
                radioGroup1.SelectedIndex = (int)user.N_STATUS;

               
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
                else
                {
                    if (txt_LoginName.Enabled)
                    {
                        if (TS_USER.ExistsAccount(txt_LoginName.Text.Trim()))
                        {
                            MessageBox.Show("该账号已存在，不能重复添加！");
                            return;
                        }
                    }                 
                }                
                user.C_NAME = txt_UserName.Text.Trim();//姓名
                user.C_ACCOUNT = txt_LoginName.Text.Trim();//登录名                   
                user.C_MOBILE = txt_Tel.Text.Trim();//电话     
                user.N_STATUS = (TS_USER.userStatus)radioGroup1.SelectedIndex;                        
                user.Save();                  
                MessageBox.Show("操作成功!");
                this.Close();              
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
       
    }
}
