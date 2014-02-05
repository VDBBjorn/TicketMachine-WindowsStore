using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using De.TorstenMandelkow.MetroChart;
using TicketMachine.Lib.ViewModels;
using System.Resources;
using System.Reflection;
using TicketMachine.WS.Common;


namespace TicketMachine.WS.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ExpenseChartPage : TicketMachine.WS.Common.LayoutAwarePage
    {
        public ExpenseChartPage()
        {
            this.InitializeComponent();
        }

    }
}
