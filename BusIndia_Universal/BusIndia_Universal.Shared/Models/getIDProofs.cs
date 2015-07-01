using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusIndia_Universal.Models
{
   public class getIDProofs : INotifyPropertyChanged
    {
        private string _idProofID;
        private string _idProofName;

        public string idProofID
        {
            get { return _idProofID; }
            set { _idProofID = value; }
        }
        public string idProofName
        {
            get { return _idProofName; }
            set { _idProofName = value;
            OnPropertyChanged("idProofName");
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
