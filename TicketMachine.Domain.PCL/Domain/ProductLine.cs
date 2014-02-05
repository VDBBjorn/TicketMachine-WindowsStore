using System.Runtime.Serialization;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Domain
{
    [DataContract]
    public partial class ProductLine
    {
        public decimal Id { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public double TotalPrice { get; set; }



        public virtual Receipt Receipt { get; set; }

        [DataMember]
        public virtual ProductPacking ProductPacking { get; set; }
    }
}
