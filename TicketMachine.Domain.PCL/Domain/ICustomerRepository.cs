using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Domain
{
    public interface ICustomerRepository
    {
        Customer FindBy(decimal id);
        bool CheckPassword(decimal customerId, string password);
        Voucher FindVoucherByBarcode(string barcode);
        void RemoveProductPackingFromShoppingList(Customer customer,ProductPacking productPacking);
        void SaveChanges();

    }
}
