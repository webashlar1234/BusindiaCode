using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal
{
    class TripSearchModel : INotifyPropertyChanged
    {
        private string _HotelName;

        public string HotelName
        {
            get { return _HotelName; }
            set
            {
                _HotelName = value;
                OnPropertyChanged("HotelName");
            }
        }

        private string _via;

        public string via
        {
            get { return _via; }
            set
            {
                _via = value;
                OnPropertyChanged("via");
            }
        }

        private int _ammount;

        public int ammount
        {
            get { return _ammount; }
            set
            {
                _ammount = value;
                OnPropertyChanged("ammount");
            }
        }

        private DateTime _starttime;

        public DateTime starttime
        {
            get { return _starttime; }
            set
            {
                _starttime = value;
                OnPropertyChanged("starttime");
            }
        }

        private DateTime _endtime;

        public DateTime endtime
        {
            get { return _endtime; }
            set
            {
                _endtime = value;
                OnPropertyChanged("endtime");
            }
        }

        private int _seatsavailable;

        public int seatsavailable
        {
            get { return _seatsavailable; }
            set
            {
                _seatsavailable = value;
                OnPropertyChanged("seatsavailable");
            }
        }

        private string _logoURI;

        public string logoURI
        {
            get { return _logoURI; }
            set
            {
                _logoURI = value;
                OnPropertyChanged("logoURI");
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
