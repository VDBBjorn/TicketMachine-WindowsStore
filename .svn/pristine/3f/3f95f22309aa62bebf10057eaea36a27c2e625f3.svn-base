using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class ProductSavingsCardMap : EntityTypeConfiguration<ProductSavingsCard>
    {
        public ProductSavingsCardMap()
        {
            this.Property(t => t.Points).HasColumnName("points");
            this.Property(t => t.PointsToSave).HasColumnName("pointsToSave");
            this.HasRequired(p => p.Product)
                .WithMany()
                .Map(m => m.MapKey("productId"));
        }
    }
}