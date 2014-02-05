using System.Data.Entity.ModelConfiguration;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class ProductLineMap : EntityTypeConfiguration<ProductLine>
    {
        public ProductLineMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductLine");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.Amount).HasColumnName("amount");
            this.Property(t => t.TotalPrice).HasColumnName("totalPrice");

            // Relationships
            this.HasRequired(t => t.Receipt)
                .WithMany(t => t.ProductLines)
                .Map(m => m.MapKey("receiptId"));

            this.HasOptional(t => t.ProductPacking)
                .WithMany()
                .Map(m => m.MapKey("productId"));

        }
    }
}
