using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;
using BingGeocoder;

namespace TicketMachine.Lib.Services
{
    public class StoreService : IStoreService
    {
        private const string ServiceUrl = "http://localhost:17112/api/v1/Store";
        private readonly HttpClient client = new HttpClient();

        private ObservableCollection<Store> stores;

        public async Task<ObservableCollection<Store>> GetAllStoresAsync()
        {
            if (stores == null)
            {
                HttpResponseMessage response = await client.GetAsync(String.Format(ServiceUrl));
                var jsonString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                stores = JsonConvert.DeserializeObject<ObservableCollection<Store>>(jsonString);
            }
            return stores;
        }

        public async Task<Store> FindStoreByIdAsync(decimal id)
        {
            if (stores == null)
            {
                stores = await GetAllStoresAsync();
            }
            return stores.FirstOrDefault(s => s.Id == id);
        }

        public async Task<ObservableCollection<ProductPacking>> SearchProductPackingsInStore(decimal storeId, string searchValue)
        {
            ObservableCollection<ProductPacking> results = new ObservableCollection<ProductPacking>();

            HttpResponseMessage response = await client.GetAsync(String.Format("{0}/{1}?searchValue={2}", ServiceUrl, storeId, searchValue));
            var jsonString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            results = JsonConvert.DeserializeObject<ObservableCollection<ProductPacking>>(jsonString);
            
            return results;
        }

        public async Task<ObservableCollection<Store>> SearchProductPackingsByStore(string searchValue)
        {
            ObservableCollection<Store> results = new ObservableCollection<Store>();

            HttpResponseMessage response = await client.GetAsync(String.Format("{0}/?searchValue={1}", ServiceUrl, searchValue));
            var jsonString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            results = JsonConvert.DeserializeObject<ObservableCollection<Store>>(jsonString);

            return results;
        }

        public static MapLocation GetMapLocation(Store store)
        {
            String address = store.Address.Country + "," 
                                + store.Address.PostalCode + " " 
                                + store.Address.City + "," 
                                + store.Address.Street + " " 
                                + store.Address.HouseNumber;
            var geocoder = new BingGeocoderClient("An9K55D_WZkZSRhUg2RR58FayVtiW2UCf5JbDyB4O7ut40FPbS4q6jfO0wnqBqci");
            var result = new BingGeocoderResult();
            result = geocoder.Geocode(address);

            MapLocation location = new MapLocation();
            location.Latitude = Convert.ToDouble(result.Latitude);
            location.Longitude = Convert.ToDouble(result.Longitude);
            return location;
        }
    }
}
