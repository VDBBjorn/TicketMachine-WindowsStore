using System.Data.Entity.ModelConfiguration;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.HouseNumber)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Street)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.AddressId).HasColumnName("addressId");
            this.Property(t => t.City).HasColumnName("city");
            this.Property(t => t.Country).HasColumnName("country");
            this.Property(t => t.HouseNumber).HasColumnName("houseNumber");
            this.Property(t => t.PostalCode).HasColumnName("postalCode");
            this.Property(t => t.Street).HasColumnName("street");
        }
    }
}
