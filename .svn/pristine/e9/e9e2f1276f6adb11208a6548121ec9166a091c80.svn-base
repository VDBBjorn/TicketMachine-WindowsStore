using System.Data.Entity.ModelConfiguration;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class ReceiptMap : EntityTypeConfiguration<Receipt>
    {
        public ReceiptMap()
        {
            // Primary Key
            this.HasKey(t => t.TicketId);

            // Properties
            this.Property(t => t.CashDesk)
                .HasMaxLength(255);

            this.Property(t => t.Deskoperator)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Receipt");
            this.Property(t => t.TicketId).HasColumnName("ticketId");
            this.Property(t => t.Barcode).HasColumnName("barcode");
            this.Property(t => t.CashDesk).HasColumnName("cashDesk");
            this.Property(t => t.Date).HasColumnName("date");
            this.Property(t => t.Deskoperator).HasColumnName("operator");

            // Relationships

            this.HasRequired(t => t.Store)
                .WithMany()
                .Map(m => m.MapKey("store_id"));

        }
    }
}
