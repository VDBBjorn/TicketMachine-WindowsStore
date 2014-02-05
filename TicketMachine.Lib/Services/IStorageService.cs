using System.Threading.Tasks;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Lib.Services
{
    public interface IStorageService
    {
        void StorageCustomer(string customerId, Customer customer);
        Task<Customer> GetCustomer(decimal customerId); 
    }
}
