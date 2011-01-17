using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using VMS.Client.Model.Vehicle;
using VMS.Client.Database;

namespace VMS.Client.ViewModel.Summary
{
    public class VehicleViewModel:ViewModelBase
    {
        #region Constructor

        public VehicleViewModel()
        {
            GetAllVehicle();
            viewVehicle = CollectionViewSource.GetDefaultView(Vehicles);
        }

        #endregion

        #region Properties

        private long _fleetID;
        public long FleetID
        {
            get
            {
                return _fleetID;
            }
            set
            {
                if (_fleetID != value)
                {
                    _fleetID = value;
                    OnPropertyChanged("FleetID");
                    viewVehicle.Filter = FilterByFleet;
                }
            }
        }

        public ICollectionView viewVehicle;

        private ObservableCollection<VehicleModel> _vehilces = new ObservableCollection<VehicleModel>();
        public ObservableCollection<VehicleModel> Vehicles
        {
            get
            {
                return _vehilces;
            }
        }

        #endregion

        #region Method

        private void GetAllVehicle()
        {
            _vehilces.Clear();
            try
            {
                vmsLinqDataContext datacontext = new vmsLinqDataContext();
                var query = from v in datacontext.Vehicles
                            select v;
                VehicleModel model;
                foreach (var data in query)
                {
                    model = new VehicleModel();
                    model.NumPlate = data.NumPlate;
                    model.EIN = data.EIN;
                    model.VIN = data.VIN;
                    _vehilces.Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool FilterByFleet(object item)
        {
            VehicleModel model = item as VehicleModel;
            if (model.FleetID == FleetID)
                return true;
            else
                return false;
        }

        #endregion
    }
}
