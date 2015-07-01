using BusIndia_Universal.Models;
using BusIndia_Universal.Views.Bus;
using BusIndiaBLL.Helper;
using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class BusSearch : Page
    {
        public static BusSearch Current;
        string label = string.Empty;
        private DispatcherTimer _timer;
        public BusSearch()
        {
            try
            {
                this.InitializeComponent();
                HomeModel homeModel = new HomeModel();
                CommonModel.bgImage = homeModel.bgImage;
                imgBack.Source = homeModel.bgImage;
                this.NavigationCacheMode = NavigationCacheMode.Required;
                _timer = new DispatcherTimer();
                arrivalDatePicker.Date.ToString("dd MMM yyyy");
                arrivalDatePicker.MinYear = Convert.ToDateTime(DateTime.Now);
                LoderPopup.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          arrivalDatePicker.Date.Equals(arrivalDatePicker.Date.ToString("dd MMM yyyy"));
            try
            {
                HomeModel homeModel = new HomeModel();
                CommonModel.bgImage = homeModel.bgImage;
                imgBack.Source = homeModel.bgImage;

                arrivalDatePicker.MinYear = Convert.ToDateTime(DateTime.Now);
                var nav = (PlaceList)e.Parameter;

                if (e.Parameter != null)
                {
                    string l1 = nav.Label;
                    if (l1 == "fromlocation")
                    {

                        lblSourceNameoneway.Text = nav.PlaceName;
                       

                        lblSourceCodeNameoneway.Text = nav.PlaceCode;
                        lblSourceIDNameoneway.Text = nav.PlaceID;
                        lblSourcrReturnName.Text = nav.PlaceName;
                    }
                    else if (l1 == "tolocation")
                    {
                        lblDestinationNameoneway.Text = nav.PlaceName;                      

                        lblDestinationCodeNameoneway.Text = nav.PlaceCode;
                        lblDestinationIDNameoneway.Text = nav.PlaceID;
                        lblDestReturnName.Text = nav.PlaceName;
                    }
                    else if (l1 == "fromlocationsearchreturn")
                    {
                        lblSourcrReturnName.Text = nav.PlaceName;

                        // lblSourceNameoneway.Text = nav.PlaceName;
                        lblSourceCodeNameoneway.Text = nav.PlaceCode;
                        lblSourceIDNameoneway.Text = nav.PlaceID;
                        lblSourcrReturnName.Text = nav.PlaceName;

                        stackBlueOne.Visibility = Visibility.Visible;
                        stackBlue.Visibility = Visibility.Collapsed;
                        OneWayGrid.Visibility = Visibility.Collapsed;
                        ReturnGrid.Visibility = Visibility.Visible;

                    }
                    else if (l1 == "tolocationsearchreturn")
                    {
                        lblDestReturnName.Text = nav.PlaceName;

                        lblDestinationCodeNameoneway.Text = nav.PlaceCode;
                        lblDestinationIDNameoneway.Text = nav.PlaceID;
                        lblDestReturnName.Text = nav.PlaceName;
                      
                        stackBlueOne.Visibility = Visibility.Visible;
                        stackBlue.Visibility = Visibility.Collapsed;
                        OneWayGrid.Visibility = Visibility.Collapsed;
                        ReturnGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {

                    }
                }

                switch (PageNavigationMode.Mode)
                {
                    case "Top":
                        {
                            Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
                            break;
                        }
                    case "Bottom":
                        {
                            Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Bottom } };
                            break;
                        }
                    case "Left":
                        {
                            Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Left } };
                            break;
                        }
                    case "Right":
                        {
                            Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Right } };
                            break;
                        }
                    default:
                        {
                            Frame.ContentTransitions = new TransitionCollection { new PaneThemeTransition { Edge = EdgeTransitionLocation.Top } };
                            break;
                        }
                }
                postXMLData1();
            }

            catch
            {

            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
        public void postXMLData1()
        {
             var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async() =>
             {
            try
            {

                string uri = AppStatic.WebServiceBaseURL;  // some xml string
                Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
                xmlUtility listings = new xmlUtility();
                getPlaceListRequest _objgetPlaceListRequest = listings.GetUserRequestParameters();
                XDocument element = listings.getList(_objgetPlaceListRequest);
                string file = element.ToString();
                var httpClient = new Windows.Web.Http.HttpClient();
                var info = AppStatic.WebServiceAuthentication;
                var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
                httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
                httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
                Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
                httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
                IHttpContent content = new HttpStringContent(file, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                httpRequestMessage.Content = content;
                Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);
                string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();

                byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(strXmlReturned);
                StorageFile files = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("PlaceNames.xml", CreationCollisionOption.ReplaceExisting);
                String historyTestContent = await FileIO.ReadTextAsync(files);
                using (var stream = await files.OpenStreamForWriteAsync())
                {                    
                    stream.Write(fileBytes, 0, fileBytes.Length);
                }
                LoderPopup.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                ErrorpopUp.Visibility = Visibility.Visible;
                LoderPopup.Visibility = Visibility.Collapsed;
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
             }).AsTask();

        }
        public List<Scenario> Scenarios
        {
            get { return this.Scenarios; }
        }
        private void tabOneWay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            stackBlue.Visibility = Visibility.Visible;
            stackBlueOne.Visibility = Visibility.Collapsed;
            ReturnGrid.Visibility = Visibility.Collapsed;
            OneWayGrid.Visibility = Visibility.Visible;
        }

        private void tabRoundTrip_Tapped(object sender, TappedRoutedEventArgs e)
        {
            stackBlueOne.Visibility = Visibility.Visible;
            stackBlue.Visibility = Visibility.Collapsed;
            OneWayGrid.Visibility = Visibility.Collapsed;
            ReturnGrid.Visibility = Visibility.Visible;
        }

        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            lblDestinationNameoneway.Text = "Select";
            lblDestinationCodeNameoneway.Text = "Select";
            lblSourceNameoneway.Text = "Select";
            lblSourcrReturnName.Text = "Select";
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(Home));

        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void calander_DisplayDateChanged(object sender, WinRTXamlToolkit.Controls.CalendarDateChangedEventArgs e)
        {

            MyAccountTab.Visibility = Visibility.Visible;
            ContentPanel.Visibility = Visibility.Visible;
            cal.Visibility = Visibility.Collapsed;

        }

        private async void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            try
            {
                if (lblSourceNameoneway.Text == "Select" || lblDestinationNameoneway.Text == "Select")
                {
                    PopupValidation.Visibility = Visibility.Visible;
                }
                else if (lblSourceNameoneway.Text == lblDestinationNameoneway.Text)
                {
                    PopupSameCity.Visibility = Visibility.Visible;
                }
                else
                {
                    getBusSearch _objBusSerchIn = new getBusSearch();
                    _objBusSerchIn.placeCodeTo = lblDestinationCodeNameoneway.Text;
                    _objBusSerchIn.placeIDFrom = lblSourceIDNameoneway.Text;
                    _objBusSerchIn.placeIDTo = lblDestinationIDNameoneway.Text;
                    _objBusSerchIn.placeCodeFrom = lblSourceCodeNameoneway.Text;
                    _objBusSerchIn.Fromplace = lblSourceNameoneway.Text;
                    _objBusSerchIn.Toplace = lblDestinationNameoneway.Text;
                    _objBusSerchIn.Date = arrivalDatePicker.Date.ToString("dd MMM yyyy");                   
                    _objBusSerchIn.Label = "SingleBusSearch";
                    _objBusSerchIn.LabelReturn = "Empty";
                    lblDestinationNameoneway.Text = "Select";
                    lblDestinationCodeNameoneway.Text = "Select";
                    lblSourceNameoneway.Text = "Select";
                    lblSourcrReturnName.Text = "Select";
                    PageNavigationMode.Mode = PageTransmission.Bottom;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(TripSearch), _objBusSerchIn));
                  //  this.Frame.Navigate(typeof(TripSearch), _objBusSerchIn);

                }
            }
            catch
            {

            }
        }





        private void tabgreatSaving_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                stackBlueOne.Visibility = Visibility.Visible;
                stackBlue.Visibility = Visibility.Collapsed;
                OneWayGrid.Visibility = Visibility.Collapsed;
                ReturnGrid.Visibility = Visibility.Visible;

            }
            catch
            {

            }
        }

        private async void tapfromlocationsearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                label = "fromlocation";
                PageNavigationMode.Mode = PageTransmission.Bottom;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearchDepartureCity), label));
               // this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
            }
            catch
            {

            }
        }

        private async void taptolocationsearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                label = "tolocation";
                PageNavigationMode.Mode = PageTransmission.Bottom;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearchDepartureCity), label));
                //this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
            }
            catch
            {

            }
        }

        private async void tabfromlocationsearchreturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                label = "fromlocationsearchreturn";
                PageNavigationMode.Mode = PageTransmission.Bottom;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearchDepartureCity), label));
               // this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
            }
            catch
            {

            }

        }

        private async void tabtolocationsearchreturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                label = "tolocationsearchreturn";
                PageNavigationMode.Mode = PageTransmission.Bottom;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearchDepartureCity), label));
              //  this.Frame.Navigate(typeof(BusSearchDepartureCity), label);
            }
            catch
            {

            }
        }

        private async void imgSearchHistory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                PageNavigationMode.Mode = PageTransmission.Bottom;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearchHistory)));
              //  this.Frame.Navigate(typeof(BusSearchHistory));

            }
            catch
            {


            }
        }

        private void tapCloseValidationPopup_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopupValidation.Visibility = Visibility.Collapsed;
        }

        private async void tapSearchReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            if (lblSourcrReturnName.Text == "Select" || lblDestReturnName.Text == "Select")
            {
                PopupValidation.Visibility = Visibility.Visible;
            }
            else if (lblSourcrReturnName.Text == lblDestReturnName.Text)
            {
                PopupSameCity.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    getBusSearch _objBusSerchIn = new getBusSearch();
                    _objBusSerchIn.placeCodeTo = lblDestinationCodeNameoneway.Text;
                    _objBusSerchIn.placeIDFrom = lblSourceIDNameoneway.Text;
                    _objBusSerchIn.placeIDTo = lblDestinationIDNameoneway.Text;
                    _objBusSerchIn.placeCodeFrom = lblSourceCodeNameoneway.Text;
                    _objBusSerchIn.Fromplace = lblSourcrReturnName.Text;
                    _objBusSerchIn.Toplace = lblDestReturnName.Text;
                    _objBusSerchIn.Date = roundTripDepartDatePicker.Date.ToString("dd MMM yyyy");
                    _objBusSerchIn.DateReturn = roundTripreturnDatePicker.Date.ToString("dd MMM yyyy");
                    _objBusSerchIn.Label = "ReturneBusSearch";
                    _objBusSerchIn.LabelReturn = "FirstTrip";
                    pickDropHelper.objgetBusSearch = _objBusSerchIn;
                    lblDestinationNameoneway.Text = "Select";
                    lblDestinationCodeNameoneway.Text = "Select";
                    lblSourceNameoneway.Text = "Select";
                    lblSourcrReturnName.Text = "Select";
                    PageNavigationMode.Mode = PageTransmission.Bottom;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(TripSearch), _objBusSerchIn));
                    //this.Frame.Navigate(typeof(TripSearch), _objBusSerchIn);
                }
                catch (Exception ex)
                {
                    throw;
                };
            }
        }

        private void tapPopupSameCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopupSameCity.Visibility = Visibility.Collapsed;
        }

        private void lblNo_Click(object sender, RoutedEventArgs e)
        {
            PopupSameCity.Visibility = Visibility.Collapsed;
        }

        private async void lblRetry_Click(object sender, RoutedEventArgs e)
        {
            ErrorpopUp.Visibility = Visibility.Collapsed;
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearch)));
            LoderPopup.Visibility = Visibility.Visible;
        }

        private async  void lblCancel_Click(object sender, RoutedEventArgs e)
        {
            
            ErrorpopUp.Visibility = Visibility.Collapsed;
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(Home)));
        }

        private void lblOk_Click(object sender, RoutedEventArgs e)
        {
            PopupSameCity.Visibility = Visibility.Collapsed;
        }
    }
}
