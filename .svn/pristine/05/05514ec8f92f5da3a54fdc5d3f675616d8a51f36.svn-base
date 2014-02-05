using System;
using System.Runtime.Serialization;
using TicketMachine.Lib.Models;

namespace TicketMachine.Domain.PCL.Domain
{
    [DataContract]
    public partial class Voucher
    {
        [DataMember]
        public decimal VoucherId { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public DateTime ExpiryDate { get; set; }

        [DataMember]
        public double InitialValue { get; set; }

        [DataMember]
        public double RemainingValue { get; set; }

        [DataMember]
        public string VoucherType { get; set; }

        [DataMember]
        public virtual Store Store { get; set; }

    }
}
