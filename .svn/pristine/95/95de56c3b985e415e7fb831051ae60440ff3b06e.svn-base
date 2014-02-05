using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using Bing.Maps;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.WS.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class StoreMapPage : TicketMachine.WS.Common.LayoutAwarePage
    {
        public StoreMapPage()
        {
           this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            base.LoadState(navigationParameter, pageState);
            // TODO: Assign a bindable group to this.DefaultViewModel["Group"]
            // TODO: Assign a collection of bindable items to this.DefaultViewModel["Items"]
            
            if (pageState == null)
            {
                // When this is a new page, select the first item automatically unless logical page
                // navigation is being used (see the logical page navigation #region below.)
                if (!this.UsingLogicalPageNavigation() && this.itemsViewSource.View != null)
                {
                    this.itemsViewSource.View.MoveCurrentToFirst();
                }
            }
            else
            {
                // Restore the previously saved state associated with this page
                if (/*pageState.ContainsKey("SelectedItem") &&*/ this.itemsViewSource.View != null)
                {
                    this.itemsViewSource.View.MoveCurrentToFirst();
                }
            }

        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            this.itemListView.SelectedIndex = -1;
        }

        void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Invalidate the view state when logical page navigation is in effect, as a change
            // in selection may cause a corresponding change in the current logical page.  When
            // an item is selected this has the effect of changing from displaying the item list
            // to showing the selected item's details.  When the selection is cleared this has the
            // opposite effect.
            //if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();
            if (((GridView)sender).SelectedItem != null)
            {
                
                
                MapLocation mapLocation = StoreService.GetMapLocation(((GridView)sender).SelectedItem as Store);
                Location location = new Location(mapLocation.Latitude, mapLocation.Longitude);
                if (this.myMap == null)
                {
                    return;
                }
                this.myMap.Center = location;

                //remove old pins
                var ps = from p in myMap.Children
                         where ((string)((Pushpin)p).Tag) == "Store"
                         select p;
                var psa = ps.ToArray();
                for (int i = 0; i < psa.Count(); i++)
                {
                    myMap.Children.Remove(psa[i]);
                }

                //place the new pushpin
                Pushpin newpin = new Pushpin();
                newpin.Tag = "Store";
                myMap.Children.Add(newpin);
                MapLayer.SetPosition(newpin, location);
            }
        }

        private bool UsingLogicalPageNavigation(ApplicationViewState? viewState = null)
        {
            if (viewState == null) viewState = ApplicationView.Value;
            return viewState == ApplicationViewState.FullScreenPortrait ||
                viewState == ApplicationViewState.Snapped;
        }
    }
}
