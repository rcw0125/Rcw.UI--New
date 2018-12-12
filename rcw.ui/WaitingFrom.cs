using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.UI
{
    public class WaitingFrom
    {
        public static SplashScreenManager _loadForm;

        /// <summary>
        /// 等待窗体管理对象
        /// </summary>
        public static SplashScreenManager LoadForm
        {
            get
            {
                if (_loadForm == null)
                {
                    _loadForm = new SplashScreenManager(null, typeof(CustomWaitForm), true, true);
                    _loadForm.ClosingDelay = 0;
                }
                return _loadForm;
            }
        }

        public static void ShowWait()
        {
            try
            {
                bool flag = !LoadForm.IsSplashFormVisible;
                if (flag)
                {
                    LoadForm.ShowWaitForm();
                }
                else
                {
                    LoadForm.CloseWaitForm();
                    LoadForm.ShowWaitForm();
                }
            }
            catch
            {

            }

          
        }

        public static void CloseWait()
        {
            try
            {
                bool isSplashFormVisible = LoadForm.IsSplashFormVisible;
                if (isSplashFormVisible)
                {
                    LoadForm.CloseWaitForm();
                }
            }
            catch
            {

            }

            
        }
    }
}
