using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BusIndia_Universal.Models;
using System.Text.RegularExpressions;
using Windows.Phone.UI.Input;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HotelBookingSummary : Page
    {
        public  HotelBookingSummaryClass dd
        {
            get { return (this.DataContext as HotelBookingSummaryClass); }
            set { this.DataContext = value; }
        }
        public HotelBookingSummary()
        {
            this.InitializeComponent();
            dd = new HotelBookingSummaryClass();
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           

            if (txtMobile.Text.ToString() == null || txtMobile.Text.ToString() == "")
            {
                dd.errorMessage = "Please enter mobile number";
                ErrorPopup.Visibility = Visibility.Visible;
            }

            if (txtEmail.Text == null || txtEmail.Text == "")
            {
                dd.errorMessage = "Please enter emailid";
                ErrorPopup.Visibility = Visibility.Visible;
            }

            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
            {
                dd.errorMessage = "Please enter valid emailid";
                ErrorPopup.Visibility = Visibility.Visible;
            }
        }

        private void txtMobile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPlaceCity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HotelDetails));
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ErrorPopup.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
