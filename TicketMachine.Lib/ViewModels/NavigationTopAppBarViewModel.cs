using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class NavigationTopAppBarViewModel : ViewModel
    {
        private ICustomerService customerService;
        private INavigationService navigationService;

        public ICommand MainPageClickedCommand { get; set; }
        public ICommand ReceiptsClickedCommand { get; set; }
        public ICommand VouchersClickedCommand { get; set; }
        public ICommand LoyaltyCardsClickedCommand { get; set; }
        public ICommand ShoppingListClickedCommand { get; set; }
        public ICommand ProductSearchResultClickedCommand { get; set; }
        public ICommand StoreMapClickedCommand { get; set; }
        public ICommand SignOutCommand { get; set; }


        public NavigationTopAppBarViewModel(ICustomerService customerService, INavigationService navigationService, IStorageService storageService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            MainPageClickedCommand = new RelayCommand(() => navigationService.Navigate("MainPage"));
            ReceiptsClickedCommand = new RelayCommand(() => navigationService.Navigate("ReceiptsSplitPage"));
            VouchersClickedCommand = new RelayCommand(() => navigationService.Navigate("VouchersItemPage"));
            LoyaltyCardsClickedCommand = new RelayCommand(() => navigationService.Navigate("LoyaltyCardsItemPage"));
            ShoppingListClickedCommand = new RelayCommand(() => navigationService.Navigate("myCart"));
            ProductSearchResultClickedCommand = new RelayCommand(() => navigationService.Navigate("ShoppingListPage"));
            StoreMapClickedCommand = new RelayCommand(() => navigationService.Navigate("StoreMapPage"));
            SignOutCommand = new RelayCommand(() => customerService.SignOut());
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
