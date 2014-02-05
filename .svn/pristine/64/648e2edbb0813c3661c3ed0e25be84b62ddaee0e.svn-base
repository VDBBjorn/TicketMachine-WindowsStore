using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties
            this.Property(t => t.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            //this.Property(t => t.authority)
            //    .IsRequired()
            //    .HasMaxLength(10);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerId).HasColumnName("customerId");
            this.Property(t => t.FirstName).HasColumnName("firstName");
            this.Property(t => t.LastName).HasColumnName("lastName");
            this.Property(t => t.Password).HasColumnName("password");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany()
                .Map(m => m.MapKey("addressId"));

            this.HasMany(c => c.Receipts)
                .WithRequired()
                .Map(m => m.MapKey("customer_id"));

            this.HasMany(c => c.Vouchers)
                .WithOptional()
                .Map(m => m.MapKey("customer_customerId"));

            this.HasMany(t => t.LoyaltyCards)
                .WithRequired()
                .Map(m => m.MapKey("customer_customerId"));

            this.HasOptional(t => t.ShoppingList)
                .WithOptionalDependent()
                .Map(m => m.MapKey("shoppingListId"));

            //password vault
        }
    }
}
