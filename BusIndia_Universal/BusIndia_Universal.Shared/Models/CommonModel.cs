using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace BusIndia_Universal
{
    class CommonModel
    {
        public static bool isUserLogin { get; set; }
        public static BitmapImage bgImage { get; set; }
    }
    public class HomeModel
    {
        //private string _bgImage = @"Assets\hdpi\splash_background.png";
        public BitmapImage bgImage { get; set; }
        public BitmapImage bgBlurImage { get; set; }
        public BitmapImage userImage { get; set; }
        public bool isUserLogin { get; set; }
        public bool isHotelCodesAvailble { get; set; }
        public bool isBusCodesAvailble { get; set; }
        public bool isCabCodesAvailble { get; set; }
        public HomeModel()
        {
            TimeSpan startEarlyMorning = new TimeSpan(3, 0, 0); //3 o'clock AM
            TimeSpan endEarlyMorning = new TimeSpan(9, 0, 0); //9 o'clock AM
            TimeSpan startMorning = new TimeSpan(9, 0, 0); //9 o'clock AM
            TimeSpan endMorning = new TimeSpan(15, 0, 0); //3 o'clock PM
            TimeSpan startEvening = new TimeSpan(15, 0, 0); //3 o'clock  PM
            TimeSpan endEvening = new TimeSpan(21, 0, 0); //9 o'clock PM
            TimeSpan startNight = new TimeSpan(21, 0, 0); //9 o'clock PM
            TimeSpan endNight = new TimeSpan(3, 0, 0); //3 o'clock AM
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now > startEarlyMorning) && (now < endEarlyMorning)) // 3AM- 9AM
            {
                bgImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_a.jpg", UriKind.RelativeOrAbsolute));
                bgBlurImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_a_blur.jpg", UriKind.RelativeOrAbsolute));
                //bgImage = new Uri("/Assets/Images/Home_a.jpg", UriKind.Relative);
                //bgBlurImage = new Uri("Assets/Images/Home_a_blur.jpg", UriKind.Relative); //@"\Assets\Images\Home_a_blur.jpg";
            }
            else if ((now > startMorning) && (now < endMorning)) // 9AM - 3PM 
            {
                bgImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_b.jpg", UriKind.RelativeOrAbsolute));
                bgBlurImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_b_blur.jpg", UriKind.RelativeOrAbsolute));
                //bgImage = new Uri("/Assets/Images/Home_b.jpg", UriKind.Relative);
                //bgBlurImage = new Uri("Assets/Images/Home_b_blur.jpg", UriKind.Relative);
                //bgImage = @"\Assets\Images\Home_b.jpg";
                //bgBlurImage = @"\Assets\Images\Home_b_blur.jpg";
            }
            else if ((now > startEvening) && (now < endEvening)) // 3PM - 9PM
            {
                bgImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_c.jpg", UriKind.RelativeOrAbsolute));
                bgBlurImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_c_blur.jpg", UriKind.RelativeOrAbsolute));
                //bgImage = @"\Assets\Images\Home_c.jpg";
                //bgBlurImage = @"\Assets\Images\Home_c_blur.jpg";
            }
            else
            {
                bgImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_d.jpg", UriKind.RelativeOrAbsolute));
                bgBlurImage = new BitmapImage(new Uri("ms-appx:///Assets/Images/Home_d_blur.jpg", UriKind.RelativeOrAbsolute));
                //bgImage = new Uri("/Assets/Images/Home_d.jpg", UriKind.Relative);
                //bgBlurImage = new Uri("Assets/Images/Home_d_blur.jpg", UriKind.Relative);
                //bgImage = @"\Assets\Images\Home_d.jpg";
                //bgBlurImage = @"\Assets\Images\Home_d_blur.jpg";
            }
            userImage = new BitmapImage(new Uri("ms-appx:///Assets/hdpi/home_not_logged_in.png", UriKind.RelativeOrAbsolute)); //@"\Assets\hdpi\home_not_logged_in.png";
        }
    }
    public class OfferList
    {
        public string OfferText { get; set; }
        public string OfferCode { get; set; }
    }
    public class MytripList
    {
        public string From { get; set; }
        public string To { get; set; }
        public string travelby { get; set; }
        public string datedepart { get; set; }
        public string datearrive { get; set; }
        public string departtime { get; set; }
        public string arrivaltime { get; set; }
        public string lastUpdated { get; set; }
    }

    public class TripReceipt
    {
        public string StationName { get; set; }
        public string Via { get; set; }
        public string CustomerName { get; set; }
        public string DepartDate { get; set; }
        public string DepartFrom { get; set; }
        public string TravelTo { get; set; }
        public string DepartTime { get; set; }
        public string ArrivalTime { get; set; }
        public string AvailbleSeat { get; set; }
        public string TravelBy { get; set; }
        public string TotalCost { get; set; }
        public string LastUpdate { get; set; }

    }

    public static class FeedBackModel
    {
        public static string id { get; set; }
        public static int usefulness { get; set; }
        public static int easeofuse { get; set; }
        public static int Design { get; set; }

        public static string FeedbackText { get; set; }
    }

    public static class PageNavigationMode
    {
        public static string Mode { get; set; }
    }
    public static class PageTransmission
    {
        public static string Top = "Top";
        public static string Bottom = "Bottom";
        public static string Right = "Right";
        public static string Left = "Left";
    }
    public class MyAccountDetailModel
    {
        public string CustomerName { get; set; }
        public string Points { get; set; }
        public string AccountStatus { get; set; }
        public string MembershipNumber { get; set; }
        public string AccountBackground { get; set; }
        public BitmapImage AccountBgImage { get; set; }
    }
}
