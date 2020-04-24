using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //AutoUpdaterDotNET.AutoUpdater.ShowRemindLaterButton = false;
            //AutoUpdaterDotNET.AutoUpdater.Start(@"C:\Users\Ricky\Desktop\Update\AutoUpdaterTest.xml");

            LIBUtil.DBConnection.initialize(Settings.CONNECTIONSTRING_DEFAULTPARAMS, Settings.SQL_USERNAME, Settings.SQL_PASSWORD);
            //LIBUtil.Util.ensureSingleInstance(runApplication);
            runApplication();
        }

        static void runApplication()
        {
            Application.Run(new Login_Form());
            DBUtil.terminateActiveSqlConnection();
        }
    }
}
