using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.Core;
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
    public sealed partial class BusConfirmation : Page
    {
        public BusConfirmation()
        {
          
            this.InitializeComponent();
            InitialData();
        }

        public void InitialData()
        {
            txtBArrivingTimeDP.Text = pickDropHelper.objGetAvailableService.arrivalTime;
            txtBConfirmationCodeDP.Text = pickDropHelper.objGetAvailableService.tripCode;
            txtBStartDateDP.Text = pickDropHelper.objGetAvailableService.arrivalDate;
            txtBLocationDP.Text = pickDropHelper.objGetAvailableService.className;
            txtBRoutDP.Text = pickDropHelper.objGetAvailableService.viaPlaces;
            txtBFromLocationDP.Text = pickDropHelper.objGetAvailableService.placeNameFrom;
            txtBToLocationDP.Text = pickDropHelper.objGetAvailableService.placeNameTo;
            txtBStationDP.Text = pickDropHelper.objGetPickDrop.pickupPoint;
            txtBPickupTimeDP.Text = pickDropHelper.objGetPickDrop.pickupTime;
            txtBDepartingDateDP.Text = pickDropHelper.objGetAvailableService.departureTime;
            txtBSeatsDP.Text = pickDropHelper.objGetPickDrop.seatsType;
            txtBTripCodeDP.Text = pickDropHelper.objGetAvailableService.tripCode;

        }
      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage; 
        }

        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void imgCofirm_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(Home)));
          //  this.Frame.Navigate(typeof(Home));
        }

        private void stkReturnTrip_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OneWayGridDP.Visibility = Visibility.Collapsed;
            OneWayGridRT.Visibility = Visibility.Visible;

            stkDepartureTrip.Background = new SolidColorBrush(Colors.Transparent);
            stkReturnTrip.Background = new SolidColorBrush(Colors.White);


            txtBReturnTrip.Foreground = new SolidColorBrush(Colors.Black);
            txtBDepartureTrip.Foreground = new SolidColorBrush(Colors.White);
        }

        private void stkDepartureTrip_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OneWayGridRT.Visibility = Visibility.Collapsed;
            OneWayGridDP.Visibility = Visibility.Visible;

            stkDepartureTrip.Background = new SolidColorBrush(Colors.White);
            stkReturnTrip.Background = new SolidColorBrush(Colors.Transparent);


            txtBReturnTrip.Foreground = new SolidColorBrush(Colors.White);
            txtBDepartureTrip.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
