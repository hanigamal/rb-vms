using System.Windows.Controls;
using VMS.Client.ViewModel.Summary;

namespace VMS.Client.View.Component.Summary
{
    /// <summary>
    /// Interaction logic for EmployeeDetailView.xaml
    /// </summary>
    public partial class DriverView : UserControl
    {
        public DriverViewModel driverViewModel= null;
        public DriverView()
        {
            InitializeComponent();
            driverViewModel = new DriverViewModel();
            this.DataContext = driverViewModel;
        }
    }
}
