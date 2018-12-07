namespace Rcw.UI
{
    partial class FrmUserManage
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Query = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Right = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Role = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gc_User = new DevExpress.XtraGrid.GridControl();
            this.gv_User = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelControl1);
            this.flowLayoutPanel1.Controls.Add(this.txtUserName);
            this.flowLayoutPanel1.Controls.Add(this.labelControl2);
            this.flowLayoutPanel1.Controls.Add(this.txtAccountName);
            this.flowLayoutPanel1.Controls.Add(this.btn_Query);
            this.flowLayoutPanel1.Controls.Add(this.btn_Add);
            this.flowLayoutPanel1.Controls.Add(this.btn_Edit);
            this.flowLayoutPanel1.Controls.Add(this.btn_Right);
            this.flowLayoutPanel1.Controls.Add(this.btn_Role);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(892, 37);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_Query
            // 
            this.btn_Query.ImageOptions.ImageUri.Uri = "Zoom;Size16x16";
            this.btn_Query.Location = new System.Drawing.Point(246, 5);
            this.btn_Query.Margin = new System.Windows.Forms.Padding(8, 5, 2, 2);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(56, 22);
            this.btn_Query.TabIndex = 0;
            this.btn_Query.Text = "查询";
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Add.Location = new System.Drawing.Point(312, 5);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(8, 5, 2, 2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 22);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "添加用户";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Edit.Location = new System.Drawing.Point(397, 5);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(8, 5, 2, 2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 22);
            this.btn_Edit.TabIndex = 4;
            this.btn_Edit.Text = "修改用户";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Right
            // 
            this.btn_Right.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Right.Location = new System.Drawing.Point(482, 5);
            this.btn_Right.Margin = new System.Windows.Forms.Padding(8, 5, 2, 2);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(75, 22);
            this.btn_Right.TabIndex = 1;
            this.btn_Right.Text = "权限分配";
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Role
            // 
            this.btn_Role.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Role.Location = new System.Drawing.Point(567, 5);
            this.btn_Role.Margin = new System.Windows.Forms.Padding(8, 5, 2, 2);
            this.btn_Role.Name = "btn_Role";
            this.btn_Role.Size = new System.Drawing.Size(75, 22);
            this.btn_Role.TabIndex = 2;
            this.btn_Role.Text = "角色分配";
            this.btn_Role.Click += new System.EventHandler(this.btn_Role_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.simpleButton1.Location = new System.Drawing.Point(652, 5);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(8, 5, 2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 22);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "部门分配";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gc_User
            // 
            this.gc_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_User.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gc_User.Location = new System.Drawing.Point(0, 37);
            this.gc_User.MainView = this.gv_User;
            this.gc_User.Margin = new System.Windows.Forms.Padding(2);
            this.gc_User.Name = "gc_User";
            this.gc_User.Size = new System.Drawing.Size(892, 494);
            this.gc_User.TabIndex = 1;
            this.gc_User.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_User});
            // 
            // gv_User
            // 
            this.gv_User.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gv_User.GridControl = this.gc_User;
            this.gv_User.Name = "gv_User";
            this.gv_User.OptionsBehavior.Editable = false;
            this.gv_User.OptionsView.ShowGroupPanel = false;
            this.gv_User.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_User_CustomDrawRowIndicator);
            this.gv_User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_User_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "姓名";
            this.gridColumn1.FieldName = "姓名";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用户名";
            this.gridColumn2.FieldName = "用户名";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "邮箱";
            this.gridColumn3.FieldName = "邮箱";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "手机号码";
            this.gridColumn4.FieldName = "手机号码";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "操作人";
            this.gridColumn5.FieldName = "操作人";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "添加时间";
            this.gridColumn6.DisplayFormat.FormatString = "G";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "添加时间";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "角色名称";
            this.gridColumn7.FieldName = "角色名称";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "状态";
            this.gridColumn8.FieldName = "状态";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "部门";
            this.gridColumn9.FieldName = "部门";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "C_ID";
            this.gridColumn10.FieldName = "C_ID";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 8);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8, 8, 2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "姓名";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(38, 6);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 6, 2, 2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(73, 20);
            this.txtUserName.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(121, 8);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8, 8, 2, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "用户名";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(163, 6);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(4, 6, 2, 2);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(73, 20);
            this.txtAccountName.TabIndex = 12;
            // 
            // FrmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 531);
            this.Controls.Add(this.gc_User);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmUserManage";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FrmUserManage_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gc_User;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_User;
        private DevExpress.XtraEditors.SimpleButton btn_Query;
        private DevExpress.XtraEditors.SimpleButton btn_Right;
        private DevExpress.XtraEditors.SimpleButton btn_Role;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAccountName;
    }
}