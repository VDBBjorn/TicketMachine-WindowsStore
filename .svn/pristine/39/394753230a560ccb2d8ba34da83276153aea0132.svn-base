using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class SavingsCardMap : EntityTypeConfiguration<SavingsCard>
    {
        public SavingsCardMap()
        {
            this.Property(t => t.SavingPercentage).HasColumnName("savingPercentage");
        }
    }
}