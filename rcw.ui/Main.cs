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

namespace Rcw
{
    public partial class Main : Form
    {
        //DataTable dt;
        float fontsize = 13;
        DbEntityTable<TS_MODULE> moduleResource = new DbEntityTable<TS_MODULE>();
        public Main()
        {
            DbContext.DefaultDataSourceName = "capdb";
            //就是MDI窗口容器，只有设置了这个属性为True，才可以当作其他的窗口的MDI父窗口！
            this.IsMdiContainer = true;
            InitializeComponent();
            //initMenu();
            loadMenu();

        }

        /// <summary>
        /// 使用DbEntityTable加载菜单
        /// </summary>

        public void loadMenu()
        {
            moduleResource.LoadDataByWhere("C_PARENTMODULEID !='0' and C_MODULE_TYPE='1'");


            var test = moduleResource;
            var topMenuList = DbContext.LoadDataByWhere<TS_MODULE>("C_PARENTMODULEID='0'");
            this.treeView1.Nodes.Clear();
            foreach (var item in topMenuList)
            {
                TreeNode node = new TreeNode
                {
                    Name = item.C_MODULECLASS,
                    Text = item.C_MODULENAME,
                    Tag = item.C_ASSEMBLYNAME,
                    ImageIndex = Convert.ToInt32(item.N_IMAGEINDEX),
                    NodeFont = new System.Drawing.Font("新宋体", fontsize, FontStyle.Bold),
                    SelectedImageIndex = Convert.ToInt32(item.N_IMAGEINDEX)
                };
                //添加根菜单
                this.treeView1.Nodes.Add(node);
                //计算二级菜单
                this.CreateChildNodeNew(node, item.C_MODULEID, fontsize);
            }

            foreach (var item in topMenuList)
            {
                ToolStripMenuItem topMenu = new ToolStripMenuItem();
                topMenu.Name = item.C_MODULECLASS;
                topMenu.Text = item.C_MODULENAME;
                topMenu.Tag = item.C_ASSEMBLYNAME;
                topMenu.Font = new System.Drawing.Font("新宋体", fontsize, FontStyle.Bold);
                this.menuStrip1.Items.Add(topMenu);
                this.CreateChildNodeNew(topMenu, item.C_MODULEID, fontsize);
            }




        }
        /// <summary>
        /// 使用datatable加载菜单
        /// </summary>
        //public void initMenu()
        //{
        //    this.dt = DbContext.GetDataTable("select * from TS_MODULE where C_PARENTMODULEID !='0' and C_MODULE_TYPE='1'");
        //    DataTable table = DbContext.GetDataTable("select * from TS_MODULE where C_PARENTMODULEID='0'");
        //    this.treeView1.Nodes.Clear();

        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {

        //        TreeNode node = new TreeNode
        //        {
        //            Name = table.Rows[i]["C_MODULECLASS"].ToString(),
        //            Text = table.Rows[i]["C_MODULENAME"].ToString(),
        //            Tag = table.Rows[i]["C_ASSEMBLYNAME"].ToString(),
        //            ImageIndex = Convert.ToInt32(table.Rows[i]["N_IMAGEINDEX"].ToString()),
        //            NodeFont = new System.Drawing.Font("宋体", fontsize, FontStyle.Bold),
        //            SelectedImageIndex = Convert.ToInt32(table.Rows[i]["N_IMAGEINDEX"].ToString())
        //        };
        //        this.treeView1.Nodes.Add(node);

               
        //        //this.CreateChildNode(node, table.Rows[i]["C_MODULEID"].ToString());
        //        this.CreateChildNode(node, table.Rows[i]["C_MODULEID"].ToString(), fontsize);

              
        //    }

        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {             
        //        ToolStripMenuItem topMenu = new ToolStripMenuItem();
        //        topMenu.Name = table.Rows[i]["C_MODULECLASS"].ToString();
        //        topMenu.Text = table.Rows[i]["C_MODULENAME"].ToString();
        //        topMenu.Tag = table.Rows[i]["C_ASSEMBLYNAME"].ToString();
        //        topMenu.Font = new System.Drawing.Font("宋体", fontsize, FontStyle.Bold);
        //        this.menuStrip1.Items.Add(topMenu);
        //        this.CreateChildNode(topMenu, table.Rows[i]["C_MODULEID"].ToString(), fontsize);
        //    }
        //}

        /// <summary>
        /// 生成侧边栏菜单
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentId"></param>
        /// <param name="fsize"></param>
        private void CreateChildNodeNew(TreeNode parentNode, string parentId, float fsize)
        {         
            var list = moduleResource.Where(o => o.C_PARENTMODULEID == parentId);
            if (fsize > 10)
            {
                fsize = fsize - 1;
            }

            foreach (var item in list)
            {
                TreeNode node = new TreeNode
                {
                    Name = item.C_MODULECLASS,
                    Text = item.C_MODULENAME,
                    Tag = item.C_ASSEMBLYNAME,
                    ImageIndex = Convert.ToInt32(item.N_IMAGEINDEX),
                    NodeFont = new System.Drawing.Font("新宋体", fsize),
                    SelectedImageIndex = Convert.ToInt32(item.N_IMAGEINDEX)
                };
                parentNode.Nodes.Add(node);
                this.CreateChildNodeNew(node, item.C_MODULEID, fsize);

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
            var list = moduleResource.Where(o => o.C_PARENTMODULEID == parentId);
            if (fsize > 10)
            {
                fsize = fsize - 1;
            }

            foreach (var item in list)
            {
                ToolStripMenuItem secondMenu = new ToolStripMenuItem();              
                secondMenu.Name = item.C_MODULECLASS;
                secondMenu.Text = item.C_MODULENAME;
                secondMenu.ImageIndex = Convert.ToInt32(item.C_MODULEID);
                secondMenu.Tag = item.C_ASSEMBLYNAME;
                secondMenu.Font = new System.Drawing.Font("新宋体", fsize);
                parentNode.DropDownItems.Add(secondMenu);

                secondMenu.Click += new EventHandler(ItemClick);

                this.CreateChildNodeNew(secondMenu, item.C_MODULEID.ToString(), fsize);
            }

           
        }
        /// <summary>
        /// 生成侧边栏菜单
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentId"></param>
        /// <param name="fsize"></param>
        //private void CreateChildNode(TreeNode parentNode, string parentId, float fsize)
        //{
        //    EnumerableRowCollection<DataRow> rows = this.dt.AsEnumerable().Where<DataRow>(dt => dt.Field<string>("C_PARENTMODULEID") == parentId);
        //    if (fsize > 10)
        //    {
        //        fsize = fsize - 1;
        //    }

        //    foreach (DataRow row in rows)
        //    {
        //        TreeNode node = new TreeNode
        //        {
        //            Name =  row["C_MODULECLASS"].ToString(),
        //            Text = row["C_MODULENAME"].ToString(),
        //            Tag = row["C_ASSEMBLYNAME"].ToString(),
        //            ImageIndex = Convert.ToInt32(row["N_IMAGEINDEX"].ToString()),
        //            NodeFont = new System.Drawing.Font("宋体", fsize),
        //            SelectedImageIndex = Convert.ToInt32(row["N_IMAGEINDEX"].ToString())
        //        };
        //        parentNode.Nodes.Add(node);


        //        this.CreateChildNode(node, row["C_MODULEID"].ToString(), fsize);
        //    }
        //}

        /// <summary>
        /// ToolStripMenuItem生成传统经典的菜单
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentId"></param>
        /// <param name="fsize"></param>
        //private void CreateChildNode(ToolStripMenuItem parentNode, string parentId, float fsize)
        //{
        //    EnumerableRowCollection<DataRow> rows = this.dt.AsEnumerable().Where<DataRow>(dt => dt.Field<string>("C_PARENTMODULEID") == parentId);
        //    if (fsize > 10)
        //    {
        //        fsize = fsize - 1;
        //    }

        //    foreach (DataRow row in rows)
        //    {
        //        ToolStripMenuItem secondMenu = new ToolStripMenuItem();
        //        secondMenu.Name = row["C_MODULECLASS"].ToString();
        //        secondMenu.Text = row["C_MODULENAME"].ToString();
        //        secondMenu.Tag = row["C_ASSEMBLYNAME"].ToString();
        //        secondMenu.Font = new System.Drawing.Font("宋体", fsize);
        //        parentNode.DropDownItems.Add(secondMenu);

        //        secondMenu.Click += new EventHandler(ItemClick);

        //        this.CreateChildNode(secondMenu, row["C_MODULEID"].ToString(), fsize);
        //    }
        //}

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node.Nodes.Count == 0) && (!string.IsNullOrEmpty(this.treeView1.SelectedNode.Name) && !string.IsNullOrEmpty(this.treeView1.SelectedNode.Tag.ToString())))
            {
                this.OpenOrActiveForm(true, this.treeView1.SelectedNode.Name, string.Empty, this.treeView1.SelectedNode.Text, string.Empty, this.treeView1.SelectedNode.Tag.ToString());
               
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

                        this.showForm(frm);
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }

        private void showForm(Form fr)
        {

            if (Application.OpenForms[fr.Name] == null)
            {

                this.CreateFormPanel(fr, true);
            }
            else
            {

                this.ToSelect(Application.OpenForms[fr.Name]);
            }

        }

        private void ToSelect(Form _obj)
        {
            this.superTabControl1.SelectedTab = (SuperTabItem)this.superTabControl1.Tabs["bi_" + _obj.Name];
        }

        private void CreateFormPanel(Form _obj, bool _inPanel)
        {
            _obj.TopLevel = true;
            _obj.FormBorderStyle = FormBorderStyle.None;
            _obj.MdiParent = this;
            _obj.Dock = DockStyle.Fill;
            _obj.FormBorderStyle = FormBorderStyle.None;
            Size size = new Size(0x50c, 0x298);
            _obj.Size = size;
            SuperTabItem item = new SuperTabItem
            {
                Name = "bi_" + _obj.Name,
                Text = _obj.Text,
                TextAlignment = eItemAlignment.Center
            };
            this.superTabControl1.Tabs.Insert(this.superTabControl1.Tabs.Count, item);
            SuperTabControlPanel panel = new SuperTabControlPanel
            {
                Name = "stcp_" + _obj.Name
            };
            this.superTabControl1.CreateTab(item, panel, 0);
            this.superTabControl1.SelectedTab = item;
            panel.Controls.Add(_obj);
            _obj.Show();
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.IsExpanded)
            {
                e.Node.Collapse();
            }
            else
            {
                e.Node.Expand();
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
                this.OpenOrActiveForm(true, ((ToolStripMenuItem)sender).Name.ToString(), string.Empty, ((ToolStripMenuItem)sender).Text.ToString(), string.Empty, ((ToolStripMenuItem)sender).Tag.ToString());

            }


        }

        private void menuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
