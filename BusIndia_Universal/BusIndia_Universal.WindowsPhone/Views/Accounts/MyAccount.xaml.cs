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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyAccount : Page
    {
        MyAccountDetailModel myaccountDetail = new MyAccountDetailModel();
            
        public MyAccount()
        {
            
            this.InitializeComponent();
            myaccountDetail.AccountStatus = "Gold";
            if (myaccountDetail.AccountStatus == "Gold")
            {
                myaccountDetail.AccountStatus = "Gold";
               myaccountDetail.AccountBackground = "#C2A661";
                //var brush = new ImageBrush();
                //brush.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/hdpi/my_account_gold_card.png"));
                //myaccountDetail.AccountBackground = brush;
                myaccountDetail.Points = "987";
                myaccountDetail.CustomerName = "Mr.Tim Cook";
                myaccountDetail.MembershipNumber = "232131231231";
                myaccountDetail.AccountBgImage = CommonModel.bgImage;
                this.DataContext = myaccountDetail;
            }
            if(myaccountDetail.AccountStatus == "Silver")
            {
                myaccountDetail.AccountStatus = "Silver";
                myaccountDetail.AccountBackground = "Silver";
                myaccountDetail.Points = "987";
                
                myaccountDetail.CustomerName = "Mr.Tim Cook";
                myaccountDetail.MembershipNumber = "232131231231";
                myaccountDetail.AccountBgImage = CommonModel.bgImage;
                this.DataContext = myaccountDetail;
            }
            if (myaccountDetail.AccountStatus == "Blue")
            {
                myaccountDetail.AccountStatus = "#4747DA";
                myaccountDetail.AccountBackground = "#4747DA";
                myaccountDetail.Points = "987";
               
                myaccountDetail.CustomerName = "Mr.Tim Cook";
                myaccountDetail.MembershipNumber = "232131231231";
                myaccountDetail.AccountBgImage = CommonModel.bgImage;
                this.DataContext = myaccountDetail;
            }
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
            
        }
        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        private void tabAccountDetail_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RecentBookingGrid.Visibility = Visibility.Collapsed;
            AccountDetailGrid.Visibility = Visibility.Visible;
            tabRecentBooking.Background = new SolidColorBrush(Colors.Transparent);
            lblRecentBooking.Foreground = new SolidColorBrush(Colors.White);
            tabAccountDetail.Background = new SolidColorBrush(Colors.White);
            lblAccountDetail.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void tabRecentBooking_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AccountDetailGrid.Visibility = Visibility.Collapsed;
            RecentBookingGrid.Visibility = Visibility.Visible;
            tabAccountDetail.Background = new SolidColorBrush(Colors.Transparent);
            lblAccountDetail.Foreground = new SolidColorBrush(Colors.White);
            tabRecentBooking.Background = new SolidColorBrush(Colors.White);
            lblRecentBooking.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
