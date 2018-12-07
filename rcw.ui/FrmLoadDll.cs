using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Rcw.Method;
using Rcw.Model;
using Rcw.Data;


namespace Rcw.UI
{
    public partial class FrmLoadDll : Form
    {
        private string strModuleID = "0";
        private string strModuleName = "";
        public List<TS_MODULE> moduleList = new List<TS_MODULE>();
        public FrmLoadDll(string strID,string strName)
        {
            InitializeComponent();

            strModuleID = strID;
            strModuleName = strName;
            lbl_ParentName.Text = strModuleName;
            gc_Module.DataSource = moduleList;
            gv_Module.SetMultiSelect();
        }

        

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectDll_Click(object sender, EventArgs e)
        {
            if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
            {

                moduleList.Clear();
                try
                {

                    AppDomain ad = app_domain.GetInstance(this.dlgOpenFile.FileName);
                    //ProxyObject obj = (ProxyObject)ad.CreateInstanceFromAndUnwrap(@"Rcw.UI.dll", "Rcw.UI.ProxyObject");
                    //ad.CreateInstanceFromAndUnwrap(@"程序集名称", "Rcw.Method.Refdll");
                    Refdll obj = (Refdll)ad.CreateInstanceFromAndUnwrap(@"Rcw.dll", "Rcw.Method.Refdll");
                    obj.LoadAssembly(this.dlgOpenFile.FileName);
                    //var m_Assembly = Assembly.LoadFile(this.dlgOpenFile.FileName);
                    string fullName = typeof(Form).FullName;

                    int i_order = PrivilegeMag.GetModuleMaxOrder(strModuleID);
                    foreach (System.Type type in obj.assembly.GetTypes())
                    {
                        if (type.BaseType != null)
                        {
                            if (type.BaseType.FullName == fullName)
                            {
                                var displayName = type.FullName;
                                var objName = obj.Invoke(type.FullName, "GetFormName");
                                if (objName.ToString() != "False")
                                {
                                    displayName = objName.ToString();
                                }
                                TS_MODULE item = new TS_MODULE();
                                item.C_DISABLE = "1";
                                item.C_ASSEMBLYNAME = this.dlgOpenFile.FileName.Substring(dlgOpenFile.FileName.LastIndexOf("\\")+1);
                                item.C_MODULECLASS = type.FullName;
                                item.C_NAME = displayName;
                                item.C_PARENT_ID = strModuleID;
                                item.N_ORDER = i_order + 1;
                                item.C_DISABLE = "1";
                                item.C_EMP_ID = UserInfo.UserID;

                                item.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
                                item.N_IMAGEINDEX = 1;
                                moduleList.Add(item);
                            }
                        }
                    }
                    gv_Module.RefreshData();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(string.Format("装载程序集失败！错误信息：\r\n{0}", exception.Message), "失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

         

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectData = TS_MODULE.GetSelectedRow(gv_Module);         
            selectData.Update();
            MessageBox.Show("操作成功！");
            moduleList.Clear();
            gv_Module.RefreshData();
            
        }
    }
}
