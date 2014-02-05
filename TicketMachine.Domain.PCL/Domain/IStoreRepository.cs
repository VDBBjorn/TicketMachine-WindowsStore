using System.Linq;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Domain
{
    public interface IStoreRepository
    {
        IQueryable<Store> FindAllStoresInfo(); //enkel info winkels
        Store GetStore(decimal id);
        IQueryable<Store> FindProductPackingsAllStores(string searchValue); //winekels met gezochte product 
        IQueryable<ProductPacking> FindProductPackingsByStore(decimal id, string searchText); //gezochte producten in bepaalde winkel
        ProductPacking GetProdcutPakcing(decimal id);
    }
}
