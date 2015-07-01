using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HotelDetails : Page
    {
        public HotelDetails()
        {
            this.InitializeComponent();
            myMapControl1.Center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = 47.604,
                    Longitude = -122.329
                });
            myMapControl1.ZoomLevel = 12;
            myMapControl1.LandmarksVisible = true;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelAvailibility));
        }

        private void imgMapL_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void imgMapS_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void imgMapK_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelBookingSummary));
        }
    }
}
