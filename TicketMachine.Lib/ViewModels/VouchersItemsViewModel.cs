using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;

namespace TicketMachine.Lib.ViewModels
{
    public class VouchersItemsViewModel : ViewModel
    {
        private ICustomerService customerService;

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                Set<bool>(() => IsBusy, ref isBusy, value);
            }
        }

        private ObservableCollection<VoucherGroup> voucherGroups;
        public ObservableCollection<VoucherGroup> VoucherGroups
        {
            get { return voucherGroups; }
            set { Set<ObservableCollection<VoucherGroup>>(() => VoucherGroups, ref voucherGroups, value); }
        }

        public RelayCommand<Voucher> VoucherClickedCommand { get; set; }
        public RelayCommand<string> AddVoucherCommand { get; set; }

        public VouchersItemsViewModel(ICustomerService customerService, INavigationService navigationService)
        {
            this.customerService = customerService;
            this.NavigationService = navigationService;
            VoucherGroups = new ObservableCollection<VoucherGroup>();
            IsBusy = true;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            VoucherClickedCommand = new RelayCommand<Voucher>((voucher) => NavigationService.Navigate("VoucherDetailPage", voucher.VoucherId));
            AddVoucherCommand = new RelayCommand<string>(AddVoucher);
        }

        private async void AddVoucher(string voucherCode)
        {
            var result = await customerService.AddVoucherToCustomer(voucherCode);
            if (result)
            {
                this.LoadState(null, null);
            }
        }

        public override async void LoadState(object parameter, Dictionary<string, object> viewModelState)
        {
            Dictionary<String, VoucherGroup> voucherGroupsDictionairy = new Dictionary<String, VoucherGroup>();
            foreach (var v in await customerService.GetAllVouchersAsync())
            {
                if (!voucherGroupsDictionairy.ContainsKey(v.VoucherType))
                    voucherGroupsDictionairy.Add(v.VoucherType, new VoucherGroup(v.VoucherType));
                voucherGroupsDictionairy[v.VoucherType].AddVoucher(v);
            }
            VoucherGroups = new ObservableCollection<VoucherGroup>(voucherGroupsDictionairy.Values);
            IsBusy = false;
        }

        public override void SaveState(Dictionary<string, object> viewModelState)
        {
        }
    }
}
