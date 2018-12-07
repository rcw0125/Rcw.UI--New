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
using Rcw.Model;

namespace Rcw.UI
{
    public partial class FrmMenuAdd : Form
    {
        private string strModuleID = "0";
        private bool IsEdit = false;

        private TS_MODULE curModule = null;
        private TS_MODULE parModule = null;

        public FrmMenuAdd(string strID, bool bl)
        {
            InitializeComponent();

            strModuleID = strID;

            IsEdit = bl;
        }

        private void FrmMenuAdd_Load(object sender, EventArgs e)
        {
            ShowBll();

            BindInfo();
        }

        private void BindInfo()
        {
            try
            {
                curModule = TS_MODULE.GetModel(strModuleID);

                if (IsEdit)//修改
                {
                    if (curModule != null)
                    {
                        parModule = TS_MODULE.GetModel(curModule.C_PARENT_ID);
                        if (parModule != null)
                        {
                            lbl_ParentName.Text = parModule.C_NAME;
                        }
                        else
                        {
                            lbl_ParentName.Text = "";
                        }

                        icbo_ImgIndex.Text = curModule.N_IMAGEINDEX.ToString();
                        txt_ModuleName.Text = curModule.C_NAME.ToString();
                        cbo_BllName.Text = curModule.C_ASSEMBLYNAME.ToString();

                        ShowForm(cbo_BllName.Text);

                        cbo_FrmName.Text = curModule.C_MODULECLASS.ToString();
                        icbo_State.Text = curModule.C_DISABLE.ToString();
                        txt_Parameter.Text = curModule.C_QUERY_STR.ToString();
                    }
                    else
                    {
                        lbl_ParentName.Text = "";
                    }

                }
                else//新增
                {
                    if (curModule != null)
                    {
                        lbl_ParentName.Text = curModule.C_NAME;
                    }
                    else
                    {
                        lbl_ParentName.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowBll()
        {
            try
            {
                if (!string.IsNullOrEmpty(DllPath.strPath))
                {
                    string windowsPath = Path.GetFullPath(DllPath.strPath);

                    if (Directory.Exists(windowsPath))
                    {
                        DirectoryInfo folder = new DirectoryInfo(windowsPath);

                        FileInfo[] file = folder.GetFiles("*.dll");

                        if (file.Length > 0)
                        {
                            for (int i = 0; i < file.Length; i++)
                            {
                                if (file[i].Name.Contains("XGCAP.UI"))
                                {
                                    this.cbo_BllName.Properties.Items.Add(file[i].Name);
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

        private void ShowForm(string strBllName)
        {
            try
            {
                this.cbo_FrmName.Properties.Items.Clear();
                this.cbo_FrmName.SelectedIndex = -1;

                Assembly assembly = null;
                string windowsPath = DllPath.strPath;
                if (!string.IsNullOrEmpty(windowsPath))
                {
                    if (Directory.Exists(windowsPath))
                    {
                        foreach (string dllFile in Directory.GetFiles(windowsPath, strBllName))
                        {
                            assembly = Assembly.LoadFile(dllFile);
                            Type[] types = assembly.GetTypes();

                            foreach (Type t in types)
                            {
                                if (t.BaseType == typeof(Form))
                                {
                                    this.cbo_FrmName.Properties.Items.Add(t.FullName);
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
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEdit)//修改
                {
                    curModule.C_NAME = txt_ModuleName.Text.Trim();
                    curModule.C_ASSEMBLYNAME = cbo_BllName.Text;
                    curModule.C_MODULECLASS = cbo_FrmName.Text;
                    curModule.C_DISABLE = icbo_State.EditValue.ToString();
                    curModule.N_IMAGEINDEX = Convert.ToInt32(icbo_ImgIndex.EditValue.ToString());
                    curModule.C_EMP_ID = UserInfo.UserID;         
                    curModule.C_QUERY_STR = txt_Parameter.Text.Trim();
                    curModule.Save();
                    MessageBox.Show("操作成功！");
                    this.Close();
                   
                }
                else//新增
                {
                    TS_MODULE modNew = new TS_MODULE();

                    if (curModule != null)
                    {
                        modNew.C_PARENT_ID = curModule.C_ID;
                    }
                    else
                    {
                        modNew.C_PARENT_ID = "0";
                    }

                    modNew.C_NAME = txt_ModuleName.Text.Trim();
                    modNew.C_ASSEMBLYNAME = cbo_BllName.Text;
                    modNew.C_MODULECLASS = cbo_FrmName.Text;
                    modNew.C_DISABLE = icbo_State.EditValue.ToString();
                    modNew.N_IMAGEINDEX = Convert.ToInt32(icbo_ImgIndex.EditValue.ToString());
                    modNew.N_ORDER = PrivilegeMag.GetModuleMaxOrder(modNew.C_PARENT_ID) +1;
                    modNew.C_EMP_ID = UserInfo.UserID;

                    modNew.N_MODULE_TYPE = TS_MODULE.MODULE_TYPE.系统模块;
                    modNew.C_QUERY_STR = txt_Parameter.Text.Trim();
                    modNew.Save();
                    MessageBox.Show("操作成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败："+ex.ToString());
            }
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowForm(cbo_BllName.SelectedText);
        }

        private void FrmMenuAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrivilegeMag frmMenu;
            frmMenu = (FrmPrivilegeMag)this.Owner;
            frmMenu.BindTreeList();
        }
    }
}
