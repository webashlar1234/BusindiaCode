using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusIndia_Universal.Models;

namespace BusIndia_Universal.Models
{
    public class CabBookingSummaryClass : INotifyPropertyChanged
    {
        private string _errorMessage;

        public string errorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("errorMessage");
            }
        }


        private string _City;

        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        private string _Street;

        public string Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                OnPropertyChanged("Street");
            }
        }

        private string _FlatNumber;

        public string FlatNumber
        {
            get { return _FlatNumber; }
            set
            {
                _FlatNumber = value;
                OnPropertyChanged("FlatNumber");
            }
        }

        private string _State;

        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                OnPropertyChanged("State");
            }
        }

        private int _Phone;

        public int Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                OnPropertyChanged("Phone");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            // Send an event notification that the property changed
            // This allows the UI to know when one of the items changes
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
