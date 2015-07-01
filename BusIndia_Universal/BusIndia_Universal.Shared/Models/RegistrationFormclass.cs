using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal
{
    public class RegistrationFormclass : INotifyPropertyChanged
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


        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _fullName;

        public string fullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("fullName");
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
