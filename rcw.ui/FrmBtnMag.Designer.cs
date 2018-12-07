namespace Rcw.UI
{
    partial class FrmBtnMag
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
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gc_ANXX = new DevExpress.XtraGrid.GridControl();
            this.modTSMODULEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gv_ANXX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_PARENT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_ASSEMBLYNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_MODULECLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DISABLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colN_IMAGEINDEX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_MODULE_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_QUERY_STR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_REMARK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EMP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tSUSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colD_MOD_DT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lab_Name = new DevExpress.XtraEditors.LabelControl();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ANXX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modTSMODULEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ANXX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(231, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 495);
            this.splitterControl1.TabIndex = 3;
            this.splitterControl1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gc_ANXX);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(236, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 495);
            this.panel3.TabIndex = 4;
            // 
            // gc_ANXX
            // 
            this.gc_ANXX.DataSource = this.modTSMODULEBindingSource;
            this.gc_ANXX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_ANXX.Location = new System.Drawing.Point(0, 38);
            this.gc_ANXX.MainView = this.gv_ANXX;
            this.gc_ANXX.Name = "gc_ANXX";
            this.gc_ANXX.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemCheckEdit1});
            this.gc_ANXX.Size = new System.Drawing.Size(823, 457);
            this.gc_ANXX.TabIndex = 4;
            this.gc_ANXX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ANXX});
            // 
            // modTSMODULEBindingSource
            // 
            this.modTSMODULEBindingSource.DataSource = typeof(Rcw.Model.TS_MODULE);
            // 
            // gv_ANXX
            // 
            this.gv_ANXX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colC_ID,
            this.colC_PARENT_ID,
            this.colC_NAME,
            this.colC_ASSEMBLYNAME,
            this.colC_MODULECLASS,
            this.colC_DISABLE,
            this.colN_IMAGEINDEX,
            this.colN_MODULE_TYPE,
            this.colC_QUERY_STR,
            this.colC_REMARK,
            this.colC_EMP_ID,
            this.colD_MOD_DT,
            this.gridColumn1});
            this.gv_ANXX.GridControl = this.gc_ANXX;
            this.gv_ANXX.Name = "gv_ANXX";
            this.gv_ANXX.OptionsView.ShowGroupPanel = false;
            // 
            // colC_ID
            // 
            this.colC_ID.Caption = "模块编码";
            this.colC_ID.FieldName = "C_ID";
            this.colC_ID.Name = "colC_ID";
            this.colC_ID.OptionsColumn.AllowEdit = false;
            // 
            // colC_PARENT_ID
            // 
            this.colC_PARENT_ID.Caption = "父模块编码";
            this.colC_PARENT_ID.FieldName = "C_PARENT_ID";
            this.colC_PARENT_ID.Name = "colC_PARENT_ID";
            this.colC_PARENT_ID.OptionsColumn.AllowEdit = false;
            // 
            // colC_NAME
            // 
            this.colC_NAME.Caption = "按钮名称";
            this.colC_NAME.FieldName = "C_NAME";
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.Visible = true;
            this.colC_NAME.VisibleIndex = 0;
            // 
            // colC_ASSEMBLYNAME
            // 
            this.colC_ASSEMBLYNAME.Caption = "装配件";
            this.colC_ASSEMBLYNAME.FieldName = "C_ASSEMBLYNAME";
            this.colC_ASSEMBLYNAME.Name = "colC_ASSEMBLYNAME";
            // 
            // colC_MODULECLASS
            // 
            this.colC_MODULECLASS.Caption = "按钮ID";
            this.colC_MODULECLASS.FieldName = "C_MODULECLASS";
            this.colC_MODULECLASS.Name = "colC_MODULECLASS";
            this.colC_MODULECLASS.Visible = true;
            this.colC_MODULECLASS.VisibleIndex = 1;
            // 
            // colC_DISABLE
            // 
            this.colC_DISABLE.Caption = "是否启用";
            this.colC_DISABLE.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colC_DISABLE.FieldName = "C_DISABLE";
            this.colC_DISABLE.Name = "colC_DISABLE";
            this.colC_DISABLE.Visible = true;
            this.colC_DISABLE.VisibleIndex = 5;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "1";
            this.repositoryItemCheckEdit1.ValueUnchecked = "0";
            // 
            // colN_IMAGEINDEX
            // 
            this.colN_IMAGEINDEX.Caption = "图片索引";
            this.colN_IMAGEINDEX.FieldName = "N_IMAGEINDEX";
            this.colN_IMAGEINDEX.Name = "colN_IMAGEINDEX";
            // 
            // colN_MODULE_TYPE
            // 
            this.colN_MODULE_TYPE.Caption = "模块类型";
            this.colN_MODULE_TYPE.FieldName = "N_MODULE_TYPE";
            this.colN_MODULE_TYPE.Name = "colN_MODULE_TYPE";
            // 
            // colC_QUERY_STR
            // 
            this.colC_QUERY_STR.Caption = "注入参数";
            this.colC_QUERY_STR.FieldName = "C_QUERY_STR";
            this.colC_QUERY_STR.Name = "colC_QUERY_STR";
            // 
            // colC_REMARK
            // 
            this.colC_REMARK.Caption = "备注";
            this.colC_REMARK.FieldName = "C_REMARK";
            this.colC_REMARK.Name = "colC_REMARK";
            // 
            // colC_EMP_ID
            // 
            this.colC_EMP_ID.Caption = "维护人";
            this.colC_EMP_ID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colC_EMP_ID.FieldName = "C_EMP_ID";
            this.colC_EMP_ID.Name = "colC_EMP_ID";
            this.colC_EMP_ID.OptionsColumn.AllowEdit = false;
            this.colC_EMP_ID.Visible = true;
            this.colC_EMP_ID.VisibleIndex = 3;
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
            // tSUSERBindingSource
            // 
            this.tSUSERBindingSource.DataSource = typeof(Rcw.Model.TS_USER);
            // 
            // colD_MOD_DT
            // 
            this.colD_MOD_DT.Caption = "维护时间";
            this.colD_MOD_DT.DisplayFormat.FormatString = "G";
            this.colD_MOD_DT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colD_MOD_DT.FieldName = "C_TS";
            this.colD_MOD_DT.Name = "colD_MOD_DT";
            this.colD_MOD_DT.OptionsColumn.AllowEdit = false;
            this.colD_MOD_DT.Visible = true;
            this.colD_MOD_DT.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "顺序";
            this.gridColumn1.FieldName = "N_ORDER";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lab_Name);
            this.panel4.Controls.Add(this.btn_Add);
            this.panel4.Controls.Add(this.btn_Save);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 38);
            this.panel4.TabIndex = 3;
            // 
            // lab_Name
            // 
            this.lab_Name.Location = new System.Drawing.Point(270, 14);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(0, 14);
            this.lab_Name.TabIndex = 132;
            // 
            // btn_Add
            // 
            this.btn_Add.ImageOptions.ImageUri.Uri = "Add;Size16x16";
            this.btn_Add.Location = new System.Drawing.Point(6, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 26);
            this.btn_Add.TabIndex = 128;
            this.btn_Add.Text = "添加";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Save.Location = new System.Drawing.Point(103, 8);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 26);
            this.btn_Save.TabIndex = 130;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Saves_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.panelControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 495);
            this.panel2.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Indent = 19;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 32);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(231, 463);
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
            this.panelControl1.Size = new System.Drawing.Size(231, 32);
            this.panelControl1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(7, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "业务导航";
            // 
            // FrmBtnMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 495);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBtnMag";
            this.Text = "按钮权限";
            this.Load += new System.EventHandler(this.FrmQR_ANQX_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_ANXX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modTSMODULEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ANXX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gc_ANXX;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ANXX;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.BindingSource modTSMODULEBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_PARENT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ASSEMBLYNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_MODULECLASS;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DISABLE;
        private DevExpress.XtraGrid.Columns.GridColumn colN_IMAGEINDEX;
        private DevExpress.XtraGrid.Columns.GridColumn colN_MODULE_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_QUERY_STR;
        private DevExpress.XtraGrid.Columns.GridColumn colC_REMARK;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colD_MOD_DT;
        private DevExpress.XtraEditors.LabelControl lab_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource tSUSERBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}