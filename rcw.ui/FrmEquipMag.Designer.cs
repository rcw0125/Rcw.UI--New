﻿namespace Rcw.UI
{
    partial class FrmEquipMag
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
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.tSEQUIPMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tSEQUIPMENTITEMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EQUIPMENT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NC_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGRADE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIGCLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_EMP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colC_TS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaveEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.TSDEPTBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSEQUIPMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSEQUIPMENTITEMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(230, 528);
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
            this.treeView1.Size = new System.Drawing.Size(230, 490);
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
            this.panelControl1.Size = new System.Drawing.Size(230, 38);
            this.panelControl1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "设备";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(230, 0);
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
            this.panel4.Location = new System.Drawing.Point(235, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 38);
            this.panel4.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnQuery);
            this.flowLayoutPanel1.Controls.Add(this.btn_Edit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(730, 38);
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
            // btn_Edit
            // 
            this.btn_Edit.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Edit.Location = new System.Drawing.Point(84, 3);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(82, 26);
            this.btn_Edit.TabIndex = 134;
            this.btn_Edit.Text = "更换设备";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // tSEQUIPMENTBindingSource
            // 
            this.tSEQUIPMENTBindingSource.DataSource = typeof(Rcw.Model.TS_EQUIPMENT);
            // 
            // tSEQUIPMENTITEMBindingSource
            // 
            this.tSEQUIPMENTITEMBindingSource.DataSource = typeof(Rcw.Model.TS_EQUIPMENT_ITEM);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tSEQUIPMENTITEMBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(730, 191);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colC_ID,
            this.colC_EQUIPMENT_ID,
            this.colC_NAME,
            this.colC_NC_CODE,
            this.colN_STATUS,
            this.colGRADE,
            this.colBIGCLASS,
            this.colC_EMP_ID,
            this.colC_TS,
            this.colSaveEnable});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colC_ID
            // 
            this.colC_ID.FieldName = "C_ID";
            this.colC_ID.Name = "colC_ID";
            // 
            // colC_EQUIPMENT_ID
            // 
            this.colC_EQUIPMENT_ID.FieldName = "C_EQUIPMENT_ID";
            this.colC_EQUIPMENT_ID.Name = "colC_EQUIPMENT_ID";
            // 
            // colC_NAME
            // 
            this.colC_NAME.FieldName = "C_NAME";
            this.colC_NAME.Name = "colC_NAME";
            this.colC_NAME.Visible = true;
            this.colC_NAME.VisibleIndex = 0;
            // 
            // colC_NC_CODE
            // 
            this.colC_NC_CODE.FieldName = "C_NC_CODE";
            this.colC_NC_CODE.Name = "colC_NC_CODE";
            this.colC_NC_CODE.Visible = true;
            this.colC_NC_CODE.VisibleIndex = 1;
            // 
            // colN_STATUS
            // 
            this.colN_STATUS.FieldName = "N_STATUS";
            this.colN_STATUS.Name = "colN_STATUS";
            // 
            // colGRADE
            // 
            this.colGRADE.Caption = "设备等级";
            this.colGRADE.FieldName = "GRADE";
            this.colGRADE.Name = "colGRADE";
            this.colGRADE.Visible = true;
            this.colGRADE.VisibleIndex = 2;
            // 
            // colBIGCLASS
            // 
            this.colBIGCLASS.Caption = "设备大类";
            this.colBIGCLASS.FieldName = "BIGCLASS";
            this.colBIGCLASS.Name = "colBIGCLASS";
            this.colBIGCLASS.Visible = true;
            this.colBIGCLASS.VisibleIndex = 3;
            // 
            // colC_EMP_ID
            // 
            this.colC_EMP_ID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colC_EMP_ID.FieldName = "C_EMP_ID";
            this.colC_EMP_ID.Name = "colC_EMP_ID";
            this.colC_EMP_ID.Visible = true;
            this.colC_EMP_ID.VisibleIndex = 4;
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
            // colC_TS
            // 
            this.colC_TS.FieldName = "C_TS";
            this.colC_TS.Name = "colC_TS";
            this.colC_TS.Visible = true;
            this.colC_TS.VisibleIndex = 5;
            // 
            // colSaveEnable
            // 
            this.colSaveEnable.FieldName = "SaveEnable";
            this.colSaveEnable.Name = "colSaveEnable";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(235, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(730, 490);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 11;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(730, 295);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(724, 266);
            this.xtraTabPage1.Text = "使用实绩";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(724, 266);
            this.xtraTabPage2.Text = "点检记录";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(724, 266);
            this.xtraTabPage3.Text = "故障记录";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(724, 266);
            this.xtraTabPage4.Text = "计划检修记录";
            // 
            // FrmEquipMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 528);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmEquipMag";
            this.Text = "设备档案";
            this.Load += new System.EventHandler(this.FrmDEPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TSDEPTBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSUSERBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tSEQUIPMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSEQUIPMENTITEMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Windows.Forms.BindingSource tSEQUIPMENTBindingSource;
        private System.Windows.Forms.BindingSource tSEQUIPMENTITEMBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EQUIPMENT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NC_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colN_STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colGRADE;
        private DevExpress.XtraGrid.Columns.GridColumn colBIGCLASS;
        private DevExpress.XtraGrid.Columns.GridColumn colC_EMP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_TS;
        private DevExpress.XtraGrid.Columns.GridColumn colSaveEnable;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
    }
}