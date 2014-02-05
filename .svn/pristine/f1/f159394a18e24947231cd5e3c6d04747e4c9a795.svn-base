using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;
using TicketMachine.Lib.ViewModels;

namespace TicketMachine.Lib.ViewModels
{
    public class ProductSearchResultViewModel : ViewModel
    {

        private IStoreService storeService;
        private ICustomerService customerService;

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                Set<bool>(() => IsBusy, ref isBusy, value);
            }
        }

        private Store selectedStore;
        public Store SelectedStore
        {
            get { return selectedStore; }
            set { 
                Set<Store>(() => SelectedStore, ref selectedStore, value);
                if(SelectedStore != null)
                    ProductSearchResults = SelectedStore.ProductPackings.ToObservableCollection();
            }
        }

        private ObservableCollection<Store> storeSearchResults;
        public ObservableCollection<Store> StoreSearchResults
        {
            get { return storeSearchResults; }
            set
            {
                Set<ObservableCollection<Store>>(() => StoreSearchResults, ref storeSearchResults, value);
            }
        }

        private ObservableCollection<ProductPacking> productSearchResults;

        public ObservableCollection<ProductPacking> ProductSearchResults
        {
            get { return productSearchResults; }
            set
            {
                Set<ObservableCollection<ProductPacking>>(() => ProductSearchResults, ref productSearchResults, value);
            }
        }

        public RelayCommand<ProductPacking> ProductPackingAddCommand { get; private set; }

        public ProductSearchResultViewModel(ICustomerService customerService, IStoreService storeService)
        {
            this.customerService = customerService;
            this.storeService = storeService;
            StoreSearchResults = new ObservableCollection<Store>();
            ProductSearchResults = new ObservableCollection<ProductPacking>();
            IsBusy = true;
            InitializeCommands();
        }

        private String queryText;
        public string QueryText
        {
            get { return queryText; }
            set { Set<String>(() => QueryText, ref queryText, value); }
        }

        public async void Initialize(object parameter)
        {
            QueryText = parameter.ToString();
            StoreSearchResults = await storeService.SearchProductPackingsByStore(QueryText);
        }

        private void InitializeCommands()
        {
            ProductPackingAddCommand = new RelayCommand<ProductPacking>(AddProductPacking);
        }

        private async void AddProductPacking(ProductPacking productPacking)
        {
            var result = await customerService.AddProductPakcingToShoppingList(productPacking.PackingId);
            if (result)
            {
                //toon shoppingCart?
            }
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            StoreSearchResults = null; 
            ProductSearchResults = await customerService.GetFavoriteProducts(10);
            
            IsBusy = false;

        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
