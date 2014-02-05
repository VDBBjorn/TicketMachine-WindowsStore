﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using Callisto.Controls;
using TicketMachine.Lib.ViewModels;
using TicketMachine.WS.Views;

namespace TicketMachine.WS.Helper
{
    public sealed partial class LargeBarcode : UserControl
    {
        public LargeBarcode(string barcode)
        {
            this.InitializeComponent();
            this.barcodeBlock.Text = barcode;
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            Flyout f = this.Parent as Flyout;
            f.IsOpen = false;
        }
    }
}
