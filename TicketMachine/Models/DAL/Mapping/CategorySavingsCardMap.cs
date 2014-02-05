using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class CategorySavingsCardMap : EntityTypeConfiguration<CategorySavingsCard>
    {
        public CategorySavingsCardMap()
        {
            this.Property(t => t.Points).HasColumnName("points");
            this.Property(t => t.PointsToSave).HasColumnName("pointsToSave");
            
            this.HasRequired(c => c.Category)
                .WithMany()
                .Map(m => m.MapKey("categoryId"));
        }
    }
}