using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace Rcw.UI
{
    public partial class MessageForm : WaitForm
    {
        public int second = 2;
        public MessageForm()
        {
            InitializeComponent();
            //this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            label1.Text = caption;
            //this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            double d = 0;
            if (double.TryParse(description, out d))
            {
                second = Convert.ToInt16(description);
            }
            label2.Text = second + "秒后自动关闭";
            //label1.Text = description;
            //this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second--;
            label2.Text = second + "秒后自动关闭";
        }
    }
}