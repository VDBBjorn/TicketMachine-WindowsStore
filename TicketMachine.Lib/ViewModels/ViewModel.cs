using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMachine.Lib.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TicketMachine.Lib.ViewModels
{
    public abstract class ViewModel : ViewModelBase
    {
        public abstract void LoadState(Object parameter, Dictionary<String, Object> viewModelState);
        public abstract void SaveState(Dictionary<String, Object> viewModelState);
        public INavigationService NavigationService { get; set; }
        public IStorageService StorageService { get; set; }

        //public virtual bool CanGoBack
        //{
        //    get
        //    {
        //        if (NavigationService != null) return NavigationService.CanGoBack;
        //        return false;
        //    }
        //}
        //public virtual bool CanGoForward
        //{
        //    get
        //    {
        //        if (NavigationService != null) return NavigationService.CanGoForward;
        //        return false;
        //    }
        //}
    }
}
