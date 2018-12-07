using Rcw.UI;
using Skin.Bars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rcw.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //就是MDI窗口容器，只有设置了这个属性为True，才可以当作其他的窗口的MDI父窗口！
            this.IsMdiContainer = true;
            showForm(new FrmRole());
        }


        private void showForm(Form fr)
        {

            if (Application.OpenForms[fr.Name] == null)
            {

                this.CreateFormPanel(fr, true);
            }
            else
            {

                this.ToSelect(Application.OpenForms[fr.Name]);
            }

        }

        private void ToSelect(Form _obj)
        {
            this.superTabControl1.SelectedTab = (SuperTabItem)this.superTabControl1.Tabs["bi_" + _obj.Name];
        }

        private void CreateFormPanel(Form _obj, bool _inPanel)
        {
            _obj.TopLevel = true;
            _obj.FormBorderStyle = FormBorderStyle.None;
            _obj.MdiParent = this;
            _obj.Dock = DockStyle.Fill;
            _obj.FormBorderStyle = FormBorderStyle.None;
            Size size = new Size(0x50c, 0x298);
            _obj.Size = size;
            SuperTabItem item = new SuperTabItem
            {
                Name = "bi_" + _obj.Name,
                Text = _obj.Text,
                TextAlignment = eItemAlignment.Center
            };
            this.superTabControl1.Tabs.Insert(this.superTabControl1.Tabs.Count, item);
            SuperTabControlPanel panel = new SuperTabControlPanel
            {
                Name = "stcp_" + _obj.Name
            };
            this.superTabControl1.CreateTab(item, panel, 0);
            this.superTabControl1.SelectedTab = item;
            panel.Controls.Add(_obj);
            _obj.Show();
        }
    }
}
