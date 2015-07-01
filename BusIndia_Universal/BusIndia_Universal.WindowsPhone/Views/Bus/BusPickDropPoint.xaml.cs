using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
//using WebServiceClassLiberary.Model;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusPickDropPoint : Page
    {
        public ValidationSelectPoint WM
        {
            get { return (this.DataContext as ValidationSelectPoint); }
            set { this.DataContext = value; }
        }
        string parameter = string.Empty;
        List<getBoardingPoints> _getBoardingPoints = new List<getBoardingPoints>();
        getBoardingPoints _obj = new getBoardingPoints();
       string commantripType= "";
        public BusPickDropPoint()
        {
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            WM = new ValidationSelectPoint();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           if (e.Parameter is GetAvailableService)
           {
               
               var nav = (GetAvailableService)e.Parameter;
               if (nav.tripType == "RoundTrip")
               {
                   commantripType = "RoundTrip";
                   var test = nav.SearNumbers.ToList();
                   string str = string.Empty;
                   foreach (var item in test)
                   {
                       str = str + item + ",";
                   }
                   str = str.Remove(str.Length - 1);
                   txtBSeatsType.Text = str;
               }
               else if (nav.tripType == "FirstTrip")
               {
                   commantripType = "FirstTrip";
                   var test = nav.SearNumbers.ToList();
                   string str = string.Empty;
                   foreach (var item in test)
                   {
                       str = str + item + ",";
                   }
                   str = str.Remove(str.Length - 1);
                   txtBSeatsType.Text = str;
               }
               else
               {
                   var test = nav.SearNumbers.ToList();
                   string str = string.Empty;
                   foreach (var item in test)
                   {
                       str = str + item + ",";
                   }
                   str = str.Remove(str.Length - 1);
                   txtBSeatsType.Text = str;
               }
           }
           else if (e.Parameter is getBoardingPoints)
           {
               var nav = (getBoardingPoints)e.Parameter;
               if (nav.Lable == "PickUp")
               {
                   txtbPickupPoint.Text = nav.pointName;
                   txtbPickupTime.Text = nav.Time;
                   txtBPUP.Text = "Boarding point";
               }
               else if (nav.Lable == "DropOff")
               {
                   txtBDropOffPoint.Text = nav.pointName;
                   txtbDropOffTime.Text = nav.Time;
                   txtBDRP.Text = "Drop-off point";
               }

           }
           
            GetAllDetails();
        }

        public void GetAllDetails()
        {
            txtbFrom.Text = pickDropHelper.objGetAvailableService.corpCode;
            txtbviarouts.Text = pickDropHelper.objGetAvailableService.viaPlaces;
            txtbDTripPrice.Text = pickDropHelper.objGetAvailableService.fare;
            string d1 = pickDropHelper.objGetAvailableService.journeyDate;
            System.DateTime dt1 = System.DateTime.ParseExact(d1, "d/M/yyyy", CultureInfo.InvariantCulture);                      
            txtbFromDateD.Text = dt1.ToString("dd MMM yyyy");
            txtbFromLocationD.Text = pickDropHelper.objGetAvailableService.placeNameFrom;
            txtbFromTimeD.Text = pickDropHelper.objGetAvailableService.departureTime;
            string d2 = pickDropHelper.objGetAvailableService.journeyDate;
            System.DateTime dt2 = System.DateTime.ParseExact(d2, "d/M/yyyy", CultureInfo.InvariantCulture);
            txtbToDateD.Text = dt2.ToString("dd MMM yyyy");
            txtbToLocationD.Text = pickDropHelper.objGetAvailableService.placeNameTo;
            txtbToTimeD.Text = pickDropHelper.objGetAvailableService.arrivalTime;
            txtBFromLocationT.Text = pickDropHelper.objGetAvailableService.placeNameFrom;
            txtBToLocationT.Text = pickDropHelper.objGetAvailableService.placeNameTo;
            txtbSelectedSeats.Text = pickDropHelper.objGetSeatLayout.SelectedSeat;

        }


        private async void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSeatSelection)));
           // Frame.Navigate(typeof(BusSeatSelection));          
        }

        private async void StackPDropOffPoint_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusDropOffPoint)));
           // Frame.Navigate(typeof(BusDropOffPoint));          
            txtBCommonPickDrop.Text = "DropOff";        
        }

        private async void StackPickUpPoint_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusPickUpPoint)));
            //Frame.Navigate(typeof(BusPickUpPoint));        
            txtBCommonPickDrop.Text = "PickUp";          
        }

      

       
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ValidationPopup.Visibility = Visibility.Collapsed;
        }
        private async void txtBNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txtbPickupPoint.Text == "Please select boarding point")
            {
                WM.errorMessage = "No Boarding Point selected ! " + Environment.NewLine + "Please select a Boarding Point";
                ValidationPopup.Visibility = Visibility.Visible;
            }
            else if (txtBDropOffPoint.Text == "Please select drop-off point")
            {
                WM.errorMessage = "No Drop Off Point selected !" + Environment.NewLine + "Please select a Drop Off Point";
                ValidationPopup.Visibility = Visibility.Visible;
            }
            else
            {
                if (commantripType == "RoundTrip")
                {
                    PickupDropoffRequest _objpdr = new PickupDropoffRequest();
                    _objpdr.dropOffTime = txtbDropOffTime.Text;
                    _objpdr.dropOffPoint = txtBDropOffPoint.Text;
                    _objpdr.pickupTime = txtbPickupTime.Text;
                    _objpdr.pickupPoint = txtbPickupPoint.Text;
                    _objpdr.numberOfSeats = txtbSelectedSeats.Text;
                    _objpdr.seatsType = txtBSeatsType.Text;
                    pickDropHelper.objGetPickDrop = _objpdr;
                    txtBDRP.Text = "";
                    txtBPUP.Text = "";
                    txtbPickupTime.Text = "";
                    txtbPickupPoint.Text = "Please select boarding point";
                    txtbDropOffTime.Text = "";
                    txtBDropOffPoint.Text = "Please select drop-off point";
                    PageNavigationMode.Mode = PageTransmission.Bottom;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(PasangerInformation), _objpdr));
                  //  Frame.Navigate(typeof(PasangerInformation), _objpdr);
                }
                else if (commantripType == "FirstTrip")
                {
                    PickupDropoffReturn _objpdr = new PickupDropoffReturn();
                    _objpdr.dropOffTime = txtbDropOffTime.Text;
                    _objpdr.dropOffPoint = txtBDropOffPoint.Text;
                    _objpdr.pickupTime = txtbPickupTime.Text;
                    _objpdr.pickupPoint = txtbPickupPoint.Text;
                    _objpdr.numberOfSeats = txtbSelectedSeats.Text;
                    _objpdr.seatsType = txtBSeatsType.Text;
                    pickDropHelper.objGetPickDropReturn = _objpdr;
                    pickDropHelper.objgetBusSearch.LabelReturn = "RoundTrip";
                    txtbPickupTime.Text = "";
                    txtbPickupPoint.Text = "Please select boarding point";
                    txtbDropOffTime.Text = "";
                    txtBDropOffPoint.Text = "Please select drop-off point";
                    txtBDRP.Text = "";
                    txtBPUP.Text = "";
                    PageNavigationMode.Mode = PageTransmission.Bottom;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(TripSearch), pickDropHelper.objgetBusSearch));
                   // Frame.Navigate(typeof(TripSearch), pickDropHelper.objgetBusSearch);
                }
                else
                {
                    PickupDropoffRequest _objpdr = new PickupDropoffRequest();
                    _objpdr.dropOffTime = txtbDropOffTime.Text;
                    _objpdr.dropOffPoint = txtBDropOffPoint.Text;
                    _objpdr.pickupTime = txtbPickupTime.Text;
                    _objpdr.pickupPoint = txtbPickupPoint.Text;
                    _objpdr.numberOfSeats = txtbSelectedSeats.Text;
                    _objpdr.seatsType = txtBSeatsType.Text;
                    pickDropHelper.objGetPickDrop = _objpdr;
                    txtbPickupTime.Text = "";
                    txtbPickupPoint.Text = "Please select boarding point";
                    txtbDropOffTime.Text = "";
                    txtBDropOffPoint.Text = "Please select drop-off point";
                    PageNavigationMode.Mode = PageTransmission.Bottom;
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(PasangerInformation), _objpdr));
                    //Frame.Navigate(typeof(PasangerInformation), _objpdr);
                }
            }
        }
    }
}
