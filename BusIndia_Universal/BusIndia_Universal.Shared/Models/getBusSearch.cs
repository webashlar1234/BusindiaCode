using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusIndia_Universal.Models
{
   
    public class getBusSearch : INotifyPropertyChanged
    {
        private string _Fromplace;
        private string _Toplace;
        private string _placeIDFrom;
        private string _placeCodeFrom;
        private string _placeIDTo;
        private string _placeCodeTo;

        private string _DateDepart;
        private string _DateReturn;

        public string DateReturn
        {
            get { return _DateReturn; }
            set { _DateReturn = value; }
        }
        public string Fromplace
        {
            get { return _Fromplace; }
            set { _Fromplace = value; }
        }
        public string Toplace
        {
            get { return _Toplace; }
            set { _Toplace = value; }
        }
        public string placeIDFrom
        {
            get { return _placeIDFrom; }
            set { _placeIDFrom = value; }
        }

        public string placeCodeFrom
        {
            get { return _placeCodeFrom; }
            set { _placeCodeFrom = value; }
        }

        public string placeIDTo
        {
            get { return _placeIDTo; }
            set { _placeIDTo = value; }
        }

        public string placeCodeTo
        {
            get { return _placeCodeTo; }
            set { _placeCodeTo = value; }
        }

        public string Date
        {
            get { return _DateDepart; }
            set { _DateDepart = value; NotifyPropertyChanged("PlaceName"); }
        }

        private string _Label;

        public string Label
        {
            get { return _Label; }
            set
            {
                _Label = value;

            }
        }
        private string _LabelReturn;
        public string LabelReturn
        {
            get { return _LabelReturn; }
            set
            {
                _LabelReturn = value;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
