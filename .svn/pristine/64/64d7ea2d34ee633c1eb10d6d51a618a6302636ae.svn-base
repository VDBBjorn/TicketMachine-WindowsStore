using System.Data.Entity.ModelConfiguration;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);
        
            this.Property(t => t.Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.CategoryId).HasColumnName("categoryId");
            this.Property(t => t.Description).HasColumnName("description");
            this.Property(t => t.Name).HasColumnName("name");
        }
    }
}
