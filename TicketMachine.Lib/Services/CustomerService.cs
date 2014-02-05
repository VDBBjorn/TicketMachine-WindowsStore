using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.Services
{
   public class CustomerService : ICustomerService
    {       
       private const string CustomerUrl = "http://localhost:17112/api/v1/Customer";
       private const string VoucherUrl = "http://localhost:17112/api/v1/Voucher";
       private const string ShoppingListUrl = "http://localhost:17112/api/v1/ShoppingList";

       private HttpClient client;

       private Customer customer;
       private Credentials credentials;

       private IStorageService storageService;
       private ICredentialsService credentialsService;
       private INotificationService notificationService;

       public CustomerService(ICredentialsService credentialsService, IStorageService storageService, INotificationService notificationService)
       {
           this.credentialsService = credentialsService;
           this.storageService = storageService;
           this.notificationService = notificationService;

           this.GetCustomerAsync();
       }

       public async Task<Customer> GetCustomerAsync()
       {
           credentials = await credentialsService.GetCredentials(); 
           customer = await storageService.GetCustomer(Convert.ToDecimal(credentials.CustomerId));
           if (customer != null && customer.Password != credentials.Password)
               customer = null;
           this.SetClient(credentials);
           customer = await LoadCustomer();

           List<Voucher> vouchersToExpire = await FindVouchersToExpire();
           notificationService.CreateSimpleSquareTileNotifications("Vouchers To Expire", vouchersToExpire.Count);

           return customer; 
       }

       private void SetClient(Credentials credentials)
       {
           HttpClientHandler handler = new HttpClientHandler();
           handler.Credentials = new NetworkCredential(credentials.CustomerId.ToString(), credentials.Password);
           client = new HttpClient(handler);
       }

       private async Task<Customer> LoadCustomer()
       {
           bool downloadSucceeded;
           try
           {
                HttpResponseMessage response = await client.GetAsync(String.Format("{0}", CustomerUrl));
                var jsonString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var jsonSettings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All};
                customer = JsonConvert.DeserializeObject<Customer>(jsonString, jsonSettings);
               
               storageService.StorageCustomer(credentials.CustomerId, customer);
               if(credentials.Remeber)
                    credentialsService.SaveCredential(credentials);
               
               downloadSucceeded = true;

           }
           catch (Exception e)
           {
               downloadSucceeded = false;
           }

           if (downloadSucceeded || customer!=null)
                return customer;
           else
                return await GetCustomerAsync();
       }

       public async void SignOut()
       {
           try
           {
               credentialsService.RemoveCredentials(Convert.ToDecimal(credentials.CustomerId));
           }
           catch (Exception)
           {
               
           }
           await GetCustomerAsync();
       }

       public async Task<Customer> GetCustomer()
       {
           if (customer == null)
           {
               customer = await GetCustomerAsync();
           }
           return customer;
       }

       public async Task<ObservableCollection<Receipt>> GetAllReceiptsAsync()
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
            return customer.Receipts.OrderByDescending(r => r.Date).ToObservableCollection();

       }

       public async Task<Receipt> FindReceiptByIdAsync(decimal id)
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
           return customer.ReceiptById(id); 
       }

       public async Task<ObservableCollection<Voucher>> GetAllVouchersAsync()
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
            return customer.Vouchers.ToObservableCollection(); ;
       }

       public async Task<Voucher> FindVoucherByIdAsync(decimal id)
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
            return customer.VoucherById(id);
       }

       public async Task<List<Voucher>> FindVouchersToExpire()
       {
           if (customer == null)
           {
               customer = await GetCustomerAsync();
           }
           return customer.VouchersToExpire(); 
       }

       public async Task<ObservableCollection<LoyaltyCard>> GetAllLoyaltyCardsAsync()
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
            return customer.LoyaltyCards.ToObservableCollection();
       }

       public async Task<LoyaltyCard> FindLoyalyCardByIdAsync(decimal id)
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
           return customer.LoyalyCardById(id);
       }

       public async Task<ShoppingList> FindShoppingListAsync()
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }
            return customer.ShoppingList;
       }
       
       public async Task<bool> AddProductPakcingToShoppingList(decimal productPackingId)
       {
            HttpResponseMessage response = await client.GetAsync(String.Format("{0}/{1}{2}", ShoppingListUrl, "?productPackingId=", productPackingId));
            
            /*
                var jsonString = JsonConvert.SerializeObject(productPackingId);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(ShoppingListUrl, content));
           */

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            ProductPacking productPacking = JsonConvert.DeserializeObject<ProductPacking>(jsonString);
            if (productPacking == null)
                return false;
            else
            {
                customer.AddProductPakcingToShoppingList(productPacking);
                if (credentials.Remeber)
                    storageService.StorageCustomer(credentials.CustomerId, customer);
                return true;
            }
       }

       public async Task<bool> RemoveProductPakcingFromShoppingList(decimal productPackingId)
       {
           
           HttpResponseMessage response = await client.GetAsync(String.Format("{0}/{1}{2}", ShoppingListUrl, "?removeProductPackingId=", productPackingId));
           //HttpResponseMessage response = await client.DeleteAsync(String.Format("{0}/{1}", ShoppingListUrl, productPackingId));

           response.EnsureSuccessStatusCode();
           ProductPacking removedProductPacking = customer.ShoppingList.ProductPackings.FirstOrDefault(pp => pp.PackingId == productPackingId);
           customer.RemoveProductPakcingFromShoppingList(removedProductPacking); 
           if (credentials.Remeber)
               storageService.StorageCustomer(credentials.CustomerId, customer);
           return true;
       }

       public async Task<ObservableCollection<ProductPacking>> GetFavoriteProducts(int number)
       {
            if (customer == null)
            {
                customer = await GetCustomerAsync();
            }

           return customer.FavoriteProductPackings(number).ToObservableCollection(); 
       }

       public async Task<bool> AddVoucherToCustomer(string barcode)
       {
           if (!customer.ContainsVoucher(barcode))
           { 
               
               HttpResponseMessage response = await client.GetAsync(String.Format("{0}/{1}{2}", VoucherUrl, "?voucherBarcode=", barcode));             
               var jsonString = await response.Content.ReadAsStringAsync();
               response.EnsureSuccessStatusCode();
               
               /*
               var jsonString = JsonConvert.SerializeObject(barcode);
               var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
               var result = await client.PutAsync(VoucherUrl, content);
               result.EnsureSuccessStatusCode();
               jsonString = await result.Content.ReadAsStringAsync();
                */
               

               Voucher voucher = JsonConvert.DeserializeObject<Voucher>(jsonString);
               if (voucher == null)
                   return false;
               else
               {
                   customer.AddVoucher(voucher);
                   if (credentials.Remeber)
                       storageService.StorageCustomer(credentials.CustomerId, customer);
                   return true;
               }
           }
           return false;
       }

       public async Task<Address> GetAddressCustomerAsync()
       {
           if (customer == null)
           {
               customer = await GetCustomerAsync();
           }

           return customer.Address; 
       }

       public async Task<bool> SaveAddressCustomerAsync()
       {
           var jsonString = JsonConvert.SerializeObject(customer.Address);
           var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
           var result = await client.PutAsync(CustomerUrl, content);

           if (!result.IsSuccessStatusCode)
                return false;
           else
           {
               if (credentials.Remeber)
                   storageService.StorageCustomer(credentials.CustomerId, customer);
               return true;
           }
       }

       private string Serialize(Customer customer)
       {
           return JsonConvert.SerializeObject(customer);
       }
    }
}
