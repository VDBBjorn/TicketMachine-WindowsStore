using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234
using NotificationsExtensions.ToastContent;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.ViewModels;

namespace TicketMachine.WS.Views
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for
    /// the currently selected item.
    /// </summary>
    public sealed partial class ShoppingListPage : TicketMachine.WS.Common.LayoutAwarePage
    {
        public ShoppingListPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            if (navigationParameter == null)
            {
                base.LoadState(navigationParameter, pageState);
                
            }
            else
            {
                (DataContext as ProductSearchResultViewModel).Initialize(navigationParameter);
            }
        }

        private void AddProductPackingToShoppingList_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as ProductSearchResultViewModel).ProductPackingAddCommand.Execute(productListViewSearched.SelectedItem);
            ProductPacking p = productListViewSearched.SelectedItem as ProductPacking;
            IToastNotificationContent toastContent = null;
            IToastText01 templateContent = ToastContentFactory.CreateToastText01();
            templateContent.TextBodyWrap.Text = "Product "+p.Product.Name+" has been added to your shoppinglist!";
            toastContent = templateContent;
            ToastNotification toast = toastContent.CreateNotification();
            ToastNotificationManager.CreateToastNotifier().Show(toast); 
        }
    }
}
