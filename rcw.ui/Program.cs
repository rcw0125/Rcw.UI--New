using Rcw;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rcw.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Rcw.Data.DbContext.SetDbName(Rcw.Data.DbContext.DbName.capdb);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
