using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using System.Windows;
using System.ComponentModel;
using Windows.UI;
using Windows.Phone.UI.Input;
using System.Globalization;
using Windows.UI.Popups;

using BusIndia_Universal.Views.Bus;
using BusIndiaBLL.Model;
using BusIndiaBLL.Helper;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusSeatSelection : Page
    {
        int number;
        GetAvailableService _GetAvailableServiceobj = new GetAvailableService();
        getSeatlayout seatlayoutContext;
        List<getSeatlayout> _getSeatlayout = new List<getSeatlayout>();

        int r = 0;
        int c = 0;
        int s = 0;
        string t = "";
        string q = "";
        string SeatS = "";
        getSeatlayout _objS = new getSeatlayout();
        List<getSeatlayout> _getStudDetails = new List<getSeatlayout>();
        string CommanTripType = "";
        public BusSeatSelection()
        {
            
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            seatlayoutContext = new getSeatlayout();
            this.DataContext = seatlayoutContext;
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;

            try
            {
                if (e.Parameter is GetAvailableService)
                {
                    var _objectGetAvailableService = (GetAvailableService)e.Parameter;
                    if (_objectGetAvailableService != null)
                    {
                        if (_objectGetAvailableService.tripType == "RoundTrip")
                        {
                            CommanTripType = "RoundTrip";
                            postXMLData1(_objectGetAvailableService);
                            placeCodeFrom.Text = _objectGetAvailableService.placeCodeFrom;
                            placeCodeTo.Text = _objectGetAvailableService.placeCodeTo;
                            placeIDFrom.Text = _objectGetAvailableService.placeIDFrom;
                            placeIDFrom.Text = _objectGetAvailableService.placeIDto;
                            placeNameFrom.Text = _objectGetAvailableService.placeNameFrom;
                            placeNameTo.Text = _objectGetAvailableService.placeNameTo;
                            arrivalDate.Text = _objectGetAvailableService.arrivalDate;
                        }
                        else if (_objectGetAvailableService.tripType == "FirstTrip")
                        {
                            CommanTripType = "FirstTrip";
                            postXMLData1(_objectGetAvailableService);
                            placeCodeFrom.Text = _objectGetAvailableService.placeCodeFrom;
                            placeCodeTo.Text = _objectGetAvailableService.placeCodeTo;
                            placeIDFrom.Text = _objectGetAvailableService.placeIDFrom;
                            placeIDFrom.Text = _objectGetAvailableService.placeIDto;
                            placeNameFrom.Text = _objectGetAvailableService.placeNameFrom;
                            placeNameTo.Text = _objectGetAvailableService.placeNameTo;
                            arrivalDate.Text = _objectGetAvailableService.arrivalDate;
                        }
                        else
                        {
                            postXMLData1(_objectGetAvailableService);
                            placeCodeFrom.Text = _objectGetAvailableService.placeCodeFrom;
                            placeCodeTo.Text = _objectGetAvailableService.placeCodeTo;
                            placeIDFrom.Text = _objectGetAvailableService.placeIDFrom;
                            placeIDFrom.Text = _objectGetAvailableService.placeIDto;
                            placeNameFrom.Text = _objectGetAvailableService.placeNameFrom;
                            placeNameTo.Text = _objectGetAvailableService.placeNameTo;
                            arrivalDate.Text = _objectGetAvailableService.arrivalDate;
                        }
                    }
                }              
                else if(e.Parameter is pickDropHelper)
                {
                    var _objectGetAvailableService = pickDropHelper.objGetAvailableService;
                    postXMLData1(_objectGetAvailableService);
                    placeCodeFrom.Text = _objectGetAvailableService.placeCodeFrom;
                    placeCodeTo.Text = _objectGetAvailableService.placeCodeTo;
                    placeIDFrom.Text = _objectGetAvailableService.placeIDFrom;
                    placeIDFrom.Text = _objectGetAvailableService.placeIDto;
                    placeNameFrom.Text = _objectGetAvailableService.placeNameFrom;
                    placeNameTo.Text = _objectGetAvailableService.placeNameTo;
                    arrivalDate.Text = _objectGetAvailableService.arrivalDate;
                }
                else
                {
                    var _objectGetAvailableService = pickDropHelper.objGetAvailableService;
                    postXMLData1(_objectGetAvailableService);
                    placeCodeFrom.Text = _objectGetAvailableService.placeCodeFrom;
                    placeCodeTo.Text = _objectGetAvailableService.placeCodeTo;
                    placeIDFrom.Text = _objectGetAvailableService.placeIDFrom;
                    placeIDFrom.Text = _objectGetAvailableService.placeIDto;
                    placeNameFrom.Text = _objectGetAvailableService.placeNameFrom;
                    placeNameTo.Text = _objectGetAvailableService.placeNameTo;
                    arrivalDate.Text = _objectGetAvailableService.arrivalDate;
                }
            }
            catch (Exception )
            {
               
            }
        }

        public  void postXMLData1(GetAvailableService Get)
        {
            try
            {
                 var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async() =>
             {
                string uri = AppStatic.WebServiceBaseURL;
                Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
                GetSeatlayoutRequest _objSLR = new GetSeatlayoutRequest();
                _objSLR.franchUserID = AppStatic.franchUserID;
                _objSLR.password = AppStatic.password;
                _objSLR.userID = AppStatic.userID;
                _objSLR.userKey = AppStatic.userKey;
                _objSLR.userName = AppStatic.userName;
                _objSLR.userRole = AppStatic.userRole;
                _objSLR.userStatus = AppStatic.userStatus;
                _objSLR.userType = AppStatic.userType;
                _objSLR.placeIDFrom = Get.placeIDFrom;
                _objSLR.placeCodeFrom = Get.placeCodeFrom;
                _objSLR.placeNameFrom = Get.placeNameFrom;
                _objSLR.placeIDto = Get.placeIDto;
                _objSLR.placeCodeTo = Get.placeCodeTo;
                _objSLR.placeNameTo = Get.placeNameTo;
                _objSLR.journeyDate = Get.journeyDate;
                _objSLR.classID = Get.classID;
                _objSLR.classLayoutID = Get.classLayoutID;
                _objSLR.serviceID = Get.serviceID;               
                _objSLR.placeCodestuFromPlace = txthplaceCodeStatusFrm.Text;
                _objSLR.placeCodestuToPlace = txthplaceCodeStatusTo.Text;
                _objSLR.placeIDstuFromPlace = txthplaceIDStatusFrm.Text;
                _objSLR.placeIDstuToPlace = txthplaceIDStatusTo.Text;
                _objSLR.placeNamestuFromPlace = txthplaceNameStatusFrm.Text;
                _objSLR.placeNamestuToPlace = txthplaceNameStatusTo.Text;
                _objSLR.studID = Get.studID;
                _objSLR.totalPassengers = "?";
                xmlUtility listings = new xmlUtility();
                XDocument element = listings.getlayout(_objSLR);

                string stringXml = element.ToString();
                var httpClient = new Windows.Web.Http.HttpClient();
                var info = AppStatic.WebServiceAuthentication;
                var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
                httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
                httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
                Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
                httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
                IHttpContent content = new HttpStringContent(stringXml, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                httpRequestMessage.Content = content;
                Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);
                string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(strXmlReturned);
                XDocument loadedData = XDocument.Parse(strXmlReturned);
                List<XElement> _listResponse = (from t1 in loadedData.Descendants("wsResponse") select t1).ToList();
                List<getSeatlayout> responsList = new List<getSeatlayout>();
                string _msg = "";
                if (_listResponse != null)
                {
                    foreach (XElement _elemet in _listResponse)
                    {
                        getSeatlayout _obj = new getSeatlayout();
                        _obj.message = _elemet.Element("message").Value.ToString();
                        responsList.Add(_obj);
                    }
                    _msg = responsList.FirstOrDefault().message.ToString();
                }
                if (_msg != "FAILURE")
                {
                    var sdata = loadedData.Descendants("Seatlayout").
                    Select(x => new getSeatlayout
                    {
                        availableSeatNos = x.Element("availableSeatNos").Value,
                        bookedSeatNos = x.Element("bookedSeatNos").Value,
                        conductorSeatNo = x.Element("conductorSeatNo").Value,
                        ladiesAvailableSeatNos = x.Element("ladiesAvailableSeatNos").Value,
                        ladiesBookedSeatNos = x.Element("ladiesBookedSeatNos").Value,
                        maxColCount = x.Element("maxColCount").Value,
                        maxRowCount = x.Element("maxRowCount").Value,
                        column = x.Element("seatDetails").Element("seats").Element("column").Value,
                        quota = x.Element("seatDetails").Element("seats").Element("quota").Value,
                        row = x.Element("seatDetails").Element("seats").Element("row").Value,
                        seatNo = x.Element("seatDetails").Element("seats").Element("seatNo").Value,
                        seatStatus = x.Element("seatDetails").Element("seats").Element("seatStatus").Value,
                        type = x.Element("seatDetails").Element("seats").Element("type").Value,
                        busID = x.Element("service").Element("busID").Value,
                        distance = x.Element("service").Element("distance").Value,
                        endPoint = x.Element("service").Element("endPoint").Value,
                        startPoint = x.Element("service").Element("startPoint").Value,
                        placeCodestuFromPlace = x.Element("stuFromPlace").Element("placeCode").Value,
                        placeIDstuFromPlace = x.Element("stuFromPlace").Element("placeID").Value,
                        placeNamestuFromPlace = x.Element("stuFromPlace").Element("placeName").Value,
                        placeCodestuToPlace = x.Element("stuToPlace").Element("placeCode").Value,
                        placeIDstuToPlace = x.Element("stuToPlace").Element("placeID").Value,
                        placeNamestuToPlace = x.Element("stuToPlace").Element("placeName").Value,
                        totalSeats = x.Element("totalSeats").Value,
                        message = x.Element("wsResponse").Element("message").Value,
                        statusCode = x.Element("wsResponse").Element("statusCode").Value
                    });
                    
                    foreach (var item in sdata)
                    {                       
                        _objS.placeCodestuFromPlace = item.placeCodestuFromPlace;
                        _objS.placeIDstuFromPlace = item.placeIDstuFromPlace;
                        _objS.placeNamestuFromPlace = item.placeNamestuFromPlace;
                        _objS.placeCodestuToPlace = item.placeCodestuToPlace;
                        _objS.placeIDstuToPlace = item.placeIDstuToPlace;
                        _objS.placeNamestuToPlace = item.placeNamestuToPlace;
                        _getStudDetails.Add(_objS);                 
                        break;
                    }
                                                         

                    int maxrowCount;
                    int maxcolcount;
                    var _listCol = (from t1 in loadedData.Descendants("maxColCount") select t1).FirstOrDefault();
                    var _listRow = (from t1 in loadedData.Descendants("maxRowCount") select t1).FirstOrDefault();

                    maxcolcount = Convert.ToInt32(_listCol.Value.ToString());
                    maxrowCount = Convert.ToInt32(_listRow.Value.ToString());
                    int b = maxrowCount;
                    int a = maxcolcount;

                    for (int r = 0; r <= a; r++)
                    {
                        Mygrid.RowDefinitions.Add(new RowDefinition());
                    }
                    for (int c = 0; c < b; c++)
                    {
                        Mygrid.ColumnDefinitions.Add(new ColumnDefinition());
                    }                  

                    List<XElement> _srow = (from t1 in loadedData.Descendants("seats") select t1).ToList();
                    List<getSeatlayout> srow = new List<getSeatlayout>();
                    foreach (XElement _elemetsr in _srow)
                    {
                        Image img = new Image();
                        TextBlock txtSeatnumber = new TextBlock();
                        TextBlock txtType = new TextBlock();

                        txtSeatnumber.Visibility = Visibility.Visible;
                        getSeatlayout _objsr = new getSeatlayout();
                        _objsr.row = _elemetsr.Element("row").Value.ToString();
                        _objsr.column = _elemetsr.Element("column").Value.ToString();
                        _objsr.seatNo = _elemetsr.Element("seatNo").Value.ToString();
                        _objsr.type = _elemetsr.Element("type").Value.ToString();
                        _objsr.quota = _elemetsr.Element("quota").Value.ToString();
                        _objsr.seatStatus = _elemetsr.Element("seatStatus").Value.ToString();
                        srow.Add(_objsr);


                        c = Convert.ToInt32(srow.LastOrDefault().row.ToString());
                        r = Convert.ToInt32(srow.LastOrDefault().column.ToString());
                        s = Convert.ToInt32(srow.LastOrDefault().seatNo.ToString());
                        t = srow.LastOrDefault().type.ToString();
                        q = srow.LastOrDefault().quota.ToString();
                        SeatS = srow.LastOrDefault().seatStatus.ToString();

                        int nn = -(r - (a + 1));

                        img.SetValue(Grid.ColumnProperty, c - 1);
                        img.SetValue(Grid.RowProperty, nn - 1);
                        txtSeatnumber.SetValue(Grid.ColumnProperty, c - 1);
                        txtSeatnumber.SetValue(Grid.RowProperty, nn - 1);
                        txtType.SetValue(Grid.ColumnProperty, c - 1);
                        txtType.SetValue(Grid.RowProperty, nn - 1);


                        txtType.FontSize = 12;
                        txtType.Text = t.ToString();
                        txtType.Foreground = new SolidColorBrush(Colors.Black);
                        txtType.Margin = new Thickness { Left = 20, Top = 95, Right = 0, Bottom = 0 };


                        txtSeatnumber.FontSize = 12;
                        txtSeatnumber.Text = s.ToString();
                        txtSeatnumber.Foreground = new SolidColorBrush(Colors.Black);
                        txtSeatnumber.Margin = new Thickness { Left = 5, Top = 95, Right = 0, Bottom = 0 };

                        img.Height = 40;
                        img.Width = 40;
                        img.Margin = new Thickness { Left = 0, Top = 40, Right = 0, Bottom = 0 };
                        if (SeatS == "AVAILABLE")
                        {
                            img.Name = txtSeatnumber.Text + txtType.Text;
                            img.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/Seats/ss_empty_seat.png"));
                            img.Tapped += img_Tapped;

                        }
                        else
                        {
                            img.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/Seats/ss_booked_seat.png"));
                        }


                        for (int row = 0; row < Mygrid.RowDefinitions.Count; row++)
                        {
                            for (int column = 0; column < Mygrid.ColumnDefinitions.Count; column++)
                            {
                                if (nn == row && c == column)
                                {
                                    txtSeatnumber.Visibility = Visibility.Visible;
                                    txtType.Visibility = Visibility.Visible;
                                    img.Visibility = Visibility.Visible;
                                    Mygrid.Children.Add(txtSeatnumber);
                                    Mygrid.Children.Add(img);
                                    Mygrid.Children.Add(txtType);
                                }
                            }
                        }
                    }
                    LoderPopup.Visibility = Visibility.Collapsed;
                }
                else
                {
                    LoderPopup.Visibility = Visibility.Collapsed;
                }
             }).AsTask();
            }

            catch (Exception e)
            {
                var messagedialog = new Windows.UI.Popups.MessageDialog("There is service not available");
            }          
          
        }

        private  void img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage img1 = new BitmapImage();
            BitmapImage img2 = new BitmapImage();
            
            BitmapImage _objseatimage = (BitmapImage)img.Source;

            img2.UriSource = new Uri("ms-appx:///Assets/Seats/ss_selected_seat.png");
            img1.UriSource = new Uri("ms-appx:///Assets/Seats/ss_empty_seat.png");

            string SeatImage = _objseatimage.UriSource.ToString();
            string i1 = img1.UriSource.ToString();

            if (SeatImage == i1)
            {
                if (img.Name != null)
                {
                    _GetAvailableServiceobj.SearNumbers.Add(img.Name);
                }
                if (number < 6)
                {
                    number = number + 1;
                    txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
                    img.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/Seats/ss_selected_seat.png", UriKind.Absolute));
                }
                else
                {
                    txtBError.Text = "There is already six seat selected! ";
                    ValidationPopup.Visibility = Visibility.Visible;
                }

            }
            else
            {
                if (img.Name != null)
                {
                    _GetAvailableServiceobj.SearNumbers.Remove(img.Name);
                }
                if (number > 0)
                {
                    number = number - 1;
                    txtBNumberOfSeatsSelected.Text = Convert.ToString(number);
                    img.Source = new BitmapImage(new System.Uri("ms-appx:///Assets/Seats/ss_empty_seat.png", UriKind.Absolute));
                }
            }
            
        }

        private async  void stackDone_Tapped(object sender, TappedRoutedEventArgs e)
        {           
            if (number == 0 )
            {
                txtBError.Text = "There is no seat selected! " + Environment.NewLine + "Please select at list one seat";
                ValidationPopup.Visibility = Visibility.Visible;
            }
            
            else
            {
                if (CommanTripType == "RoundTrip")
                {
                    if (pickDropHelper.objGetSeatLayout.SelectedSeat == Convert.ToString(number))
                    {
                        _objS.SelectedSeat = Convert.ToString(number);
                        pickDropHelper.objGetSeatLayout = _objS;
                        _GetAvailableServiceobj.tripType = "RoundTrip";
                        PageNavigationMode.Mode = PageTransmission.Left;
                        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusPickDropPoint), _GetAvailableServiceobj));
                       // this.Frame.Navigate(typeof(BusPickDropPoint), _GetAvailableServiceobj);
                    }
                    else
                    {
                        txtBError.Text = "Invalid Seat selection ! " + Environment.NewLine + "Please select " + pickDropHelper.objGetSeatLayout.SelectedSeat + " Seat(S) to proceed.";
                        ValidationPopup.Visibility = Visibility.Visible;
                    }
                }
                else if (CommanTripType == "FirstTrip")
                {
                    _objS.SelectedSeat = Convert.ToString(number);
                    pickDropHelper.objGetSeatLayout = _objS;
                    _GetAvailableServiceobj.tripType = "FirstTrip";
                   // this.Frame.Navigate(typeof(BusPickDropPoint), _GetAvailableServiceobj);
                    PageNavigationMode.Mode = PageTransmission.Left;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusPickDropPoint), _GetAvailableServiceobj));
                }
                else
                {
                    _objS.SelectedSeat = Convert.ToString(number);
                    pickDropHelper.objGetSeatLayout = _objS;
                  //  this.Frame.Navigate(typeof(BusPickDropPoint), _GetAvailableServiceobj);
                    PageNavigationMode.Mode = PageTransmission.Left;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusPickDropPoint), _GetAvailableServiceobj));
                }
            }
        }
        
        private async void ttxtCancle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (CommanTripType == "RoundTrip")
            {
                  getBusSearch obj = new getBusSearch();
                   obj.placeCodeFrom= placeCodeFrom.Text;
                   obj.placeCodeTo= placeCodeTo.Text  ;
                   obj.placeIDFrom=  placeIDFrom.Text ;
                   obj.placeIDTo= placeIDFrom.Text  ;
                   obj.Toplace= placeNameFrom.Text  ;
                   obj.Fromplace= placeNameTo.Text ;
                   string d = arrivalDate.Text;
                   System.DateTime dt = System.DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                   obj.DateReturn = dt.ToString("dd MMM yyyy");                 
                   obj.Label = "ReturneBusSearch";
                   obj.LabelReturn = "RoundTrip";
                   PageNavigationMode.Mode = PageTransmission.Left;
                   await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(TripSearch), obj));
                 //  this.Frame.Navigate(typeof(TripSearch), obj);
            }
            else if (CommanTripType == "FirstTrip")
            {
                getBusSearch obj = new getBusSearch();
                obj.placeCodeFrom = placeCodeFrom.Text;
                obj.placeCodeTo = placeCodeTo.Text;
                obj.placeIDFrom = placeIDFrom.Text;
                obj.placeIDTo = placeIDFrom.Text;
                obj.Toplace = placeNameFrom.Text;
                obj.Fromplace = placeNameTo.Text;
                string d = arrivalDate.Text;
                System.DateTime dt = System.DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj.Date = dt.ToString("dd MMM yyyy");
                obj.Label = "ReturneBusSearch";
                obj.LabelReturn = "FirstTrip";
               // this.Frame.Navigate(typeof(TripSearch), obj);
                PageNavigationMode.Mode = PageTransmission.Left;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(TripSearch), obj));
               
            }
            else
            {
                PageNavigationMode.Mode = PageTransmission.Left;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(TripSearch)));
                //this.Frame.Navigate(typeof(TripSearch));
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ValidationPopup.Visibility = Visibility.Collapsed;
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ValidationPopup.Visibility = Visibility.Collapsed;
        }


    }

}
