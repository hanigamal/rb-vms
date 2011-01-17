using System.Windows;
using System.Windows.Controls;
using VMS.Client.ViewModel.Summary;

namespace VMS.Client.View.Component.Summary
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class FleetView : UserControl
    {
        public FleetViewModel fleetViewModel = null;

        #region Fields

        private GridLength _gridLength;

        #endregion

        #region Constructors

        public FleetView()
        {
            InitializeComponent();
            fleetViewModel = new FleetViewModel();
            this.DataContext = fleetViewModel;
            this.lstFleet.SelectionChanged += new SelectionChangedEventHandler(lstFleet_SelectionChanged);
        }

        void lstFleet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        #endregion

        #region Events
        #endregion
    }
}
