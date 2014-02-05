using TicketMachine.Lib.Services;
using Windows.Storage;

namespace TicketMachine.WS.Services
{
    public class StateService : IStateService
    {
        ApplicationDataContainer roamingSettings = null;

        public StateService()
        {
            roamingSettings = ApplicationData.Current.RoamingSettings;
        }

        public void SaveState<T>(string key, T value)
        {
            roamingSettings.Values[key] = value;
        }

        public T LoadState<T>(string key)
        {
            if (roamingSettings.Values.ContainsKey(key))
                return (T)roamingSettings.Values[key];
            return default(T);
        }

    }
}
