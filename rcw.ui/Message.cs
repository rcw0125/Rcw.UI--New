using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcw.UI
{
    public class Message
    {
        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="time">显示时间，默认2秒（2000）</param>
        public static void Show(string message = "",int time=2000)
        {          
            var loadForm = new SplashScreenManager(null, typeof(MessageForm), true, true);         
            loadForm.ClosingDelay = 0;
            loadForm.ShowWaitForm();
            if (message != "")
            {
                loadForm.SetWaitFormCaption("       "+message);
            }
            System.Threading.Thread.Sleep(time);
            loadForm.CloseWaitForm();
        }
    }
}
