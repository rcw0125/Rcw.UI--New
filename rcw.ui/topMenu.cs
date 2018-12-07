using Rcw.Data;
using Rcw.Model;
using Skin.Bars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Rcw.UI
{
    public partial class topMenu : Form
    {
        float fontsize = 13;
        
        /// <summary>
        /// 用户的所有权限(非按钮)
        /// </summary>
        List<TS_MODULE> userResource = null;
        public topMenu()
        {
            InitializeComponent();         
            //就是MDI窗口容器，只有设置了这个属性为True，才可以当作其他的窗口的MDI父窗口！
            this.IsMdiContainer = true;
            loadMenu();
        }
        /// <summary>
        /// 使用DbEntityTable加载菜单
        /// </summary>

        public void loadMenu()
        {
            
           

            try
            {
                var allResouce = PrivilegeMag.GetPriviledgeByUserID(UserInfo.UserID);
                UserInfo.UserResouce = allResouce;
                UserInfo.UserBtn = allResouce.Where(o => o.N_MODULE_TYPE == TS_MODULE.MODULE_TYPE.按钮模块).ToList();
                
                //查询非按钮菜单             
                userResource = allResouce.Where(o => (o.N_MODULE_TYPE == TS_MODULE.MODULE_TYPE.系统模块)).OrderBy(o => o.N_ORDER).ToList();
                UserInfo.UserMenu = userResource;
                //根菜单
                var topMenuList = userResource.Where(o => o.C_PARENT_ID == "0").ToList();
                foreach (var item in topMenuList)
                {
                    ToolStripMenuItem topMenu = new ToolStripMenuItem();
                    topMenu.Name = item.C_MODULECLASS;
                    topMenu.Text = item.C_NAME;
                    topMenu.Tag = item.C_ASSEMBLYNAME;
                    topMenu.Font = new System.Drawing.Font("新宋体", fontsize);
                    //添加根菜单
                    this.menuStrip1.Items.Add(topMenu);
                    /// 计算二级菜单
                    this.CreateChildNodeNew(topMenu, item.C_ID, fontsize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成菜单时出错："+ex.ToString());
            }
            
        }

        /// <summary>
        /// ToolStripMenuItem生成传统经典的菜单
        /// 使用ImageIndex记录窗体的id
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentId"></param>
        /// <param name="fsize"></param>
        private void CreateChildNodeNew(ToolStripMenuItem parentNode, string parentId, float fsize)
        {
            var list = userResource.Where(o => o.C_PARENT_ID == parentId);
            if (fsize > 10)
            {
                fsize = fsize - 1;
            }

            foreach (var item in list)
            {
                ToolStripMenuItem secondMenu = new ToolStripMenuItem();
                secondMenu.Name = item.C_MODULECLASS;
                secondMenu.Text = item.C_NAME;               
                secondMenu.Tag = item.C_ASSEMBLYNAME;
                secondMenu.Font = new System.Drawing.Font("新宋体", fsize);
                parentNode.DropDownItems.Add(secondMenu);

                secondMenu.Click += new EventHandler(ItemClick);

                this.CreateChildNodeNew(secondMenu, item.C_ID.ToString(), fsize);
            }
        }
        /// <summary>
        /// 菜单的点击事件，点击时，记住窗体id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemClick(object sender, EventArgs e)
        {

            if ((((ToolStripMenuItem)sender).Tag.ToString() != "") && ((((ToolStripMenuItem)sender).Name.ToString() != "")))
            {
                //
                // Public.formid = ((ToolStripMenuItem)sender).ImageIndex.ToString();
                WaitingFrom.ShowWait();
                this.OpenOrActiveForm(true, ((ToolStripMenuItem)sender).Name.ToString(), string.Empty, ((ToolStripMenuItem)sender).Text.ToString(), string.Empty, ((ToolStripMenuItem)sender).Tag.ToString());
                WaitingFrom.CloseWait();
            }


        }

        private void OpenOrActiveForm(bool isForm, string name, string subName, string text, string methodNames, string strNameSpace)
        {
            if (isForm)
            {

                try
                {
                    Form frm = null;
                    frm = Activator.CreateInstance(Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory.ToString() + strNameSpace).GetType(name, false)) as Form;
                    if (frm == null)
                    {
                        MessageBox.Show("未找到指定的程序窗体");
                    }
                    else
                    {

                        this.showForm(frm,text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("未找到指定的程序窗体，或注册的类名不正确"+ex.ToString());
                }

            }
        }

        private void showForm(Form fr,string text)
        {

            //if (Application.OpenForms[fr.Name] == null)
            //{

            //    this.CreateFormPanel(fr, text);
            //}
            //else
            //{

            //    this.ToSelect(Application.OpenForms[fr.Name]);
            //}

            if (Application.OpenForms[fr.Name] == null||!formDictory.Contains(text))
            {

                this.CreateFormPanel(fr, text);
            }
            else
            {

                //this.ToSelect(Application.OpenForms[fr.Name]);
                this.ToSelect(text);
            }

        }

        private void ToSelect(string _obj)
        {
            this.superTabControl1.SelectedTab = (SuperTabItem)this.superTabControl1.Tabs["bi_" + _obj];
        }

        List<string> formDictory = new List<string>();
        private void CreateFormPanel(Form _obj,string text)
        {
            _obj.TopLevel = true;
            _obj.FormBorderStyle = FormBorderStyle.None;
            _obj.MdiParent = this;
            _obj.Dock = DockStyle.Fill;
            _obj.FormBorderStyle = FormBorderStyle.None;
            _obj.Text = text;
            Size size = new Size(0x50c, 0x298);
            _obj.Size = size;
            SuperTabItem item = new SuperTabItem
            {
                //Name = "bi_" + _obj.Name,
                //Text = _obj.Text,
                Name = "bi_" + text,
                Text = text,
                TextAlignment = eItemAlignment.Center
            };
            this.superTabControl1.Tabs.Insert(this.superTabControl1.Tabs.Count, item);
            SuperTabControlPanel panel = new SuperTabControlPanel
            {
                //Name = "stcp_" + _obj.Name
                 Name = "stcp_" + text
            };
            this.superTabControl1.CreateTab(item, panel, 0);
            this.superTabControl1.SelectedTab = item;
            panel.Controls.Add(_obj);
            _obj.Show();
            formDictory.Add(text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
