using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketMachine.Lib.ViewModels;
using TicketMachine.WS.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Networking.Connectivity;
using Windows.Security.Credentials;
using Windows.Security.Credentials.UI;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using TicketMachine.WS.Common;

namespace TicketMachine.WS.Views
{
    
    public sealed partial class MainPage : TicketMachine.WS.Common.LayoutAwarePage    {

        private ConnectionProfile internetConnectionProfile;
        
        public MainPage()
        
        {
            InitializeComponent();
            internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (internetConnectionProfile == null)
                /*&& InternetConnectionProfile.GetNetworkConnectivityLevel() != NetworkConnectivityLevel.InternetAccess*/
            {
                var messageDialog = new MessageDialog("No Internetconnection available. Current data could be outdated.");
                messageDialog.ShowAsync();
            }
        }

        private void ShoppingListClick_OnClick(object sender, RoutedEventArgs e)
        {
            if (internetConnectionProfile == null)
            {
                var messageDialog = new MessageDialog("Products are not available without a Internetconnection.");
                messageDialog.ShowAsync();
            }
            else
                (DataContext as MainPageViewModel).ProductSearchResultClickedCommand.Execute(null);
        }
    }
}
