
using Rcw.Data;
using Rcw.Model;
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
    public partial class FrmBtnMag : Form
    {
        private static string namespaceString = string.Empty;


        float fontsize = 13;     
        /// <summary>
        /// 用户的所有权限
        /// </summary>
        List<TS_MODULE> userResource = null;
        /// <summary>
        /// 用户的所有权限(非按钮)
        /// </summary>
        List<TS_MODULE> menuResource = null;

        /// <summary>
        /// 按钮权限
        /// </summary>
        List<TS_MODULE> btnResource = new List<TS_MODULE> ();

        /// <summary>
        /// 按钮权限（全部）
        /// </summary>
        List<TS_MODULE> btnAllResource = null;
        string tag = "";
        string strParentID = "-1";

        private string moduleClassname = "";
       
        public FrmBtnMag()
        {
            InitializeComponent();
        }
        private void FrmQR_ANQX_Load(object sender, EventArgs e)
        {
            repositoryItemLookUpEdit1.DataSource = TS_USER.GetList();
            btnAllResource = TS_MODULE.GetList("N_MODULE_TYPE=@N_MODULE_TYPE",TS_MODULE.MODULE_TYPE.按钮模块);
            loadMenu();
        }
        public void loadMenu()
        {
            //N_MODULE_TYPE IS '模块类型：1-普通模块;2-系统模块;3-按钮模块'
            //查询非按钮菜单             
            userResource = PrivilegeMag.GetPriviledgeByUserID(UserInfo.UserID);

            menuResource=userResource.Where(o => (o.N_MODULE_TYPE == TS_MODULE.MODULE_TYPE.系统模块)).OrderBy(o => o.N_ORDER).ToList();

            //根菜单
            var topMenuList = menuResource.Where(o=>o.C_PARENT_ID=="0").OrderBy(o => o.N_ORDER).ToList();

            this.treeView1.Nodes.Clear();
            foreach (var item in topMenuList)
            {
                TreeNode node = new TreeNode
                {
                    Name = item.C_MODULECLASS,
                    Text = item.C_NAME,
                    Tag = item.C_ID,
                    //ImageIndex = Convert.ToInt32(item.N_IMAGEINDEX),
                    NodeFont = new System.Drawing.Font("新宋体", fontsize),
                    SelectedImageIndex = Convert.ToInt32(item.N_IMAGEINDEX)
                };
                //添加根菜单
                this.treeView1.Nodes.Add(node);
                //计算二级菜单
                this.CreateChildNodeNew(node, item.C_ID, fontsize);
            }
        }

        /// <summary>
        /// 生成侧边栏菜单
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentId"></param>
        /// <param name="fsize"></param>
        private void CreateChildNodeNew(TreeNode parentNode, string parentId, float fsize)
        {
            var list = menuResource.Where(o => o.C_PARENT_ID == parentId).OrderBy(o=>o.N_ORDER).ToList();
            if (fsize > 10)
            {
                fsize = fsize - 1;
            }
            foreach (var item in list)
            {
                TreeNode node = new TreeNode
                {
                    Name = item.C_MODULECLASS,
                    Text = item.C_NAME,
                    Tag = item.C_ID,
                    ImageIndex = Convert.ToInt32(item.N_IMAGEINDEX),
                    NodeFont = new System.Drawing.Font("新宋体", fsize),
                    SelectedImageIndex = Convert.ToInt32(item.N_IMAGEINDEX)
                };
                parentNode.Nodes.Add(node);
                this.CreateChildNodeNew(node, item.C_ID, fsize);

            }


        }

       
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                TS_MODULE tsMoudle = new TS_MODULE();           
                tsMoudle.C_PARENT_ID = tag;
                tsMoudle.N_ORDER = PrivilegeMag.GetModuleMaxOrder(tsMoudle.C_PARENT_ID) + 1;
                tsMoudle.C_EMP_ID = UserInfo.UserID;
                tsMoudle.C_DISABLE = "1";
                tsMoudle.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.按钮模块;
                tsMoudle.C_ASSEMBLYNAME = lab_Name.Text;
                btnResource.Add(tsMoudle);
                gv_ANXX.RefreshData();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gv_ANXX.GetDataRow(gv_ANXX.FocusedRowHandle);
                if (dr != null)
                {
                    //int a = bllModule.GetUsingCount(dr["C_ID"].ToString());
                    //if (a > 0)
                    //{
                    //    if (MessageBox.Show("这个按钮分配按钮权限时已经使用，是否确认删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    //    {
                    //        bllModule.Delete(dr["C_ID"].ToString());
                    //        bllModule.Delete_UserFunction(dr["C_ID"].ToString());

                    //        gv_ANXX.DeleteRow(gv_ANXX.FocusedRowHandle);
                    //    }
                    //}
                    //else
                    //{
                    //    bllModule.Delete(dr["C_ID"].ToString());
                    //    bllModule.Delete_UserFunction(dr["C_ID"].ToString());

                    //    gv_ANXX.DeleteRow(gv_ANXX.FocusedRowHandle);
                    //}
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
        private void btn_Saves_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (btnResource.Count > 0)
                {
                    if (btnResource.Update())
                    {
                        MessageBox.Show("保存成功！");
                    }
                    
                }
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            moduleClassname = treeView1.SelectedNode.Name;
            string text = treeView1.SelectedNode.Text;
            tag = treeView1.SelectedNode.Tag.ToString();
            lab_Name.Text = text;

            if (!string.IsNullOrEmpty(moduleClassname) && !string.IsNullOrEmpty(treeView1.SelectedNode.Tag.ToString()))
            {
                btn_Add.Enabled = true;
                btn_Save.Enabled = true;
                strParentID = tag;
                RefreshBtnItem();
            }
            else
            {
                btn_Add.Enabled = false;
                btn_Save.Enabled = false;
            }
        }

        public void RefreshBtnItem()
        {
            btnResource = TS_MODULE.GetList("N_MODULE_TYPE=@N_MODULE_TYPE and C_PARENT_ID=@C_PARENT_ID order by N_ORDER",TS_MODULE.MODULE_TYPE.按钮模块, tag);
            this.gc_ANXX.DataSource = btnResource;
            gv_ANXX.BestFitColumns();
            
        }
    }
}








