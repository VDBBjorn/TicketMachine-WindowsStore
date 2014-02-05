using System;
using System.Runtime.Serialization;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Domain.PCL.Domain
{
    [DataContract]
    [KnownType(typeof(SavingsCard))]
    [KnownType(typeof(ProductSavingsCard))]
    [KnownType(typeof(CategorySavingsCard))]
    public abstract class LoyaltyCard
    {
        [DataMember]
        public decimal CardId { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public int Barcode { get; set; }
        [DataMember]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public virtual Store Store { get; set; }
    }
}
