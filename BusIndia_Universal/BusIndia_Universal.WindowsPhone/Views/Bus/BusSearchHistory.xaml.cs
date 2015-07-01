using BusIndia_Universal.Models;
using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
//using WebServiceClassLiberary;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    // An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusSearchHistory : Page
    {
       
        List<GetAvailableService> availableservice = new List<GetAvailableService>();
        public BusSearchHistory()
        {
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
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
            postXMLData1();
        }

       
        public async void postXMLData1()
        {
            try
            {
                //var sampleFile1 = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("HistoryTest1.xml");
                //await sampleFile1.DeleteAsync(StorageDeleteOption.PermanentDelete);     

                StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("HistoryTest1.xml");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                String HistorySearch = "<arg>" + timestamp + "</arg>";
                XDocument loadedDatas = XDocument.Parse(HistorySearch);
                var sdata = loadedDatas.Descendants("arg0").
                       Select(x => new GetAvailableServicesRequest
                       {
                           placeCodeFrom = x.Element("biFromPlace").Element("placeCode").Value,
                           placeCodeTo = x.Element("biToPlace").Element("placeCode").Value,
                           placeIDFrom = x.Element("biFromPlace").Element("placeID").Value,
                           placeIDto = x.Element("biToPlace").Element("placeID").Value,
                           placeNameFrom = x.Element("biFromPlace").Element("placeName").Value,
                           placeNameTo = x.Element("biToPlace").Element("placeName").Value,
                           journeyDate = x.Element("journeyDate").Value

                       });
                ListMenuItems.ItemsSource = sdata;

                List<XElement> _srow = (from t1 in loadedDatas.Descendants("biFromPlace") select t1).ToList();
                List<GetAvailableServicesRequest> srow = new List<GetAvailableServicesRequest>();
                foreach (XElement _elemetsr in _srow)
                {
                    GetAvailableServicesRequest _objsr = new GetAvailableServicesRequest();
                    _objsr.placeCodeFrom = _elemetsr.Element("placeCode").Value.ToString();                   
                    _objsr.placeIDFrom = _elemetsr.Element("placeID").Value.ToString();                  
                    _objsr.placeNameFrom = _elemetsr.Element("placeName").Value.ToString();                 
                    srow.Add(_objsr);
                }
            }
            catch(Exception ex)
            {
                btnClearAll.Visibility = Visibility.Collapsed;
                PopupError.Visibility = Visibility.Visible;
                ExceptionLog obj= new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }

        }
        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BusSearch));
        }

        private void imgNextArrow_Tapped(object sender, TappedRoutedEventArgs e)
        {
           // Frame.Navigate(typeof(TripSearch));
        }

        private async void btnClearAll_Tapped(object sender, TappedRoutedEventArgs e)
        {
             var sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("HistoryTest1.xml");
             await sampleFile.DeleteAsync(StorageDeleteOption.PermanentDelete);           
            Frame.Navigate(typeof(BusSearch));
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
