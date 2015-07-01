using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceClassLiberary.Model
{
   public class getBoardingPointsRequest
    {
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

        private string _journeyDate;
        public string journeyDate
        {
            get { return _journeyDate; }
            set { _journeyDate = value; }
        }


        private string _placeIDFrom;
        public string placeIDFrom
        {
            get { return _placeIDFrom; }
            set { _placeIDFrom = value; }
        }

        private string _placeIDto;
        public string placeIDto
        {
            get { return _placeIDto; }
            set { _placeIDto = value; }
        }
        public string _placeNameFrom;
        public string placeNameFrom
        {
            get { return _placeNameFrom; }
            set { _placeNameFrom = value; }
        }

        public string _placeNameTo;
        public string placeNameTo
        {
            get { return _placeNameTo; }
            set { _placeNameTo = value; }
        }
        public string _placeCodeFrom;
        public string placeCodeFrom
        {
            get { return _placeCodeFrom; }
            set { _placeCodeFrom = value; }
        }

        public string _placeCodeTo;
        public string placeCodeTo
        {
            get { return _placeCodeTo; }
            set { _placeCodeTo = value; }
        }

        private string _serviceID;
        public string serviceID
        {
            get { return _serviceID; }
            set { _serviceID = value; }
        }

        private string _stulID;
        public string stulID
        {
            get { return _stulID; }
            set
            {
                _stulID = value;
            }
        }


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
