using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rcw.UI
{
    public class UserButtonRight
    {
        /// <summary>
        /// 初始化当前窗体的按钮权限
        /// </summary>
        /// <param name="frm">窗体</param>
        public static void GetBtnFun(Form frm)
        {
            if (Rcw.UI.UserInfo.UserAccount == "system")
            {
                return;
            }
            //通过当前窗体的text属性，查询该信息
            var curfrm = UserInfo.UserMenu.Where(o => o.C_NAME == frm.Text).FirstOrDefault();
            if (curfrm == null)
            {
                return;
            }
            //根据当前窗体的C_ID，查询拥有的按钮权限
            var btnList = UserInfo.UserBtn.Where(o => o.C_PARENT_ID == curfrm.C_ID).ToList();

            foreach (Control item in frm.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    GetControls(item, btnList);
                }
                else
                {
                    if (item is Button || item is DevExpress.XtraEditors.SimpleButton)
                    {
                        if (item.Text.Trim() == "查询")
                        {
                            item.Enabled = true;
                            continue;
                        }

                        bool ISView = false;

                        foreach (var btnitem in btnList)
                        {
                            if (item.Name == btnitem.C_MODULECLASS || item.Text.Trim() == btnitem.C_NAME.Trim())
                            {
                                ISView = true;

                                break;
                            }
                        }

                        if (ISView)
                        {
                            item.Enabled = true;
                        }
                        else
                        {
                            item.Enabled = false;
                        }

                    }
                }
            }
        }

        private static void GetControls(Control fatherControl, List<Rcw.Model.TS_MODULE> dt)
        {
            //遍历所有控件
            foreach (Control item in fatherControl.Controls)
            {

                if (item.Controls.Count > 0)
                {
                    GetControls(item, dt);
                }
                else
                {
                    if (item is Button || item is DevExpress.XtraEditors.SimpleButton)
                    {
                        if (item.Text.Trim() == "查询")
                        {
                            item.Enabled = true;
                            continue;
                        }

                        bool ISView = false;

                        foreach (var btnitem in dt)
                        {
                            if (item.Name == btnitem.C_MODULECLASS||item.Text.Trim()==btnitem.C_NAME.Trim())
                            {
                                ISView = true;

                                break;
                            }
                        }
                      

                        if (ISView)
                        {
                            item.Enabled = true;
                        }
                        else
                        {
                            item.Enabled = false;
                        }

                    }
                }

            }
        }

    }
}
