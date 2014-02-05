using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TicketMachine.Domain.PCL.Domain
{
    [DataContract]
    public class ShoppingList
    {
        public ShoppingList()
        {
            this.ProductPackings = new List<ProductPacking>();
        }

        [DataMember]
        public decimal Id { get; set; }

        [DataMember]
        public virtual ICollection<ProductPacking> ProductPackings { get; set; }

        public void AddProductPacking(ProductPacking productPacking)
        {
            ProductPackings.Add(productPacking);
        }

        public void RemoveProductPacking(ProductPacking productPacking)
        {
            ProductPackings.Remove(productPacking);
        }

        public double TotalPrice { get { return ProductPackings.Sum(p => p.Price); } }
    }
}
