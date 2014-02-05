using System.Collections.ObjectModel;
using System.Linq;
using TicketMachine.Domain.PCL.Domain;

namespace TicketMachine.Lib.Models
{
    public class VoucherGroup
    {

        private ObservableCollection<Voucher> vouchers = new ObservableCollection<Voucher>();

        public ObservableCollection<Voucher> Vouchers
        {
            get { return this.vouchers; }
        }

        private string type = string.Empty;

        public VoucherGroup(string voucherType)
        {
            Type = voucherType;
        }

        public string Type
        {
            get { return this.type; }
            set { type = value; }
        }

        public int VouchersCount
        {
            get
            {
                return this.Vouchers.Count;
            }
        }

        public void AddVoucher(Voucher voucher)
        {
            Vouchers.Add(voucher);
        }

        public Voucher FindVoucher(long id)
        {
            return Vouchers.FirstOrDefault(v => v.VoucherId == id);
        }

    }

}
