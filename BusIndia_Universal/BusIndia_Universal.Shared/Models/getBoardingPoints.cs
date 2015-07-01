using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
   public  class getBoardingPoints : INotifyPropertyChanged
    {
        private string _platformNo;
        private string _pointID;
        private string _pointName;
        private string _Time;
        private string _Type;

        public string platformNo
        {
            get { return _platformNo; }
            set { _platformNo = value; }
        }
        public string pointID
        {
            get { return _pointID; }
            set { _pointID = value; }
        }
        public string pointName
        {
            get { return _pointName; }
            set { 
                _pointName = value;
                OnPropertyChanged("pointName");
                }
        }
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public string Type
        {
            get { return _Type; }
            set {_Type = value; }
        }
        string _Lable;

        public string Lable
        {
            get { return _Lable; }
            set { _Lable = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   public class ValidationSelectPoint : INotifyPropertyChanged
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
