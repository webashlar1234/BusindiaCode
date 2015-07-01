using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Phone.UI.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CabSearch : Page
    {
        public CabSearch()
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

        private void rdbtnFullday_Tapped(object sender, TappedRoutedEventArgs e)
        {
              
        }

        private void rdbtnHalfday_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home));
        }

      

       

        private void calander_DisplayDateChanged(object sender, WinRTXamlToolkit.Controls.CalendarDateChangedEventArgs e)
        {

        }

        private void calander_DisplayDateChanged_1(object sender, WinRTXamlToolkit.Controls.CalendarDateChangedEventArgs e)
        {

        }

        private void tabLocal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LocalGrid.Visibility = Visibility.Visible;
            stackBlueLocal.Visibility = Visibility.Visible;
            OutStationGrid.Visibility = Visibility.Collapsed;
            stackBlueOutStation.Visibility = Visibility.Collapsed;
            TransferGrid.Visibility = Visibility.Collapsed;
            stackBlueTransfer.Visibility = Visibility.Collapsed;
            lblLocal.Foreground = new SolidColorBrush(Colors.Black);
           // lblTransfer.Foreground = new SolidColorBrush(Colors.White);
            //lblOutStation.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tabTransfer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LocalGrid.Visibility = Visibility.Collapsed;
            stackBlueLocal.Visibility = Visibility.Collapsed;
            OutStationGrid.Visibility = Visibility.Collapsed;
            stackBlueOutStation.Visibility = Visibility.Collapsed;
            TransferGrid.Visibility = Visibility.Visible;
            stackBlueTransfer.Visibility = Visibility.Visible;

            //lblLocal.Foreground = new SolidColorBrush(Colors.White);
            lblTransfer.Foreground = new SolidColorBrush(Colors.Black);
            //lblOutStation.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tabOutStation_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LocalGrid.Visibility = Visibility.Collapsed;
            stackBlueLocal.Visibility = Visibility.Collapsed;
            OutStationGrid.Visibility = Visibility.Visible;
            stackBlueOutStation.Visibility = Visibility.Visible;
            TransferGrid.Visibility = Visibility.Collapsed;
            stackBlueTransfer.Visibility = Visibility.Collapsed;

           // lblLocal.Foreground = new SolidColorBrush(Colors.White);
            lblTransfer.Foreground = new SolidColorBrush(Colors.Black);
            //lblOutStation.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void rbtnOneWayOutstation_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void rbtnReturnOutstation_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void rbtnMultipleOutstation_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void rbtnAirporttransfer_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void rbtnRailwayStationtransfer_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void rbtnAreaStationtransfer_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void rbtnOneWayOutstation_Checked(object sender, RoutedEventArgs e)
        {
           // rbtnOneWayOutstation.BorderBrush = new SolidColorBrush(Colors.Green);
        }

        private void tabcalenderOutsattion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            cal.Visibility = Visibility.Visible;
            SecondRow.Visibility = Visibility.Collapsed;
            ThirdRow.Visibility = Visibility.Collapsed;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void tabSerchOutstationPickupCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Frame.Navigate(typeof(CabSearchCity));
        }

        private void tabSerchOutstationDropoffCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
           // Frame.Navigate(typeof(CabSearchCity));
        }

        private void tabSerchLocalCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Frame.Navigate(typeof(CabSearchCity));
        }

        private void tabSerchTransferPickupCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Frame.Navigate(typeof(CabSearchCity));
        }

        private void tabSerchTransferDropoffCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
           // Frame.Navigate(typeof(CabSearchCity));
        }

        private void tabSerchTransferCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
           // Frame.Navigate(typeof(CabSearchCity));
        }

        private void btnOutStationSearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CabSearchResult));
        }

        private void imgCabHistory_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CabSearchHistory));
        }

        private void btntransferSearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CabSearchResult));
        }

        private void btnLocalSearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CabSearchResult));
        }
    }
}
