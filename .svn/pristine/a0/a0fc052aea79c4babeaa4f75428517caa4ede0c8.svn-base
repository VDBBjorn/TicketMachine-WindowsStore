using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Callisto.Controls;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;
using TicketMachine.Lib.ViewModels;
using TicketMachine.WS.Helper;
using Windows.Security.Credentials;
using Windows.Security.Credentials.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace TicketMachine.WS.Services
{
    class CredentialsService : ICredentialsService
    {
        private CredentialPickerOptions options;

        const string VAULT_RESOURCE = "TicketMachine Credentials";
        private PasswordVault vault;

        public CredentialsService()
        {
            vault = new PasswordVault();

            options = new CredentialPickerOptions()
            {
                AuthenticationProtocol = AuthenticationProtocol.Basic,
                CredentialSaveOption = Windows.Security.Credentials.UI.CredentialSaveOption.Selected,
                CallerSavesCredential = true,
                Caption = "Ticket Machine Login",
                Message = " ",
                TargetName = "."
            };
        }

        public async Task<Credentials> GetCredentials()
        {
            string customerId;
            string password;
            try
            {
                var creds = vault.FindAllByResource(VAULT_RESOURCE).FirstOrDefault();
                if (creds != null)
                {
                    customerId = creds.UserName;
                    password = vault.Retrieve(VAULT_RESOURCE, customerId).Password;
                    return new Credentials(Convert.ToDecimal(customerId), password, true);
                }
            }
            catch (Exception)
            {
                //return AskCredentials(1);
            }
            return await AskCredentials(0);
        }

        public async Task<Credentials> AskCredentials(uint errorCode)
        {
            options.ErrorCode =  errorCode; 
            Credentials credentials = null;
            while(credentials == null){
                CredentialPickerResults results = await CredentialPicker.PickAsync(options);
                decimal customerIdDec = 0;
                if (results.Credential != null && decimal.TryParse(results.CredentialUserName, out customerIdDec) && results.CredentialPassword != "")
                {
                    string password = results.CredentialPassword;
                    credentials = new Credentials(customerIdDec, password, results.CredentialSaveOption == CredentialSaveOption.Selected);
                }
            }
            return credentials;
        }

        public void RemoveCredentials(decimal customerId)
        {
            vault.Remove(vault.Retrieve(VAULT_RESOURCE, customerId.ToString()));
        }

        public void SaveCredential(Credentials credentials)
        {
            vault.Add(new PasswordCredential(VAULT_RESOURCE, credentials.CustomerId, credentials.Password));
        }
    }
}
