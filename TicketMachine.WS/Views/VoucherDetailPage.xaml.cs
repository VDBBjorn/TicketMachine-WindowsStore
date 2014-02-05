using System;
using System.Collections.Generic;
using Callisto.Controls;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using TicketMachine.WS.Common;
using TicketMachine.WS.Helper;

namespace TicketMachine.WS.Views
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public partial class VoucherDetailPage : TicketMachine.WS.Common.LayoutAwarePage
    {
        public VoucherDetailPage()
        {
            this.InitializeComponent();
        }

        private void enlarge_barcode(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.flipView.SelectedItem;
            Flyout f = new Flyout
            {
                PlacementTarget = sender as UIElement,
                HostMargin = new Thickness(0),
                Content = new LargeBarcode((selectedItem as Voucher).Barcode),
                IsOpen = true
            };
        }
    }
}
