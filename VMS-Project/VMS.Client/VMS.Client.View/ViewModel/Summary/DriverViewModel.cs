using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using VMS.Client.Database;
using VMS.Client.Model.Driver;

namespace VMS.Client.ViewModel.Summary
{
    public class DriverViewModel : ViewModelBase
    {
        public DriverViewModel()
        {
            GetAllDriver();
        }

        private ObservableCollection<DriverModel> _drivers = new ObservableCollection<DriverModel>();
        public ObservableCollection<DriverModel> Drivers
        {
            get
            {
                return _drivers;
            }
        }

        private void GetAllDriver()
        {
            _drivers.Clear();
            try
            {
                vmsLinqDataContext datacontext = new vmsLinqDataContext();
                var query = from d in datacontext.Drivers
                             select d;
                DriverModel model;
                foreach (Driver data in query)
                {
                    model = new DriverModel();
                    model.ID = data.ID;
                    model.FirstName = data.FirstName;
                    model.LastName = data.LastName;
                    model.BirthDay = Convert.ToDateTime(data.BirthDay);
                    _drivers.Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
