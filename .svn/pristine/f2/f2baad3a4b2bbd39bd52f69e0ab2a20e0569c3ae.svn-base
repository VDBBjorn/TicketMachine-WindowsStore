using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.WS.Helper
{
    public class LoyaltyCardDataTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate PointsTemplate { get; set; }
        public DataTemplate PercentageTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var lc = item as LoyaltyCard;
            if (lc is ProductSavingsCard || lc is CategorySavingsCard)
            {
                return PointsTemplate;
            }
            else if (lc is SavingsCard)
            {
                return PercentageTemplate;
            }
            return null;
        }
    }
}
