using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusIndia_Universal.Models
{
    public class getSeatlayout : INotifyPropertyChanged
    {
        private string _availableSeatNos;
        private string _bookedSeatNos;
        private string _conductorSeatNo;
        private string _ladiesAvailableSeatNos;
        private string _ladiesBookedSeatNos;
        private string _maxColCount;
        private string _maxRowCount;
      
        private string _totalSeats;


        private string _busID;
        private string _distance;
        private string _endPoint;
        private string _startPoint;
        private string _placeCodestuFromPlace;
        private string _placeIDstuFromPlace;
        private string _placeNamestuFromPlace;
        private string _placeCodestuToPlace;
        private string _placeIDstuToPlace;
        private string _placeNamestuToPlace;

        private string _message;
        private string _statusCode;


           private string _SelectedSeat;
        private string _SelectedSeatList;


        public string SelectedSeat
        {
            get { return _SelectedSeat; }
            set
            {
                _SelectedSeat = value;
            }
        }
        public string SelectedSeatList
        {
            get { return _SelectedSeatList; }
            set { _SelectedSeatList = value; }
        }


        public string busID
        {
            get { return _busID; }
            set { _busID = value; }
        }
        public string distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        public string endPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }
        public string startPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }
        public string placeCodestuFromPlace
        {
            get { return _placeCodestuFromPlace; }
            set
            {
                _placeCodestuFromPlace = value;
            }
        }
        public string placeIDstuFromPlace
        {
            get { return _placeIDstuFromPlace; }
            set { _placeIDstuFromPlace = value; }
        }
        public string placeNamestuFromPlace
        {
            get { return _placeNamestuFromPlace; }
            set { _placeNamestuFromPlace = value; }
        }
        public string placeCodestuToPlace
        {
            get { return _placeCodestuToPlace; }
            set { _placeCodestuToPlace = value; }
        }
        public string placeIDstuToPlace
        {
            get { return _placeIDstuToPlace; }
            set { _placeIDstuToPlace = value; }
        }
        public string placeNamestuToPlace
        {
            get { return _placeNamestuToPlace; }
            set { _placeNamestuToPlace = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string statusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }


        public string availableSeatNos
        {
            get { return _availableSeatNos; }
            set { _availableSeatNos = value; }
        }
        public string bookedSeatNos
        {
            get { return _bookedSeatNos; }
            set { _bookedSeatNos = value; }
        }
        public string conductorSeatNo
        {
            get { return _conductorSeatNo; }
            set { _conductorSeatNo = value; }
        }
        public string ladiesAvailableSeatNos
        {
            get { return _ladiesAvailableSeatNos; }
            set { _ladiesAvailableSeatNos = value; }
        }
        public string ladiesBookedSeatNos
        {
            get { return _ladiesBookedSeatNos; }
            set
            {
                _ladiesBookedSeatNos = value;
            }
        }
        public string maxColCount
        {
            get { return _maxColCount; }
            set { _maxColCount = value; }
        }
        public string maxRowCount
        {
            get { return _maxRowCount; }
            set { _maxRowCount = value; }
        }
       
        

        protected void OnPropertyChanged(string propertyName)
        {
          
            if (!String.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _column;
        private string _quota;
        private string _row;
        private string _seatNo;
        private string _seatStatus;
        private string _type;
        public string column
        {
            get { return _column; }
            set { _column = value; }
        }
        public string quota
        {
            get { return _quota; }
            set { _quota = value; }
        }
        public string row
        {
            get { return _row; }
            set
            {
                _row = value;
            }
        }
        public string seatNo
        {
            get { return _seatNo; }
            set { _seatNo = value; }
        }
        public string seatStatus
        {
            get { return _seatStatus; }
            set { _seatStatus = value; }
        }
       
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string totalSeats
        {
            get { return _totalSeats; }
            set { _totalSeats = value; }
        }

        private List<SeatDesc> _seats = new List<SeatDesc>();
        public List<SeatDesc> seats
        {
            get { return _seats; }
            set
            {
                _seats = value;
                NotifyPropertyChanged("seats");
            }
        }

        




        #region INotify Property Chnaged Event
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        } 
        #endregion
    }


    public class SeatDesc : INotifyPropertyChanged
    {
        private string _seatId;

        private string _column;
        private string _quota;
        private string _row;
        private string _seatNo;
        private string _seatStatus;
        private string _type;
        public string column
        {
            get { return _column; }
            set { _column = value; }
        }
        public string quota
        {
            get { return _quota; }
            set { _quota = value; }
        }
        public string row
        {
            get { return _row; }
            set
            {
                _row = value;
            }
        }
        public string seatNo
        {
            get { return _seatNo; }
            set { _seatNo = value; }
        }
        public string seatStatus
        {
            get { return _seatStatus; }
            set { _seatStatus = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string seatId
        {
            get { return _seatId; }
            set
            {
                _seatId = value;
                NotifyPropertyChanged("seatId");
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

    public class getSeatRowLayout : INotifyPropertyChanged
    {
        private List<getSeatlayout> _seatRowLayout= new List<getSeatlayout>();
        public List<getSeatlayout> seatRowLayout
        {
            get { return _seatRowLayout; }
            set
            {
                _seatRowLayout = value;
                NotifyPropertyChanged("seatRowLayout");
            }
        }
       
        #region INotify Property Chnaged Event
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }


    public class Visibilityss : INotifyPropertyChanged

    { 
       private bool _Isseatvisible;
        public bool Isseatvisible
        {
            get { return _Isseatvisible; }
            set { _Isseatvisible = value;
            NotifyPropertyChanged("Isseatvisible");
            }
        }
        #region INotify Property Chnaged Event
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion    
        
    }

    public class StudDetails
    {
        private string _placeCodestuFromPlace;
        private string _placeIDstuFromPlace;
        private string _placeNamestuFromPlace;
        private string _placeCodestuToPlace;
        private string _placeIDstuToPlace;
        private string _placeNamestuToPlace;
     
        public string placeCodestuFromPlace
        {
            get { return _placeCodestuFromPlace; }
            set
            {
                _placeCodestuFromPlace = value;
            }
        }
        public string placeIDstuFromPlace
        {
            get { return _placeIDstuFromPlace; }
            set { _placeIDstuFromPlace = value; }
        }
        public string placeNamestuFromPlace
        {
            get { return _placeNamestuFromPlace; }
            set { _placeNamestuFromPlace = value; }
        }
        public string placeCodestuToPlace
        {
            get { return _placeCodestuToPlace; }
            set { _placeCodestuToPlace = value; }
        }
        public string placeIDstuToPlace
        {
            get { return _placeIDstuToPlace; }
            set { _placeIDstuToPlace = value; }
        }
        public string placeNamestuToPlace
        {
            get { return _placeNamestuToPlace; }
            set { _placeNamestuToPlace = value; }
        }
    }
}
