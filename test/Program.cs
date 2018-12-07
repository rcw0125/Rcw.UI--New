using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rcw.Data;

namespace test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Rcw.Data.DbContext.SetDbName(DbContext.DbName.iuapdb);
            Rcw.Data.DbContext.Create<Rcw.Model.TS_USER_FUN>();
           // Rcw.UI.PrivilegeMag.initSystem();
            Application.Run(new Rcw.UI.Login());
        }
    }
}
