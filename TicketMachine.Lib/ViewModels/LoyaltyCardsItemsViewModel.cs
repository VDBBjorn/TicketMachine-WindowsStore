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

namespace TicketMachine.Lib.ViewModels
{
    public class LoyaltyCardsItemsViewModel : ViewModel
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

        private ObservableCollection<LoyaltyCardGroup> loyaltyCardGroups;
        public ObservableCollection<LoyaltyCardGroup> LoyaltyCardGroups
        {
            get { return loyaltyCardGroups; }
            set { Set<ObservableCollection<LoyaltyCardGroup>>(() => LoyaltyCardGroups, ref loyaltyCardGroups, value); }
        }

        public RelayCommand<LoyaltyCard> LoyaltyCardClickedCommand { get; set; }

        public LoyaltyCardsItemsViewModel(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.NavigationService = navigationService;
            IsBusy = true;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoyaltyCardClickedCommand = new RelayCommand<LoyaltyCard>((loyaltyCard) => NavigationService.Navigate("LoyaltyCardDetailPage", loyaltyCard.CardId));
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            Dictionary<String, LoyaltyCardGroup> loyaltyCardGroupsDictionairy = new Dictionary<String, LoyaltyCardGroup>();
            foreach (var l in await customerService.GetAllLoyaltyCardsAsync())
            {
                Type p = l.GetType();
                if (!loyaltyCardGroupsDictionairy.ContainsKey(p.Name))
                    loyaltyCardGroupsDictionairy.Add(p.Name, new LoyaltyCardGroup(p.Name));
                loyaltyCardGroupsDictionairy[p.Name].AddLoyaltyCard(l);
            }
            LoyaltyCardGroups = new ObservableCollection<LoyaltyCardGroup>(loyaltyCardGroupsDictionairy.Values);
            IsBusy = false;
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
