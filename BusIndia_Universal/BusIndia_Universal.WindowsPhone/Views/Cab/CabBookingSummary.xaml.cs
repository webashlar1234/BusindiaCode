using BusIndia_Universal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
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
    public sealed partial class CabBookingSummary : Page
    {
        public CabBookingSummaryClass dd
        {
            get { return (this.DataContext as CabBookingSummaryClass); }
            set { this.DataContext = value; }
        }

        public CabBookingSummary()
        {
            this.InitializeComponent();
            dd = new CabBookingSummaryClass();
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

        private void txtBterms_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void txtBpolicy_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CabSearchResult));
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (txtBstate.Text == null || txtBstate.Text == "")
            {
                dd.errorMessage = "Please enter state";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (txtBcity.Text == null || txtBcity.Text == "")
            {
                dd.errorMessage = "Please enter city";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (txtBstreet.Text == null || txtBstreet.Text == "")
            {
                dd.errorMessage = "Please enter Street";
                ErrorPopup.Visibility = Visibility.Visible;
            }

            if (txtBflatNo.Text.ToString() == null || txtBflatNo.Text.ToString() == "")
            {
                dd.errorMessage = "Please enter flat number";
                ErrorPopup.Visibility = Visibility.Visible;
            }

            if (txtBnumber.Text.ToString() == null || txtBnumber.Text.ToString() == "")
            {
                dd.errorMessage = "Please enter phone number";
                ErrorPopup.Visibility = Visibility.Visible;
            }
        }

        private void txtBnumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBflatNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtBstreet_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void txtBcity_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtBstate_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorPopup.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
