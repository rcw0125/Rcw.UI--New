using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rcw.Model;

namespace Rcw.UI
{
    public partial class FrmRight : Form
    {
        private DataTable dt = null;

        private List<TS_MODULE> listModule = null;
        private List<TS_MODULE> roleFunList = null;
        private List<TS_USER_FUN> listUserFun = null;
        private string strID = "0";
        private string strType = "1";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="str">用户id或角色id</param>
        /// <param name="stype">用户添加方式或角色添加</param>
        public FrmRight(string str, string stype)
        {
            InitializeComponent();

            strID = str;
            strType = stype;
        }

        private void FrmRight_Load(object sender, EventArgs e)
        {
            //BindTreeList();
        }

        public void BindTreeList()
        {
            try
            {
                tl_Module.ClearNodes();
                string strSql = " 1=1";
                if (checkEdit1.Checked)
                {
                    strSql += " and N_MODULE_TYPE=0";
                }
                strSql += " and C_DISABLE='1' order by N_ORDER asc";
                listModule = TS_MODULE.GetList(strSql);
              
                tl_Module.KeyFieldName = "C_ID";//主键名称  
                tl_Module.ParentFieldName = "C_PARENT_ID";//父级ID 

                bscTSMODULE.DataSource = listModule;

                tl_Module.DataSource = bscTSMODULE;//数据源

                //tl_Module.DataSource = dt;//数据源

                BindRight();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载已有的权限
        /// </summary>
        private void BindRight()
        {
            try
            {
                if (tl_Module.Nodes.Count > 0)
                {
                    if (strType == "1")//用户权限
                    {
                        //获取用户的分配的权限 界面权限选择 勾选一次 
                        listUserFun = TS_USER_FUN.GetList("C_USER_ID=@C_USER_ID", strID);
                        foreach (var item in listUserFun)
                        {
                            TreeListNode node = tl_Module.FindNodeByKeyID(item.C_MODULE_ID);
                            if (node != null)
                            {
                                if (!node.Checked)
                                {
                                    node.CheckState = CheckState.Checked;
                                    SetCheckedParentNodes(node, node.CheckState);
                                }
                            }
                        }                    

                    }
                    else if (strType == "2")//角色权限
                    {
                        roleFunList = TS_MODULE.GetList("  userfun.C_ROLE_ID='" + strID + "' ");
                        foreach (var item in roleFunList)
                        {
                            TreeListNode node = tl_Module.FindNodeByKeyID(item.C_ID);
                            if (node != null)
                            {
                                if (!node.Checked)
                                {
                                    node.CheckState = CheckState.Checked;
                                    SetCheckedParentNodes(node, node.CheckState);
                                }
                            }
                            
                        }
          
                    }
                }
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BindTreeList();
           
        }



        #region 节点选中前事件  
        private void tl_Module_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (e.PrevState == CheckState.Checked)
            {
                e.State = CheckState.Unchecked;
            }
            else
            {
                e.State = CheckState.Checked;
            }
        }
        #endregion

        #region 节点选中后事件  
        private void tl_Module_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
        #endregion

        #region 设置子节点状态  
        private void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        #endregion

        #region 设置父节点状态  
        private void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                if (b)
                {
                    node.ParentNode.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    node.ParentNode.CheckState = check;
                }
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        #endregion

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.lstCheckedID.Clear();

                if (tl_Module.Nodes.Count > 0)
                {
                    foreach (TreeListNode root in tl_Module.Nodes)
                    {
                        //控件状态是选中或不确定状态时，添加该菜单权限
                        if (root.CheckState == CheckState.Checked||root.CheckState==CheckState.Indeterminate)
                        {
                            TS_MODULE curModule = tl_Module.GetDataRecordByNode(root) as TS_MODULE;
                            if (curModule != null)
                            {                               
                                lstCheckedID.Add(curModule.C_ID);
                            }
                        }
                        GetCheckedID(root);
                    }
                }

                string idStr = string.Empty;
                
                List<string> listTemp = new List<string>();
                foreach (string id in lstCheckedID)
                {
                    if (strType == "1")
                    {
                        //角色功能中已有的不在添加
                        var data = listUserFun.Where(o => o.C_MODULE_ID == id&&o.N_ADD_TYPE== TS_USER_FUN.ADD_TYPE.角色添加).FirstOrDefault();
                        if (data == null)
                        {
                            listTemp.Add(id);
                        }                      
                    }               
                }

                if (strType == "1")//用户权限
                {
                    PrivilegeMag.SaveUserFun(listTemp, strID);
                    MessageBox.Show("权限分配成功！");
                    this.Close();
                }
                else if (strType == "2")//角色权限
                {
                    PrivilegeMag.SaveRoleFun(lstCheckedID, strID);
                    MessageBox.Show("权限分配成功！");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<string> lstCheckedID = new List<string>();

        /// <summary>
        /// 获取选择状态的数据主键ID集合
        /// </summary>
        /// <param name="parentNode">父级节点</param>
        private void GetCheckedID(TreeListNode parentNode)
        {
            if (parentNode.Nodes.Count == 0)
            {
                return;//递归终止
            }

            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.CheckState == CheckState.Checked||node.CheckState== CheckState.Indeterminate)
                {                 
                        TS_MODULE curModule = tl_Module.GetDataRecordByNode(node) as TS_MODULE;
                        if (curModule != null)
                        {
                            lstCheckedID.Add(curModule.C_ID);
                        }              
                }

                GetCheckedID(node);

            }
        }    
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            BindTreeList();
        }

        private void FrmRight_Shown(object sender, EventArgs e)
        {
            BindTreeList();
        }
    }
}
