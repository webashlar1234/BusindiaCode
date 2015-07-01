using System;
using System.Collections.Generic;
using System.Text;

namespace BusIndia_Universal.Models
{
    public class filterBus
    {
        private string _minTime;

        public string minTime
        {
            get { return _minTime; }
            set { _minTime = value; }
        }


        private string _maxTime;

        public string maxTime
        {
            get { return _maxTime; }
            set { _maxTime = value; }
        }

        private string _minPrice;
        public string minPrice
        {
            get { return _minPrice; }
            set { _minPrice = value; }
        }
        public string _maxPrice;
        public string maxPrice
        {
            get { return _maxPrice; }
            set { _maxPrice = value; }
        }

        public string _corpAll;
        public string corpAll
        {
            get { return _corpAll; }
            set { _corpAll = value; }
        }
        public string _GSRTC;
        public string GSRTC
        {
            get { return _GSRTC; }
            set { _GSRTC = value; }
        }

        public string _classAll;
        public string classAll
        {
            get { return _classAll; }
            set { _classAll = value; }
        }


        private string _franchUserID;


        public string franchUserID
        {
            get { return _franchUserID; }
            set { _franchUserID = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _userID;

        public string userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userKey;
        public string userKey
        {
            get { return _userKey; }
            set { _userKey = value; }
        }

        private string _userName;

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }


        private string _userRole;
        public string userRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }

        private string _userStatus;
        public string userStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }
        private string _userType;

        public string userType
        {
            get { return _userType; }
            set { _userType = value; }
        }
    }
}
