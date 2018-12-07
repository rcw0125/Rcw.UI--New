namespace Rcw.UI
{
    partial class FrmDEPT
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
            this.TSDEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.tSUSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colC_REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            this.gc_ANXX = new DevExpress.XtraGrid.GridControl();
            this.gv_ANXX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_PARENT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_ASSEMBLYNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EMP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TSDEPTBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ANXX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ANXX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // TSDEPTBindingSource
            // 
            this.TSDEPTBindingSource.DataSource = typeof(Rcw.Model.TS_Dept);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.panelControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 528);
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
            this.treeView1.Size = new System.Drawing.Size(290, 490);
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
            this.panelControl1.Size = new System.Drawing.Size(290, 38);
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
            this.splitterControl1.Location = new System.Drawing.Point(290, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 528);
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
            this.panel4.Location = new System.Drawing.Point(295, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(670, 38);
            this.panel4.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnQuery);
            this.flowLayoutPanel1.Controls.Add(this.btn_Add);
            this.flowLayoutPanel1.Controls.Add(this.btn_Edit);
            this.flowLayoutPanel1.Controls.Add(this.btn_Del);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(670, 38);
            this.flowLayoutPanel1.TabIndex = 135;
            // 
            // btnQuery
            // 
            this.btnQuery.ImageOptions.ImageUri.Uri = "Zoom;Size16x16";
            this.btnQuery.Location = new System.Drawing.Point(3, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 26);
            this.btnQuery.TabIndex = 131;
            this.btnQuery.Text = "刷新";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btn_Add.Location = new System.Drawing.Point(84, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 26);
            this.btn_Add.TabIndex = 128;
            this.btn_Add.Text = "添加";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Edit.Location = new System.Drawing.Point(165, 3);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 26);
            this.btn_Edit.TabIndex = 134;
            this.btn_Edit.Text = "保存";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.btn_Del.Location = new System.Drawing.Point(246, 3);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 26);
            this.btn_Del.TabIndex = 131;
            this.btn_Del.Text = "删除";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // gc_ANXX
            // 
            this.gc_ANXX.DataSource = this.TSDEPTBindingSource;
            this.gc_ANXX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_ANXX.Location = new System.Drawing.Point(295, 38);
            this.gc_ANXX.MainView = this.gv_ANXX;
            this.gc_ANXX.Name = "gc_ANXX";
            this.gc_ANXX.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gc_ANXX.Size = new System.Drawing.Size(670, 490);
            this.gc_ANXX.TabIndex = 11;
            this.gc_ANXX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ANXX});
            // 
            // gv_ANXX
            // 
            this.gv_ANXX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colC_ID,
            this.colC_PARENT_ID,
            this.colC_NAME,
            this.colC_ASSEMBLYNAME,
            this.colC_EMP_ID});
            this.gv_ANXX.GridControl = this.gc_ANXX;
            this.gv_ANXX.Name = "gv_ANXX";
            this.gv_ANXX.OptionsView.ShowGroupPanel = false;
            // 
            // colC_ID
            // 
            this.colC_ID.Caption = "编码";
            this.colC_ID.FieldName = "C_ID";
            this.colC_ID.Name = "colC_ID";
            this.colC_ID.OptionsColumn.AllowEdit = false;
            this.colC_ID.Visible = true;
            this.colC_ID.VisibleIndex = 0;
            // 
            // colC_PARENT_ID
            // 
            this.colC_PARENT_ID.Caption = "C_PARENT_ID";
            this.colC_PARENT_ID.FieldName = "C_PARENT_ID";
            this.colC_PARENT_ID.Name = "colC_PARENT_ID";
            this.colC_PARENT_ID.OptionsColumn.AllowEdit = false;
            // 
            // colC_NAME
            // 
            this.colC_NAME.Caption = "部门代码";
            this.colC_NAME.FieldName = "C_CODE";
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.OptionsColumn.AllowEdit = false;
            // 
            // colC_ASSEMBLYNAME
            // 
            this.colC_ASSEMBLYNAME.Caption = "部门名称";
            this.colC_ASSEMBLYNAME.FieldName = "C_NAME";
            this.colC_ASSEMBLYNAME.Name = "colC_ASSEMBLYNAME";
            this.colC_ASSEMBLYNAME.Visible = true;
            this.colC_ASSEMBLYNAME.VisibleIndex = 1;
            // 
            // colC_EMP_ID
            // 
            this.colC_EMP_ID.Caption = "维护人";
            this.colC_EMP_ID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colC_EMP_ID.FieldName = "C_EMP_ID";
            this.colC_EMP_ID.Name = "colC_EMP_ID";
            this.colC_EMP_ID.OptionsColumn.AllowEdit = false;
            this.colC_EMP_ID.Visible = true;
            this.colC_EMP_ID.VisibleIndex = 2;
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
            // FrmDEPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 528);
            this.Controls.Add(this.gc_ANXX);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmDEPT";
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.FrmDEPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TSDEPTBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_ANXX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ANXX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource TSDEPTBindingSource;
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
        private DevExpress.XtraGrid.GridControl gc_ANXX;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ANXX;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_PARENT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ASSEMBLYNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMP_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
    }
}