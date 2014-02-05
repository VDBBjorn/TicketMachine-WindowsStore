using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class StoreMapViewModel : ViewModel
    {
        private IStoreService storeService;

        public StoreMapViewModel(IStoreService storeService, INavigationService navigationService)
        {
            this.NavigationService = navigationService;
            this.storeService = storeService;
            Stores = new ObservableCollection<Store>();
            SelectedStore = new Store();
        }

        private ObservableCollection<Store> stores;
        public ObservableCollection<Store> Stores
        {
            get { return stores; }
            set { Set<ObservableCollection<Store>>(() => Stores, ref stores, value); }
        }

        private Store selectedStore;

        public Store SelectedStore
        {
            get { return selectedStore; } 
            set { Set<Store>(() => SelectedStore, ref selectedStore, value); }
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            Stores = await storeService.GetAllStoresAsync();
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
