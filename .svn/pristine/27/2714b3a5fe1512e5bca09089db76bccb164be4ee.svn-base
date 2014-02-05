using System.Text;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;
using Windows.ApplicationModel.DataTransfer;

namespace TicketMachine.WS.Services
{
    public class ShareService : IShareService
    {
        public ShoppingList SharedShoppingList { get; set; }
        
        public void Initialize()
        {
            DataTransferManager dataTransferManager;
            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested -= this.DataRequested;
            dataTransferManager.DataRequested += this.DataRequested;
        }

        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            if (SharedShoppingList != null)
            {
                e.Request.Data.Properties.Title = "ShoppingList";

                e.Request.Data.Properties.Description = "ShoppingList";

                // Share shoppingList text
                StringBuilder builder = new StringBuilder();
                builder.Append("Products\r\n");

                foreach (var productPacking in SharedShoppingList.ProductPackings)
                {
                    builder.Append("- " + productPacking.Product.Name);
                    builder.Append("\r\n");
                }

                e.Request.Data.SetText(builder.ToString());
            }
        }

    }
}
