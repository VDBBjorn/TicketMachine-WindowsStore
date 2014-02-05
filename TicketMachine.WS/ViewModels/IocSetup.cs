/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TicketMachine.WS"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using TicketMachine.Lib.Services;
using TicketMachine.WS.Services;

namespace TicketMachine.WS.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class IocSetup
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static IocSetup()
        {
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IStateService, StateService>();
            SimpleIoc.Default.Register<INotificationService, NotificationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IShareService, ShareService>();
            SimpleIoc.Default.Register<ISettingsService, SettingsService>();

            SimpleIoc.Default.Register<ICredentialsService, CredentialsService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
        }
        
       
    }
}