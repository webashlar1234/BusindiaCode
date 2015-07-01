using BusIndia_Universal.Models;
using BusIndia_Universal.Views.Bus;
using BusIndiaBLL.Helper;
using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
//using WebServiceClassLiberary;
//using WebServiceClassLiberary.Model;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusPickUpPoint : Page
    {

        string parameter = string.Empty;
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;
        string selecteditem { get; set; }
        List<getBoardingPoints> _getBoardingPoints = new List<getBoardingPoints>();
        public BusPickUpPoint()
        {
            this.InitializeComponent();
           
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            postXMLData1();
            
        }

        public async void postXMLData1()
        {
            try
            {
                string uri = AppStatic.WebServiceBaseURL; // some xml string
                Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
                getBoardingPointsRequest _objBPR = new getBoardingPointsRequest();
                _objBPR.franchUserID = AppStatic.franchUserID;
                _objBPR.password = AppStatic.password;
                _objBPR.userID = AppStatic.userID;
                _objBPR.userKey = AppStatic.userKey;
                _objBPR.userName = AppStatic.userName;
                _objBPR.userRole = AppStatic.userRole;
                _objBPR.userStatus = AppStatic.userStatus;
                _objBPR.userType = AppStatic.userType;

                _objBPR.placeIDFrom = pickDropHelper.objGetAvailableService.placeIDFrom;
                _objBPR.placeCodeFrom = pickDropHelper.objGetAvailableService.placeCodeFrom;
                _objBPR.placeNameFrom = pickDropHelper.objGetAvailableService.placeNameFrom;
                _objBPR.placeIDto = pickDropHelper.objGetAvailableService.placeIDto;
                _objBPR.placeCodeTo = pickDropHelper.objGetAvailableService.placeCodeTo;
                _objBPR.placeNameTo = pickDropHelper.objGetAvailableService.placeNameTo;
                _objBPR.journeyDate = pickDropHelper.objGetAvailableService.journeyDate;
                _objBPR.serviceID = pickDropHelper.objGetAvailableService.serviceID;
                _objBPR.placeCodestuFromPlace = pickDropHelper.objGetSeatLayout.placeCodestuFromPlace;
                _objBPR.placeCodestuToPlace = pickDropHelper.objGetSeatLayout.placeCodestuToPlace;
                _objBPR.placeIDstuFromPlace = pickDropHelper.objGetSeatLayout.placeIDstuFromPlace;
                _objBPR.placeIDstuToPlace = pickDropHelper.objGetSeatLayout.placeIDstuToPlace;
                _objBPR.placeNamestuFromPlace = pickDropHelper.objGetSeatLayout.placeNamestuFromPlace;
                _objBPR.placeNamestuToPlace = pickDropHelper.objGetSeatLayout.placeNamestuToPlace;
                _objBPR.stulID = pickDropHelper.objGetAvailableService.studID;

                xmlUtility listings = new xmlUtility();
                XDocument element = listings.getBoardingPoint(_objBPR);

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
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(strXmlReturned);
                XDocument loadedData = XDocument.Parse(strXmlReturned);

                List<getBoardingPoints> sdata = loadedData.Descendants("boardingPoints").Where(c => c.Element("type").Value == "BOARDING POINT").Select(c => new getBoardingPoints()
                {
                    platformNo = c.Element("platformNo").Value,
                    pointID = c.Element("pointID").Value,
                    Time = c.Element("time").Value,
                    Type = c.Element("type").Value,
                    pointName = c.Element("pointName").Value
                }).ToList();
                foreach (var item in sdata)
                {
                    getBoardingPoints _obj = new getBoardingPoints();
                    _obj.platformNo = item.platformNo;
                    _obj.pointID = item.pointID;
                    _obj.pointName = item.pointName;
                    _obj.Time = item.Time;
                    _obj.Type = item.Type;
                    _getBoardingPoints.Add(_obj);
                }
                ListMenuItems.ItemsSource = sdata;
                LoaderPopPickup.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

            }
        }
        private void SearchVisualTree(DependencyObject targetElement)
        {

            var count = VisualTreeHelper.GetChildrenCount(targetElement);//get count targeted dependecnyobject 

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);//detecting listboxitem child items 
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    prevText = textBlock1.Text;
                    if ((textBlock1.Name == "Type") && textBlock1.Text.ToUpper().Contains(txtSerchCity.Text.ToUpper()))
                    {
                        HighlightText();//after finding textblock child item call method for highligh color 
                    }
                }
                else
                {
                    SearchVisualTree(child);//repeat method call until targeted dependency found child items 
                }
            }
        }

       
        private void HighlightText()
        {
            if (textBlock1 != null)
            {
                string text = textBlock1.Text.ToUpper();
                textBlock1.Text = text;
                textBlock1.Inlines.Clear();

                int index = text.IndexOf(txtSerchCity.Text.ToUpper());
                int lenth = txtSerchCity.Text.Length;

                if (!(index < 0))
                {

                    Run run = new Run() { Text = prevText.Substring(index, lenth) };
                    run.Foreground = new SolidColorBrush(Colors.Blue);//format search text color with orange 
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(0, index) });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(index + lenth) });
                }
            }
        }
        private void txtBSerachGridResult_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BusSearchCitySearchClass city = new BusSearchCitySearchClass { DepartureCityOneWay = txtSerchCity.Text };
            Frame.Navigate(typeof(BusPickDropPoint), city);
        }

        private void imgclearCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txtSerchCity.Text = "";
        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BusPickDropPoint));
        }

        private void txtSerchCity_DragLeave(object sender, DragEventArgs e)
        {
        }

        private void txtSerchCity_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListMenuItems.SelectedItem != null)
            {
               
                getBoardingPoints myobject = ListMenuItems.SelectedItem as getBoardingPoints;
                parameter = "PickUp";
                myobject.Lable = parameter;
                Frame.Navigate(typeof(BusPickDropPoint), myobject);
            }
        }
        private void ListMenuItems_LayoutUpdated(object sender, object e)
        {
            if (LayoutUpdateFlag)
            {
                SearchVisualTree(ListMenuItems);
            }
            LayoutUpdateFlag = false;
        }

        private void txtSerchCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ListMenuItems.ItemsSource = _getBoardingPoints.Where(w => w.pointName.ToLower().Contains(txtSerchCity.Text.ToLower()));
            LayoutUpdateFlag = true;
        }
    }
}
