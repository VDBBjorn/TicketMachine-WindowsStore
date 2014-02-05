using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Services
{
    public interface IShareService
    {
        ShoppingList SharedShoppingList { get; set; }
        void Initialize();
    }
}