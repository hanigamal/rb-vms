using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using VMS.Client.TrackingSystem.Views;
using System.Reflection;

namespace VMS.Client.TrackingSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static App()
        {
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        public MainView mainWindows = null;

        public App()
            : base()
        {
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            InitializeComponent();

            if (SingleApplication.Run())
            {
                mainWindows = new MainView();
                Current.MainWindow = mainWindows;
                Current.MainWindow.Show();
                return;
            }
            Application.Current.Shutdown();
            System.Environment.Exit(1);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
