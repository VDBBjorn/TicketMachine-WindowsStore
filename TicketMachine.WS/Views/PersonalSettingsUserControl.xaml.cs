using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NotificationsExtensions.ToastContent;
using TicketMachine.Lib.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TicketMachine.WS.Views
{
    public sealed partial class PersonalSettingsUserControl : UserControl
    {
        public PersonalSettingsUserControl()
        {
            this.InitializeComponent();
            (DataContext as PersonalSettingsViewModel).LoadState(null, null);
        }

        private async void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            IToastNotificationContent toastContent = null;
            IToastText01 templateContent = ToastContentFactory.CreateToastText01();
            if (await (DataContext as PersonalSettingsViewModel).SaveChanges()) 
                templateContent.TextBodyWrap.Text = "Personal settings are changed succesfull!";           
            else
                templateContent.TextBodyWrap.Text = "Someting went wrong while saving your personal settings. Personal settings are not changed.";           
            toastContent = templateContent;
            ToastNotification toast = toastContent.CreateNotification();
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
