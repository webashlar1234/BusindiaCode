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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BusIndia_Universal
{
    public sealed partial class ErrorHandlingUserControl : UserControl
    {
        public ErrorHandlingUserControl()
        {
            this.InitializeComponent();
        }

        private void btnYes_Tapped(object sender, TappedRoutedEventArgs e)
        {
           //this.Frame.Navigate(typeof());        
          
        }

        private void btnNo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
        }
    }
}
