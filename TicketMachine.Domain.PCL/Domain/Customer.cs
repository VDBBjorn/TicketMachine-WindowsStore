using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Domain.PCL.Domain
{
    [DataContract]
    public class Customer
    {
        private const int DAYSTOEXPIRE = 5;

        public Customer()
        {
            this.LoyaltyCards = new List<LoyaltyCard>();
            this.Vouchers = new List<Voucher>();
            this.Receipts = new List<Receipt>();
            this.ShoppingList = new ShoppingList(); 
        }

        public decimal CustomerId { get; set; }
        
        [DataMember]
        public string FirstName { get; set; }
        
        [DataMember]
        public string LastName { get; set; }
        
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public virtual Address Address { get; set; }

        [DataMember]
        public virtual ICollection<LoyaltyCard> LoyaltyCards { get; set; }

        [DataMember]
        public virtual ICollection<Voucher> Vouchers { get; set; }

        [DataMember]
        public virtual ICollection<Receipt> Receipts { get; set; }

        [DataMember]
        public virtual ShoppingList ShoppingList { get; set; }

        public Receipt ReceiptById(decimal id)
        {
            return Receipts.FirstOrDefault(r => r.TicketId == id);
        }

        public IEnumerable<Receipt> ReceiptsLastPeriod(int period)
        {
            var lastDate = DateTime.Now.Date.AddDays(-7);
            switch (period)
            {
                case 1: lastDate = DateTime.Now.Date.AddDays(-7); break;
                case 2: lastDate = DateTime.Now.Date.AddMonths(-1); break;
                case 3: lastDate = DateTime.Now.Date.AddYears(-1); break;
            }
            return Receipts.Where(r => r.Date > lastDate);
        } 

        public Voucher VoucherById(decimal id)
        {
            return Vouchers.FirstOrDefault(v => v.VoucherId == id);
        }

        public bool ContainsVoucher(string barcode)
        {
            return Vouchers.FirstOrDefault(v => v.Barcode == barcode) != null; 
        }

        public List<Voucher> VouchersToExpire()
        {
            return Vouchers.Where(v => (v.ExpiryDate - DateTime.Today).Days < DAYSTOEXPIRE && v.ExpiryDate >= DateTime.Today).ToList(); 
        }

        public void AddVoucher(Voucher voucher)
        {
            Vouchers.Add(voucher);
        }

        public LoyaltyCard LoyalyCardById(decimal id)
        {
            return LoyaltyCards.FirstOrDefault(l => l.CardId == id);
        }

        public void AddProductPakcingToShoppingList(ProductPacking productPacking)
        {
            ShoppingList.AddProductPacking(productPacking);
        }

        public void RemoveProductPakcingFromShoppingList(ProductPacking productPacking)
        {
            ShoppingList.RemoveProductPacking(productPacking);
        }

        public IEnumerable<ProductPacking> FavoriteProductPackings(int number)
        {
            return Receipts.SelectMany(r => r.ProductLines)
                .GroupBy(pp => pp.ProductPacking)
                .Select(lijst => new { Product = lijst.Key, Count = lijst.Count() }).ToList()
                .OrderByDescending(l => l.Count)
                .Select(l => l.Product)
                .Take(number);
        }

    }
}
