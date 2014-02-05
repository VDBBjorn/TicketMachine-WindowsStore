using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class ExpenseChartViewModel : ViewModel
    {
        private ICustomerService customerService;
        private Customer customer;

        public RelayCommand<string> OverviewClickedCommand { get; private set; }

        public ExpenseChartViewModel(ICustomerService customerService, INavigationService navigationService)
        {
            this.NavigationService = navigationService;
            this.customerService = customerService;
            Categories = new ObservableCollection<ProductCatergory>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            OverviewClickedCommand = new RelayCommand<string>(SetCategoriesByTime);
        }

        private string expenseSubTitle;

        public string ExpenseSubTitle
        {
            get { return expenseSubTitle; } 
            set { Set<string>(() => ExpenseSubTitle, ref expenseSubTitle, value); }
        }

        private ObservableCollection<ProductCatergory> categories;
        public ObservableCollection<ProductCatergory> Categories
        {
            get { return categories; }
            set { Set<ObservableCollection<ProductCatergory>>(() => Categories, ref categories, value); }
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            customer = await customerService.GetCustomer();
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }

        public async void SetCategoriesByTime(string period)
        {
            IEnumerable<Receipt> receipts = new List<Receipt>();
            categories = new ObservableCollection<ProductCatergory>();

            switch (period)
            {
                case "week":
                    receipts = customer.ReceiptsLastPeriod(1); 
                    ExpenseSubTitle = "Expenses for the last week";
                    break;
                case "month":
                    receipts = customer.ReceiptsLastPeriod(2); 
                    ExpenseSubTitle = "Expenses for the last month";
                    break;
                case "year":
                    receipts = customer.ReceiptsLastPeriod(3);
                    ExpenseSubTitle = "Expenses for the last year";
                    break;
                default:
                    receipts = customer.ReceiptsLastPeriod(1); 
                    ExpenseSubTitle = "Expenses for the last week";
                    break; 
            }

            Dictionary<string, Double> categoryDictionary = new Dictionary<string, double>();
            string categoryName;
            Double totalPrice;

            foreach (var receipt in receipts) 
            {
                foreach (var productline in receipt.ProductLines)
                {
                    categoryName = productline.ProductPacking.Product.Category.Name;
                    totalPrice = productline.TotalPrice;

                    if (categoryDictionary.ContainsKey(categoryName))
                        categoryDictionary[categoryName] = categoryDictionary[categoryName] + totalPrice;
                    else
                        categoryDictionary.Add(categoryName, totalPrice);
                }
            }

            foreach (var key in categoryDictionary.Keys)
            {
                Categories.Add(new ProductCatergory(key, categoryDictionary[key]));
            }
            
            NavigationService.Navigate("ExpenseChartPage");
        }

    }
}
