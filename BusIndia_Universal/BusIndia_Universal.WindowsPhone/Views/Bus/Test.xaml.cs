using BusIndia_Universal.Models;
using BusIndiaBLL.Helper;
using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
//using WebServiceClassLiberary;
//using WebServiceClassLiberary.Model;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal.Views.Bus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test : Page
    {

        ErrorHandlingUserControl _ObjErrorOccured = new ErrorHandlingUserControl();
        GetAvailableService _GetAvailableServiceobj = new GetAvailableService();

        string ErrorContent;
        int maxPrice = 0;
        int minPrice = 0;
        int maxTime = 0;
        int minTime = 0;
        int MinPrice = 0;
        int MaxPrice = 100;
        int SizePrice = 80;
        int RangePrice = 100;
        int leftPrice = 0;
        int rightPrice = 0;
        int MinTime = 0;
        int MaxTime = 24;
        int SizeTime = 80;
        int RangeTime = 100;
        int leftTime = 0;
        int rightTime = 0;
        Point leftPointPrice = new Point();
        Point rightPointPrice = new Point();
        Point initalPointPrice = new Point(0, 0);
        Point leftPointTime = new Point();
        Point rightPointTime = new Point();
        Point initalPointTime = new Point(0, 0);
        public Test()
        {
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            imgBackBlur.Source = homeModel.bgBlurImage;
            LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
            DetailsTap.Visibility = Visibility.Visible;
            ListMenuItems.Visibility = Visibility.Visible;
            SliderPrice();
            SliderTime();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;

            imgBackBlur.Source = homeModel.bgBlurImage;
            maxPrice = Convert.ToInt32(txtBMaxPrice.Text);
            maxTime = Convert.ToInt32(txtBMaxTime.Text);
            if (e.Parameter is getBusSearch)
            {
                var nav = (getBusSearch)e.Parameter;
                if (nav != null)
                {
                    lblFromPlace.Text = nav.placeCodeFrom;
                    lblToPlace.Text = nav.placeCodeTo;
                    lblJrnyDate.Text = nav.Date;
                    txtBFromLocationT.Text = nav.Fromplace;
                    txtBToLocationT.Text = nav.Toplace;
                    txtBDateTab.Text = nav.Date;
                    txtBFromCode.Text = nav.placeCodeFrom;
                    txtBFromID.Text = nav.placeIDFrom;
                    txtBToCode.Text = nav.placeCodeTo;
                    txtBToID.Text = nav.placeIDTo;
                    DetailsTap.Visibility = Visibility.Visible;
                    ListMenuItems.Visibility = Visibility.Visible;
                    string d = nav.Date;
                    System.DateTime dt = System.DateTime.ParseExact(d, "dd MMM yyyy", CultureInfo.InvariantCulture);
                    txtBPreDayTab.IsTapEnabled = PreviousDayTab.IsTapEnabled = (dt.Date > System.DateTime.Now.Date);
                }
            }
            else
            {
                var nav = pickDropHelper.objGetAvailableService;
                if (nav != null)
                {
                    lblFromPlace.Text = nav.placeCodeFrom;
                    lblToPlace.Text = nav.placeCodeTo;
                    lblJrnyDate.Text = nav.journeyDate;
                    txtBFromLocationT.Text = nav.placeNameFrom;
                    txtBToLocationT.Text = nav.placeNameTo;
                    string d1 = nav.journeyDate;
                    System.DateTime dt1 = System.DateTime.ParseExact(d1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    txtBDateTab.Text = dt1.ToString("dd MMM yyyy");
                    txtBFromCode.Text = nav.placeCodeFrom;
                    txtBFromID.Text = nav.placeIDFrom;
                    txtBToCode.Text = nav.placeCodeTo;
                    txtBToID.Text = nav.placeIDto;
                    DetailsTap.Visibility = Visibility.Visible;
                    ListMenuItems.Visibility = Visibility.Visible;
                    string d = txtBDateTab.Text;
                    System.DateTime dt = System.DateTime.ParseExact(d, "dd MMM yyyy", CultureInfo.InvariantCulture);
                    txtBPreDayTab.IsTapEnabled = PreviousDayTab.IsTapEnabled = (dt.Date > System.DateTime.Now.Date);
                }

            }
            postXMLData1();
        }
        public void SliderPrice()
        {
            var pos = SetPositionPrice(Thumb1PositionPrice);
            Thumb1PositionPrice = 0;
            Thumb2PositionPrice = 100;
            CompositeTransform ct = new CompositeTransform();
            ct.TranslateX = pos;
            LeftHandle.RenderTransform = ct;
            leftPointPrice.X = pos;
            pos = SetPositionPrice(Thumb2PositionPrice);
            CompositeTransform rCt = new CompositeTransform();
            rCt.TranslateX = pos;
            RightHandle.RenderTransform = rCt;
            rightPointPrice.X = pos;
            FillTrackGrid.Width = FillTrackPrice(rightPointPrice, leftPointPrice);
        }

        public void SliderTime()
        {
            var pos = SetPositionTime(Thumb1PositionTime);
            Thumb1PositionTime = 0;
            Thumb2PositionTime = 24;
            CompositeTransform ct = new CompositeTransform();
            ct.TranslateX = pos;
            LeftHandleTime.RenderTransform = ct;
            leftPointTime.X = pos;
            pos = SetPositionTime(Thumb2PositionTime);
            CompositeTransform rCt = new CompositeTransform();
            rCt.TranslateX = pos;
            RightHandleTime.RenderTransform = rCt;
            rightPointTime.X = pos;
            FillTrackGridTime.Width = FillTrackTime(rightPointTime, leftPointTime);
        }
        List<GetAvailableService> availableservice = new List<GetAvailableService>();
        List<SelectAgeRadio> rdoselec = new List<SelectAgeRadio>();


        public async void postXMLData1()
        {
            try
            {
                string uri = AppStatic.WebServiceBaseURL;  // some xml string
                Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
                GetAvailableServicesRequest _objAGR = new GetAvailableServicesRequest();
                _objAGR.franchUserID = AppStatic.franchUserID;
                _objAGR.password = AppStatic.password;
                _objAGR.userID = AppStatic.userID;
                _objAGR.userKey = AppStatic.userKey;
                _objAGR.userName = AppStatic.userName;
                _objAGR.userRole = AppStatic.userRole;
                _objAGR.userStatus = AppStatic.userStatus;
                _objAGR.userType = AppStatic.userType;
                _objAGR.placeNameFrom = txtBFromLocationT.Text;
                _objAGR.placeNameTo = txtBToLocationT.Text;
                _objAGR.placeIDFrom = txtBFromID.Text;
                _objAGR.placeIDto = txtBToID.Text;
                _objAGR.placeCodeFrom = txtBFromCode.Text;
                _objAGR.placeCodeTo = txtBToCode.Text;
                string d = txtBDateTab.Text;
                System.DateTime dt = System.DateTime.ParseExact(d, "dd MMM yyyy", CultureInfo.InvariantCulture);
                string Date = dt.ToString("dd/MM/yyyy");
                _objAGR.journeyDate = Date;

                xmlUtility listings = new xmlUtility();
                XDocument element = listings.getservice(_objAGR);
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

                XDocument loadedData = XDocument.Parse(strXmlReturned);

                XDocument element1 = listings.getAvailableServicelayout(_objAGR);
                string stringXml1 = element1.ToString();


                byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(stringXml1.ToString());
                StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("HistoryTest1.xml", CreationCollisionOption.OpenIfExists);
                String historyTestContent = await FileIO.ReadTextAsync(file);
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    stream.Seek(0, SeekOrigin.End);
                    stream.Write(fileBytes, 0, fileBytes.Length);
                }

                List<XElement> _list = (from t1 in loadedData.Descendants("wsResponse") select t1).ToList();
                List<PlaceList> seatsList = new List<PlaceList>();
                string _msg = "";
                if (_list != null)
                {
                    foreach (XElement _elemet in _list)
                    {
                        PlaceList _obj = new PlaceList();
                        _obj.message = _elemet.Element("message").Value.ToString();
                        seatsList.Add(_obj);
                    }
                    _msg = seatsList.FirstOrDefault().message.ToString();
                }


                if (_msg != "FAILURE")
                {
                    var sdata = loadedData.Descendants("service").
                    Select(x => new GetAvailableService
                    {
                        arrivalDate = x.Element("arrivalDate").Value,
                        arrivalTime = x.Element("arrivalTime").Value,
                        classID = x.Element("classID").Value,
                        classLayoutID = x.Element("classLayoutID").Value,
                        className = x.Element("className").Value,
                        corpCode = x.Element("corpCode").Value,
                        departureTime = x.Element("departureTime").Value,
                        destination = x.Element("destination").Value,
                        fare = x.Element("fare").Value,
                        journeyDate = x.Element("journeyDate").Value,
                        journeyHours = x.Element("journeyHours").Value,
                        maxSeatsAllowed = x.Element("maxSeatsAllowed").Value,
                        origin = x.Element("origin").Value,
                        placeIDFrom = x.Element("biFromPlace").Element("placeID").Value,
                        placeIDto = x.Element("biToPlace").Element("placeID").Value,
                        refundStatus = x.Element("refundStatus").Value,
                        routeNo = x.Element("routeNo").Value,
                        seatsAvailable = x.Element("seatsAvailable").Value,
                        seatStatus = x.Element("seatStatus").Value,
                        serviceID = x.Element("serviceID").Value,
                        startPoint = x.Element("startPoint").Value,
                        studID = x.Element("stuID").Value,
                        tripCode = x.Element("tripCode").Value,
                        viaPlaces = x.Element("viaPlaces").Value
                    });
                    foreach (var item in sdata)
                    {
                        GetAvailableService gas = new GetAvailableService();
                        gas.arrivalDate = item.arrivalDate;
                        gas.arrivalTime = item.arrivalTime;
                        gas.classID = item.classID;
                        gas.classLayoutID = item.classLayoutID;
                        gas.className = item.className;
                        gas.corpCode = item.corpCode;
                        gas.departureTime = item.departureTime;
                        gas.destination = item.destination;
                        gas.fare = item.fare;
                        gas.journeyDate = item.journeyDate;
                        gas.journeyHours = item.journeyHours;
                        gas.maxSeatsAllowed = item.maxSeatsAllowed;
                        gas.origin = item.origin;
                        gas.placeIDFrom = item.placeIDFrom;
                        gas.placeIDto = item.placeIDto;
                        gas.refundStatus = item.refundStatus;
                        gas.routeNo = item.routeNo;
                        gas.seatsAvailable = item.seatsAvailable;
                        gas.seatStatus = item.seatStatus;
                        gas.serviceID = item.serviceID;
                        gas.startPoint = item.startPoint;
                        gas.studID = item.studID;
                        gas.tripCode = item.tripCode;
                        gas.viaPlaces = item.viaPlaces;
                        availableservice.Add(gas);
                    }
                    ListMenuItems.ItemsSource = sdata;

                    string MaxPriceresult = sdata.OrderByDescending(x => x.fare).Select(x => x.fare).FirstOrDefault().ToString();
                    if (MaxPriceresult != null)
                    {
                        txtBMaxPriceCurrent.Text = MaxPriceresult;
                        txtBMaxPrice.Text = MaxPriceresult;
                        maxPrice = Convert.ToInt32(MaxPriceresult);
                        MaxPrice = Convert.ToInt32(MaxPriceresult);
                        Thumb2PositionPrice = Convert.ToInt32(MaxPriceresult);
                    }

                    string MinPriceresult = sdata.OrderBy(x => x.fare).Select(x => x.fare).FirstOrDefault().ToString();
                    if (MinPriceresult != null)
                    {
                        txtBMinPrice.Text = MinPriceresult;
                        txtBMinPriceCurrent.Text = MinPriceresult;
                        minPrice = Convert.ToInt32(MinPriceresult);
                        MinPrice = Convert.ToInt32(MinPriceresult);
                        Thumb1PositionPrice = Convert.ToInt32(MinPriceresult);
                    }
                    ListMenuItemsFilterCorp.ItemsSource = sdata.Select(x => x.corpCode).Distinct().ToList();
                    ListMenuItemsFilterBusType.ItemsSource = sdata.Select(x => x.className).Distinct().ToList();

                    FilterFunVisible();
                }
                else
                {
                    FilterFunCollapsed();

                }
            }
            catch (Exception ex)
            {

                LoaderPop.Visibility = Visibility.Collapsed;
                //gridErrorOccured.Children.Add(_ObjErrorOccured);
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
        }

        public void FilterFunVisible()
        {
            DetailsTap.Visibility = Visibility.Visible;
            ListMenuItems.Visibility = Visibility.Visible;
            LoaderPop.Visibility = Visibility.Collapsed;
            btnPriceSort.IsEnabled = true;
            btnCorporationSort.IsEnabled = true;
            btnDepartureSort.IsEnabled = true;
            btnBusTypeSort.IsEnabled = true;
            txtCorporation.IsTapEnabled = true;
            imgCorporation.IsTapEnabled = true;
            imgBusType.IsDoubleTapEnabled = true;
            txtBusType.IsTapEnabled = true;
            GrdPriceRange.Visibility = Visibility.Visible;
            GrdTimeRange.Visibility = Visibility.Visible;
            txtBDashP.Visibility = Visibility.Visible;
            txtBDashS.Visibility = Visibility.Visible;
            txtBMaxPrice.Visibility = Visibility.Visible;
            txtBdashT.Visibility = Visibility.Visible;
            txtBMaxTime.Visibility = Visibility.Visible;
            txtBHrs.Visibility = Visibility.Visible;
        }
        public void FilterFunCollapsed()
        {
            txtBDashP.Visibility = Visibility.Collapsed;
            txtBDashS.Visibility = Visibility.Collapsed;
            txtBMaxPrice.Visibility = Visibility.Collapsed;
            txtBdashT.Visibility = Visibility.Collapsed;
            txtBMaxTime.Visibility = Visibility.Collapsed;
            txtBHrs.Visibility = Visibility.Collapsed;
            btnPriceSort.IsEnabled = false;
            btnCorporationSort.IsEnabled = false;
            btnDepartureSort.IsEnabled = false;
            btnBusTypeSort.IsEnabled = false;
            txtCorporation.IsTapEnabled = false;
            imgCorporation.IsTapEnabled = false;
            imgBusType.IsDoubleTapEnabled = false;
            txtBusType.IsTapEnabled = false;
            DetailsTap.Visibility = Visibility.Collapsed;
            ListMenuItems.Visibility = Visibility.Collapsed;
            GrdPriceRange.Visibility = Visibility.Collapsed;
            GrdTimeRange.Visibility = Visibility.Collapsed;
            txtBMinTime.Visibility = Visibility.Collapsed;
            txtBMinPrice.Visibility = Visibility.Collapsed;
            Pricesign.Visibility = Visibility.Collapsed;
            HrSign.Visibility = Visibility.Collapsed;
            Hrdash.Visibility = Visibility.Visible;
            Pricedash.Visibility = Visibility.Visible;
            LoaderPop.Visibility = Visibility.Collapsed;
            Error.Visibility = Visibility.Visible;
        }
        private void PreviousDayTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                string d = txtBDateTab.Text;
                System.DateTime dt = System.DateTime.ParseExact(d, "dd MMM yyyy", CultureInfo.InvariantCulture);
                dt = dt.AddDays(-1);
                txtBDateTab.Text = dt.ToString("dd MMM yyyy");
                lblJrnyDate.Text = txtBDateTab.Text;
                txtBPreDayTab.IsTapEnabled = PreviousDayTab.IsTapEnabled = (dt.Date > System.DateTime.Now.Date);
                LoaderPop.Visibility = Visibility.Visible;
                tabRoundTrip.IsTapEnabled = true;
                txtBNextDayTab.IsTapEnabled = true;
                ErrorAdvanceBooking.Visibility = Visibility.Collapsed;
                postXMLData1();
            }
            catch (Exception ex)
            {
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
        }
        private void tabRoundTrip_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                string d = txtBDateTab.Text;
                System.DateTime dt = System.DateTime.ParseExact(d, "dd MMM yyyy", CultureInfo.InvariantCulture);
                dt = dt.AddDays(1);
                txtBDateTab.Text = dt.ToString("dd MMM yyyy");
                lblJrnyDate.Text = txtBDateTab.Text;
                txtBPreDayTab.IsTapEnabled = PreviousDayTab.IsTapEnabled = (dt.Date > System.DateTime.Now.Date);
                LoaderPop.Visibility = Visibility.Visible;
                System.DateTime Adv = System.DateTime.Now.AddDays(15);
                string AdvDate = Adv.ToString("dd MMM yyyy");
                if (AdvDate == txtBDateTab.Text)
                {
                    tabRoundTrip.IsTapEnabled = false;
                    txtBNextDayTab.IsTapEnabled = false;
                    ErrorAdvanceBooking.Visibility = Visibility.Visible;
                    Error.Visibility = Visibility.Collapsed;
                    postXMLData1();
                }
                else
                {
                    tabRoundTrip.IsTapEnabled = true;
                    txtBNextDayTab.IsTapEnabled = true;
                    ErrorAdvanceBooking.Visibility = Visibility.Collapsed;
                    postXMLData1();
                }


            }
            catch (Exception ex)
            {
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
        }
        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusSearch));
        }
        private void LayoutRoot_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Thickness margin = new Thickness(0, 0, 0, 0);
            if (LayoutRoot.Margin == margin)
            {
                LayoutRoot.Margin = new Thickness(-300, 0, 300, 0);
                LayoutRoot2.Visibility = Visibility.Visible;
            }
            else
            {
                LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
                LayoutRoot2.Visibility = Visibility.Collapsed;
            }
        }
        private void imgFilter_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Thickness margin = new Thickness(0, 0, 0, 0);
            if (LayoutRoot.Margin == margin)
            {
                LayoutRoot.Margin = new Thickness(-300, 0, 300, 0);
                LayoutRoot2.Visibility = Visibility.Visible;
            }
            else
            {
                LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
                LayoutRoot2.Visibility = Visibility.Collapsed;
            }

        }
        private void imgCorporation_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CorporationGrid.Visibility = Visibility.Visible;


        }
        private void imgBusType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BusTypeGrid.Visibility = Visibility.Visible;
        }
        private void txtCorporation_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CorporationGrid.Visibility = Visibility.Visible;
        }
        private void txtBusType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BusTypeGrid.Visibility = Visibility.Visible;
        }
        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMenuItems.SelectedItem != null)
            {
                GetAvailableService myobject = ListMenuItems.SelectedItem as GetAvailableService;
                myobject.placeNameTo = txtBToLocationT.Text;
                myobject.placeNameFrom = txtBFromLocationT.Text;
                myobject.placeCodeFrom = txtBFromCode.Text;
                myobject.placeCodeTo = txtBToCode.Text;
                pickDropHelper.objGetAvailableService = myobject;
                Frame.Navigate(typeof(BusSeatSelection), myobject);
            }
        }
        private void btnCorporationSort_Click(object sender, RoutedEventArgs e)
        {
            if (ListMenuItems != null)
            {
                ListMenuItems.ItemsSource = from p in availableservice orderby p.corpCode select p;
            }
        }
        private void btnPriceSort_Click(object sender, RoutedEventArgs e)
        {

            if (ListMenuItems != null)
            {
                ListMenuItems.ItemsSource = from p in availableservice orderby p.fare select p;
            }
        }
        private void btnDepartureSort_Click(object sender, RoutedEventArgs e)
        {

            if (ListMenuItems != null)
            {
                ListMenuItems.ItemsSource = from p in availableservice orderby p.departureTime select p;

            }
        }
        private void btnBusTypeSort_Click(object sender, RoutedEventArgs e)
        {
            if (ListMenuItems != null)
            {
                ListMenuItems.ItemsSource = from p in availableservice orderby p.className select p;
            }

        }
        private void LeftHandle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

            var t = (sender as Grid).RenderTransform as CompositeTransform;
            var x = (RightHandle.RenderTransform as CompositeTransform).TranslateX;
            var f = -this.RangePrice;
            var c = x - this.SizePrice * .1;
            double translateVal = TranslatePrice(t, e, f, c);
            t.TranslateX = TranslatePrice(t, e, f, c);
            txtBMinPrice.Text = TextPrice(t.TranslateX);

            CompositeTransform ct = new CompositeTransform();
            ct.TranslateX = TranslatePrice(t, e, f, c);
            FillTrackGrid.RenderTransform = ct;

            leftPrice = Convert.ToInt32(translateVal);

            leftPointPrice.X = t.TranslateX + e.Delta.Translation.X;
            leftPointPrice.Y = t.TranslateY + e.Delta.Translation.Y;

            FillTrackGrid.Width = FillTrackPrice(rightPointPrice, leftPointPrice);
            Filter(txtBMaxTime.Text, txtBMinTime.Text, txtBMaxPrice.Text, txtBMinPrice.Text);
        }
        private void RightHandle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var t = (sender as Grid).RenderTransform as CompositeTransform;
            var x = (LeftHandle.RenderTransform as CompositeTransform).TranslateX;
            var f = x + this.SizePrice * .1;
            var c = this.RangePrice;
            t.TranslateX = TranslatePrice(t, e, f, c);
            txtBMaxPrice.Text = TextPrice(t.TranslateX);

            double translateVal = TranslatePrice(t, e, f, c);
            rightPrice = Convert.ToInt32(translateVal);

            rightPointPrice.X = t.TranslateX + e.Delta.Translation.X;
            rightPointPrice.Y = t.TranslateY + e.Delta.Translation.Y;

            FillTrackGrid.Width = FillTrackPrice(rightPointPrice, leftPointPrice);
            Filter(txtBMaxTime.Text, txtBMinTime.Text, txtBMaxPrice.Text, txtBMinPrice.Text);
        }
        private double TranslatePrice(CompositeTransform s, ManipulationDeltaRoutedEventArgs e, double floor, double ceiling)
        {
            var target = s.TranslateX + e.Delta.Translation.X;

            if (target < floor)
                return floor;
            if (target > ceiling)
                return ceiling;
            return target;
        }
        private string TextPrice(double x)
        {
            var p = (x - (-this.RangePrice)) / ((this.RangePrice) - (-this.RangePrice)) * 100d;
            var v = (this.MaxPrice - this.MinPrice) * p / 100d + this.MinPrice;
            return ((int)v).ToString();
        }
        public double SetPositionPrice(int value)
        {
            var p = ((value - this.MinPrice) * 100d) / (this.MaxPrice - this.MinPrice);
            var x = (p * (this.RangePrice - (-this.RangePrice)) / 100d) + (-this.RangePrice);
            return x;
        }
        public double FillTrackPrice(Point A, Point B)
        {
            double a = A.X - B.X;
            double b = A.Y - B.Y;
            double distance = Math.Sqrt(a * a + b * b);
            return distance;
        }
        private void RightHandleTime_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var t = (sender as Grid).RenderTransform as CompositeTransform;
            var x = (LeftHandleTime.RenderTransform as CompositeTransform).TranslateX;
            var f = x + this.SizePrice * .1;
            var c = this.RangeTime;
            t.TranslateX = TranslateTime(t, e, f, c);
            txtBMaxTime.Text = TextTime(t.TranslateX);

            double translateVal = TranslateTime(t, e, f, c);
            rightTime = Convert.ToInt32(translateVal);

            rightPointTime.X = t.TranslateX + e.Delta.Translation.X;
            rightPointTime.Y = t.TranslateY + e.Delta.Translation.Y;

            FillTrackGridTime.Width = FillTrackTime(rightPointTime, leftPointTime);
            Filter(txtBMaxTime.Text, txtBMinTime.Text, txtBMaxPrice.Text, txtBMinPrice.Text);
        }
        private void LeftHandleTime_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var t = (sender as Grid).RenderTransform as CompositeTransform;
            var x = (RightHandleTime.RenderTransform as CompositeTransform).TranslateX;
            var f = -this.RangeTime;
            var c = x - this.SizeTime * .1;
            double translateVal = TranslateTime(t, e, f, c);
            t.TranslateX = TranslateTime(t, e, f, c);
            txtBMinTime.Text = TextTime(t.TranslateX);

            CompositeTransform ct = new CompositeTransform();
            ct.TranslateX = TranslateTime(t, e, f, c);
            FillTrackGridTime.RenderTransform = ct;

            leftTime = Convert.ToInt32(translateVal);

            leftPointTime.X = t.TranslateX + e.Delta.Translation.X;
            leftPointTime.Y = t.TranslateY + e.Delta.Translation.Y;

            FillTrackGridTime.Width = FillTrackTime(rightPointTime, leftPointTime);
            Filter(txtBMaxTime.Text, txtBMinTime.Text, txtBMaxPrice.Text, txtBMinPrice.Text);
        }
        public void Filter(string MaxTimerange, string MinTimerange, string Maxpricerange, string Minpricerange)
        {

            Decimal MaxTime = Math.Round(Convert.ToDecimal(MaxTimerange), 0);
            Decimal MinTime = Math.Round(Convert.ToDecimal(MinTimerange), 0);
            ListMenuItems.ItemsSource = availableservice.Where(w => Math.Round(Convert.ToDecimal(w.departureTime.Replace(':', '.')), 0) >= MinTime && Math.Round(Convert.ToDecimal(w.departureTime.Replace(':', '.')), 0) <= MaxTime && Convert.ToInt32(w.fare) <= Convert.ToInt32(Maxpricerange) && Convert.ToInt32(w.fare) >= Convert.ToInt32(Minpricerange));
        }
        private double TranslateTime(CompositeTransform s, ManipulationDeltaRoutedEventArgs e, double floor, double ceiling)
        {
            var target = s.TranslateX + e.Delta.Translation.X;

            if (target < floor)
                return floor;
            if (target > ceiling)
                return ceiling;
            return target;
        }
        private string TextTime(double x)
        {
            var p = (x - (-this.RangeTime)) / ((this.RangeTime) - (-this.RangeTime)) * 100d;
            var v = (this.MaxTime - this.MinTime) * p / 100d + this.MinTime;
            return ((int)v).ToString();
        }
        public double SetPositionTime(int value)
        {
            var p = ((value - this.MinTime) * 100d) / (this.MaxTime - this.MinTime);
            var x = (p * (this.RangeTime - (-this.RangeTime)) / 100d) + (-this.RangeTime);
            return x;
        }
        public double FillTrackTime(Point A, Point B)
        {
            double a = A.X - B.X;
            double b = A.Y - B.Y;
            double distance = Math.Sqrt(a * a + b * b);
            return distance;
        }
        private void rdbFilterCorp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            string rdbname = Convert.ToString(rdb.Content);
            txtCorporation.Text = rdbname;
            ListMenuItems.ItemsSource = availableservice.Where(w => w.corpCode == rdbname);
            CorporationGrid.Visibility = Visibility.Collapsed;
        }
        private void rdbFilterBusType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            string rdbname = Convert.ToString(rdb.Content);
            txtBusType.Text = rdbname;
            ListMenuItems.ItemsSource = availableservice.Where(w => w.className == rdbname);
            BusTypeGrid.Visibility = Visibility.Collapsed;
        }
        private void rdbFilterBusTypeALL_Tapped(object sender, TappedRoutedEventArgs e)
        {

            ListMenuItems.ItemsSource = availableservice.Where(w => w.className != "");
            txtBusType.Text = "ALL";
            BusTypeGrid.Visibility = Visibility.Collapsed;
        }

        private void rdbFilterCorpAll_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txtBusType.Text = "ALL";
            ListMenuItems.ItemsSource = availableservice.Where(w => w.className != "");
            CorporationGrid.Visibility = Visibility.Collapsed;
        }
        private int thumb1PosPrice;
        public int Thumb1PositionPrice
        {
            get { return thumb1PosPrice; }
            set
            {
                thumb1PosPrice = value;
            }
        }

        private int thumb2PosPrice;
        public int Thumb2PositionPrice
        {
            get { return thumb2PosPrice; }
            set
            {
                thumb2PosPrice = value;
            }
        }

        private string _corpCode;
        public string corpCode
        {
            get { return _corpCode; }
            set
            {
                _corpCode = value;
            }
        }

        private int thumb1PosTime;
        public int Thumb1PositionTime
        {
            get { return thumb1PosTime; }
            set
            {
                thumb1PosTime = value;
            }
        }

        private int thumb2PosTime;
        public int Thumb2PositionTime
        {
            get { return thumb2PosTime; }
            set
            {
                thumb2PosTime = value;
            }
        }
    }
}
