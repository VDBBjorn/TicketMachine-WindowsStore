using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Services;
using Windows.Storage;

namespace TicketMachine.WS.Services
{
    public class StorageService : IStorageService
    {
        private JsonSerializerSettings jsonSettings;
        private StorageFolder folder; 

        public StorageService()
        {
            folder = ApplicationData.Current.LocalFolder;

            jsonSettings = new JsonSerializerSettings();
            jsonSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            jsonSettings.TypeNameHandling = TypeNameHandling.All;
        }

        public async void StorageCustomer(string customerId, Customer customer)
        {
            string customerString = this.Serialize(customer);

            StorageFile file = await folder.CreateFileAsync(customerId, CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(file, customerString);
        }

        public async Task<Customer> GetCustomer(decimal customerId)
        {
            string customerString = String.Empty;              
            if (await DoesFileExistAsync(customerId.ToString(), folder))
            {
                //use the cached version
                StorageFile file = await folder.GetFileAsync(customerId.ToString());
                customerString = await Windows.Storage.FileIO.ReadTextAsync(file);
                return JsonConvert.DeserializeObject<Customer>(customerString, jsonSettings);
            }
            return null;
        }

        private async static Task<bool> DoesFileExistAsync(string fileName, StorageFolder folder)
        {
            try
            {
                await folder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string Serialize(Customer customer)
        {
            return JsonConvert.SerializeObject(customer, jsonSettings);
        }
    }
}
