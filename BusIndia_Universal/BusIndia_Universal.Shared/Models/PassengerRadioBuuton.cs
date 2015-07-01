using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusIndia_Universal.Models
{
    class PassengerRadioBuuton
    {

    }

    public class SelectAgeRadio : INotifyPropertyChanged
    {
        public int Name { get; set; }
        public bool Selected { get; set; }
        public string Corp { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PassengerIn : INotifyPropertyChanged
    {
        private string _PassengerName ;
        private string _PassengerAge;
        private string _PassengerGender ;
       
        public string PassengerName
        {
            get { return _PassengerName; }
            set
            {
                _PassengerName = value;               
                OnPropertyChanged("PassengerName");
            }
        }

        private string _NAMEs = "Name One";

        public string NAMEs
        {
            get { return _NAMEs; }
            set
            {
                _NAMEs = value;
                OnPropertyChanged("NAMEs");
            }
        }


        public string PassengerAge
        {
            get { return _PassengerAge; }
            set
            {
                _PassengerAge = value;
                OnPropertyChanged("PassengerAge");
            }
        }
        public string PassengerGender
        {
            get { return _PassengerGender; }
            set
            {
                _PassengerGender = value;
                OnPropertyChanged("PassengerGender");
            }
        }
      

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PassengerRequiredfield : INotifyPropertyChanged
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

        
        private string _Passenger;
        public string Passenger
        {
            get { return _Passenger; }
            set
            {
                _Passenger = value;
                OnPropertyChanged("Passenger");
            }
        }

        private string _PassengerPlaceholder;
        public string PassengerPlaceholder
        {
            get { return _PassengerPlaceholder; }
            set
            {
                _PassengerPlaceholder = value;
                OnPropertyChanged("_PassengerPlaceholder");
            }
        }

        private string _Age;
        public string Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                OnPropertyChanged("Age");
            }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                OnPropertyChanged("Gender");
            }
        }
        
        private bool _Main;
        public bool Main
        {
            get { return _Main; }
            set
            {
                _Main = value;
                OnPropertyChanged("Main");
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

        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                _Mobile = value;
                OnPropertyChanged("Mobile");
            }
        }
        private string _IDProof;
        public string IDProof
        {
            get { return _IDProof; }
            set
            {
                _IDProof = value;
                OnPropertyChanged("IDProof");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
         
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class HotelSearchRoom : INotifyPropertyChanged
    {

        private string _RoomNumber;

        public string RoomNumber
        {
            get { return _RoomNumber; }
            set
            {
                _RoomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }



        private string _PassengerPlaceholder;
        public string PassengerPlaceholder
        {
            get { return _PassengerPlaceholder; }
            set
            {
                _PassengerPlaceholder = value;
                OnPropertyChanged("_PassengerPlaceholder");
            }
        }

               public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {

            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
