using System.Threading.Tasks;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Services
{
    public interface ICredentialsService
    {
        Task<Credentials> GetCredentials();
        Task<Credentials> AskCredentials(uint errorCode);
        void SaveCredential(Credentials credentials);
        void RemoveCredentials(decimal customerId);
    }
}
