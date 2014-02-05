using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class ReceiptsSplitPage : ViewModel
    {
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
        public Double TotalPriceAllProductLines { get; set; }

        private ObservableCollection<Receipt> receipts;
        public ObservableCollection<Receipt> Receipts
        {
            get { return receipts; }
            set { Set<ObservableCollection<Receipt>>(() => Receipts, ref receipts, value); }
        }

        public RelayCommand ExpenseChartClickedCommand { get; private set; }
        public RelayCommand NutritionChartClickedCommand { get; private set; }

        public ReceiptsSplitPage(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.NavigationService = navigationService;
            Receipts = new ObservableCollection<Receipt>();
            IsBusy = true;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ExpenseChartClickedCommand = new RelayCommand(ExpenseChartClicked);
            NutritionChartClickedCommand = new RelayCommand(NutritionChartClicked);
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            Receipts = await customerService.GetAllReceiptsAsync();
            IsBusy = false;
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }

        private void ExpenseChartClicked()
        {
            NavigationService.Navigate("ExpenseChartPage", null);
        }

        private void NutritionChartClicked()
        {
            NavigationService.Navigate("NutritionChartPage", null);
        }
    }
}
