using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL
{
    public class StoreRepository : IStoreRepository
    {
        private TicketMachineContext context;
        
        private DbSet<Store> stores;
        private DbSet<ProductPacking> productPackings;

        public StoreRepository(TicketMachineContext context)
        {
            this.context = context;
            stores = context.Stores;
            productPackings = context.ProductPackings; 
        }

        public IQueryable<Store> FindAllStoresInfo()
        {
            var storeList = stores.Include(s => s.Address)
                .OrderBy(s => s.Name);
            return storeList;
        }

        public Store GetStore(decimal id)
        {
            var store = stores.Include(s => s.Address)
                .Include(s => s.ProductPackings)
                .Include(s => s.ProductPackings.Select(pp=>pp.Product))
                .Include(s => s.ProductPackings.Select(pp => pp.Product.Category))
                .Include(s => s.ProductPackings.Select(pp => pp.Promotions))
                .FirstOrDefault(s => s.Id == id);
            return store;
        }

        public IQueryable<Store> FindProductPackingsAllStores(string searchValue)
        {
            var storesWithProduct=new Collection<Store>();
            foreach (Store store in stores.Include(s=> s.Address).Include(s=> s.ProductPackings).Include(s=> s.ProductPackings.Select(pp=>pp.Product)).Include(s=> s.ProductPackings.Select(pp=>pp.Promotions)))
            {
                var prodcuten = store.ProductPackings; 
                ProductPacking prodcut =
                    store.ProductPackings.FirstOrDefault(
                        pp => pp.Product.Name.Contains(searchValue) || pp.Description.Contains(searchValue));
                if(prodcut != null)
                    storesWithProduct.Add(store);
            }
            foreach (Store store in storesWithProduct)
            {
                store.ProductPackings = store.ProductPackings.Where(pp => pp.Product.Name.Contains(searchValue) || pp.Description.Contains(searchValue)).ToList(); 
            }
            return storesWithProduct.AsQueryable(); 
        }

        public IQueryable<ProductPacking> FindProductPackingsByStore(decimal id, string searchValue)
        {
            return productPackings
                .Include(pp => pp.Product)
                .Include(pp => pp.Product.Category)
                .Include(pp => pp.Promotions)
                .Where(pp => pp.Product.Name.Contains(searchValue) || pp.Description.Contains(searchValue));
        }

        public ProductPacking GetProdcutPakcing(decimal id)
        {
            return productPackings
                .Include(pp => pp.Product)
                .Include(pp => pp.Product.Category)
                .Include(pp => pp.Promotions)
                .FirstOrDefault(pp => pp.PackingId == id);
        }
    }
}