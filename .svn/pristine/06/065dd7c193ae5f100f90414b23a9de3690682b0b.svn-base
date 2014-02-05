using System;
using TicketMachine.Lib.Services;
using Windows.UI.Popups;

namespace TicketMachine.WS.Services
{
    public class DialogService : IDialogService
    {
        public async void ShowDialog(string message)
        {
            MessageDialog messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }

        public async void ShowDeleteConfirmation()
        {
            MessageDialog messageDialog = new MessageDialog("The item has been deleted");
            await messageDialog.ShowAsync();
        }
        
    }
}
