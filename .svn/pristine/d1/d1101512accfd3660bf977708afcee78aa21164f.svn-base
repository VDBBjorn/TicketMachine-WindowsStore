using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private ICustomerService customerService;
        private INavigationService navigationService;

        public ICommand ReceiptsClickedCommand { get; set; }
        public ICommand VouchersClickedCommand { get; set; }
        public ICommand LoyaltyCardsClickedCommand { get; set; }
        public ICommand ProductSearchResultClickedCommand { get; set; }

        public MainPageViewModel(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.navigationService = navigationService;
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            ReceiptsClickedCommand = new RelayCommand(() => navigationService.Navigate("ReceiptsSplitPage"));
            VouchersClickedCommand = new RelayCommand(() => navigationService.Navigate("VouchersItemPage"));
            LoyaltyCardsClickedCommand = new RelayCommand(() => navigationService.Navigate("LoyaltyCardsItemPage"));
            ProductSearchResultClickedCommand = new RelayCommand(() => navigationService.Navigate("ShoppingListPage"));
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        { 
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
