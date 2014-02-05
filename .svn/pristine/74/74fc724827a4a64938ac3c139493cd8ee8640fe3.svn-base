using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Callisto.Controls;
using TicketMachine.Lib.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.Security.Credentials;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using TicketMachine.WS.Views;
using ReceiptsSplitPage = TicketMachine.WS.Views.ReceiptsSplitPage;

namespace TicketMachine.WS.Helper
{
    public sealed partial class NavigationTopAppBar : UserControl
    {
        private ConnectionProfile internetConnectionProfile;
        //NetworkStatusChangedEventHandler networkStatusCallback = null;
        //public static bool registeredNetworkStatusNotif = false;

        public static Popup settingsPopup = null;

        public NavigationTopAppBar()
        {
            this.InitializeComponent();
            internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
        }
 
        private void BtnProducts_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (internetConnectionProfile == null)
            {
                var messageDialog = new MessageDialog("Products are not available without an Internetconnection.");
                messageDialog.ShowAsync();
            } else 
                (DataContext as NavigationTopAppBarViewModel).ProductSearchResultClickedCommand.Execute(null);
        }

        private void BtnStores_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (internetConnectionProfile == null)
            {
                var messageDialog = new MessageDialog("Stores are not available without an Internetconnection.");
                messageDialog.ShowAsync();
            }
            else
                (DataContext as NavigationTopAppBarViewModel).StoreMapClickedCommand.Execute(null);
        }

        private async void btnMyCart_Click(object sender, RoutedEventArgs e)
        {
            if (internetConnectionProfile == null)
            {
                var messageDialog = new MessageDialog("Changes made without an Internetconnection will not be saved.");
                messageDialog.ShowAsync();
            }
            settingsPopup = new Popup();
            Rect windowsBounds = Window.Current.Bounds;
            settingsPopup.Closed += settingsPopup_Closed;
            Window.Current.Activated += Current_Activated;

            settingsPopup.IsLightDismissEnabled = true;
            settingsPopup.Height = windowsBounds.Height;
            myCartPage cartPage = new myCartPage { Height = windowsBounds.Height };

            settingsPopup.Child = cartPage;
            settingsPopup.SetValue(Canvas.LeftProperty, windowsBounds.Width - 425);
            settingsPopup.SetValue(Canvas.TopProperty, 0);

            settingsPopup.IsOpen = true;
        }

        void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                settingsPopup.IsOpen = false;
            }
        }

        void settingsPopup_Closed(object sender, object e)
        {
            Window.Current.Activated -= Current_Activated;
        }
    }
}
