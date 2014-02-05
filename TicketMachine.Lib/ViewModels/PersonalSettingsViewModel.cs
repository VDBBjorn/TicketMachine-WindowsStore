using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class PersonalSettingsViewModel:ViewModel
    {
        private ICustomerService customerService;

        private Address address;

        public Address Address 
        {
            get { return address; }
            set { Set<Address>(() => Address, ref address, value); }
        }

        public PersonalSettingsViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
        }

        public async Task<bool> SaveChanges()
        {
            return await customerService.SaveAddressCustomerAsync();
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            Address = await customerService.GetAddressCustomerAsync(); 
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
            throw new NotImplementedException();
        }
    }
}
