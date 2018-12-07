namespace Rcw.UI
{
    partial class FrmUserAdd
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_LoginName = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Tel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Tel.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "账号";
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LoginName.Location = new System.Drawing.Point(82, 2);
            this.txt_LoginName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.txt_LoginName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_LoginName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_LoginName.Properties.Appearance.Options.UseFont = true;
            this.txt_LoginName.Properties.MaxLength = 50;
            this.txt_LoginName.Size = new System.Drawing.Size(311, 22);
            this.txt_LoginName.TabIndex = 1;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_UserName.Location = new System.Drawing.Point(82, 39);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.txt_UserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_UserName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_UserName.Properties.Appearance.Options.UseFont = true;
            this.txt_UserName.Properties.MaxLength = 20;
            this.txt_UserName.Size = new System.Drawing.Size(311, 22);
            this.txt_UserName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(2, 39);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 33);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "姓名";
            // 
            // txt_Tel
            // 
            this.txt_Tel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Tel.Location = new System.Drawing.Point(82, 76);
            this.txt_Tel.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Tel.Name = "txt_Tel";
            this.txt_Tel.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.txt_Tel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_Tel.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Tel.Properties.Appearance.Options.UseFont = true;
            this.txt_Tel.Properties.MaxLength = 20;
            this.txt_Tel.Size = new System.Drawing.Size(311, 22);
            this.txt_Tel.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.Location = new System.Drawing.Point(2, 76);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 33);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "电话";
            // 
            // btn_Save
            // 
            this.btn_Save.ImageOptions.ImageUri.Uri = "Save;Size16x16";
            this.btn_Save.Location = new System.Drawing.Point(211, 267);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(83, 30);
            this.btn_Save.TabIndex = 20;
            this.btn_Save.Text = "确定";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
            this.btn_Cancle.Location = new System.Drawing.Point(367, 267);
            this.btn_Cancle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(81, 30);
            this.btn_Cancle.TabIndex = 21;
            this.btn_Cancle.Text = "取消";
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.Location = new System.Drawing.Point(2, 113);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 33);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "状态";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_LoginName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_UserName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_Tel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioGroup1, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(98, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 148);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(83, 114);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "正常"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "冻结")});
            this.radioGroup1.Size = new System.Drawing.Size(309, 31);
            this.radioGroup1.TabIndex = 6;
            // 
            // FrmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 368);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.btn_Save);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.FrmUserAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_LoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Tel.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_LoginName;
        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_Tel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancle;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}