/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TicketMachine.Lib"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ICustomerService, CustomerService>();
            SimpleIoc.Default.Register<IStoreService, StoreService>();

            SimpleIoc.Default.Register<NavigationTopAppBarViewModel>();

            SimpleIoc.Default.Register<MainPageViewModel>();

            SimpleIoc.Default.Register<ReceiptsSplitPage>();

            SimpleIoc.Default.Register<ProductSearchResultViewModel>();
            SimpleIoc.Default.Register<ShoppingListViewModel>();

            SimpleIoc.Default.Register<VouchersItemsViewModel>();
            SimpleIoc.Default.Register<VoucherDetailViewModel>();
            
            SimpleIoc.Default.Register<LoyaltyCardsItemsViewModel>();
            SimpleIoc.Default.Register<LoyaltyCardDetailViewModel>();

            SimpleIoc.Default.Register<StoreMapViewModel>();

            SimpleIoc.Default.Register<ExpenseChartViewModel>();
            SimpleIoc.Default.Register<NutritionChartViewModel>();

            SimpleIoc.Default.Register<PersonalSettingsViewModel>();
        }

        public NavigationTopAppBarViewModel NavigationTopAppBarViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationTopAppBarViewModel>();
            }
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public ReceiptsSplitPage ReceiptItemsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReceiptsSplitPage>();
            }
        }

        public ShoppingListViewModel ShoppingListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShoppingListViewModel>();
            }
        }

        public ProductSearchResultViewModel ProductSearchResultViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductSearchResultViewModel>();
            }
        }


        public VouchersItemsViewModel VouchersItemsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VouchersItemsViewModel>();
            }
        }

        public VoucherDetailViewModel VoucherDetailViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VoucherDetailViewModel>();
            }
        }

        public LoyaltyCardsItemsViewModel LoyaltyCardsItemsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoyaltyCardsItemsViewModel>();
            }
        }

        public LoyaltyCardDetailViewModel LoyaltyCardDetailViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoyaltyCardDetailViewModel>();
            }
        }

        public StoreMapViewModel StoreMapViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StoreMapViewModel>();
            }
        }

        public ExpenseChartViewModel ExpenseChartViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ExpenseChartViewModel>();
            }
        }

        public NutritionChartViewModel NutritionChartViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NutritionChartViewModel>();
            }
        }

        public PersonalSettingsViewModel PersonalSettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonalSettingsViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}