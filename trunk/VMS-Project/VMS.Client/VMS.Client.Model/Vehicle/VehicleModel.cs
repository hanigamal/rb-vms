using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace VMS.Client.Model.Vehicle
{
    public class VehicleModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Properties

        private string _numPlate;
        public string NumPlate
        {
            get
            {
                return _numPlate;
            }
            set
            {
                if (_numPlate != value)
                {
                    _numPlate = value;
                    OnPropertyChanged("NumPlate");
                }
            }
        }

        private string _ein;
        public string EIN
        {
            get
            {
                return _ein;
            }
            set
            {
                if (_ein != value)
                {
                    _ein = value;
                    OnPropertyChanged("EIN");
                }
            }
        }

        private string _vin;
        public string VIN
        {
            get
            {
                return _vin;
            }
            set
            {
                if (_vin != value)
                {
                    _vin = value;
                    OnPropertyChanged("VIN");
                }
            }
        }

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
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected Dictionary<string, string> _errors = new Dictionary<string, string>();
        public IDictionary<string, string> Errors
        {
            get
            {
                return _errors;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string errorMessage = string.Empty;
                this.Errors.Remove(columnName);

                switch (columnName)
                {
                    default:
                        break;
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    this.Errors.Add(columnName, errorMessage);
                }
                return errorMessage;
            }
        }


        #endregion
    }
}
