using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusIndia_Universal.Models
{
   public class PassengerInfoDetails : INotifyPropertyChanged
    {
       private List<string> _passengerName = new List<string>();
       public List<string> passengerName
       {
           get { return _passengerName; }
           set
           {
               _passengerName = value;
               OnPropertyChanged("passengerName");
           }
       }
       private List<string> _passengerAge= new List<string>();
       public List<string> passengerAge
       {
           get { return _passengerAge; }
           set
           {
               _passengerAge = value;
               OnPropertyChanged("passengerAge");
           }
       }

       private List<string> _passengerGender = new List<string>();
       public List<string> passengerGender
       {
           get { return _passengerGender; }
           set
           {
               _passengerGender = value;
               OnPropertyChanged("passengerGender");
           }
       }

       public string Email { get; set; }
       public string Mobile { get; set; }
       public string IDProof { get; set; }

       public string TotalAmount { get; set; }
     
       public event PropertyChangedEventHandler PropertyChanged;
       //private void NotifyPropertyChanged(string property)
       //{
       //    if (PropertyChanged != null)
       //    {
       //        PropertyChanged(this, new PropertyChangedEventArgs(property));
       //    }
       //}

       //   public event PropertyChangedEventHandler PropertyChanged;

       protected void OnPropertyChanged(string propertyName)
       {
           // Send an event notification that the property changed
           // This allows the UI to know when one of the items changes
           if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
    }
}
