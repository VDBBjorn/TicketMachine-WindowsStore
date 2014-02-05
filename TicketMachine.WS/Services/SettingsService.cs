using System.Text;
using Callisto.Controls;
using TicketMachine.Lib.Models;
using TicketMachine.Lib.Services;
using TicketMachine.WS.Views;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Media;

namespace TicketMachine.WS.Services
{
    public class SettingsService : ISettingsService
    {
        private Color background = Color.FromArgb(255, 224, 91, 91);

        public SettingsService()
        {
            SettingsPane.GetForCurrentView().CommandsRequested -= OnCommandsRequested;
            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            // Add an About command
            var about = new SettingsCommand("about", "About", (handler) =>
            {
                var settings = new SettingsFlyout();
                settings.Content = new AboutUserControl();
                settings.HeaderBrush = new SolidColorBrush(background);
                settings.Background = new SolidColorBrush(background);
                settings.HeaderText = "About";
                settings.IsOpen = true;
            });

            args.Request.ApplicationCommands.Add(about);

            // Add a Preferences command
            var personalSettings = new SettingsCommand("personalSettings", "Personal Settings", (handler) =>
            {
                var settings = new SettingsFlyout();
                settings.Content = new PersonalSettingsUserControl();
                settings.HeaderBrush = new SolidColorBrush(background);
                settings.ContentBackgroundBrush = new SolidColorBrush(background);
                settings.HeaderText = "Personal Settings";
                settings.IsOpen = true;
            });

            args.Request.ApplicationCommands.Add(personalSettings);

        }
    }
}
