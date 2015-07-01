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
    public sealed partial class FeedBack : Page
    {

        public FeedBack()
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

        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void SubmitFeedBack(object sender, RoutedEventArgs e)
        {
            FeedBackModel.FeedbackText = txtfeedback.Text;
        }

        private void usefullness_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender != null && sender is Image)
            {
                Image usefullness = sender as Image;
                if (usefullness.Name.Contains('1'))
                {
                    FeedBackModel.usefulness = 1;
                }
                else if (usefullness.Name.Contains('2'))
                {
                    FeedBackModel.usefulness = 2;
                }
                else if (usefullness.Name.Contains('3'))
                {
                    FeedBackModel.usefulness = 3;
                }
                else if (usefullness.Name.Contains('4'))
                {
                    FeedBackModel.usefulness = 4;
                }
                else if (usefullness.Name.Contains('5'))
                {
                    FeedBackModel.usefulness = 5;
                }

            }
        }


        private void EaseofUse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender != null && sender is Image)
            {
                Image easeofuse = sender as Image;
                if (easeofuse.Name.Contains('1'))
                {
                    FeedBackModel.easeofuse = 1;
                }
                else if (easeofuse.Name.Contains('2'))
                {
                    FeedBackModel.easeofuse = 2;
                }
                else if (easeofuse.Name.Contains('3'))
                {
                    FeedBackModel.easeofuse = 3;
                }
                else if (easeofuse.Name.Contains('4'))
                {
                    FeedBackModel.easeofuse = 4;
                }
                else if (easeofuse.Name.Contains('5'))
                {
                    FeedBackModel.easeofuse = 5;
                }

            }
        }

        private void Design_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender != null && sender is Image)
            {
                Image design = sender as Image;
                if (design.Name.Contains('1'))
                {
                    FeedBackModel.Design = 1;
                }
                else if (design.Name.Contains('2'))
                {
                    FeedBackModel.Design = 2;
                }
                else if (design.Name.Contains('3'))
                {
                    FeedBackModel.Design = 3;
                }
                else if (design.Name.Contains('4'))
                {
                    FeedBackModel.Design = 4;
                }
                else if (design.Name.Contains('5'))
                {
                    FeedBackModel.Design = 5;
                }
            }
        }
    }
}
