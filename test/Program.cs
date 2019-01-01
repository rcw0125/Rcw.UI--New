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
            //Rcw.Data.DbContext.SetDbName(DbContext.DbName.iuapdb);
            Rcw.Data.DbContext.AddDataSource("lg", DbContext.DbType.Oracle, "192.168.36.151", "XGMES", "XGMES", "XGMES");
            DbContext.DefaultDataSourceName = "lg";
            Rcw.Data.DbContext.Create<Rcw.Model.TS_EQUIPMENT_ITEM>();
            //Rcw.UI.PrivilegeMag.initSystem();
            Application.Run(new Rcw.UI.Login());
        }
    }
}
