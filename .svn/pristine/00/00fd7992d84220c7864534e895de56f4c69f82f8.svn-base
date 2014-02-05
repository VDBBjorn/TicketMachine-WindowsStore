using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TicketMachine.Models.Mapping;

namespace TicketMachine.Models
{
    public partial class TicketMachineContext : DbContext
    {
        static TicketMachineContext()
        {
            Database.SetInitializer<TicketMachineContext>(null);
        }

        public TicketMachineContext()
            : base("Name=centric_dbContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoyaltyCard> loyaltyCards { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<ProductPacking> ProductPackings { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new loyaltyCardMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductLineMap());
            modelBuilder.Configurations.Add(new ProductPackingMap());
            modelBuilder.Configurations.Add(new PromotionMap());
            modelBuilder.Configurations.Add(new ReceiptMap());
            modelBuilder.Configurations.Add(new ShoppingListMap());
            modelBuilder.Configurations.Add(new StoreMap());
            modelBuilder.Configurations.Add(new VoucherMap());
        }
    }
}
