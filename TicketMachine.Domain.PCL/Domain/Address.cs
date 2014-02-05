using System.Runtime.Serialization;

namespace TicketMachine.Domain.PCL.Domain
{
    [DataContract]
    public class Address
    {

        public decimal AddressId { get; set; }
        
        [DataMember]
        public string City { get; set; }
        
        [DataMember]
        public string Country { get; set; }
        
        [DataMember]
        public string HouseNumber { get; set; }

        [DataMember]
        public int PostalCode { get; set; }

        [DataMember]
        public string Street { get; set; }
    }
}
