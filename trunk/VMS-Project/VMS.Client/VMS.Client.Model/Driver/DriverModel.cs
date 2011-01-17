using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace VMS.Client.Model.Driver
{
    public class DriverModel:INotifyPropertyChanged, IDataErrorInfo
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

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private DateTime _birthDay;
        public DateTime BirthDay
        {
            get
            {
                return _birthDay;
            }
            set
            {
                if (_birthDay != value)
                {
                    _birthDay = value;
                    OnPropertyChanged("BirthDay");
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
