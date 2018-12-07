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
                //IQueryable<TS_USER> user=null;
                //TS_USER.Where(user, o => o.N_TYPE == 3 && o.C_ACCOUNT=="17318" && o.C_TS.CompareTo("2018-12-03 17:11:44") >0&&o.N_STATUS== TS_USER.userStatus.正常&&o.C_TS.CompareTo("2018-12-08 17:11:44") <0);

                //TS_USER.IQueryable.Where(o => o.N_TYPE == 3 && o.C_ACCOUNT == "17318" && o.C_TS.CompareTo("2018-12-03 17:11:44") > 0 && o.N_STATUS == TS_USER.userStatus.正常 && o.C_TS.CompareTo("2018-12-08 17:11:44") < 0);
                //ModTS_USER modUser = bllUser.GetModel(txt_Name.Text.Trim(), Common.MD5(txt_Pwd.Text.Trim()));
                WaitingFrom.ShowWait();
                //TS_USER User = TS_USER.GetModel("  C_ACCOUNT=@C_ACCOUNT and C_PASSWORD=@C_PASSWORD", txt_Name.Text.Trim(), Common.MD5(txt_Pwd.Text.Trim()));
                string userName = txt_Name.Text.Trim();
                
                string passWord = Common.MD5(txt_Pwd.Text.Trim());
                TS_USER User = TS_USER.IQueryable.
                    Where(o => o.C_ACCOUNT.ToString() == userName && o.C_PASSWORD == passWord.ToString() && o.N_STATUS == TS_USER.userStatus.正常 && o.C_TS.CompareTo("2018-12-03 17:11:44") > 0&&o.ts!=null&&o.ts>System.DateTime.Now.AddDays(-5));
                var data = TS_USER.IQueryable.Where(o => o.ts !=null);
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
                    topMenu frm = new topMenu();
                    frm.Show();
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

        /// <summary>
        /// 工位id翻译成描述
        /// </summary>
        /// <returns></returns>
        //public RepositoryItemImageComboBox GetUserName()
        //{
        //    //var dt = bllUser.GetList().Tables[0];
        //    //var repo = new RepositoryItemImageComboBox();
        //    //foreach (DataRow item in dt.Rows)
        //    //{
        //    //    var list = new ImageComboBoxItem(item["C_NAME"].ToString(), item["C_ACCOUNT"]);
        //    //    repo.Items.Add(list);
        //    //}
        //    //return repo;
        //}
    }
}
