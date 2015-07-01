using BusIndia_Universal.Models;
using BusIndia_Universal.Views.Bus;
using BusIndiaBLL.Helper;
using BusIndiaBLL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Xml.Linq;
//using WebServiceClassLiberary;
//using WebServiceClassLiberary.Model;
using Windows.Data.Xml.Dom;
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
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterBusIndia : Page
    {

        public RegistrationFormclass WM
        {
            get { return (this.DataContext as RegistrationFormclass); }
            set { this.DataContext = value; }
        }

        public RegisterBusIndia()
        {
            this.InitializeComponent();
            setDateTime();
           
            WM = new RegistrationFormclass();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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


        public async void postXMLData1()
        {
            try
            {
                string uri = AppStatic.WebServiceBaseURL;  // some xml string
                Uri _url = new Uri(uri, UriKind.RelativeOrAbsolute);

                xmlUtility listings = new xmlUtility();
                getPlaceListRequest _objgetPlaceListRequest = listings.GetUserRequestParameters();
                XDocument element = listings.getList(_objgetPlaceListRequest);
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
                var PlaceList = loadedData.Descendants("PlaceList").
                Select(x => new PlaceList
                {
                    PlaceID = x.Element("placeID").Value,
                    PlaceCode = x.Element("placeCode").Value,
                    PlaceName = x.Element("placeName").Value
                });            
            }
            catch (Exception ex)
            {

             
                ExceptionLog obj = new ExceptionLog();
                Error objError = new Error();
                objError.ErrorEx = ex.Message;
                obj.CreateLogFile(objError);
            }
        }



        private void RegisterBusIndiaClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(WM.Email))
            {
                WM.errorMessage = "Please enter emailid";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
            {
                WM.errorMessage = "Please enter valid emailid";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (txtPassword.Password.ToString() == null || txtPassword.Password.ToString() == "")
            {
                WM.errorMessage = "Please enter password";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (txtPassword.Password.ToString() != txtConfirmPassword.Password.ToString())
            {
                WM.errorMessage = "Passwords do not match";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (string.IsNullOrEmpty(WM.fullName))
            {
                WM.errorMessage = "Please enter full name";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (txtPhone.Text.ToString() == null || txtPhone.Text.ToString() == "")
            {
                WM.errorMessage = "Please enter phone number";
                ErrorPopup.Visibility = Visibility.Visible;
            }
            if (txtPhone.Text.Length != 10)
            {
                WM.errorMessage = "Please enter valid phone number";
                ErrorPopup.Visibility = Visibility.Visible;
            }  
        }

        private void GoBackOnClose(object sender, TappedRoutedEventArgs e)
        {

            ((Frame)Window.Current.Content).Navigate(typeof(Home));
        }

        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.TabNavigation = KeyboardNavigationMode.Once;
            PageNavigationMode.Mode = PageTransmission.Left;
            this.Frame.GoBack();
        }

        private void txtDOB_GotFocus(object sender, RoutedEventArgs e)
        {
            DatePickerPopUpGrid.Visibility = Visibility.Visible;
        }

        private void txtGender_GotFocus(object sender, RoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Visible;
            rdbtnMale.Focus(FocusState.Keyboard);
        }
        private void btnSetDate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DatePickerPopUpGrid.Visibility = Visibility.Collapsed;
            int day = Convert.ToInt16(txtDay.Text.ToString());
            int month = Convert.ToInt16(hdnMonth.Text.ToString());
            int year = Convert.ToInt16(txtYear.Text.ToString());
            txtDOB.Text = day + "/" + month + "/" + year;
            txtPhone.Focus(FocusState.Keyboard);
        }
        private void btnAddMonth_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            int h = Convert.ToInt16(hdnMonth.Text.ToString());
            if (h < 12)
            {
                int x = h + 1;
                txtMonth.Text = getMonthName(x);
                hdnMonth.Text = x.ToString();
            }
        }

        private void btnMinusMonth_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            int h = Convert.ToInt16(hdnMonth.Text.ToString());
            if (h > 1)
            {
                int x = h - 1;
                txtMonth.Text = getMonthName(x);
                hdnMonth.Text = x.ToString();
            }
        }

        private void btnAddDay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int h = Convert.ToInt16(txtDay.Text.ToString());
            if (h < 31)
            {
                int x = h + 1;
                if (h < 9)
                {
                    txtDay.Text = "0" + x.ToString();
                }
                else
                {
                    txtDay.Text = x.ToString();
                }
            }

        }

        private void btnMinusDay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int h = Convert.ToInt16(txtDay.Text.ToString());
            if (h > 1)
            {
                int x = h - 1;
                if (h < 11)
                {
                    txtDay.Text = "0" + x.ToString();
                }
                else
                {
                    txtDay.Text = x.ToString();
                }
            }

        }

        private void btnAddYear_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int h = Convert.ToInt16(txtYear.Text.ToString());
            int x = h + 1;
            txtYear.Text = x.ToString();
        }

        private void btnMinusYear_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int h = Convert.ToInt16(txtYear.Text.ToString());
            int x = h - 1;
            txtYear.Text = x.ToString();
        }

        public void setDateTime()
        {
            int Day = DateTime.Now.Day;
            int Month = DateTime.Now.Month;
            if (Day < 10)
            {
                txtDay.Text = "0" + Day.ToString();
            }
            else
                txtDay.Text = Day.ToString();

            txtMonth.Text = getMonthName(Month);
            hdnMonth.Text = Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        public string getMonthName(int month)
        {
            string monthName = string.Empty;
            switch (month)
            {
                case 1:
                    monthName = "Jan";
                    break;
                case 2:
                    monthName = "Feb";
                    break;
                case 3:
                    monthName = "Mar";
                    break;
                case 4:
                    monthName = "Apr";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "Jun";
                    break;
                case 7:
                    monthName = "Jul";
                    break;
                case 8:
                    monthName = "Aug";
                    break;
                case 9:
                    monthName = "Sep";
                    break;
                case 10:
                    monthName = "Oct";
                    break;
                case 11:
                    monthName = "Nov";
                    break;
                case 12:
                    monthName = "Dec";
                    break;
            }
            return monthName;
        }

        private void rdbtnfemale_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Collapsed;
            txtGender.Text = "Female";
        }

        private void rdbtnMale_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GenderPopUpGrid.Visibility = Visibility.Collapsed;
            txtGender.Text = "Male";
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            WM.Email = this.txtEmail.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorPopup.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            WM.fullName = this.txtFullName.Text.ToString();
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
        }

    }
}
