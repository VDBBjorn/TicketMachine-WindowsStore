using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Lib.Models
{
    [DataContract(Name = "SavingsCard")]
    public class SavingsCard : LoyaltyCard
    {
        [DataMember]
        public double SavingPercentage { get; set; }
    }
}