using System.Data.Entity.ModelConfiguration;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.Brand)
                .HasMaxLength(255);

            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.VatCode)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.ProductId).HasColumnName("productId");
            this.Property(t => t.Brand).HasColumnName("brand");
            this.Property(t => t.Calories).HasColumnName("calories");
            this.Property(t => t.Carbohydrates).HasColumnName("carbohydrates");
            this.Property(t => t.Fats).HasColumnName("fats");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.Proteins).HasColumnName("proteins");
            this.Property(t => t.UnitPrice).HasColumnName("unitPrice");
            this.Property(t => t.VatCode).HasColumnName("vatCode");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .Map(m => m.MapKey("categoryId"));

        }
    }
}
