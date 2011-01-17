using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using VMS.Client.Model.Driver;

namespace VMS.Client.Model.Fleet
{
    public class FleetModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Properties

        private long _id;
        public long ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private DriverModel _foreMan;
        public DriverModel ForeMan
        {
            get
            {
                return _foreMan;
            }
            set
            {
                if (_foreMan != value)
                {
                    _foreMan = value;
                    OnPropertyChanged("ForeMain");
                }
            }
        }

        private DriverModel _subForeMan;
        public DriverModel SubForeMan
        {
            get
            {
                return _subForeMan;
            }
            set
            {
                if (_subForeMan != value)
                {
                    _subForeMan = value;
                    OnPropertyChanged("SubForeMan");
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
