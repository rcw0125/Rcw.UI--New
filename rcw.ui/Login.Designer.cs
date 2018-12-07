namespace Rcw.UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(674, 449);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(81, 28);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "退出";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(569, 449);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(81, 28);
            this.btn_Login.TabIndex = 18;
            this.btn_Login.Text = "登录";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Location = new System.Drawing.Point(569, 407);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '●';
            this.txt_Pwd.Size = new System.Drawing.Size(186, 25);
            this.txt_Pwd.TabIndex = 17;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(569, 367);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(186, 25);
            this.txt_Name.TabIndex = 16;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(518, 415);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 18);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "密码：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(503, 370);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 18);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "用户名：";
            // 
            // Login
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackgroundImage = global::Rcw.UI.Properties.Resources.login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(977, 544);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Pwd);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产管控一体化";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_Login;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_Name;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}