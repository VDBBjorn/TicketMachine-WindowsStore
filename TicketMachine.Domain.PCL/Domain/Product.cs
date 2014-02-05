using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TicketMachine.Lib.Models
{
    [DataContract]
    public class Product
    {
        public Product()
        {}

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public double Calories { get; set; }

        [DataMember]
        public double Carbohydrates { get; set; }

        [DataMember]
        public double Fats { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Proteins { get; set; }

        [DataMember]
        public double UnitPrice { get; set; }

        [DataMember]
        public string VatCode { get; set; }

        [DataMember]
        public virtual Category Category { get; set; }
    }
}
