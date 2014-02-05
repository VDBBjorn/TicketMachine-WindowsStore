using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;


namespace TicketMachine.Lib.Models
{
    [DataContract(Name = "CategorySavingsCard")]
    public class CategorySavingsCard: LoyaltyCard
    {
        [DataMember]
        public int Points { get; set; }
        [DataMember]
        public int PointsToSave { get; set; }
        [DataMember]    
        public virtual Category Category { get; set; }
    }
}