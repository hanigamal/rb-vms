using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Windows.Controls.Ribbon;

namespace VMS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainView : Window
    {
        #region Fields

        private GridLength _gridLength;

        #endregion

        #region Constructors

        public MainView()
        {
            InitializeComponent();
            this.myMainGridToggleButton.Checked += new RoutedEventHandler(myMainGridToggleButton_Checked);
            this.myMainGridToggleButton.Unchecked += new RoutedEventHandler(myMainGridToggleButton_Unchecked);
            this.MouseDoubleClick += new MouseButtonEventHandler(MainView_MouseDoubleClick);
        }

        #endregion

        #region Events

        private void MainView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            if (p.Y < 22)
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    this.btnCloseMiniMaxi.togbtnMaximize.IsChecked = false;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    this.btnCloseMiniMaxi.togbtnMaximize.IsChecked = true;
                }
            }
        }

        private void myMainGridToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!myMainGridFirstColumnSplitter.IsDragging)
                myMainGridFirstColumn.Width = _gridLength;
            this.myNavigationPaneButton.Visibility = Visibility.Collapsed;
        }

        private void myMainGridToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (myMainGridFirstColumn.ActualWidth > myMainGridFirstColumn.MinWidth)
                _gridLength = myMainGridFirstColumn.Width;
            myMainGridFirstColumn.Width = new GridLength(myMainGridFirstColumn.MinWidth);
            this.myNavigationPaneButton.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #endregion
    }
}
