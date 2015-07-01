using BusIndia_Universal.Models;
using BusIndia_Universal.Views.Hotel;
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
    public sealed partial class HotelSearchPage : Page
    {
        public HotelSearchPage()
        {
            this.InitializeComponent();
        }

    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var nav = (PlaceList)e.Parameter;
            if (nav != null)
            {
                txtBHotelLocation.Text = nav.PlaceName;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(Home));
        }

        private void imgFilter_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Bottom;
            this.Frame.Navigate(typeof(HotelSearchHistory));
            
        }

       

        private void imgCloseRoom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tapOptionSearchRoom.Visibility = Visibility.Collapsed;
        }

        private void rdbtn1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AdultPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfAdult.Text = "1";
        }

        private void rdbtn2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AdultPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfAdult.Text = "2";
        }

        private void rdbtn3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AdultPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfAdult.Text = "3";
        }

        private void rdbtn4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AdultPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfAdult.Text = "4";
        }

        private void tapNumberOfAdult_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AdultPopUpGrid.Visibility = Visibility.Visible;
        }

        private void tapNumberOfChildren_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Visible;
        }

        private void rdbtn1C_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfChildren.Text = "1";
        }

        private void rdbtn2C_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfChildren.Text = "2";
        }

        private void rdbtn3C_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfChildren.Text = "3";
        }

        private void rdbtn4C_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfChildren.Text = "4";
        }

        private void rdbtn5C_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfChildren.Text = "5";
        }

        private void rdbtn6C_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ChildrenPopUpGrid.Visibility = Visibility.Collapsed;
            txtBNumberOfChildren.Text = "6";
        }

        private void tapSelectHotelCity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Top;
           this.Frame.Navigate(typeof(HotelSearchLocation));
        }

        private void btnNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(HotelAvailibility));
        }

        private void imgAddNewHotel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
