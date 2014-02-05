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
    public class NutritionChartViewModel : ViewModel
    {
        private ICustomerService customerService;
        private Customer customer;

        public RelayCommand<string> OverviewClickedCommand { get; private set; }

        public NutritionChartViewModel(ICustomerService customerService, INavigationService navigationService)
        {

            this.NavigationService = navigationService;
            this.customerService = customerService;
            NutritionSets = new ObservableCollection<NutritionSet>();
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            OverviewClickedCommand = new RelayCommand<string>(SetNutritionByTime);
        }

        private string nutritionSubTitle;

        public string NutritionSubTitle
        {
            get { return nutritionSubTitle; } 
            set { Set<string>(() => NutritionSubTitle, ref nutritionSubTitle, value); }
        }

        private ObservableCollection<NutritionSet> nutritionSets;
        public ObservableCollection<NutritionSet> NutritionSets
        {
            get { return nutritionSets; }
            set { Set<ObservableCollection<NutritionSet>>(() => NutritionSets, ref nutritionSets, value); }
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            customer = await customerService.GetCustomer();
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }

        public async void SetNutritionByTime(string period)
        {
            IEnumerable<Receipt> receipts = new List<Receipt>();
            NutritionSets.Add(new NutritionSet("Calories (in cal)", 0));
            NutritionSets.Add(new NutritionSet("Carbohydrates (in grams)", 0));
            NutritionSets.Add(new NutritionSet("lipids (in grams)", 0));
            NutritionSets.Add(new NutritionSet("proteins (in grams)", 0));

            switch (period)
            {
                case "week":
                    receipts = customer.ReceiptsLastPeriod(1);
                    nutritionSubTitle = "Nutritional report for the last week";
                    break;
                case "month":
                    receipts = customer.ReceiptsLastPeriod(2);
                    nutritionSubTitle = "Nutritional report for the last month";
                    break;
                case "year":
                    receipts = customer.ReceiptsLastPeriod(3);
                    nutritionSubTitle = "Nutritional report for the last year";
                    break;
                default:
                    receipts = customer.ReceiptsLastPeriod(1);
                    nutritionSubTitle = "Nutritional report for the last week";
                    break;
            }

            foreach (var receipt in receipts)
            {
                foreach (var productline in receipt.ProductLines)
                {
                    NutritionSets.ElementAt(0).Nutrition += productline.ProductPacking.Product.Calories;
                    nutritionSets.ElementAt(1).Nutrition += productline.ProductPacking.Product.Carbohydrates;
                    nutritionSets.ElementAt(2).Nutrition += productline.ProductPacking.Product.Fats;
                    nutritionSets.ElementAt(3).Nutrition += productline.ProductPacking.Product.Proteins;
                }
            }
            NavigationService.Navigate("NutritionChartPage");
        }
    }
}
