using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Controllers
{
    public class StoreController : ApiController
    {
        private IStoreRepository storeRepository;
     
        public StoreController(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        //api/v1/store/  
        //haalt enkel storeinfo op, geen prodcutpackings!!
        public IEnumerable<Store> GetStoresInfo()
        {
            var stores = storeRepository.FindAllStoresInfo().ToList();
            return stores;
        }

        public Store GetStoreById(decimal id)
        {
            return storeRepository.GetStore(id);
        }

        //api/v1/store/?searchValue=xx        
        public IEnumerable<Store> GetProductPackingsAllStores(string searchValue)
        {
            var storesWithProductPacking = storeRepository.FindProductPackingsAllStores(searchValue);
            if (storesWithProductPacking != null)
                return storesWithProductPacking;
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //api/v1/store/xx?searchValue=xx        
        public IEnumerable<ProductPacking> GetProductPackingsByStore(decimal id, String searchValue)
        {
            var productPacings = storeRepository.FindProductPackingsByStore(id, searchValue);
            if (productPacings != null)
                return productPacings;
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
