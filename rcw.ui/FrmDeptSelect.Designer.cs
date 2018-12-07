namespace Rcw.UI
{
    partial class FrmDeptSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlDept = new DevExpress.XtraTreeList.TreeList();
            this.colC_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_PARENT_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_CODE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN_DEPTATTR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN_STATUS = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_EMP_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colD_MOD_DT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tSDEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDEPTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlDept);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btn_Save);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(456, 422);
            this.splitContainerControl1.SplitterPosition = 335;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlDept
            // 
            this.tlDept.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colC_ID,
            this.colC_PARENT_ID,
            this.colC_CODE,
            this.colN_DEPTATTR,
            this.colC_NAME,
            this.colN_STATUS,
            this.colC_EMP_ID,
            this.colD_MOD_DT});
            this.tlDept.DataSource = this.tSDEPTBindingSource;
            this.tlDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDept.Location = new System.Drawing.Point(0, 0);
            this.tlDept.Name = "tlDept";
            this.tlDept.Size = new System.Drawing.Size(456, 335);
            this.tlDept.TabIndex = 0;
            // 
            // colC_ID
            // 
            this.colC_ID.FieldName = "C_ID";
            this.colC_ID.Name = "colC_ID";
            // 
            // colC_PARENT_ID
            // 
            this.colC_PARENT_ID.FieldName = "C_PARENT_ID";
            this.colC_PARENT_ID.Name = "colC_PARENT_ID";
            // 
            // colC_CODE
            // 
            this.colC_CODE.FieldName = "C_CODE";
            this.colC_CODE.Name = "colC_CODE";
            // 
            // colN_DEPTATTR
            // 
            this.colN_DEPTATTR.FieldName = "N_DEPTATTR";
            this.colN_DEPTATTR.Name = "colN_DEPTATTR";
            // 
            // colC_NAME
            // 
            this.colC_NAME.Caption = "部门列表";
            this.colC_NAME.FieldName = "C_NAME";
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.Visible = true;
            this.colC_NAME.VisibleIndex = 0;
            // 
            // colN_STATUS
            // 
            this.colN_STATUS.FieldName = "N_STATUS";
            this.colN_STATUS.Name = "colN_STATUS";
            // 
            // colC_EMP_ID
            // 
            this.colC_EMP_ID.FieldName = "C_EMP_ID";
            this.colC_EMP_ID.Name = "colC_EMP_ID";
            // 
            // colD_MOD_DT
            // 
            this.colD_MOD_DT.FieldName = "D_MOD_DT";
            this.colD_MOD_DT.Name = "colD_MOD_DT";
            // 
            // tSDEPTBindingSource
            // 
            this.tSDEPTBindingSource.DataSource = typeof(Rcw.Model.TS_Dept);
            // 
            // btn_Save
            // 
            this.btn_Save.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Save.Location = new System.Drawing.Point(292, 30);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(72, 30);
            this.btn_Save.TabIndex = 20;
            this.btn_Save.Text = "确定";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // FrmDeptSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 422);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmDeptSelect";
            this.Text = "FrmDeptSelect";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDEPTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraTreeList.TreeList tlDept;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_PARENT_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_CODE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN_DEPTATTR;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN_STATUS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_EMP_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colD_MOD_DT;
        private System.Windows.Forms.BindingSource tSDEPTBindingSource;
    }
}