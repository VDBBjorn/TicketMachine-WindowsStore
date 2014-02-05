using System.Data.Entity.ModelConfiguration;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class VoucherMap : EntityTypeConfiguration<Voucher>
    {
        public VoucherMap()
        {
            // Primary Key
            this.HasKey(t => t.VoucherId);

            // Properties
            this.Property(t => t.Barcode)
                .HasMaxLength(255);

            this.Property(t => t.VoucherType)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Voucher");
            this.Property(t => t.VoucherId).HasColumnName("voucherId");
            this.Property(t => t.Barcode).HasColumnName("barcode");
            this.Property(t => t.CreationDate).HasColumnName("creationDate");
            this.Property(t => t.ExpiryDate).HasColumnName("expiryDate");
            this.Property(t => t.InitialValue).HasColumnName("initialValue");
            this.Property(t => t.RemainingValue).HasColumnName("remainingValue");
            this.Property(t => t.VoucherType).HasColumnName("voucherType");
            //this.Property(t => t.customer_customerId).HasColumnName("customer_customerId");
            //this.Property(t => t.store_id).HasColumnName("store_id");

            //// Relationships
            this.HasRequired(t => t.Store)
                .WithMany()
                .Map(m => m.MapKey("store_id"));



        }
    }
}
