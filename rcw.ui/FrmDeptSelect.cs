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
    public partial class FrmDeptSelect : Form
    {
        public string strDeptId = "";
        public FrmDeptSelect()
        {
            InitializeComponent();

            LoadList();
        }
        public void LoadList()
        {
            tlDept.KeyFieldName = "C_ID";
            tlDept.ParentFieldName = "C_PARENT_ID";
            tSDEPTBindingSource.DataSource = TS_Dept.GetList("1=1 order by c_id");
            tlDept.OptionsBehavior.Editable = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var dept = tlDept.GetFocusedRow() as TS_Dept;
            if (dept == null)
            {
                MessageBox.Show("请选择部门");
                return;
            }
            strDeptId = dept.C_ID;
            this.Close();
        }
    }
}
