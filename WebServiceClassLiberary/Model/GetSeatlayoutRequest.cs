using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceClassLiberary.Model
{
   public class GetSeatlayoutRequest
    {
        private string _placeIDFrom;
        private string _placeIDto;
        private string _classID;
        private string _classLayoutID;
        private string _className;
        private string _serviceID;
        private string _journeyDate;
        private string _placeNameFrom;
        private string _placeNameTo;
        private string _placeCodeFrom;
        private string _placeCodeTo;
        private string _placeCodestuFromPlace;
        private string _placeIDstuFromPlace;
        private string _placeNamestuFromPlace;
        private string _placeCodestuToPlace;
        private string _placeIDstuToPlace;
        private string _placeNamestuToPlace;
        private string _totalPassengers;
        private string _studID;

        public string studID
        {
            get { return _studID; }
            set
            {
                _studID = value;
            }
        }


        public string totalPassengers
        {
            get { return _totalPassengers; }
            set
            {
                _totalPassengers = value;
            }
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

        public string journeyDate
        {
            get { return _journeyDate; }
            set { _journeyDate = value; }
        }
        public string serviceID
        {
            get { return _serviceID; }
            set { _serviceID = value; }
        }
        public string placeNameFrom
        {
            get { return _placeNameFrom; }
            set { _placeNameFrom = value; }
        }
        public string placeNameTo
        {
            get { return _placeNameTo; }
            set { _placeNameTo = value; }
        }

        public string placeCodeFrom
        {
            get { return _placeCodeFrom; }
            set { _placeCodeFrom = value; }
        }


        public string placeCodeTo
        {
            get { return _placeCodeTo; }
            set { _placeCodeTo = value; }
        }
       
        public string placeIDFrom
        {
            get { return _placeIDFrom; }
            set { _placeIDFrom = value; }
        }
        public string placeIDto
        {
            get { return _placeIDto; }
            set { _placeIDto = value; }
        }
        public string classID
        {
            get { return _classID; }
            set
            {
                _classID = value;
            }
        }
        public string classLayoutID
        {
            get { return _classLayoutID; }
            set { _classLayoutID = value; }
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
