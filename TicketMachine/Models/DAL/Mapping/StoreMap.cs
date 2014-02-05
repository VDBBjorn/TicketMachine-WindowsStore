using System.Data.Entity.ModelConfiguration;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class StoreMap : EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Store");
            this.Property(t => t.Id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.PhoneNumber).HasColumnName("phoneNumber");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany()
                .Map(m => m.MapKey("addressId"));

            this.HasMany(s => s.ProductPackings)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("Store_ProductPacking");
                    m.MapLeftKey("Store_id");
                    m.MapRightKey("products_packingId");
                });
            }
    }
}
