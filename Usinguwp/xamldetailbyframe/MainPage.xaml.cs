using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace xamldetailbyframe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
            #region Event
            DetailFrame.Navigated += DetailFrame_Navigated;
            MasterFrame.Navigated += MasterFrame_Navigated;
            SystemNavigationManager.GetForCurrentView().BackRequested += View_BackRequested;
            #endregion
        }
        private void MasterFrame_Navigated(object sender, NavigationEventArgs e)
        {
            UpdateUI();
        }

        private void DetailFrame_Navigated(object sender, NavigationEventArgs e)
        {
            while (DetailFrame.BackStack.Count > 1)
            {
                DetailFrame.BackStack.RemoveAt(1);
            }
            UpdateUI();
        }
        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateUI();
        }
        private void View_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (DetailFrame.CanGoBack)
            {
                DetailFrame.GoBack();
                e.Handled = true;
            }
            else if (MasterFrame.CanGoBack)
            {
                MasterFrame.GoBack();
                e.Handled = true;
            }
        }
        private void UpdateUI()
        {
            if (AdaptiveStates.CurrentState.Name == "NarrowState")
            {
                DetailFrame.Visibility = DetailFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = DetailFrame.CanGoBack || MasterFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MasterFrame.Navigate(typeof(NewsPage));
            DetailFrame.Navigate(typeof(BackgroundPage));
        }
    }
}
