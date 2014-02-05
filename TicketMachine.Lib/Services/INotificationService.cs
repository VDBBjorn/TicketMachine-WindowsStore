using System.Collections.Generic;
using TicketMachine.Lib.Models;

namespace TicketMachine.Lib.Services
{
    public interface INotificationService
    {
        void CreateSimpleSquareTileNotifications(string text, int count);
        void CreateSimpleSquareTileWithNameNotifications(string text, int count);
        //void CreateWideTileNotifications(IList<> groups);
    }
}