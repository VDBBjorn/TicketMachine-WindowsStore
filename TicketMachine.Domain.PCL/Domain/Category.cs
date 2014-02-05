using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TicketMachine.Lib.Models
{
    [DataContract]
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<Product> Products { get; set; }
    }
}