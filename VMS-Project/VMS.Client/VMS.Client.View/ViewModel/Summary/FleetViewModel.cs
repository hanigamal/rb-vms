using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.Client.Database;
using System.Windows;
using VMS.Client.Model.Fleet;

namespace VMS.Client.ViewModel.Summary
{
    public class FleetViewModel:ViewModelBase
    {
        #region Constructor

        public FleetViewModel()
        {
            GetData();
        }
        
        #endregion

        #region Properties


        private FleetModel _selectedFleet = new FleetModel();
        public FleetModel SelectedFleet
        {
            get
            {
                return _selectedFleet;
            }
            set
            {
                if (_selectedFleet != value)
                {
                    _selectedFleet = value;
                    OnPropertyChanged("SelectedFleet");
                }
            }
        }

        private List<FleetModel> _fleetModels = new List<FleetModel>();
        public List<FleetModel> FleetModels
        {
            get
            {
                return _fleetModels;
            }
        }

        #endregion

        #region Method

        private void GetData()
        {
            FleetModels.Clear();
            try
            {
                vmsLinqDataContext datacontext = new vmsLinqDataContext();
                var query = from f in datacontext.Fleets
                            select f;
                FleetModel model;
                foreach (var data in query)
                {
                    model = new FleetModel();
                    model.ID = data.ID;
                    model.Name = data.Name;
                    FleetModels.Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion
    }
}
