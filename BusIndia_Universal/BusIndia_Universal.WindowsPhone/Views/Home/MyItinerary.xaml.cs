using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
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
    public sealed partial class MyItinerary : Page
    {
        public MyItinerary()
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
        }

        private void stkUpcomingBooking_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OneWayGridUp.Visibility = Visibility.Collapsed;
            OneWayGridPrev.Visibility = Visibility.Visible;
           
            stkUpcomingBooking.Background = new SolidColorBrush(Colors.White);
            stkPreviousBooking.Background = new SolidColorBrush(Colors.Transparent);
           

            txtBUpcomingBooking.Foreground = new SolidColorBrush(Colors.Black);
            txtBPreviousBooking.Foreground = new SolidColorBrush(Colors.White);
            
        }

        private void stkPreviousBooking_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OneWayGridUp.Visibility = Visibility.Visible;
            OneWayGridPrev.Visibility = Visibility.Collapsed;

            stkUpcomingBooking.Background = new SolidColorBrush(Colors.Transparent);
            stkPreviousBooking.Background = new SolidColorBrush(Colors.White);


            txtBUpcomingBooking.Foreground = new SolidColorBrush(Colors.White);
            txtBPreviousBooking.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home));
        }
    }
}
