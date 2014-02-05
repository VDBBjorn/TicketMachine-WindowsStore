using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine.Lib.Services
{
    public interface INavigationService
    {
        //Frame Frame { get; set; }
        void GoHome();
        void GoBack();
        void GoForward();
        void Navigate(string pageName);
        void Navigate(string pageName, object parameter);
        bool CanGoBack { get; }
        bool CanGoForward { get; }
    }
}
