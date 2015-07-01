using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal.Views.Bus
{
  
    public sealed partial class PayUGateway : Page
    {
        public PayUGateway()
        {
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;      
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;      
            test();
        }
        public void test()
        {
             var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async() =>
             {
            try
            {
                StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("mm.html");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                HTML3.Text = @timestamp;
                myWebView.NavigateToString(HTML3.Text);
            }
            catch(Exception ex)
            { 
            
            }
             }).AsTask();
           
        }
      
        private void close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(PaymentOptionsPage));
        }

        private void myWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            LoderPopup.Visibility = Visibility.Visible;
        }

        private void myWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            LoderPopup.Visibility = Visibility.Collapsed;
        }

        private void myWebView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            SuccespopUp.Visibility = Visibility.Visible;
        }

        private void lblRetry_Click(object sender, RoutedEventArgs e)
        {
            SuccespopUp.Visibility = Visibility.Visible;
            Frame.Navigate(typeof(PayUGateway));
        }

        private void lblCancel_Click(object sender, RoutedEventArgs e)
        {
            SuccespopUp.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(PaymentOptionsPage));
        }

        private void lblYes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lblNo_Click(object sender, RoutedEventArgs e)
        {

        }           

      
    }
}
