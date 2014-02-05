using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Domain
{
    [DataContract]
    public class Receipt
    {
        public Receipt()
        {
            this.ProductLines = new List<ProductLine>();
        }

        [DataMember]
        public decimal TicketId { get; set; }

        [DataMember]
        public int Barcode { get; set; }

        [DataMember]
        public string CashDesk { get; set; }

        [DataMember]
        public string Deskoperator { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public virtual ICollection<ProductLine> ProductLines { get; set; }

        [DataMember]
        public virtual Store Store { get; set; }

        public double TotalPrice { get { return ProductLines.Sum(line => line.TotalPrice); }  }

    }
}
