using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Rcw.Data;
using Rcw.Model;
namespace Rcw.UI
{
    public partial class FrmEquipMag : Form
    {
        string name = "";
        string text = "";
        string tag = "";
        List<TS_EQUIPMENT> childDeptList = null;
        List<TS_EQUIPMENT_ITEM> equipItemList = null;
        public FrmEquipMag()
        {
            InitializeComponent();
           
            btn_Edit.Enabled = false;
            tSUSERBindingSource.DataSource = TS_USER.GetList();
        }
        private void FrmDEPT_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }
        public void LoadMenu()
        {
            try
            {
                childDeptList = PrivilegeMag.GetEquipList();

                var dt_root = PrivilegeMag.GetEquipRootList();

                //创建根节点
                this.treeView1.Nodes.Clear();//清空节点

                foreach (var item in dt_root)
                {
                    TreeNode rootNode = new TreeNode();

                    rootNode.Name = item.C_PARENT_ID;
                    rootNode.Text = item.C_NAME;
                    rootNode.Tag = item.C_ID;

                    this.treeView1.Nodes.Add(rootNode);

                    CreateChildNode(rootNode, item.C_ID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateChildNode(TreeNode parentNode, string parentId)
        {
            //找到该节点下的子项（父节点值等于该节点编号）
            var nodes = childDeptList.Where(o => o.C_PARENT_ID == parentId).OrderBy(o => o.C_ID).ToList();
            //创建该节点子节点
            foreach (var item in nodes)
            {
                TreeNode node = new TreeNode();
                node.Name = item.C_PARENT_ID;
                node.Text = item.C_NAME;
                node.Tag = item.C_ID;
                //父节点添加子节点
                parentNode.Nodes.Add(node);
                //调用自身：递归
                CreateChildNode(node, item.C_ID);
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

                TS_EQUIPMENT_ITEM tsDept = new TS_EQUIPMENT_ITEM(); 
                tsDept.C_NAME = "设备";
                tsDept.C_EQUIPMENT_ID = tag;
                tsDept.C_EMP_ID = UserInfo.UserID;              
                tsDept.N_STATUS = 1;
                equipItemList.Add(tsDept);
                gridView1.RefreshData();
        
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
                var item = gridView1.GetFocusedRow() as TS_EQUIPMENT_ITEM;
                if (MessageBox.Show("确认要删除数据" + item.C_NAME + "吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    item.DataState = DataRowState.Deleted;
                    item.Save();
                    equipItemList.Remove(item);
                    gridView1.RefreshData();

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                equipItemList.Update();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
               
                btn_Edit.Enabled = true;
               ;
                name = treeView1.SelectedNode.Name;
                text = treeView1.SelectedNode.Text;
                tag = treeView1.SelectedNode.Tag.ToString();
                if (!string.IsNullOrEmpty(treeView1.SelectedNode.Name) && !string.IsNullOrEmpty(treeView1.SelectedNode.Tag.ToString()))
                {

                    equipItemList = TS_EQUIPMENT_ITEM.GetList("C_EQUIPMENT_ID=@C_EQUIPMENT_ID order by C_ID", tag);
                    gridControl1.DataSource = equipItemList;
                    gridView1.BestFitColumns();                              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }
    }
}








