using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using System.Reflection;
using System.Windows;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {

        public Home()
        {
            try
            {
                this.InitializeComponent();
                HomeModel homeModel = new HomeModel();
                CommonModel.isUserLogin = false;
                CommonModel.bgImage = homeModel.bgBlurImage;
                homeModel.isUserLogin = CommonModel.isUserLogin;
                homeModel.isBusCodesAvailble = true;
                homeModel.isCabCodesAvailble = true;
                homeModel.isHotelCodesAvailble = true;
                if (CommonModel.isUserLogin)
                {
                    homeModel.userImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/hdpi/home_logged_in.png", UriKind.RelativeOrAbsolute));
                }
                IList<OfferList> _TextLists = new List<OfferList>();
                OfferList item = new OfferList();
                item.OfferText = "500rs Off on hotel Booking 500rs Off on hotel Booking";
                item.OfferCode = "BIHOTEL500";
                _TextLists.Add(item);
                OfferList item1 = new OfferList();
                item1.OfferText = "100rs cashback on your cab Booking";
                item1.OfferCode = "BICAb100";
                _TextLists.Add(item1);
                OfferList item2 = new OfferList();
                item2.OfferText = "100rs Off on next bus Booking";
                item2.OfferCode = "BIBUS10000";
                _TextLists.Add(item2);
                for (int i = 0; i < 5; i++)
                {
                    OfferList item3 = new OfferList();
                    item3.OfferText = "200 Rs OFf on cab booking";
                    item3.OfferCode = "BIBus200";
                    _TextLists.Add(item3);

                }
                ListBoxBusCode.ItemsSource = _TextLists.ToList();

                List<MytripList> tripList = new List<MytripList>();
                for (int i = 0; i < 5; i++)
                {
                    MytripList trip = new MytripList();
                    trip.From = "BANGLORE" + i;
                    trip.To = "MANGLORE" + i;
                    trip.travelby = "BUS";
                    trip.departtime = "10:30 AM";
                    trip.arrivaltime = "3:30 PM";
                    trip.datedepart = "18th feb 2015";
                    tripList.Add(trip);
                }

                MyTripList.ItemsSource = tripList.ToList();
                this.DataContext = homeModel;
                this.InitializeComponent();
                Frame mainFrame = Window.Current.Content as Frame;
                mainFrame.ContentTransitions = null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        
        public string settext(string copytext)
        {
            return "copied";
        }

        private void ReadCallback(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }
     

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
           
        }
      
        private void OpenClose_Left(object sender, RoutedEventArgs e)
        {
            try
            {
                var left = Canvas.GetLeft(LayoutRoot);
                if (left > -100)
                {

                    MoveViewWindow(-300);
                }
                else
                {

                    MoveViewWindow(0);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void SelectLogin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginMain));
        }

        void MoveViewWindow(double left)
        {
            try
            {
                _viewMoved = true;
                ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
                ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = left;
                ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void canvas_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < 0)
                Canvas.SetLeft(LayoutRoot, Convert.ToDouble(Math.Min(Math.Max(-300, Canvas.GetLeft(LayoutRoot) + e.Cumulative.Translation.X), 0)));
        }

        double initialPosition;
        bool _viewMoved = false;
        private void canvas_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            _viewMoved = false;
            initialPosition = Canvas.GetLeft(LayoutRoot);
        }

        private void canvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);           

        }

        
        private async void Bus_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            //this.Frame.Navigate(typeof(BusSearch));
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(BusSearch)));
        }
        private async void Cabs_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
           // this.Frame.Navigate(typeof(CabSearch));
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(CabSearch)));
        }
        private async void Hotels_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            //this.Frame.Navigate(typeof(HotelSearchPage));
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(HotelSearchPage)));
        }

        private async void MyAccount_Tap(object sender, TappedRoutedEventArgs e)
        {
          //  this.Frame.Navigate(typeof(MyAccount));
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(MyAccount)));
        }
        private async void MyItineraries_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(MyItinerary)));
          //  this.Frame.Navigate(typeof(MyItinerary));

        }
        private void RateUs_Tap(object sender, TappedRoutedEventArgs e)
        {

        }
        private void ShareIt_Tap(object sender, TappedRoutedEventArgs e)
        {

        }
        private async void Feedback_Tap(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(FeedBack)));
            //this.Frame.Navigate(typeof(FeedBack));
        }

        private void OfferItemTapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                PopUpGrid.Visibility = Visibility.Visible;
                if (sender != null && sender is StackPanel)
                {
                    StackPanel stack = sender as StackPanel;
                    if (stack.DataContext is OfferList)
                    {
                        OfferList offer = stack.DataContext as OfferList;
                        if (offer != null)
                        {
                            PopUpGrid.DataContext = offer;
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void OfferClose(object sender, RoutedEventArgs e)
        {
            PopUpGrid.Visibility = Visibility.Collapsed;         

        }

        private void OfferCode_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void txtOfferCode_GotFocus(object sender, RoutedEventArgs e)
        {

           
        }

        private async void TripListItemTapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender != null && sender is StackPanel)
            {
                StackPanel stack = sender as StackPanel;
                if (stack.DataContext is MytripList)
                {
                    MytripList tripDetail = stack.DataContext as MytripList;
                    if (tripDetail != null)
                    {
                        PageNavigationMode.Mode = PageTransmission.Left;
                        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(ReceiptPage), tripDetail));
                        //this.Frame.Navigate(typeof(ReceiptPage), tripDetail);
                    }
                }
            }

        }


        private void MenuOpenClose(object sender, TappedRoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -100)
            {
                
                MoveViewWindow(-300);
            }
            else
            {
                
                MoveViewWindow(0);
            }
        }

        private void UserIconTapped(object sender, TappedRoutedEventArgs e)
        {
            
        }

        private void OfferCode_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var copytext = txtOfferCode.Text;
            settext(copytext);
        }

        private async void UserImageLogo_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(LoginMain)));
           // this.Frame.Navigate(typeof(LoginMain), UriKind.Relative);            
        }

        private void txtOfferCode_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txtOfferCode.SelectAll();
        }
    }
}
