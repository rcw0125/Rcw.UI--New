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
    public partial class FrmPrivilegeMag : Form
    {
        private List<TS_MODULE> tsModuleList = null;

        private DataTable dt = null;

        private string strID = "0";

        public FrmPrivilegeMag()
        {
            InitializeComponent();
        }

        private void FrmMenuManage_Load(object sender, EventArgs e)
        {
            BindTreeList();
            //string res;
            //frmWaitingBox f = new frmWaitingBox((obj, args) =>
            //{
            //    BindTreeList();
            //});
            //f.ShowDialog(this);
            //res = f.Message;
            //if (!string.IsNullOrEmpty(res))
            //    MessageBox.Show(res);
        }

        public void BindTreeList()
        {
            try
            {
                //dt = bllModule.GetList("", "").Tables[0];
                tsModuleList = TS_MODULE.GetList(" N_MODULE_TYPE='0' order by MAIN.N_ORDER asc");

                tl_Module.KeyFieldName = "C_ID";//主键名称  
                tl_Module.ParentFieldName = "C_PARENT_ID";//父级ID 

                bscTSMODULE.DataSource = tsModuleList;

                tl_Module.DataSource = bscTSMODULE;//数据源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tl_Module_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            strID = e.Node.GetValue("C_ID").ToString();
        }

        /// <summary>
        /// 添加根目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {               
                FrmMenuAdd frmAdd = new FrmMenuAdd("0", false);
                frmAdd.Owner = this;
                frmAdd.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 添加子目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                var ts = tl_Module.GetFocusedRow() as TS_MODULE;
                if (ts == null)
                {
                    return;
                }
                FrmLoadDll frmAdd = new FrmLoadDll(strID,ts.C_NAME );
                frmAdd.Owner = this;
                frmAdd.ShowDialog();
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

        private void tl_Module_DoubleClick(object sender, EventArgs e)
        {
            var item = tl_Module.GetFocusedRow() as TS_MODULE;        
            if (item != null)
            {              
                FrmMenuAdd frmAdd = new FrmMenuAdd(item.C_ID, true);
                frmAdd.Owner = this;
                frmAdd.ShowDialog();
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //object item = this.bscTSMODULE.Current;
                var item = this.bscTSMODULE.Current as TS_MODULE;
                if (item != null)
                {

                    TS_MODULE mod = TS_MODULE.GetModel("C_PARENT_ID=@C_PARENT_ID and N_ORDER=@N_ORDER", item.C_PARENT_ID, Convert.ToInt32(item.N_ORDER) - 1);
                    if (mod != null)
                    {
                        int order_up = Convert.ToInt32(mod.N_ORDER);
                        int order_down = Convert.ToInt32(item.N_ORDER);

                        item.N_ORDER = order_up;
                        mod.N_ORDER = order_down;
                        item.Save();
                        mod.Save();
                        BindTreeList();

                        foreach (TreeListNode node in tl_Module.Nodes)
                        {
                            if (node.Nodes.Count > 0)
                            {
                                PRV_SetState(item.C_ID, node);
                            }

                            string a = node.GetValue("C_ID").ToString();
                            string b = item.C_ID;
                            if (node.GetValue("C_ID").ToString() == item.C_ID)
                            {
                                node.Selected = true;
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

        private void PRV_SetState(string sId, TreeListNode IN_CheckedNode)
        {
            if (IN_CheckedNode.HasChildren)
            {
                foreach (TreeListNode Each_Node in IN_CheckedNode.Nodes)
                {
                    PRV_SetState(sId, Each_Node);
                }
            }
            else
            {
                if (IN_CheckedNode.GetValue("C_ID").ToString() == sId)
                {
                    IN_CheckedNode.Selected = true;
                }
                
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                var item = this.bscTSMODULE.Current as TS_MODULE;
                if (item != null)
                {

                    TS_MODULE mod = TS_MODULE.GetModel("C_PARENT_ID=@C_PARENT_ID and N_ORDER=@N_ORDER", item.C_PARENT_ID, Convert.ToInt32(item.N_ORDER) + 1);
                    if (mod != null)
                    {
                        int order_up = Convert.ToInt32(mod.N_ORDER);
                        int order_down = Convert.ToInt32(item.N_ORDER);

                        item.N_ORDER = order_up;
                        mod.N_ORDER = order_down;
                        item.Save();
                        mod.Save();
                        BindTreeList();

                        foreach (TreeListNode node in tl_Module.Nodes)
                        {
                            if (node.Nodes.Count > 0)
                            {
                                PRV_SetState(item.C_ID, node);
                            }

                            string a = node.GetValue("C_ID").ToString();
                            string b = item.C_ID;
                            if (node.GetValue("C_ID").ToString() == item.C_ID)
                            {
                                node.Selected = true;
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

        private void btnAddChildMenu_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMenuAdd frmAdd = new FrmMenuAdd(strID, false);
                frmAdd.Owner = this;
                frmAdd.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            var item = tl_Module.GetFocusedRow() as TS_MODULE;
            if (item != null)
            {
                FrmMenuAdd frmAdd = new FrmMenuAdd(item.C_ID, true);
                frmAdd.Owner = this;
                frmAdd.ShowDialog();
            }
        }
    }
}
