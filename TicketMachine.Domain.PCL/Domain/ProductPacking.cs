using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TicketMachine.Lib.Models;

namespace TicketMachine.Domain.PCL.Domain
{
    [DataContract]
    public class ProductPacking
    {
        public ProductPacking()
        {
            this.Promotions = new List<Promotion>();
        }

        [DataMember]
        public int PackingId { get; set; }

        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string PictureUrl { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public virtual ICollection<Promotion> Promotions { get; set; }

        public double Price { get { return Math.Round(Amount / 1000 * Product.UnitPrice, 2); } }
    }
}
