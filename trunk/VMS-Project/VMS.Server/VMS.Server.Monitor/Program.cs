using System;
using System.Windows.Forms;

namespace VMS.Server.Monitor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstance.SingleApplication.Run(TaskTrayApplicationContext.GetInstance());
        }
    }
}