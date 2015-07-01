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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BusIndia_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Splash : Page
    {
        private DispatcherTimer _timer;
        public Splash()
        {
            this.InitializeComponent();
            _timer = new DispatcherTimer();
            //Set your specific time here using TimeSpan instance
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += (s, e) => Tick();
            _timer.Start();
        }
        private void Tick()
        {
            //_timer.Stop();
            //this.Frame.Navigate(typeof(HomeModel));
        }
    }
}
