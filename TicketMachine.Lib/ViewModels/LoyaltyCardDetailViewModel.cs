using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class LoyaltyCardDetailViewModel : ViewModel
    {
        private ICustomerService customerService;

        private ObservableCollection<LoyaltyCard> loyaltyCards;
        public ObservableCollection<LoyaltyCard> LoyaltyCards
        {
            get { return loyaltyCards; }
            set { Set<ObservableCollection<LoyaltyCard>>(() => LoyaltyCards, ref loyaltyCards, value); }
        }

        private LoyaltyCard selectedLoyaltyCard;
        public LoyaltyCard SelectedLoyaltyCard
        {
            get { return selectedLoyaltyCard; }
            set { Set<LoyaltyCard>(() => SelectedLoyaltyCard, ref selectedLoyaltyCard, value); }
        }

        public LoyaltyCardDetailViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;
            LoyaltyCards = new ObservableCollection<LoyaltyCard>();
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null && viewModelState.ContainsKey("SelectedItem"))
            {
                parameter = viewModelState["SelectedItem"];
            }
            decimal cardId = (decimal)parameter;
            LoyaltyCards = await customerService.GetAllLoyaltyCardsAsync();
            selectedLoyaltyCard = LoyaltyCards.FirstOrDefault(l => l.CardId == cardId);
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
            string cardIdString = SelectedLoyaltyCard.CardId.ToString();
            viewModelState["SelectedItem"] = cardIdString; //SelectedLoyaltyCard.CardId;
        }
    }
}
