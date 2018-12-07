namespace Rcw.UI
{
    partial class FrmSetRole
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
            this.btn_Sure = new DevExpress.XtraEditors.SimpleButton();
            this.gc_Role = new DevExpress.XtraGrid.GridControl();
            this.gv_Role = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Role)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Role)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_Sure);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(831, 43);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_Sure
            // 
            this.btn_Sure.ImageUri.Uri = "Save;Size16x16";
            this.btn_Sure.Location = new System.Drawing.Point(10, 6);
            this.btn_Sure.Margin = new System.Windows.Forms.Padding(10, 6, 3, 3);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(75, 28);
            this.btn_Sure.TabIndex = 0;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // gc_Role
            // 
            this.gc_Role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Role.Location = new System.Drawing.Point(0, 43);
            this.gc_Role.MainView = this.gv_Role;
            this.gc_Role.Name = "gc_Role";
            this.gc_Role.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gc_Role.Size = new System.Drawing.Size(831, 467);
            this.gc_Role.TabIndex = 2;
            this.gc_Role.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Role});
            // 
            // gv_Role
            // 
            this.gv_Role.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gv_Role.GridControl = this.gc_Role;
            this.gv_Role.Name = "gv_Role";
            this.gv_Role.OptionsSelection.MultiSelect = true;
            this.gv_Role.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "主键";
            this.gridColumn1.FieldName = "C_ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "角色名";
            this.gridColumn2.FieldName = "C_ROLE_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "选择";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn3.FieldName = "C_CHECKSTATE";
            this.gridColumn3.MaxWidth = 40;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.ShowCaption = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "1";
            this.repositoryItemCheckEdit1.ValueUnchecked = "0";
            // 
            // FrmSetRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 510);
            this.Controls.Add(this.gc_Role);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FrmSetRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置角色";
            this.Load += new System.EventHandler(this.FrmSetRole_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Role)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Role)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_Sure;
        private DevExpress.XtraGrid.GridControl gc_Role;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Role;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}