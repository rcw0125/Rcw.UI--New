namespace Rcw.UI
{
    partial class FrmPrivilegeMag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrivilegeMag));
            this.bscTSMODULE = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddParentMenu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddChildMenu = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colC_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_PARENT_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_ASSEMBLYNAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_MODULECLASS = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_DISABLE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN_ORDER = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_IMAGEINDEX = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN_MODULE_TYPE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_QUERY_STR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colN_STATUS = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_REMARK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colC_EMP_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colD_MOD_DT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tl_Module = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.bscTSMODULE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl_Module)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.ImageUri.Uri = "Refresh;Size16x16";
            this.simpleButton1.Location = new System.Drawing.Point(10, 15);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(66, 22);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "刷新";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnAddParentMenu
            // 
            this.btnAddParentMenu.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btnAddParentMenu.Location = new System.Drawing.Point(88, 15);
            this.btnAddParentMenu.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.btnAddParentMenu.Name = "btnAddParentMenu";
            this.btnAddParentMenu.Size = new System.Drawing.Size(91, 22);
            this.btnAddParentMenu.TabIndex = 19;
            this.btnAddParentMenu.Text = "添加根目录";
            this.btnAddParentMenu.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.ImageUri.Uri = "Filter;Size16x16";
            this.simpleButton3.Location = new System.Drawing.Point(294, 15);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(91, 22);
            this.simpleButton3.TabIndex = 20;
            this.simpleButton3.Text = "加载子目录";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.flowLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(827, 55);
            this.panelControl1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.simpleButton1);
            this.flowLayoutPanel1.Controls.Add(this.btnAddParentMenu);
            this.flowLayoutPanel1.Controls.Add(this.btnAddChildMenu);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton3);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton4);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(823, 51);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // btnAddChildMenu
            // 
            this.btnAddChildMenu.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btnAddChildMenu.Location = new System.Drawing.Point(191, 15);
            this.btnAddChildMenu.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.btnAddChildMenu.Name = "btnAddChildMenu";
            this.btnAddChildMenu.Size = new System.Drawing.Size(91, 22);
            this.btnAddChildMenu.TabIndex = 19;
            this.btnAddChildMenu.Text = "添加子目录";
            this.btnAddChildMenu.Click += new System.EventHandler(this.btnAddChildMenu_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.ImageUri.Uri = "Edit;Size16x16";
            this.btnEdit.Location = new System.Drawing.Point(397, 15);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 22);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(475, 15);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(56, 22);
            this.simpleButton4.TabIndex = 21;
            this.simpleButton4.Text = "上移";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.ImageOptions.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(543, 15);
            this.simpleButton5.Margin = new System.Windows.Forms.Padding(10, 15, 2, 2);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(56, 22);
            this.simpleButton5.TabIndex = 22;
            this.simpleButton5.Text = "下移";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "0";
            this.repositoryItemCheckEdit1.ValueUnchecked = "1";
            // 
            // colC_ID
            // 
            this.colC_ID.Caption = "模块编码";
            this.colC_ID.FieldName = "C_ID";
            this.colC_ID.Name = "colC_ID";
            this.colC_ID.Width = 78;
            // 
            // colC_PARENT_ID
            // 
            this.colC_PARENT_ID.Caption = "父模块编码";
            this.colC_PARENT_ID.FieldName = "C_PARENT_ID";
            this.colC_PARENT_ID.Name = "colC_PARENT_ID";
            this.colC_PARENT_ID.Width = 78;
            // 
            // colC_NAME
            // 
            this.colC_NAME.Caption = "模块名称";
            this.colC_NAME.FieldName = "C_NAME";
            this.colC_NAME.MinWidth = 52;
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.OptionsColumn.AllowEdit = false;
            this.colC_NAME.OptionsColumn.AllowSize = false;
            this.colC_NAME.Visible = true;
            this.colC_NAME.VisibleIndex = 0;
            this.colC_NAME.Width = 200;
            // 
            // colC_ASSEMBLYNAME
            // 
            this.colC_ASSEMBLYNAME.Caption = "命名空间";
            this.colC_ASSEMBLYNAME.FieldName = "C_ASSEMBLYNAME";
            this.colC_ASSEMBLYNAME.Name = "colC_ASSEMBLYNAME";
            this.colC_ASSEMBLYNAME.OptionsColumn.AllowEdit = false;
            this.colC_ASSEMBLYNAME.Visible = true;
            this.colC_ASSEMBLYNAME.VisibleIndex = 1;
            this.colC_ASSEMBLYNAME.Width = 78;
            // 
            // colC_MODULECLASS
            // 
            this.colC_MODULECLASS.Caption = "模块地址";
            this.colC_MODULECLASS.FieldName = "C_MODULECLASS";
            this.colC_MODULECLASS.Name = "colC_MODULECLASS";
            this.colC_MODULECLASS.OptionsColumn.AllowEdit = false;
            this.colC_MODULECLASS.Visible = true;
            this.colC_MODULECLASS.VisibleIndex = 2;
            this.colC_MODULECLASS.Width = 78;
            // 
            // colC_DISABLE
            // 
            this.colC_DISABLE.Caption = "状态";
            this.colC_DISABLE.FieldName = "N_STATUS";
            this.colC_DISABLE.Name = "colC_DISABLE";
            this.colC_DISABLE.OptionsColumn.AllowEdit = false;
            this.colC_DISABLE.Visible = true;
            this.colC_DISABLE.VisibleIndex = 5;
            this.colC_DISABLE.Width = 77;
            // 
            // colN_ORDER
            // 
            this.colN_ORDER.Caption = "顺序号";
            this.colN_ORDER.FieldName = "N_ORDER";
            this.colN_ORDER.Name = "colN_ORDER";
            this.colN_ORDER.OptionsColumn.AllowEdit = false;
            this.colN_ORDER.Visible = true;
            this.colN_ORDER.VisibleIndex = 3;
            this.colN_ORDER.Width = 77;
            // 
            // colC_IMAGEINDEX
            // 
            this.colC_IMAGEINDEX.FieldName = "C_IMAGEINDEX";
            this.colC_IMAGEINDEX.Name = "colC_IMAGEINDEX";
            this.colC_IMAGEINDEX.Width = 77;
            // 
            // colN_MODULE_TYPE
            // 
            this.colN_MODULE_TYPE.FieldName = "N_MODULE_TYPE";
            this.colN_MODULE_TYPE.Name = "colN_MODULE_TYPE";
            this.colN_MODULE_TYPE.Width = 77;
            // 
            // colC_QUERY_STR
            // 
            this.colC_QUERY_STR.Caption = "注入参数";
            this.colC_QUERY_STR.FieldName = "C_QUERY_STR";
            this.colC_QUERY_STR.Name = "colC_QUERY_STR";
            this.colC_QUERY_STR.OptionsColumn.AllowEdit = false;
            this.colC_QUERY_STR.Visible = true;
            this.colC_QUERY_STR.VisibleIndex = 4;
            this.colC_QUERY_STR.Width = 77;
            // 
            // colN_STATUS
            // 
            this.colN_STATUS.FieldName = "N_STATUS";
            this.colN_STATUS.Name = "colN_STATUS";
            this.colN_STATUS.Width = 77;
            // 
            // colC_REMARK
            // 
            this.colC_REMARK.FieldName = "C_REMARK";
            this.colC_REMARK.Name = "colC_REMARK";
            this.colC_REMARK.Width = 77;
            // 
            // colC_EMP_ID
            // 
            this.colC_EMP_ID.FieldName = "C_EMP_ID";
            this.colC_EMP_ID.Name = "colC_EMP_ID";
            this.colC_EMP_ID.Width = 77;
            // 
            // colD_MOD_DT
            // 
            this.colD_MOD_DT.FieldName = "D_MOD_DT";
            this.colD_MOD_DT.Name = "colD_MOD_DT";
            this.colD_MOD_DT.Width = 77;
            // 
            // tl_Module
            // 
            this.tl_Module.AllowDrop = true;
            this.tl_Module.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colC_ID,
            this.colC_PARENT_ID,
            this.colC_NAME,
            this.colC_ASSEMBLYNAME,
            this.colC_MODULECLASS,
            this.colC_DISABLE,
            this.colN_ORDER,
            this.colC_IMAGEINDEX,
            this.colN_MODULE_TYPE,
            this.colC_QUERY_STR,
            this.colN_STATUS,
            this.colC_REMARK,
            this.colC_EMP_ID,
            this.colD_MOD_DT});
            this.tl_Module.Cursor = System.Windows.Forms.Cursors.Default;
            this.tl_Module.DataSource = this.bscTSMODULE;
            this.tl_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_Module.ImageIndexFieldName = "N_IMAGEINDEX";
            this.tl_Module.Location = new System.Drawing.Point(0, 55);
            this.tl_Module.Margin = new System.Windows.Forms.Padding(2);
            this.tl_Module.Name = "tl_Module";
            this.tl_Module.OptionsBehavior.PopulateServiceColumns = true;
            this.tl_Module.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemCheckEdit1});
            this.tl_Module.Size = new System.Drawing.Size(827, 388);
            this.tl_Module.TabIndex = 1;
            this.tl_Module.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tl_Module_FocusedNodeChanged);
            this.tl_Module.DoubleClick += new System.EventHandler(this.tl_Module_DoubleClick);
            // 
            // FrmPrivilegeMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 443);
            this.Controls.Add(this.tl_Module);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPrivilegeMag";
            this.Text = "模块管理";
            this.Load += new System.EventHandler(this.FrmMenuManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bscTSMODULE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tl_Module)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bscTSMODULE;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnAddParentMenu;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_PARENT_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_ASSEMBLYNAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_MODULECLASS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_DISABLE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN_ORDER;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_IMAGEINDEX;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN_MODULE_TYPE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_QUERY_STR;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colN_STATUS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_REMARK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colC_EMP_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colD_MOD_DT;
        private DevExpress.XtraTreeList.TreeList tl_Module;
        private DevExpress.XtraEditors.SimpleButton btnAddChildMenu;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}