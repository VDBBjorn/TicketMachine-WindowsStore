using System;
using TicketMachine.Lib.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace TicketMachine.WS.Services
{
    public class NavigationService : INavigationService
    {
        public Frame Frame { get { return (Frame) Window.Current.Content; } }

        public void GoHome()
        {
            if (Frame != null)
                while (Frame.CanGoBack) Frame.GoBack();
        }

        public void GoBack()
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }

        public void GoForward()
        {
            if (Frame != null && Frame.CanGoForward) Frame.GoForward();
        }

        public void Navigate(string pageName)
        {
            Navigate(pageName, null);
        }

        public void Navigate(string pageName, object parameter)
        {
            string viewTypeName = String.Format("{0}.{1}",  "TicketMachine.WS.Views" , pageName);
            var viewType = Type.GetType(viewTypeName);
            Frame.Navigate(viewType, parameter);
        }

        public bool CanGoBack
        {
            get { return Frame.CanGoBack; }
        }

        public bool CanGoForward
        {
            get { return Frame.CanGoForward; }
        }
    }
}
