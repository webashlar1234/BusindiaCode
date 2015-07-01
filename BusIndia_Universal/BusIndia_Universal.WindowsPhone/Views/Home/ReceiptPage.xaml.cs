using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class ReceiptPage : Page
    {
        public ReceiptPage()
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
            MytripList SelectedTrip = e.Parameter as MytripList;
            TripReceipt tripReceipt = new TripReceipt();
            tripReceipt.ArrivalTime = SelectedTrip.arrivaltime;
            tripReceipt.AvailbleSeat = "12A,12C,12B";
            tripReceipt.CustomerName = "MR. Dharmin Naik";
            tripReceipt.DepartDate = SelectedTrip.datedepart;
            tripReceipt.DepartFrom = SelectedTrip.From;
            tripReceipt.DepartTime = SelectedTrip.departtime;
            tripReceipt.StationName = "KRTC";
            tripReceipt.TotalCost = "625.50";
            tripReceipt.TravelBy = SelectedTrip.travelby;
            tripReceipt.TravelTo = SelectedTrip.To;
            tripReceipt.Via = "MYC,BKC,BC ROAD";
            this.DataContext = tripReceipt;
        }

        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
