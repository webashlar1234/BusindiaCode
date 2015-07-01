using BusIndia_Universal.Models;
using BusIndia_Universal.Views.Bus;
using BusIndiaBLL.Helper;
using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class PasangerInformation : Page
    {
        int numberOfseats;
        PassengerRequiredfield selectedPassenger;
        List<getIDProofs> _getIDProofs = new List<getIDProofs>();
        List<PassengerRequiredfield> list;
        PassengerInfoDetails _objPassengerInfoDetails = new PassengerInfoDetails();
        public PassengerRequiredfield WM
        {
            get { return (this.DataContext as PassengerRequiredfield); }
            set { this.DataContext = value; }
        }
        public PasangerInformation()
        {
            this.InitializeComponent();
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            WM = new PassengerRequiredfield();
            PassengerIn _PassengerIn = new PassengerIn();
            ListMenuItemsPassenger.DataContext = _PassengerIn;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var nav = (PickupDropoffRequest)e.Parameter;
            if (nav != null)
            {
                numberOfseats = Convert.ToInt32(nav.numberOfSeats);
            }
            else 
            {
                numberOfseats = Convert.ToInt32(pickDropHelper.objGetPickDrop.numberOfSeats);
            }
            HomeModel homeModel = new HomeModel();
            CommonModel.bgImage = homeModel.bgImage;
            imgBack.Source = homeModel.bgImage;
            postXMLData1();
            FirstCall();
        }


        // Get all IDProofs option from web services 
        public async void postXMLData1()
        {
           
                string uri = AppStatic.WebServiceBaseURL;  // some xml string
                Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);
                getIDProofsRequest _objeIDProof = new getIDProofsRequest();
                _objeIDProof.franchUserID = AppStatic.franchUserID;
                _objeIDProof.password = AppStatic.password;
                _objeIDProof.userID = AppStatic.userID;
                _objeIDProof.userKey = AppStatic.userKey;
                _objeIDProof.userName = AppStatic.userName;
                _objeIDProof.userRole = AppStatic.userRole;
                _objeIDProof.userStatus = AppStatic.userStatus;
                _objeIDProof.userType = AppStatic.userType;
                _objeIDProof.studID = pickDropHelper.objGetAvailableService.studID;

                xmlUtility listings = new xmlUtility();
                XDocument element = listings.getIDProof(_objeIDProof);
                string file = element.ToString();
                var httpClient = new Windows.Web.Http.HttpClient();
                var info = AppStatic.WebServiceAuthentication;
                var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(info));
                httpClient.DefaultRequestHeaders.Authorization = new Windows.Web.Http.Headers.HttpCredentialsHeaderValue("Basic", token);
                httpClient.DefaultRequestHeaders.Add("SOAPAction", "");
                Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, _url);
                httpRequestMessage.Headers.UserAgent.TryParseAdd("Mozilla/4.0");
                IHttpContent content = new HttpStringContent(file, Windows.Storage.Streams.UnicodeEncoding.Utf8);
                httpRequestMessage.Content = content;
                Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.SendRequestAsync(httpRequestMessage);
                string strXmlReturned = await httpResponseMessage.Content.ReadAsStringAsync();
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(strXmlReturned);
                XDocument loadedData = XDocument.Parse(strXmlReturned);
                var sdata = loadedData.Descendants("idProofs").
               Select(x => new getIDProofs
               {
                   idProofID = x.Element("idProofID").Value,
                   idProofName = x.Element("idProofName").Value,
               }).ToList();
                foreach (var item in sdata)
                {
                    getIDProofs pl = new getIDProofs();
                    pl.idProofID = item.idProofID;
                    pl.idProofName = item.idProofName;
                    _getIDProofs.Add(pl);
                }
                ListMenuItemsIDPRoof.ItemsSource = sdata;
                getIDProofs pls = new getIDProofs();
           
        }
        public void FirstCall()
        {
            list = new List<PassengerRequiredfield>();
            for (int i = 0; i < numberOfseats; i++)
            {
                if (i == 0)
                {
                    list.Add(new PassengerRequiredfield()
                    {
                        PassengerPlaceholder = "Passenger " + (i + 1),
                        Main = true
                    });
                }
                else
                {
                    list.Add(new PassengerRequiredfield()
                    {
                        PassengerPlaceholder = "Passenger " + (i + 1),
                        //Main = true
                    });
                }

            }
            ListMenuItemsPassenger.ItemsSource = list;
        }

        private void rdbtnfemale_Tapped(object sender, TappedRoutedEventArgs e)
        {
            selectedGender(Convert.ToString(rdbtnfemale.Content));
        }
        private void rdbtnMale_Tapped(object sender, TappedRoutedEventArgs e)
        {
            selectedGender(Convert.ToString(rdbtnMale.Content));
        }

        private void selectedGender(string gender)
        {
            if (selectedPassenger != null)
            {
                selectedPassenger.Gender = gender;
            }
            GenderPopUpGrid.Visibility = Visibility.Collapsed;
        }
        private void txtGender_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox _txt = sender as TextBox;
            if (_txt != null)
            {
                selectedPassenger = (_txt.DataContext as PassengerRequiredfield);
            }
            GenderPopUpGrid.Visibility = Visibility.Visible;
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BusPickDropPoint));
        }

        private void imgGender1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Visible;
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ErrorPopup.Visibility = Visibility.Collapsed;
        }
        private void btnNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            foreach (PassengerRequiredfield item in list)
            {
                _objPassengerInfoDetails.passengerName.Add(item.Passenger);
                _objPassengerInfoDetails.passengerAge.Add(item.Age);
                _objPassengerInfoDetails.passengerGender.Add(item.Gender);
            }
            foreach (PassengerRequiredfield item in list)
            {
                if (txtIDProof.Text == null || txtIDProof.Text == "")
                {
                    WM.errorMessage = "Please select IDProof ";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (txtMobile.Text == null || txtMobile.Text == "")
                {
                    WM.errorMessage = "Please enter mobile number";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
                {
                    WM.errorMessage = "Please enter valid emailid";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (txtEmail.Text == "")
                {
                    WM.errorMessage = "Please enter emailid";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (item.Gender == null)
                {
                    WM.errorMessage = "Please select all passenger gender";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (item.Age == null)
                {
                    WM.errorMessage = "Please select all passenger age ";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (item.Passenger == null)
                {
                    WM.errorMessage = "Please enter all passenger name";
                    ErrorPopup.Visibility = Visibility.Visible;
                }
                if (item.Passenger != null && item.Age != null && item.Gender != null && txtEmail.Text != "" && txtIDProof.Text != "" && txtMobile.Text != "")
                {
                    popTransaction.Visibility = Visibility.Visible;
                    
                }
            }
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtIDProof_GotFocus(object sender, RoutedEventArgs e)
        {
            IDProofsPopup.Visibility = Visibility.Visible;
        }

        private void ListMenuItemsIDPRoof_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ListMenuItemsIDPRoof_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMenuItemsIDPRoof.SelectedItem != null)
            {
                getIDProofs myobject = ListMenuItemsIDPRoof.SelectedItem as getIDProofs;
                txtIDProof.Text = myobject.idProofName;
                IDProofsPopup.Visibility = Visibility.Collapsed;
            }
        }

        private void txtAgeP_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox _txt = sender as TextBox;
            if (_txt != null)
            {
                selectedPassenger = (_txt.DataContext as PassengerRequiredfield);
            }
            AgesPopup.Visibility = Visibility.Visible;
            var items = new List<SelectAgeRadio>();
            for (int runs = 1; runs <= 100; runs++)
            {
                items.Add(new SelectAgeRadio() { Name = runs });
            }
            ListMenuItemsAges.ItemsSource = items;
        }

        private void RadioButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedAge();
        }
        private void ListMenuItemsAges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedAge();
        }
        public void SelectedAge()
        {
            var items = (List<SelectAgeRadio>)ListMenuItemsAges.ItemsSource;
            var selectedItem = items.Where(x => x.Selected).FirstOrDefault();
            string age = Convert.ToString(selectedItem.Name);
            AgesPopup.Visibility = Visibility.Collapsed;
            if (selectedItem != null)
            {
                selectedPassenger.Age = age;
            }
        }

        private void rdbPassMain_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var items = (List<PassengerRequiredfield>)ListMenuItemsPassenger.ItemsSource;
            var selectedItem = items.Where(x => x.Main).FirstOrDefault();

        }

        private void imgAgeP_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ListMenuItemsIDPRoof_LayoutUpdated(object sender, object e)
        {

        }

      
        private void lblNo_Click(object sender, RoutedEventArgs e)
        {
            popTransaction.Visibility = Visibility.Collapsed;
        }

        private void lblYes_Click(object sender, RoutedEventArgs e)
        {
            _objPassengerInfoDetails.Mobile = txtMobile.Text;
            _objPassengerInfoDetails.Email = txtEmail.Text;
            _objPassengerInfoDetails.IDProof = txtIDProof.Text;
            Frame.Navigate(typeof(BusBookingSummary), _objPassengerInfoDetails);
        }

    }
}
