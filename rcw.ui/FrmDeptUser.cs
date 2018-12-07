using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Rcw.Model;
using Rcw.Data;
using Rcw.Method;
namespace Rcw.UI
{
    public partial class FrmDeptUser : Form
    {
        string name = "";
        string text = "";
        string tag = "";
        /// <summary>
        /// 所有部门列表
        /// </summary>
        List<TS_Dept> childDeptList = null;
        List<TS_USER> userItemList = null;

        public FrmDeptUser()
        {
            InitializeComponent();                 
            tSUSERBindingSource.DataSource = TS_USER.GetList();
            childDeptList = PrivilegeMag.GetDeptList();
            tSDEPTBindingSource.DataSource = childDeptList;
        }
        private void FrmDEPT_Load(object sender, EventArgs e)
        {
            LoadMenu();
            RefreshUserItem();
        }
        public void LoadMenu()
        {
            try
            {
                var dt_root = PrivilegeMag.GetDeptRootList();
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
                FrmUserAdd userAdd = new FrmUserAdd();
                userAdd.strDeptID = tag;
                userAdd.ShowDialog();
                RefreshUserItem();
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
               
                name = treeView1.SelectedNode.Name;
                text = treeView1.SelectedNode.Text;
                tag = treeView1.SelectedNode.Tag.ToString();
                if (!string.IsNullOrEmpty(treeView1.SelectedNode.Name) && !string.IsNullOrEmpty(treeView1.SelectedNode.Tag.ToString()))
                {
                    RefreshUserItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshUserItem()
        {
            string strSql = "";
            if (txtAccountName.Text.Trim() == "")
            {
                strSql = string.Format("C_DEPT like '{0}%' order by C_NAME", tag);
            }
            else
            {
                strSql = string.Format("C_ACCOUNT like '{0}%' order by C_NAME", txtAccountName.Text.Trim());
            }
            userItemList = TS_USER.GetList(strSql);
            gc_User.DataSource = userItemList;
            gv_User.SetMultiSelect();
            gv_User.SetUnEditable();        
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            RefreshUserItem();
        }


        private void btnUnLock_Click(object sender, EventArgs e)
        {
            var userList = TS_USER.GetSelectedRow(gv_User);
            userList.ForEach(o => o.N_STATUS = TS_USER.userStatus.正常);
            userList.Update();
            gv_User.RefreshData();
            gv_User.SetMultiSelect();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            var userList = TS_USER.GetSelectedRow(gv_User);
            userList.ForEach(o=>o.N_STATUS=TS_USER.userStatus.冻结);
            userList.Update();
            gv_User.RefreshData();
            gv_User.SetMultiSelect();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Del_Click(object sender, EventArgs e)
        {
            var userList = TS_USER.GetSelectedRow(gv_User);
            userList.DelList();
            RefreshUserItem();
            gv_User.RefreshData();

        }

        private void btnMoveDept_Click(object sender, EventArgs e)
        {

            FrmDeptSelect ds = new FrmDeptSelect();
            ds.ShowDialog();
            if (ds.strDeptId == "")
            {
                MessageBox.Show("没有选择部门！");
            }
            else
            {
                var userList = TS_USER.GetSelectedRow(gv_User);
                userList.ForEach(o => o.C_DEPT=ds.strDeptId);
                userList.Update();
                RefreshUserItem();
                gv_User.RefreshData();
                gv_User.SetMultiSelect();
                MessageBox.Show("操作成功！");
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            var userList = TS_USER.GetSelectedRow(gv_User);
            if (userList.Count != 1)
            {
                MessageBox.Show("请只选择一条数据");
                return;
            }
            if (UserInfo.UserID == userList[0].C_ID && UserInfo.UserAccount != "system")
            {
                MessageBox.Show("自己不能修改自己角色！");
                return;
            }

            FrmSetRole frm = new FrmSetRole(userList[0].C_ID);
            frm.ShowDialog();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                var userList = TS_USER.GetSelectedRow(gv_User);
                if (userList.Count != 1)
                {
                    MessageBox.Show("请只选择一条数据");
                    return;
                }
                FrmUserAdd userAdd = new FrmUserAdd();
                userAdd.user = userList[0];
                userAdd.ShowDialog();
                RefreshUserItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sbtnUserFunc_Click(object sender, EventArgs e)
        {

            try
            {
                var userList = TS_USER.GetSelectedRow(gv_User);
                if (userList.Count != 1)
                {
                    MessageBox.Show("请只选择一条数据");
                    return;
                }
                FrmRight frm = new FrmRight(userList[0].C_ID, "1");
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}








