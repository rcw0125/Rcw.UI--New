using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Rcw.Model;
using Rcw.Data;


namespace Rcw.UI
{
    public partial class Login : Form
    {
      

        public Login()
        {
            //Rcw.Data.DbContext.AddDataSource("CAP", DbContext.DbType.Oracle, "192.168.2.204", "orcl", "XGCAPTEST", "XGCAPTEST");
            //DbContext.DefaultDataSourceName = "CAP";
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txt_Name.Text = "system";
            txt_Pwd.Text = "123456";
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                
                //lambda表达式无法解析自定义的函数（Common.MD5（））
                string ps = Common.MD5(txt_Pwd.Text.Trim());
                TS_USER User = TS_USER.Queryable().
                               Where(o => o.C_ACCOUNT.ToString() == txt_Name.Text.Trim() && o.C_PASSWORD ==ps ).FirstOrDefault();

                if (User != null)
                {
                    if (User.N_STATUS != TS_USER.userStatus.正常)
                    {
                        MessageBox.Show("该账号已经冻结，请联系管理员！");
                        return;
                    }

                    UserInfo.UserID = User.C_ID;
                    UserInfo.UserAccount = User.C_ACCOUNT;
                    UserInfo.UserName = User.C_NAME;
                    //topMenu frm = new topMenu();
                    //frm.Show();
                    toolstripMenu tm = new toolstripMenu();
                    tm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                WaitingFrom.CloseWait();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }     
    }
}
