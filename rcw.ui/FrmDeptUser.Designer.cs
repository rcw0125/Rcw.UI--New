namespace Rcw.UI
{
    partial class FrmDeptUser
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
            this.modTSMODULEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.tSUSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colC_REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDept = new DevExpress.XtraEditors.SimpleButton();
            this.btnRight = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnUserFunc = new DevExpress.XtraEditors.SimpleButton();
            this.gc_User = new DevExpress.XtraGrid.GridControl();
            this.tSUSERBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gv_User = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DEPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tSDEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colC_ACCOUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_PASSWORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_MOBILE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EMP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colC_EMP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colD_MOD_DT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_MOBILE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_PHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.modTSMODULEBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // modTSMODULEBindingSource
            // 
            this.modTSMODULEBindingSource.DataSource = typeof(Rcw.Model.TS_Dept);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.panelControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 539);
            this.panel2.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10F);
            this.treeView1.Indent = 19;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 38);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(238, 501);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(238, 38);
            this.panelControl1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "部门导航";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(238, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 539);
            this.splitterControl1.TabIndex = 3;
            this.splitterControl1.TabStop = false;
            // 
            // tSUSERBindingSource
            // 
            this.tSUSERBindingSource.DataSource = typeof(Rcw.Model.TS_USER);
            // 
            // colC_REMARK
            // 
            this.colC_REMARK.Caption = "维护时间";
            this.colC_REMARK.DisplayFormat.FormatString = "G";
            this.colC_REMARK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colC_REMARK.FieldName = "D_MOD_DT";
            this.colC_REMARK.Name = "colC_REMARK";
            this.colC_REMARK.OptionsColumn.AllowEdit = false;
            this.colC_REMARK.Visible = true;
            this.colC_REMARK.VisibleIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(243, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(883, 38);
            this.panel4.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelControl2);
            this.flowLayoutPanel1.Controls.Add(this.txtAccountName);
            this.flowLayoutPanel1.Controls.Add(this.btnQuery);
            this.flowLayoutPanel1.Controls.Add(this.btn_Add);
            this.flowLayoutPanel1.Controls.Add(this.btn_Edit);
            this.flowLayoutPanel1.Controls.Add(this.btn_Del);
            this.flowLayoutPanel1.Controls.Add(this.btnMoveDept);
            this.flowLayoutPanel1.Controls.Add(this.btnRight);
            this.flowLayoutPanel1.Controls.Add(this.sbtnUserFunc);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(883, 38);
            this.flowLayoutPanel1.TabIndex = 135;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 8);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8, 8, 2, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 135;
            this.labelControl2.Text = "用户名";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(50, 6);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(4, 6, 2, 2);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(73, 20);
            this.txtAccountName.TabIndex = 136;
            // 
            // btnQuery
            // 
            this.btnQuery.ImageOptions.ImageUri.Uri = "Zoom;Size16x16";
            this.btnQuery.Location = new System.Drawing.Point(128, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 26);
            this.btnQuery.TabIndex = 131;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btn_Add.Location = new System.Drawing.Point(209, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 26);
            this.btn_Add.TabIndex = 128;
            this.btn_Add.Text = "添加";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.ImageOptions.ImageUri.Uri = "Edit;Size16x16";
            this.btn_Edit.Location = new System.Drawing.Point(290, 3);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 26);
            this.btn_Edit.TabIndex = 134;
            this.btn_Edit.Text = "修改";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.btn_Del.Location = new System.Drawing.Point(371, 3);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 26);
            this.btn_Del.TabIndex = 131;
            this.btn_Del.Text = "删除";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btnMoveDept
            // 
            this.btnMoveDept.ImageOptions.ImageUri.Uri = "Redo;Size16x16";
            this.btnMoveDept.Location = new System.Drawing.Point(452, 3);
            this.btnMoveDept.Name = "btnMoveDept";
            this.btnMoveDept.Size = new System.Drawing.Size(75, 26);
            this.btnMoveDept.TabIndex = 131;
            this.btnMoveDept.Text = "调动";
            this.btnMoveDept.Click += new System.EventHandler(this.btnMoveDept_Click);
            // 
            // btnRight
            // 
            this.btnRight.ImageOptions.ImageUri.Uri = "NavigationBar;Size16x16";
            this.btnRight.Location = new System.Drawing.Point(590, 3);
            this.btnRight.Margin = new System.Windows.Forms.Padding(60, 3, 3, 3);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 26);
            this.btnRight.TabIndex = 131;
            this.btnRight.Text = "用户角色";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // sbtnUserFunc
            // 
            this.sbtnUserFunc.ImageOptions.ImageUri.Uri = "TimeLineView;Size16x16";
            this.sbtnUserFunc.Location = new System.Drawing.Point(671, 3);
            this.sbtnUserFunc.Name = "sbtnUserFunc";
            this.sbtnUserFunc.Size = new System.Drawing.Size(75, 26);
            this.sbtnUserFunc.TabIndex = 131;
            this.sbtnUserFunc.Text = "用户权限";
            this.sbtnUserFunc.Click += new System.EventHandler(this.sbtnUserFunc_Click);
            // 
            // gc_User
            // 
            this.gc_User.DataSource = this.tSUSERBindingSource1;
            this.gc_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_User.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gc_User.Location = new System.Drawing.Point(243, 38);
            this.gc_User.MainView = this.gv_User;
            this.gc_User.Margin = new System.Windows.Forms.Padding(2);
            this.gc_User.Name = "gc_User";
            this.gc_User.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.gc_User.Size = new System.Drawing.Size(883, 501);
            this.gc_User.TabIndex = 11;
            this.gc_User.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_User});
            // 
            // tSUSERBindingSource1
            // 
            this.tSUSERBindingSource1.DataSource = typeof(Rcw.Model.TS_USER);
            // 
            // gv_User
            // 
            this.gv_User.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colC_ID,
            this.colC_NAME,
            this.colC_DEPT,
            this.colC_ACCOUNT,
            this.colC_PASSWORD,
            this.colC_EMAIL,
            this.colC_MOBILE,
            this.colN_TYPE,
            this.colN_STATUS,
            this.colC_DESC,
            this.colC_EMP_ID,
            this.colC_EMP_NAME,
            this.colD_MOD_DT,
            this.colC_MOBILE2,
            this.colC_PHONE,
            this.gridColumn1});
            this.gv_User.GridControl = this.gc_User;
            this.gv_User.Name = "gv_User";
            this.gv_User.OptionsView.ShowGroupPanel = false;
            // 
            // colC_ID
            // 
            this.colC_ID.FieldName = "C_ID";
            this.colC_ID.Name = "colC_ID";
            // 
            // colC_NAME
            // 
            this.colC_NAME.FieldName = "C_NAME";
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.Visible = true;
            this.colC_NAME.VisibleIndex = 0;
            // 
            // colC_DEPT
            // 
            this.colC_DEPT.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colC_DEPT.FieldName = "C_DEPT";
            this.colC_DEPT.Name = "colC_DEPT";
            this.colC_DEPT.Visible = true;
            this.colC_DEPT.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.DataSource = this.tSDEPTBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "C_NAME";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.ValueMember = "C_ID";
            // 
            // tSDEPTBindingSource
            // 
            this.tSDEPTBindingSource.DataSource = typeof(Rcw.Model.TS_Dept);
            // 
            // colC_ACCOUNT
            // 
            this.colC_ACCOUNT.FieldName = "C_ACCOUNT";
            this.colC_ACCOUNT.Name = "colC_ACCOUNT";
            this.colC_ACCOUNT.Visible = true;
            this.colC_ACCOUNT.VisibleIndex = 1;
            // 
            // colC_PASSWORD
            // 
            this.colC_PASSWORD.FieldName = "C_PASSWORD";
            this.colC_PASSWORD.Name = "colC_PASSWORD";
            // 
            // colC_EMAIL
            // 
            this.colC_EMAIL.FieldName = "C_EMAIL";
            this.colC_EMAIL.Name = "colC_EMAIL";
            // 
            // colC_MOBILE
            // 
            this.colC_MOBILE.FieldName = "C_MOBILE";
            this.colC_MOBILE.Name = "colC_MOBILE";
            this.colC_MOBILE.Visible = true;
            this.colC_MOBILE.VisibleIndex = 2;
            // 
            // colN_TYPE
            // 
            this.colN_TYPE.FieldName = "N_TYPE";
            this.colN_TYPE.Name = "colN_TYPE";
            // 
            // colN_STATUS
            // 
            this.colN_STATUS.Caption = "状态";
            this.colN_STATUS.FieldName = "N_STATUS";
            this.colN_STATUS.Name = "colN_STATUS";
            this.colN_STATUS.Visible = true;
            this.colN_STATUS.VisibleIndex = 4;
            // 
            // colC_DESC
            // 
            this.colC_DESC.FieldName = "C_DESC";
            this.colC_DESC.Name = "colC_DESC";
            // 
            // colC_EMP_ID
            // 
            this.colC_EMP_ID.Caption = "操作人";
            this.colC_EMP_ID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colC_EMP_ID.FieldName = "C_EMP_ID";
            this.colC_EMP_ID.Name = "colC_EMP_ID";
            this.colC_EMP_ID.Visible = true;
            this.colC_EMP_ID.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.tSUSERBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "C_NAME";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "C_ID";
            // 
            // colC_EMP_NAME
            // 
            this.colC_EMP_NAME.FieldName = "C_EMP_NAME";
            this.colC_EMP_NAME.Name = "colC_EMP_NAME";
            // 
            // colD_MOD_DT
            // 
            this.colD_MOD_DT.Caption = "注册时间";
            this.colD_MOD_DT.FieldName = "C_TS";
            this.colD_MOD_DT.Name = "colD_MOD_DT";
            this.colD_MOD_DT.Visible = true;
            this.colD_MOD_DT.VisibleIndex = 6;
            // 
            // colC_MOBILE2
            // 
            this.colC_MOBILE2.FieldName = "C_MOBILE2";
            this.colC_MOBILE2.Name = "colC_MOBILE2";
            // 
            // colC_PHONE
            // 
            this.colC_PHONE.FieldName = "C_PHONE";
            this.colC_PHONE.Name = "colC_PHONE";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "最近登录时间";
            this.gridColumn1.FieldName = "C_LASTLOGINTIME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            // 
            // FrmDeptUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 539);
            this.Controls.Add(this.gc_User);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmDeptUser";
            this.Text = "部门用户";
            this.Load += new System.EventHandler(this.FrmDEPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modTSMODULEBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSDEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource modTSMODULEBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colC_REMARK;
        private System.Windows.Forms.BindingSource tSUSERBindingSource;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Del;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraGrid.GridControl gc_User;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_User;
        private System.Windows.Forms.BindingSource tSUSERBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DEPT;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ACCOUNT;
        private DevExpress.XtraGrid.Columns.GridColumn colC_PASSWORD;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn colC_MOBILE;
        private DevExpress.XtraGrid.Columns.GridColumn colN_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colN_STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colD_MOD_DT;
        private DevExpress.XtraGrid.Columns.GridColumn colC_MOBILE2;
        private DevExpress.XtraGrid.Columns.GridColumn colC_PHONE;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private System.Windows.Forms.BindingSource tSDEPTBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnMoveDept;
        private DevExpress.XtraEditors.SimpleButton btnRight;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAccountName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton sbtnUserFunc;
    }
}