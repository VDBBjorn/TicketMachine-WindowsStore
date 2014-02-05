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
    public interface IStoreService
    {
        Task<ObservableCollection<Store>> GetAllStoresAsync();
        Task<Store> FindStoreByIdAsync(decimal id);
        Task<ObservableCollection<ProductPacking>> SearchProductPackingsInStore(decimal storeId, String searchValue);
        Task<ObservableCollection<Store>> SearchProductPackingsByStore(String searchValue);
    }

}
