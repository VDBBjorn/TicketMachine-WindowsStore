using System.Data.Entity;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Models.DAL.Mapping;

namespace TicketMachine.Models.DAL
{
    public class TicketMachineContext : DbContext
    {
        static TicketMachineContext()
        {
            Database.SetInitializer<TicketMachineContext>(null);
        }

        public TicketMachineContext() : base("Name=centric_dbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<ProductPacking> ProductPackings { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new LoyaltyCardMap());
            modelBuilder.Configurations.Add(new SavingsCardMap());
            modelBuilder.Configurations.Add(new ProductSavingsCardMap());
            modelBuilder.Configurations.Add(new CategorySavingsCardMap());
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