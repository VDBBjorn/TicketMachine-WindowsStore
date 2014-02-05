using System.Data.Entity.ModelConfiguration;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;


namespace TicketMachine.Models.DAL.Mapping
{
    public class ShoppingListMap : EntityTypeConfiguration<ShoppingList>
    {
        public ShoppingListMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ShoppingList");
            this.Property(t => t.Id).HasColumnName("id");

            // Relationships
            this.HasMany(t => t.ProductPackings)
                .WithMany()
                .Map(m =>
                    {
                        m.ToTable("ShoppingList_ProductPacking");
                        m.MapLeftKey("ShoppingList_id");
                        m.MapRightKey("products_packingId");
                    });
        }
    }
}
