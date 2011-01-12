using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace VMS
{
    /// <summary>
    /// Interaction logic for CloseMiniMaxi.xaml
    /// </summary>
    public partial class CloseMiniMaxi
    {
        public CloseMiniMaxi()
        {
            this.InitializeComponent();
            this.togbtnMaximize.IsChecked = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void togbtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                //if (!(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width == 1024 && System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height == 768))
                    //MainView.ThisMainView.ChangeWidthSecondColumn(182);
            }

            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                //MainView.ThisMainView.ChangeWidthSecondColumn(130);
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}