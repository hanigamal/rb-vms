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
using System.Windows.Controls.Primitives;

namespace VMS.Client.View.UserControls
{
    /// <summary>
    /// Interaction logic for ContainerView.xaml
    /// </summary>
    public partial class ContainerViewUserControl : UserControl
    {
        //public Grid childGrid = new Grid();
        //public ToggleButton MaxMin = new ToggleButton();
        public ContainerViewUserControl()
        {
            InitializeComponent();
            
            //MaxMin.Width = 20;
            //MaxMin.Height = 20;
            //MaxMin.VerticalAlignment = VerticalAlignment.Top;
            //MaxMin.HorizontalAlignment = HorizontalAlignment.Right;
            //MainGrid.Children.Add(MaxMin);
            //MainGrid.Children.Add(childGrid);
        }
    }
}
