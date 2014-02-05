using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class PromotionMap : EntityTypeConfiguration<Promotion>
    {
        public PromotionMap()
        {
            // Primary Key
            this.HasKey(t => t.PromotionId);

            // Properties
            this.Property(t => t.PromotionDescription)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Promotion");
            this.Property(t => t.PromotionId).HasColumnName("promotionId");
            this.Property(t => t.PromotionDescription).HasColumnName("promotionDescription");
        }
    }
}
