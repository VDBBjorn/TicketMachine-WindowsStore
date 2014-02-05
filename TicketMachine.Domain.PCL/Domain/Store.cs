using System.Collections.Generic;
using System.Runtime.Serialization;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Lib.Models
{
    [DataContract]
    public partial class Store
    {
        [DataMember]
        public decimal Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public virtual Address Address { get; set; }

        [DataMember]
        public virtual ICollection<ProductPacking> ProductPackings { get; set; }
    }
}
