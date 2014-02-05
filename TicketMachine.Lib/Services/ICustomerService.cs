using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer();
        Task<Customer> GetCustomerAsync();
        void SignOut();

        Task<ObservableCollection<Receipt>> GetAllReceiptsAsync();
        Task<Receipt> FindReceiptByIdAsync(decimal id);

        Task<ObservableCollection<Voucher>> GetAllVouchersAsync();
        Task<Voucher> FindVoucherByIdAsync(decimal id);
        Task<List<Voucher>> FindVouchersToExpire();
        Task<bool> AddVoucherToCustomer(string barcode);

        Task<ObservableCollection<LoyaltyCard>> GetAllLoyaltyCardsAsync();
        Task<LoyaltyCard> FindLoyalyCardByIdAsync(decimal id);

        Task<ShoppingList> FindShoppingListAsync();
        Task<bool> AddProductPakcingToShoppingList(decimal productPackingId);
        Task<bool> RemoveProductPakcingFromShoppingList(decimal productPackingId);
        
        Task<ObservableCollection<ProductPacking>> GetFavoriteProducts(int number);

        Task<Address> GetAddressCustomerAsync();
        Task<bool> SaveAddressCustomerAsync();
    }

}
