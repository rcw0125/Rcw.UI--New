namespace Rcw.UI
{
    partial class FrmMenuAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuAdd));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ParentName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.icbo_ImgIndex = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.txt_ModuleName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbo_BllName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbo_FrmName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.icbo_State = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Parameter = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.icbo_ImgIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ModuleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_BllName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_FrmName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbo_State.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Parameter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "父模块";
            // 
            // lbl_ParentName
            // 
            this.lbl_ParentName.Location = new System.Drawing.Point(71, 17);
            this.lbl_ParentName.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ParentName.Name = "lbl_ParentName";
            this.lbl_ParentName.Size = new System.Drawing.Size(0, 14);
            this.lbl_ParentName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 50);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "模块名称";
            // 
            // icbo_ImgIndex
            // 
            this.icbo_ImgIndex.EditValue = "0";
            this.icbo_ImgIndex.Location = new System.Drawing.Point(71, 48);
            this.icbo_ImgIndex.Margin = new System.Windows.Forms.Padding(2);
            this.icbo_ImgIndex.Name = "icbo_ImgIndex";
            this.icbo_ImgIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbo_ImgIndex.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("0", "0", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1", "1", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2", "2", 2)});
            this.icbo_ImgIndex.Properties.SmallImages = this.imageCollection1;
            this.icbo_ImgIndex.Size = new System.Drawing.Size(64, 20);
            this.icbo_ImgIndex.TabIndex = 3;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "t1.gif");
            this.imageCollection1.Images.SetKeyName(1, "t2.gif");
            this.imageCollection1.Images.SetKeyName(2, "t3.gif");
            // 
            // txt_ModuleName
            // 
            this.txt_ModuleName.Location = new System.Drawing.Point(148, 48);
            this.txt_ModuleName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ModuleName.Name = "txt_ModuleName";
            this.txt_ModuleName.Size = new System.Drawing.Size(422, 20);
            this.txt_ModuleName.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 85);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "程序集名";
            // 
            // cbo_BllName
            // 
            this.cbo_BllName.Location = new System.Drawing.Point(71, 82);
            this.cbo_BllName.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_BllName.Name = "cbo_BllName";
            this.cbo_BllName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_BllName.Size = new System.Drawing.Size(500, 20);
            this.cbo_BllName.TabIndex = 6;
            this.cbo_BllName.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // cbo_FrmName
            // 
            this.cbo_FrmName.Location = new System.Drawing.Point(71, 116);
            this.cbo_FrmName.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_FrmName.Name = "cbo_FrmName";
            this.cbo_FrmName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_FrmName.Size = new System.Drawing.Size(500, 20);
            this.cbo_FrmName.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 154);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "状态";
            // 
            // icbo_State
            // 
            this.icbo_State.EditValue = "1";
            this.icbo_State.Location = new System.Drawing.Point(71, 151);
            this.icbo_State.Margin = new System.Windows.Forms.Padding(2);
            this.icbo_State.Name = "icbo_State";
            this.icbo_State.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbo_State.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("正常", "0", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("停用", "1", -1)});
            this.icbo_State.Size = new System.Drawing.Size(91, 20);
            this.icbo_State.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(214, 154);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "注入参数";
            // 
            // txt_Parameter
            // 
            this.txt_Parameter.Location = new System.Drawing.Point(264, 151);
            this.txt_Parameter.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Parameter.Name = "txt_Parameter";
            this.txt_Parameter.Size = new System.Drawing.Size(307, 20);
            this.txt_Parameter.TabIndex = 11;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.simpleButton1.Location = new System.Drawing.Point(431, 186);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(56, 24);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.ImageUri.Uri = "Close;Size16x16";
            this.simpleButton2.Location = new System.Drawing.Point(514, 186);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(56, 24);
            this.simpleButton2.TabIndex = 13;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 119);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 14);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "窗体(类)";
            // 
            // FrmMenuAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 220);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txt_Parameter);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.icbo_State);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cbo_FrmName);
            this.Controls.Add(this.cbo_BllName);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_ModuleName);
            this.Controls.Add(this.icbo_ImgIndex);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_ParentName);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑菜单";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenuAdd_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenuAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icbo_ImgIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ModuleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_BllName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_FrmName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbo_State.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Parameter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_ParentName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbo_ImgIndex;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.TextEdit txt_ModuleName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbo_BllName;
        private DevExpress.XtraEditors.ComboBoxEdit cbo_FrmName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbo_State;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_Parameter;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}