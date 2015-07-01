using BusIndia_Universal.Models;
using BusIndia_Universal.Views.Bus;
using BusIndia_Universal.Views.Home;
using BusIndia_Universal.Views.Payment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentOptionsPage : Page
    {
        string Name="";
        string Email="";
        string mobile = "";
        string Totalamount = "";
        public PaymentOptionsPage()
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
            var nav = (PassengerInfoDetails)e.Parameter;
            if(nav!=null)
            {
                Name = nav.passengerName.FirstOrDefault();
                Email = nav.Email;
                mobile = nav.Mobile;
                Totalamount = nav.TotalAmount;
            }
          
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
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

        public void Post()
        {
             var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async() =>
             {
            string firstName = Name;
            string amount = Totalamount;
            string productInfo = "Test";
            string email = Email;
            string phone = mobile;
            string surl = "";
            string furl = "";

            RemotePost myremotepost = new RemotePost();
            string key = "JBZaLc";
            string salt = "GQs7yium";
            myremotepost.Url = "https://test.payu.in/_payment";
            myremotepost.Add("key", "JBZaLc");
            string txnid = await Generatetxnid();
            myremotepost.Add("txnid", txnid);
            myremotepost.Add("amount", amount);
            myremotepost.Add("productinfo", productInfo);
            myremotepost.Add("firstname", firstName);
            myremotepost.Add("phone", phone);
            myremotepost.Add("email", email);
            myremotepost.Add("surl", "http://sdsdsdsd");//Change the success url here depending upon the port number of your local system.
            myremotepost.Add("furl", "http://www.google.com");//Change the failure url here depending upon the port number of your local system.
            myremotepost.Add("service_provider", "payu_paisa");
            string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|||||||||||" + salt;
            await Generatehash512(hashString);
            //string hashString = "3Q5c3q|2590640|3053.00|OnlineBooking|vimallad|ladvimal@gmail.com|||||||||||mE2RxRwx";
            string hash = await Generatehash512(hashString);
            myremotepost.Add("hash", hash);
            myremotepost.PostURL();
             }).AsTask();
        }



        public async Task<string> Generatetxnid()
        {
            Random rnd = new Random();
            string strHash = await Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);
            return txnid1;
        }


        public async Task<string> Generatehash512(string test)
        {
            string uri = "http://demo.mapsearch360.com/WSFacilities.svc/Generatehash512/?text=" + test;
            Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
            HttpClient httpClient = new Windows.Web.Http.HttpClient();
            Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
            Windows.Web.Http.HttpResponseMessage response = await httpClient.SendRequestAsync(httpRequestMessage);

            string data = await response.Content.ReadAsStringAsync();
            string encryptedstring = (data.Split(new char[] { ':' }))[1].Trim(new char[] { '\\', '"', '}' });
            return encryptedstring;           
        }

      

        public class RemotePost
        {
            private Dictionary<string, string> objData = new Dictionary<string, string>();
            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";
            public void Add(string name, string value)
            {
                objData.Add(name, value);
            }
            public async void PostURL()
            {

                try
                {
                    string test2 = "";
                    foreach (KeyValuePair<string, string> kv in objData)
                    {
                        string test1 = kv.Key;
                        test2 = objData[kv.Key];
                    }
                    string Final = test2;
                    StringBuilder str = new StringBuilder();
                    str.Append("<html><head>");
                    str.Append(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                    str.Append(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                    foreach (KeyValuePair<string, string> kv in objData)
                    {
                        str.Append(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", kv.Key, objData[kv.Key]));
                    }
                    str.Append("</form>");
                    str.Append("</body></html>");

                    byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(str.ToString());
                    StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("mm.html", CreationCollisionOption.ReplaceExisting);
                    String historyTestContent = await FileIO.ReadTextAsync(file);
                    using (var stream = await file.OpenStreamForWriteAsync())
                    {
                        stream.Write(fileBytes, 0, fileBytes.Length);
                    }
                    StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("mm.html");
                    String timestamp = await FileIO.ReadTextAsync(sampleFile);
                }
                catch (Exception ex)
                {
                    
                    
                }
            }
        }

        private void imgClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            popTransaction.Visibility = Visibility.Visible;
        }          

     

        private void Grddedit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void GrdNetBanking_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void GrdPayU_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Post();
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(PayUGateway));
        }

        private void Grdcredit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void GrdPayU_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Post();
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.Navigate(typeof(PayUGateway));
        }

        private void lblYes_Click(object sender, RoutedEventArgs e)
        {
            PageNavigationMode.Mode = PageTransmission.Left;
           this.Frame.Navigate(typeof(Home));
           
        }

        private void lblNo_Click(object sender, RoutedEventArgs e)
        {
            popTransaction.Visibility = Visibility.Collapsed;
        }

    }
}
