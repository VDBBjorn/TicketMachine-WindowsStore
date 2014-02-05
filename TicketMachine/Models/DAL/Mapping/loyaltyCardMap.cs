using System.Data.Entity.ModelConfiguration;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class LoyaltyCardMap : EntityTypeConfiguration<LoyaltyCard>
    {
        public LoyaltyCardMap()
        {
            this.ToTable("loyaltyCard");
            // Primary Key
            this.HasKey(t => t.CardId);

            this.Property(m => m.CardId).HasColumnName("cardId");
            this.Property(m => m.Comments).HasColumnName("Comments");
            this.Property(m => m.Barcode).HasColumnName("barcode");
            this.Property(m => m.CreationDate).HasColumnName("creationDate");
            this.Property(m => m.ExpiryDate).HasColumnName("expiryDate");
            this.Map<SavingsCard>(map => map.Requires("type").HasValue("general"))
                .Map<ProductSavingsCard>(map => map.Requires("type").HasValue("product"))
                .Map<CategorySavingsCard>(map => map.Requires("type").HasValue("category"));

            // Relationships
            this.HasRequired(t => t.Store)
                .WithMany()
                .Map(m => m.MapKey("store_id"));

        }
    }
}
