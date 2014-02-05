using System.Data.Entity.ModelConfiguration;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class ProductPackingMap : EntityTypeConfiguration<ProductPacking>
    {
        public ProductPackingMap()
        {
            // Primary Key
            this.HasKey(t => t.PackingId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.PictureUrl)
                .HasMaxLength(255);

            this.Property(t => t.Unit)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ProductPacking");
            this.Property(t => t.PackingId).HasColumnName("packingId");
            this.Property(t => t.Amount).HasColumnName("amount");
            this.Property(t => t.Description).HasColumnName("description");
            this.Property(t => t.PictureUrl).HasColumnName("pictureUrlWin8");
            this.Property(t => t.Unit).HasColumnName("unit");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany()
                .Map(m => m.MapKey("productId")); 

            this.HasMany(t => t.Promotions)
                .WithMany()
                .Map(m =>
                    {
                        m.ToTable("ProductPacking_Promotion");
                        m.MapLeftKey("promotions_promotionId");
                        m.MapRightKey("ProductPacking_packingId");
                    });



        }
    }
}
