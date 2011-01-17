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
using VMS.Client.View.Component.Map;
using VMS.Client.View.Component.Summary;

namespace VMS.Client.TrackingSystem.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainView : Window
    {
        #region Fields

        private GridLength _gridLength;

        private SumaryView sumaryView = null;

        private MapsView mapView = null;

        #endregion

        #region Constructors

        public MainView()
        {
            InitializeComponent();
            this.myMainGridToggleButton.Checked += new RoutedEventHandler(myMainGridToggleButton_Checked);
            this.myMainGridToggleButton.Unchecked += new RoutedEventHandler(myMainGridToggleButton_Unchecked);
            this.MouseDoubleClick += new MouseButtonEventHandler(MainView_MouseDoubleClick);
            this.DataContext = new ViewModels.MainViewModel();
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

        private void Ribbon_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.DragMove();
        }

        private void tvItemCompanyData_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            grdMainControl.Children.Clear();
            if (sumaryView == null)
                sumaryView = new SumaryView();
            grdMainControl.Children.Add(this.sumaryView);
        }

        private void tvItemEmail_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            grdMainControl.Children.Clear();
            if (mapView == null)
                mapView = new MapsView();
            grdMainControl.Children.Add(mapView);
        }

        #endregion
    }
}
