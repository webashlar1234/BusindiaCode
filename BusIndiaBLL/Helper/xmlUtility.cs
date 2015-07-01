using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;

namespace BusIndiaBLL.Helper
{
    public class xmlUtility
    {
        public XDocument getList(getPlaceListRequest _objgetPlaceListRequest)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetPlaceList";

            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = AppStatic.BusIndiaWebService;
                XNamespace soapenv = AppStatic.XmlSoapSchema;
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                    new XElement("franchUserID", _objgetPlaceListRequest.franchUserID),
                    new XElement("password", _objgetPlaceListRequest.password),
                    new XElement("userID", _objgetPlaceListRequest.userID),
                    new XElement("userKey", _objgetPlaceListRequest.userKey),
                    new XElement("userName", _objgetPlaceListRequest.userName),
                    new XElement("userRole", _objgetPlaceListRequest.userRole),
                    new XElement("userStatus", _objgetPlaceListRequest.userStatus),
                    new XElement("userType", _objgetPlaceListRequest.userType)
                    )
                    )
                    )
                    )
                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getservice(GetAvailableServicesRequest _objGetAvailableServicesRequest)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetAvailableServices";
            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = AppStatic.BusIndiaWebService;
                XNamespace soapenv = AppStatic.XmlSoapSchema;
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                        new XElement("biFromPlace",
                            new XElement("placeCode", _objGetAvailableServicesRequest.placeCodeFrom),
                            new XElement("placeID", _objGetAvailableServicesRequest.placeIDFrom),
                            new XElement("placeName", _objGetAvailableServicesRequest.placeNameFrom)
                            ),
                        new XElement("biToPlace",
                            new XElement("placeCode", _objGetAvailableServicesRequest.placeCodeTo),
                            new XElement("placeID", _objGetAvailableServicesRequest.placeIDto),
                            new XElement("placeName", _objGetAvailableServicesRequest.placeNameTo)
                            ),
                        new XElement("journeyDate", _objGetAvailableServicesRequest.journeyDate),
                        new XElement("wsUser",
                            new XElement("franchUserID", _objGetAvailableServicesRequest.franchUserID),
                            new XElement("password", _objGetAvailableServicesRequest.password),
                            new XElement("userID", _objGetAvailableServicesRequest.userID),
                            new XElement("userKey", _objGetAvailableServicesRequest.userKey),
                            new XElement("userName", _objGetAvailableServicesRequest.userName),
                            new XElement("userRole", _objGetAvailableServicesRequest.userRole),
                            new XElement("userStatus", _objGetAvailableServicesRequest.userStatus),
                            new XElement("userType", _objGetAvailableServicesRequest.userType)
                        )
                    )
                    )
                    )
                    )
                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getlayout(GetSeatlayoutRequest _objGetSeatlayoutRequest)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetSeatlayout";
            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = AppStatic.BusIndiaWebService;
                XNamespace soapenv = AppStatic.XmlSoapSchema;
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                        new XElement("biFromPlace",
                            new XElement("placeCode", _objGetSeatlayoutRequest.placeCodeFrom),
                            new XElement("placeID", _objGetSeatlayoutRequest.placeIDFrom),
                            new XElement("placeName", _objGetSeatlayoutRequest.placeNameFrom)
                            ),
                        new XElement("biToPlace",
                            new XElement("placeCode", _objGetSeatlayoutRequest.placeCodeTo),
                            new XElement("placeID", _objGetSeatlayoutRequest.placeIDto),
                            new XElement("placeName", _objGetSeatlayoutRequest.placeNameTo)
                            ),

                        new XElement("classID", _objGetSeatlayoutRequest.classID),
                         new XElement("classLayoutID", _objGetSeatlayoutRequest.classLayoutID),
                         new XElement("journeyDate", _objGetSeatlayoutRequest.journeyDate),
                        new XElement("serviceID", _objGetSeatlayoutRequest.serviceID),

                         new XElement("stuFromPlace",
                            new XElement("placeCode", _objGetSeatlayoutRequest.placeCodestuFromPlace),
                            new XElement("placeID", _objGetSeatlayoutRequest.placeIDstuFromPlace),
                            new XElement("placeName", _objGetSeatlayoutRequest.placeNamestuFromPlace)
                            ),
                            new XElement("stuID", _objGetSeatlayoutRequest.studID),
                        new XElement("stuToPlace",
                            new XElement("placeCode", _objGetSeatlayoutRequest.placeCodestuToPlace),
                            new XElement("placeID", _objGetSeatlayoutRequest.placeIDstuToPlace),
                            new XElement("placeName", _objGetSeatlayoutRequest.placeNamestuToPlace)
                            ),
                            new XElement("totalPassengers", _objGetSeatlayoutRequest.totalPassengers),
                        new XElement("wsUser",
                            new XElement("franchUserID", _objGetSeatlayoutRequest.franchUserID),
                            new XElement("password", _objGetSeatlayoutRequest.password),
                            new XElement("userID", _objGetSeatlayoutRequest.userID),
                            new XElement("userKey", _objGetSeatlayoutRequest.userKey),
                            new XElement("userName", _objGetSeatlayoutRequest.userName),
                            new XElement("userRole", _objGetSeatlayoutRequest.userRole),
                            new XElement("userStatus", _objGetSeatlayoutRequest.userStatus),
                            new XElement("userType", _objGetSeatlayoutRequest.userType)
                        )
                    )
                    )
                    )
                    )
                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getAvailableServicelayout(GetAvailableServicesRequest _objGetSeatlayoutRequest)
        {
            XDocument doc = null;
            XmlDocument servicesNames = new XmlDocument();
            try
            {

                doc = new XDocument(
                    new XElement("arg0",
                        new XElement("biFromPlace",
                            new XElement("placeCode", _objGetSeatlayoutRequest.placeCodeFrom),
                            new XElement("placeID", _objGetSeatlayoutRequest.placeIDFrom),
                            new XElement("placeName", _objGetSeatlayoutRequest.placeNameFrom)
                            ),
                        new XElement("biToPlace",
                            new XElement("placeCode", _objGetSeatlayoutRequest.placeCodeTo),
                            new XElement("placeID", _objGetSeatlayoutRequest.placeIDto),
                            new XElement("placeName", _objGetSeatlayoutRequest.placeNameTo)
                            ),

                         new XElement("journeyDate", _objGetSeatlayoutRequest.journeyDate),

                        new XElement("wsUser",
                            new XElement("franchUserID", _objGetSeatlayoutRequest.franchUserID),
                            new XElement("password", _objGetSeatlayoutRequest.password),
                            new XElement("userID", _objGetSeatlayoutRequest.userID),
                            new XElement("userKey", _objGetSeatlayoutRequest.userKey),
                            new XElement("userName", _objGetSeatlayoutRequest.userName),
                            new XElement("userRole", _objGetSeatlayoutRequest.userRole),
                            new XElement("userStatus", _objGetSeatlayoutRequest.userStatus),
                            new XElement("userType", _objGetSeatlayoutRequest.userType)
                        )
                    )

                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getBoardingPoint(getBoardingPointsRequest _objgetBoardingPointsRequest)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetBoardingPoints";

            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = AppStatic.BusIndiaWebService;
                XNamespace soapenv = AppStatic.XmlSoapSchema;
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                         new XElement("biFromPlace",
                            new XElement("placeCode", _objgetBoardingPointsRequest.placeCodeFrom),
                            new XElement("placeID", _objgetBoardingPointsRequest.placeIDFrom),
                            new XElement("placeName", _objgetBoardingPointsRequest.placeNameFrom)
                            ),
                        new XElement("biToPlace",
                            new XElement("placeCode", _objgetBoardingPointsRequest.placeCodeTo),
                            new XElement("placeID", _objgetBoardingPointsRequest.placeIDto),
                            new XElement("placeName", _objgetBoardingPointsRequest.placeNameTo)
                            ),
                             new XElement("journeyDate", _objgetBoardingPointsRequest.journeyDate),
                             new XElement("serviceID", _objgetBoardingPointsRequest.serviceID),
                         new XElement("stuFromPlace",
                            new XElement("placeCode", _objgetBoardingPointsRequest.placeCodestuFromPlace),
                            new XElement("placeID", _objgetBoardingPointsRequest.placeIDstuFromPlace),
                            new XElement("placeName", _objgetBoardingPointsRequest.placeNamestuFromPlace)
                            ),
                            new XElement("stuID", _objgetBoardingPointsRequest.stulID),
                         new XElement("stuToPlace",
                            new XElement("placeCode", _objgetBoardingPointsRequest.placeCodestuToPlace),
                            new XElement("placeID", _objgetBoardingPointsRequest.placeIDstuToPlace),
                            new XElement("placeName", _objgetBoardingPointsRequest.placeNamestuToPlace)
                            ),
                    new XElement("wsUser",
                            new XElement("franchUserID", _objgetBoardingPointsRequest.franchUserID),
                            new XElement("password", _objgetBoardingPointsRequest.password),
                            new XElement("userID", _objgetBoardingPointsRequest.userID),
                            new XElement("userKey", _objgetBoardingPointsRequest.userKey),
                            new XElement("userName", _objgetBoardingPointsRequest.userName),
                            new XElement("userRole", _objgetBoardingPointsRequest.userRole),
                            new XElement("userStatus", _objgetBoardingPointsRequest.userStatus),
                            new XElement("userType", _objgetBoardingPointsRequest.userType)
                    )
                    )
                    )
                    )
                    )

                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getIDProof(getIDProofsRequest _objgetIDProofsRequest)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "GetIDProofs";

            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = AppStatic.BusIndiaWebService;
                XNamespace soapenv = AppStatic.XmlSoapSchema;
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",
                    new XElement("stuIDs", _objgetIDProofsRequest.studID),
                    new XElement("wsUser",
                    new XElement("franchUserID", _objgetIDProofsRequest.franchUserID),
                    new XElement("password", _objgetIDProofsRequest.password),
                    new XElement("userID", _objgetIDProofsRequest.userID),
                    new XElement("userKey", _objgetIDProofsRequest.userKey),
                    new XElement("userName", _objgetIDProofsRequest.userName),
                    new XElement("userRole", _objgetIDProofsRequest.userRole),
                    new XElement("userStatus", _objgetIDProofsRequest.userStatus),
                    new XElement("userType", _objgetIDProofsRequest.userType)
                    )
                    )
                    )
                    )
                    )

                );
            }
            catch (Exception ex)
            {
            }
            return doc;
        }

        public XDocument getTentativeBookings(getTentativeBookingsRequest _objgetTBReq)
        {
            XDocument doc = null;
            XElement root = null;
            string servicename = "TentativeBookings";

            XmlDocument servicesNames = new XmlDocument();
            try
            {
                XNamespace fc = AppStatic.BusIndiaWebService;
                XNamespace soapenv = AppStatic.XmlSoapSchema;
                doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"),
                root = new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "com", fc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv.NamespaceName),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(fc + servicename,
                    new XElement("arg0",

                         new XElement("seatBlock",
                         new XElement("arrivalDate", _objgetTBReq.arrivalDate),
                         new XElement("arrivalTime", _objgetTBReq.arrivalTime),
                         new XElement("biFromPlace",
                            new XElement("placeCode", _objgetTBReq.placeCodeFrom),
                            new XElement("placeID", _objgetTBReq.placeIDFrom),
                            new XElement("placeName", _objgetTBReq.placeNameFrom)
                            ),
                         new XElement("biToPlace",
                            new XElement("placeCode", _objgetTBReq.placeCodeTo),
                            new XElement("placeID", _objgetTBReq.placeIDto),
                            new XElement("placeName", _objgetTBReq.placeNameTo)
                            ),
                             new XElement("biWSClientRefNo", _objgetTBReq.biWSClientRefNo),

                         new XElement("boardingPoint",
                            new XElement("address", _objgetTBReq.addressB),
                            new XElement("contactName", _objgetTBReq.contactNameB),
                            new XElement("contactNumbers", _objgetTBReq.contactNumbersB),
                            new XElement("landmark", _objgetTBReq.landmarkB),
                            new XElement("platformNo", _objgetTBReq.platformNoB),
                            new XElement("pointID", _objgetTBReq.pointIDB),
                            new XElement("pointName", _objgetTBReq.pointNameB),
                            new XElement("time", _objgetTBReq.TimeB),
                            new XElement("type", _objgetTBReq.TypeB)

                            ),
                            new XElement("classID", _objgetTBReq.classID),
                            new XElement("classLayoutID", _objgetTBReq.classLayoutID),
                            new XElement("className", _objgetTBReq.className),
                            new XElement("corpCode", _objgetTBReq.corpCode),
                            new XElement("departureTime", _objgetTBReq.departureTime),

                         new XElement("dropOffPoint",
                            new XElement("address", _objgetTBReq.addressD),
                            new XElement("contactName", _objgetTBReq.contactNameD),
                            new XElement("contactNumbers", _objgetTBReq.contactNumbersD),
                            new XElement("landmark", _objgetTBReq.LandmarkD),
                            new XElement("platformNo", _objgetTBReq.platformNoD),
                            new XElement("pointID", _objgetTBReq.pointIDD),
                            new XElement("pointName", _objgetTBReq.pointNameD),
                            new XElement("time", _objgetTBReq.TimeD),
                            new XElement("type", _objgetTBReq.TypeD)
                          ),
                            new XElement("idProofLookupID", _objgetTBReq.idProofLookupID),
                            new XElement("idProofName", _objgetTBReq.idProofName),
                            new XElement("idProofReference", _objgetTBReq.idProofReference),
                            new XElement("journeyDate", _objgetTBReq.journeyDate),

                        new XElement("passengerAddress",
                            new XElement("address", _objgetTBReq.addressPass),
                            new XElement("city", _objgetTBReq.CityPass),
                            new XElement("email", _objgetTBReq.emailPass),
                            new XElement("mobileNo", _objgetTBReq.mobileNoPass),
                            new XElement("phoneNo", _objgetTBReq.phoneNoPass),
                            new XElement("pincode", _objgetTBReq.PincodePass)

                          ),
                            new XElement("returnServiceID", _objgetTBReq.returnServiceID),
                            new XElement("returnStuID", _objgetTBReq.returnStuID),
                            new XElement("routeNo", _objgetTBReq.routeNo),

                        new XElement("seatBlockIDs",
                            new XElement("seatBlockID", _objgetTBReq.seatBlockID)

                          ),
                            new XElement("seatBlockMessage", _objgetTBReq.seatBlockMessage),
                            new XElement("seatBlockStatus", _objgetTBReq.seatBlockStatus),

                        new XElement("selectedSeats",
                            new XElement("selectedSeats",
                            new XElement("mainPassenger", _objgetTBReq.mainPassengerSS),
                            new XElement("passngerAge", _objgetTBReq.passngerAgeSS),
                            new XElement("passngerGender", _objgetTBReq.passngerGenderSS),
                            new XElement("passngerName", _objgetTBReq.passngerNameSS),
                            new XElement("passngerType", _objgetTBReq.passngerTypeSS),
                            new XElement("seatNo", _objgetTBReq.seatNoSS)
                          )
                          ),

                          new XElement("serviceID", _objgetTBReq.serviceIDSS),

                         new XElement("stuFromPlace",
                            new XElement("placeCode", _objgetTBReq.placeCodestuFromPlace),
                            new XElement("placeID", _objgetTBReq.placeIDstuFromPlace),
                            new XElement("placeName", _objgetTBReq.placeNamestuFromPlace)
                            ),

                           new XElement("stuID", _objgetTBReq.stuID),

                        new XElement("stuToPlace",
                            new XElement("placeCode", _objgetTBReq.placeCodestuToPlace),
                            new XElement("placeID", _objgetTBReq.placeIDstuToPlace),
                            new XElement("placeName", _objgetTBReq.placeNamestuToPlace)
                            ),

                            new XElement("stuWSRefNo", _objgetTBReq.stuWSRefNo),
                            new XElement("totalPassengers", _objgetTBReq.totalPassengers),
                            new XElement("tripCode", _objgetTBReq.tripCode),
                            new XElement("tripNo", _objgetTBReq.tripNo),
                            new XElement("tripType", _objgetTBReq.tripType)
                            ),
                         new XElement("wsUser",
                            new XElement("franchUserID", _objgetTBReq.franchUserID),
                            new XElement("password", _objgetTBReq.password),
                            new XElement("userID", _objgetTBReq.userID),
                            new XElement("userKey", _objgetTBReq.userKey),
                            new XElement("userName", _objgetTBReq.userName),
                            new XElement("userRole", _objgetTBReq.userRole),
                            new XElement("userStatus", _objgetTBReq.userStatus),
                            new XElement("userType", _objgetTBReq.userType)

                    )
                    )
                    )
                    )
                    )
                );
            }
            catch (Exception ex)
            {

            }
            return doc;
        }

        public getPlaceListRequest GetUserRequestParameters()
        {
            getPlaceListRequest _objgetPlaceListRequest = new getPlaceListRequest();
            _objgetPlaceListRequest.franchUserID = AppStatic.franchUserID;
            _objgetPlaceListRequest.password = AppStatic.password;
            _objgetPlaceListRequest.userID = AppStatic.userID;
            _objgetPlaceListRequest.userKey = AppStatic.userKey;
            _objgetPlaceListRequest.userName = AppStatic.userName;
            _objgetPlaceListRequest.userRole = AppStatic.userRole;
            _objgetPlaceListRequest.userStatus = AppStatic.userStatus;
            _objgetPlaceListRequest.userType = AppStatic.userType;
            return _objgetPlaceListRequest;
        }
    }
}
