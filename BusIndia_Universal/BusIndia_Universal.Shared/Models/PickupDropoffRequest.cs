using System;
using System.Collections.Generic;
using System.Text;

namespace BusIndia_Universal.Models
{
    public class PickupDropoffRequest
    {
        private string _pickupPoint;
        private string _dropOffPoint;
        private string _pickupTime;
        private string _dropOffTime;
        private string _numberOfSeats;

        public string pickupPoint
        {
            get { return _pickupPoint; }
            set { _pickupPoint = value; }
        }
        public string dropOffPoint
        {
            get { return _dropOffPoint; }
            set { _dropOffPoint = value; }
        }
        public string pickupTime
        {
            get { return _pickupTime; }
            set
            {
                _pickupTime = value;
                
            }
        }
        public string dropOffTime
        {
            get { return _dropOffTime; }
            set { _dropOffTime = value; }
        }
        public string numberOfSeats
        {
            get { return _numberOfSeats; }
            set { _numberOfSeats = value; }
        }
        string _seatsType;

        public string seatsType
        {
            get { return _seatsType; }
            set { _seatsType = value; }
        }
    }
}
