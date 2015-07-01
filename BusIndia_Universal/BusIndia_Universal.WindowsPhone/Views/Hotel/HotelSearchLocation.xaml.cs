using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal.Views.Hotel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HotelSearchLocation : Page
    {
        string parameter = string.Empty;
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;
        string selecteditem { get; set; }
        List<PlaceList> CityList = new List<PlaceList>();
        public HotelSearchLocation()
        {
            this.InitializeComponent();
        }

     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            PlaceList m = new PlaceList();
            postXMLData1();
        }


        public async void postXMLData1()
        {
            try
            {
                StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("PlaceNames.xml");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                XDocument loadedData = XDocument.Parse(timestamp);
                var PlaceList = loadedData.Descendants("PlaceList").
                Select(x => new PlaceList
                {
                    PlaceID = x.Element("placeID").Value,
                    PlaceCode = x.Element("placeCode").Value,
                    PlaceName = x.Element("placeName").Value
                });
                foreach (var item in PlaceList)
                {
                    PlaceList pl = new PlaceList();
                    pl.PlaceID = item.PlaceID;
                    pl.PlaceName = item.PlaceName;
                    pl.PlaceCode = item.PlaceCode;
                    CityList.Add(pl);
                }
                ListMenuItems.ItemsSource = PlaceList;
                LoderPopup.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                PopupError.Visibility = Visibility.Visible;
                LoderPopup.Visibility = Visibility.Collapsed;
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
        }

        private void SearchVisualTree(DependencyObject targetElement)
        {

            var count = VisualTreeHelper.GetChildrenCount(targetElement);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    prevText = textBlock1.Text;
                    if ((textBlock1.Name == "PlaceName") && textBlock1.Text.ToUpper().Contains(txtSerchCity.Text.ToUpper()))
                    {
                        HighlightText();
                    }
                }
                else
                {
                    SearchVisualTree(child);
                }
            }
        }

        /**This method is for highlight the search text**/
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
                    run.Foreground = new SolidColorBrush(Colors.Black);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(0, index) });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(index + lenth) });
                }
            }
        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HotelSearchPage));
        }


        private void txtSerchCity_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListMenuItems.SelectedItem != null)
            {
                PlaceList myobject = ListMenuItems.SelectedItem as PlaceList;          
                Frame.Navigate(typeof(HotelSearchPage), myobject);
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
            this.ListMenuItems.ItemsSource = CityList.Where(w => w.PlaceName.ToLower().Contains(txtSerchCity.Text.ToLower()));
            LayoutUpdateFlag = true;
        }
    }
}
