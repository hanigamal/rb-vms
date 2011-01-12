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
using System.Windows.Media.Animation;

namespace DemoPOS
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        #region Fields

        private GridLength _gridLength;

        #endregion

        #region Constructors

        public ProductsControl()
        {
            InitializeComponent();
            this.myMainGridFirstColumn.Height = new GridLength(myMainGridFirstColumn.MinHeight);
            this.btnMinmaxAnimation.Checked += new RoutedEventHandler(btnMinmaxAnimation_Checked);
            this.btnMinmaxAnimation.Unchecked += new RoutedEventHandler(btnMinmaxAnimation_Unchecked);
            this.gridSplitter.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(gridSplitter_DragDelta);
        }

        #endregion

        #region Events

        private void gridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (this.myMainGridFirstColumn.ActualHeight <= this.myMainGridFirstColumn.MinHeight)
                this.btnMinmaxAnimation.IsChecked = false;
            else
                this.btnMinmaxAnimation.IsChecked = true;
            this.myMainGridFirstColumn.MaxHeight = this.grdProduct.ActualHeight / 1.5;
        }

        private void btnMinmaxAnimation_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.myMainGridFirstColumn.ActualHeight > this.myMainGridFirstColumn.MinHeight)
                _gridLength = this.myMainGridFirstColumn.Height;
            this.myMainGridFirstColumn.Height = new GridLength(this.myMainGridFirstColumn.MinHeight);
            this.grdButtonProfile.Visibility = Visibility.Collapsed;
            this.grdButtonVender.Visibility = Visibility.Collapsed;
        }

        private void btnMinmaxAnimation_Checked(object sender, RoutedEventArgs e)
        {
            if (!gridSplitter.IsDragging && _gridLength == (GridLength)(new GridLengthConverter()).ConvertFromString("Auto"))
                this.myMainGridFirstColumn.Height = (GridLength)(new GridLengthConverter()).ConvertFromString(150.ToString());
            else
                this.myMainGridFirstColumn.Height = _gridLength;
            this.grdButtonProfile.Visibility = Visibility.Visible;
            this.grdButtonVender.Visibility = Visibility.Visible;
        }

        #endregion
    }
}
