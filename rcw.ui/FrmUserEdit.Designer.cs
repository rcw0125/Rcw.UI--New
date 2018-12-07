namespace Rcw.UI
{
    partial class FrmUserEdit
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
            this.txt_Email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.icbo_State = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btn_Reset = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnEdit_Dept = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Tel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbo_State.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_Dept.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "账号";
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.Location = new System.Drawing.Point(80, 21);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Properties.MaxLength = 50;
            this.txt_LoginName.Properties.ReadOnly = true;
            this.txt_LoginName.Size = new System.Drawing.Size(249, 24);
            this.txt_LoginName.TabIndex = 1;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(80, 63);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Properties.MaxLength = 20;
            this.txt_UserName.Size = new System.Drawing.Size(249, 24);
            this.txt_UserName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "姓名";
            // 
            // txt_Tel
            // 
            this.txt_Tel.Location = new System.Drawing.Point(80, 106);
            this.txt_Tel.Name = "txt_Tel";
            this.txt_Tel.Properties.MaxLength = 20;
            this.txt_Tel.Size = new System.Drawing.Size(249, 24);
            this.txt_Tel.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(44, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "电话";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(80, 148);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Properties.MaxLength = 50;
            this.txt_Email.Size = new System.Drawing.Size(249, 24);
            this.txt_Email.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(44, 151);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(30, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "邮箱";
            // 
            // btn_Save
            // 
            this.btn_Save.ImageUri.Uri = "Save;Size16x16";
            this.btn_Save.Location = new System.Drawing.Point(44, 273);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 28);
            this.btn_Save.TabIndex = 20;
            this.btn_Save.Text = "确定";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.ImageUri.Uri = "Cancel;Size16x16";
            this.btn_Cancle.Location = new System.Drawing.Point(134, 273);
            this.btn_Cancle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancle.TabIndex = 21;
            this.btn_Cancle.Text = "取消";
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(44, 227);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 18);
            this.labelControl5.TabIndex = 22;
            this.labelControl5.Text = "状态";
            // 
            // icbo_State
            // 
            this.icbo_State.EditValue = "1";
            this.icbo_State.Location = new System.Drawing.Point(80, 224);
            this.icbo_State.Name = "icbo_State";
            this.icbo_State.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbo_State.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("正常", "1", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("冻结", "4", -1)});
            this.icbo_State.Size = new System.Drawing.Size(249, 24);
            this.icbo_State.TabIndex = 23;
            // 
            // btn_Reset
            // 
            this.btn_Reset.ImageUri.Uri = "Reset;Size16x16";
            this.btn_Reset.Location = new System.Drawing.Point(227, 273);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(98, 28);
            this.btn_Reset.TabIndex = 24;
            this.btn_Reset.Text = "重置密码";
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(44, 190);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(30, 18);
            this.labelControl6.TabIndex = 46;
            this.labelControl6.Text = "部门";
            // 
            // btnEdit_Dept
            // 
            this.btnEdit_Dept.Location = new System.Drawing.Point(81, 187);
            this.btnEdit_Dept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit_Dept.Name = "btnEdit_Dept";
            this.btnEdit_Dept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_Dept.Size = new System.Drawing.Size(248, 24);
            this.btnEdit_Dept.TabIndex = 45;
            this.btnEdit_Dept.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_Dept_ButtonClick);
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 318);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnEdit_Dept);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.icbo_State);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_Tel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_LoginName);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑用户";
            this.Load += new System.EventHandler(this.FrmUserEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_LoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Tel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbo_State.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_Dept.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_LoginName;
        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_Tel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_Email;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancle;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbo_State;
        private DevExpress.XtraEditors.SimpleButton btn_Reset;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_Dept;
    }
}