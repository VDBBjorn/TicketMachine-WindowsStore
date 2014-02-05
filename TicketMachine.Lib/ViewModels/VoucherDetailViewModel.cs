using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class VoucherDetailViewModel : ViewModel
    {
        private ICustomerService customerService;

        private ObservableCollection<Voucher> vouchers;
        public ObservableCollection<Voucher> Vouchers
        {
            get { return vouchers; }
            set { Set<ObservableCollection<Voucher>>(() => Vouchers, ref vouchers, value); }
        }

        private Voucher selectedVoucher;
        public Voucher SelectedVoucher
        {
            get { return selectedVoucher; }
            set { Set<Voucher>(() => SelectedVoucher, ref selectedVoucher, value); }
        }

        public VoucherDetailViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;
            Vouchers = new ObservableCollection<Voucher>();
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null && viewModelState.ContainsKey("SelectedItem"))
            {
                parameter = viewModelState["SelectedItem"];
            }
            decimal voucherId = (decimal)parameter;
            Vouchers = await customerService.GetAllVouchersAsync();
            selectedVoucher = Vouchers.FirstOrDefault(v => v.VoucherId == voucherId);
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
            string voucherIdString = SelectedVoucher.VoucherId.ToString();
            viewModelState["SelectedItem"] = voucherIdString; //SelectedVoucher.VoucherId;
        }
    }
}
