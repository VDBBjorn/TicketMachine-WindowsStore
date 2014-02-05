using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Callisto.Controls;
using TicketMachine.Lib.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231
using TicketMachine.WS.Helper;

namespace TicketMachine.WS.Views
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class VouchersItemPage : TicketMachine.WS.Common.LayoutAwarePage
    {
        public VouchersItemPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            base.LoadState(navigationParameter, pageState);
        }

        private void ItemGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            (DataContext as VouchersItemsViewModel).VoucherClickedCommand.Execute(e.ClickedItem);
        }

        private void btnAddVoucher_Click(object sender, RoutedEventArgs e)
        {
            ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (internetConnectionProfile == null)
            {
                var messageDialog = new MessageDialog("Cannot add a voucher without an Internetconnection.");
                messageDialog.ShowAsync();
            }
            else
            {
                Flyout f = new Flyout
                    {
                        PlacementTarget = sender as UIElement,
                        Placement = PlacementMode.Top,
                        HostMargin = new Thickness(0),
                        Content = new AddVoucher(this.DataContext),
                        IsOpen = true
                    };
            }
        }

    }
}
