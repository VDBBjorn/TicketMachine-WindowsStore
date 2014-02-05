using System.Collections.ObjectModel;
using System.Linq;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Lib.Models
{
    public class LoyaltyCardGroup
    {

        private ObservableCollection<LoyaltyCard> loyaltyCards  = new ObservableCollection<LoyaltyCard>();

        public ObservableCollection<LoyaltyCard> LoyaltyCards
        {
            get { return this.loyaltyCards; }
        }

        private string type = string.Empty;

        public LoyaltyCardGroup(string loyaltyCardType)
        {
            Type = loyaltyCardType;
        }

        public string Type
        {
            get { return this.type; }
            set { type = value; }
        }

        public int LoyaltyCardsCount
        {
            get
            {
                return this.LoyaltyCards.Count;
            }
        }

        public void AddLoyaltyCard(LoyaltyCard loyaltyCard)
        {
            LoyaltyCards.Add(loyaltyCard);
        }

        public LoyaltyCard FindLoyaltyCard(long id)
        {
            return LoyaltyCards.FirstOrDefault(l => l.CardId == id);
        }

    }

}
