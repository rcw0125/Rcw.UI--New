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
        /// <param name="time">显示时间，默认2秒（2）</param>
        public static void Show(string message = "",int time=2)
        {          
            var loadForm = new SplashScreenManager(null, typeof(MessageForm), true, true);         
            loadForm.ClosingDelay = 0;
            loadForm.ShowWaitForm();
            if (message != "")
            {
                loadForm.SetWaitFormCaption(TransLine(message));
            }
            if (time != 2)
            {
                loadForm.SetWaitFormDescription(time.ToString());
            }
            
            System.Threading.Thread.Sleep(time*1000);
            loadForm.CloseWaitForm();
        }

        public static string TransLine(string message)
        {
            if (message.Length > 40)
            {
                return message.Substring(0, 39) + "\r\n" + TransLine(message.Substring(39));
            }
            else
            {
                return message;
            }
        }
    }
}
