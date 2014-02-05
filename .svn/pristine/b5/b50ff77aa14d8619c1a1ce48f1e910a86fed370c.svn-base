using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Models.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private TicketMachineContext context;
        private DbSet<Customer> customers;
        private DbSet<Voucher> vouchers;

        public CustomerRepository(TicketMachineContext context)
        {
            this.context = context;
            customers = context.Customers;
            vouchers = context.Vouchers; 
        }

        public bool CheckPassword(decimal customerId, string password)
        {
            Customer customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            return customer != null && customer.Password.Equals(password);
        }

        public Customer FindBy(decimal id)
        {
            Customer customer = customers.Include(c=>c.Address)
                //Include Receipts
                .Include(c => c.Receipts.Select(r=>r.ProductLines.Select(p=>p.ProductPacking.Product)))
                .Include(c => c.Receipts.Select(r=>r.ProductLines.Select(p=>p.ProductPacking.Promotions)))
                .Include(c => c.Receipts.Select(r => r.ProductLines.Select(p => p.ProductPacking.Product.Category)))
                .Include(c => c.Receipts.Select(r => r.ProductLines.Select(p => p.Receipt)))
                .Include(c => c.Receipts.Select(r => r.Store.Address))
                //Include Vouchers
                .Include(c => c.Vouchers.Select(s => s.Store))
                //Include LoyaltyCards
                .Include(c => c.LoyaltyCards)
                //Include ShoppingList
                .Include(c => c.ShoppingList)
                .Include(c => c.ShoppingList.ProductPackings)
                .FirstOrDefault(c=>c.CustomerId==id);
            foreach (ProductSavingsCard c in customer.LoyaltyCards.OfType<ProductSavingsCard>())
                context.Entry(c).Reference(p => p.Product).Load();
            return customer;
        }

        public Voucher FindVoucherByBarcode(string barcode)
        {
            Voucher voucherInUse = customers.SelectMany(c => c.Vouchers).FirstOrDefault(v => v.Barcode == barcode);
            Voucher voucher=null;

            if(voucherInUse==null){
                voucher = vouchers.FirstOrDefault(v => v.Barcode == barcode);
            }
            return voucher;
        }

        public void RemoveProductPackingFromShoppingList(Customer customer, ProductPacking productPacking)
        {
            customer.ShoppingList.RemoveProductPacking(productPacking);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}