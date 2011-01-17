using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using VMS.Client.ViewModel.Summary;

namespace VMS.Client.View.Component.Summary
{
    /// <summary>
    /// Interaction logic for LowInventoriesControl.xaml
    /// </summary>
    public partial class VehicleView : UserControl
    {
        public VehicleViewModel vehicelViewModel = null;
        public VehicleView()
        {
            InitializeComponent();
            vehicelViewModel = new VehicleViewModel();
            this.DataContext = vehicelViewModel;
        }
    }
}
