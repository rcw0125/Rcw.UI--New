namespace Rcw.UI
{
    partial class FrmLoadDll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoadDll));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ParentName = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectDll = new DevExpress.XtraEditors.SimpleButton();
            this.gc_Module = new DevExpress.XtraGrid.GridControl();
            this.tSMODULEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gv_Module = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_PARENT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_ASSEMBLYNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_MODULECLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DISABLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_ORDER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_IMAGEINDEX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_MODULE_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_QUERY_STR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EMP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_MOD_DT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Module)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSMODULEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Module)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "父模块";
            // 
            // lbl_ParentName
            // 
            this.lbl_ParentName.Location = new System.Drawing.Point(98, 17);
            this.lbl_ParentName.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ParentName.Name = "lbl_ParentName";
            this.lbl_ParentName.Size = new System.Drawing.Size(0, 14);
            this.lbl_ParentName.TabIndex = 1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "t1.gif");
            this.imageCollection1.Images.SetKeyName(1, "t2.gif");
            this.imageCollection1.Images.SetKeyName(2, "t3.gif");
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSave);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSelectDll);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lbl_ParentName);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gc_Module);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(850, 402);
            this.splitContainerControl1.SplitterPosition = 42;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btnSave.Location = new System.Drawing.Point(369, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 26);
            this.btnSave.TabIndex = 132;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelectDll
            // 
            this.btnSelectDll.ImageOptions.ImageUri.Uri = "Pie;Size16x16";
            this.btnSelectDll.Location = new System.Drawing.Point(215, 11);
            this.btnSelectDll.Name = "btnSelectDll";
            this.btnSelectDll.Size = new System.Drawing.Size(112, 26);
            this.btnSelectDll.TabIndex = 132;
            this.btnSelectDll.Text = "选择程序集";
            this.btnSelectDll.Click += new System.EventHandler(this.btnSelectDll_Click);
            // 
            // gc_Module
            // 
            this.gc_Module.DataSource = this.tSMODULEBindingSource;
            this.gc_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Module.Location = new System.Drawing.Point(0, 0);
            this.gc_Module.MainView = this.gv_Module;
            this.gc_Module.Name = "gc_Module";
            this.gc_Module.Size = new System.Drawing.Size(850, 355);
            this.gc_Module.TabIndex = 0;
            this.gc_Module.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Module});
            // 
            // tSMODULEBindingSource
            // 
            this.tSMODULEBindingSource.DataSource = typeof(Rcw.Model.TS_MODULE);
            // 
            // gv_Module
            // 
            this.gv_Module.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colC_ID,
            this.colC_PARENT_ID,
            this.colC_NAME,
            this.colC_ASSEMBLYNAME,
            this.colC_MODULECLASS,
            this.colC_DISABLE,
            this.colN_ORDER,
            this.colN_IMAGEINDEX,
            this.colN_MODULE_TYPE,
            this.colC_QUERY_STR,
            this.colC_REMARK,
            this.colC_EMP_ID,
            this.colD_MOD_DT});
            this.gv_Module.GridControl = this.gc_Module;
            this.gv_Module.Name = "gv_Module";
            this.gv_Module.OptionsView.ShowGroupPanel = false;
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
            // colC_NAME
            // 
            this.colC_NAME.FieldName = "C_NAME";
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.Visible = true;
            this.colC_NAME.VisibleIndex = 0;
            // 
            // colC_ASSEMBLYNAME
            // 
            this.colC_ASSEMBLYNAME.FieldName = "C_ASSEMBLYNAME";
            this.colC_ASSEMBLYNAME.Name = "colC_ASSEMBLYNAME";
            this.colC_ASSEMBLYNAME.Visible = true;
            this.colC_ASSEMBLYNAME.VisibleIndex = 1;
            // 
            // colC_MODULECLASS
            // 
            this.colC_MODULECLASS.FieldName = "C_MODULECLASS";
            this.colC_MODULECLASS.Name = "colC_MODULECLASS";
            this.colC_MODULECLASS.Visible = true;
            this.colC_MODULECLASS.VisibleIndex = 2;
            // 
            // colC_DISABLE
            // 
            this.colC_DISABLE.FieldName = "C_DISABLE";
            this.colC_DISABLE.Name = "colC_DISABLE";
            // 
            // colN_ORDER
            // 
            this.colN_ORDER.FieldName = "N_ORDER";
            this.colN_ORDER.Name = "colN_ORDER";
            // 
            // colN_IMAGEINDEX
            // 
            this.colN_IMAGEINDEX.FieldName = "N_IMAGEINDEX";
            this.colN_IMAGEINDEX.Name = "colN_IMAGEINDEX";
            // 
            // colN_MODULE_TYPE
            // 
            this.colN_MODULE_TYPE.FieldName = "N_MODULE_TYPE";
            this.colN_MODULE_TYPE.Name = "colN_MODULE_TYPE";
            // 
            // colC_QUERY_STR
            // 
            this.colC_QUERY_STR.FieldName = "C_QUERY_STR";
            this.colC_QUERY_STR.Name = "colC_QUERY_STR";
            this.colC_QUERY_STR.Visible = true;
            this.colC_QUERY_STR.VisibleIndex = 3;
            // 
            // colC_REMARK
            // 
            this.colC_REMARK.FieldName = "C_REMARK";
            this.colC_REMARK.Name = "colC_REMARK";
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
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // FrmMenuAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 402);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "装载菜单";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Module)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSMODULEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Module)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_ParentName;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gc_Module;
        private System.Windows.Forms.BindingSource tSMODULEBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Module;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_PARENT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ASSEMBLYNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_MODULECLASS;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DISABLE;
        private DevExpress.XtraGrid.Columns.GridColumn colN_ORDER;
        private DevExpress.XtraGrid.Columns.GridColumn colN_IMAGEINDEX;
        private DevExpress.XtraGrid.Columns.GridColumn colN_MODULE_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_QUERY_STR;
        private DevExpress.XtraGrid.Columns.GridColumn colC_REMARK;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colD_MOD_DT;
        private DevExpress.XtraEditors.SimpleButton btnSelectDll;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}