using System.Runtime.Serialization;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Domain
{
    [DataContract(Name = "ProductSavingsCard")]
    public class ProductSavingsCard : LoyaltyCard
    {
        [DataMember]
        public int Points { get; set; }
        [DataMember]
        public int PointsToSave { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
    }
}