using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class ShoppingListViewModel : ViewModel
    {
        private ICustomerService customerService;
        private IShareService shareService;

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                Set<bool>(() => IsBusy, ref isBusy, value);
            }
        }

        private ShoppingList shoppingList;
        public ShoppingList ShoppingList
        {
            get { return shoppingList; }
            set
            {
                Set<ShoppingList>(() => ShoppingList, ref shoppingList, value);
                shareService.SharedShoppingList = shoppingList;
            }
        }

        public RelayCommand<decimal> ProductPackingRemoveCommand { get; private set; }

        public ShoppingListViewModel(ICustomerService customerService, IShareService shareService)
        {
            this.customerService = customerService;
            this.shareService = shareService; 

            ShoppingList = new ShoppingList();
            IsBusy = true;
            InitializeCommands();
            this.LoadState(null, null);
        }

        private void InitializeCommands()
        {
            ProductPackingRemoveCommand = new RelayCommand<decimal>(RemoveProductPacking);
        }

        private async void RemoveProductPacking(decimal packingId)
        {
            var result = await customerService.RemoveProductPakcingFromShoppingList(packingId);
            if (result)
            {
                this.LoadState(null, null);
            }
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            //Sharing
            shareService.Initialize();

            //data uit db
            ShoppingList = await customerService.FindShoppingListAsync();
            IsBusy = false;
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
