using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusBookingSummary : Page
    {
        PassengerInfoDetails obj = new PassengerInfoDetails();
      public List<PassengerInfoDetails> objs = new List<PassengerInfoDetails>();
       
        public BusBookingSummary()
        {

            int Price1 = 0;
            int Price2 = 0;
            this.InitializeComponent();
           
           if(pickDropHelper.objGetAvailableService.tripType!="Single")
           {
               OneWayGridD.Visibility = Visibility.Visible;
                txtbCorpType.Text = pickDropHelper.objGetASReturn.corpCode;
                txtbClassType.Text = pickDropHelper.objGetASReturn.className;
                txtbDTripPrice.Text = pickDropHelper.objGetASReturn.fare;
                txtbFromDateD.Text = pickDropHelper.objGetASReturn.journeyDate;
                txtBJournytime.Text = pickDropHelper.objGetASReturn.journeyHours;
                txtbFromLocationD.Text = pickDropHelper.objGetASReturn.placeNameFrom;
                txtbToLocationD.Text = pickDropHelper.objGetASReturn.placeNameTo;
                txtbFromTimeD.Text = pickDropHelper.objGetASReturn.departureTime;
                txtbToTimeD.Text = pickDropHelper.objGetASReturn.arrivalTime;
                txtbToDateD.Text = pickDropHelper.objGetASReturn.journeyDate;
                txtbTripCodeD.Text = pickDropHelper.objGetAvailableService.tripCode;
                txtbSeatNumberD.Text = pickDropHelper.objGetPickDropReturn.seatsType;
                txtbPickuplocationD.Text = pickDropHelper.objGetPickDropReturn.pickupPoint;
                txtbPickupTimeD.Text = pickDropHelper.objGetPickDropReturn.pickupTime;
                txtbBustypeD.Text = pickDropHelper.objGetASReturn.className;
                Price2 = Convert.ToInt32(pickDropHelper.objGetASReturn.fare);
           }
            txtbCorpTypeR.Text = pickDropHelper.objGetAvailableService.corpCode;
            txtbClassTypeR.Text = pickDropHelper.objGetAvailableService.className;
            txtbDTripPriceR.Text = pickDropHelper.objGetAvailableService.fare;
            txtbFromDateR.Text = pickDropHelper.objGetAvailableService.journeyDate;
            txtBJournytimeR.Text = pickDropHelper.objGetAvailableService.journeyHours;
            txtbFromLocationR.Text = pickDropHelper.objGetAvailableService.placeNameFrom;
            txtbToLocationR.Text = pickDropHelper.objGetAvailableService.placeNameTo;
            txtbFromTimeR.Text = pickDropHelper.objGetAvailableService.departureTime;
            txtbToTimeR.Text = pickDropHelper.objGetAvailableService.arrivalTime;
            txtbToDateR.Text = pickDropHelper.objGetAvailableService.journeyDate;          
             txtbTripCodeR.Text = pickDropHelper.objGetAvailableService.tripCode;
            txtbSeatNumberR.Text = pickDropHelper.objGetPickDrop.seatsType;
            txtbPickuplocationR.Text = pickDropHelper.objGetPickDrop.pickupPoint;
            txtbPickupTimeR.Text = pickDropHelper.objGetPickDrop.pickupTime;
            txtbBustypeR.Text = pickDropHelper.objGetAvailableService.className;
          
            int totalseat = Convert.ToInt32(pickDropHelper.objGetPickDrop.numberOfSeats);
            Price1 = Convert.ToInt32(pickDropHelper.objGetAvailableService.fare);
            
            txtbTotalPrice.Text = Convert.ToString(((Price1) * (totalseat)) + ((Price2) * (totalseat)));

        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        /// 
      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            var nav = (PassengerInfoDetails)e.Parameter;
            if (nav != null)
            {
                foreach (var list in nav.passengerName)
                {
                    obj.passengerName = nav.passengerName;
                    obj.passengerGender = nav.passengerGender;
                    obj.passengerAge = nav.passengerAge;
                    obj.IDProof = nav.IDProof;
                    obj.Mobile = nav.Mobile;
                    obj.Email = nav.Email;
                    obj.TotalAmount = txtbTotalPrice.Text;
                    break;

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
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;            
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(PaymentOptionsPage)));
          //  this.Frame.Navigate(typeof(PaymentOptionsPage), obj);
        }

        private async void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(PasangerInformation)));
           // this.Frame.Navigate(typeof(PasangerInformation));
        }               
    }
}
