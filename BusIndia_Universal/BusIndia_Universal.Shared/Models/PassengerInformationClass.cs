using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
    public class PassengerInformationClass : INotifyPropertyChanged
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


        private string _Passenger1;

        public string Passenger1
        {
            get { return _Passenger1; }
            set
            {
                _Passenger1 = value;
                OnPropertyChanged("Passenger1");
            }
        }

        private int _Passenger1Age;

        public int Passenger1Age
        {
            get { return _Passenger1Age; }
            set
            {
                _Passenger1Age = value;
                OnPropertyChanged("Passenger1Age");
            }
        }

        private string _Passenger1Gender;

        public string Passenger1Gender
        {
            get { return _Passenger1Gender; }
            set
            {
                _Passenger1Gender = value;
                OnPropertyChanged("Passenger1Gender");
            }
        }

        private string _Passenger2;

        public string Passenger2
        {
            get { return _Passenger2; }
            set
            {
                _Passenger2 = value;
                OnPropertyChanged("Passenger2");
            }
        }

        private int _Passenger2Age;

        public int Passenger2Age
        {
            get { return _Passenger2Age; }
            set
            {
                _Passenger2Age = value;
                OnPropertyChanged("Passenger2Age");
            }
        }

        private string _Passenger2Gender;

        public string Passenger2Gender
        {
            get { return _Passenger2Gender; }
            set
            {
                _Passenger2Gender = value;
                OnPropertyChanged("Passenger2Gender");
            }
        }
        private int _Mobile1;
        public int Mobile1
        {
            get { return _Mobile1; }
            set
            {
                _Mobile1 = value;
                OnPropertyChanged("Mobile1");
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
