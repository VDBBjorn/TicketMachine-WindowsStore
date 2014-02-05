using System;
using System.Collections.Generic;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Services;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TicketMachine.WS.Services
{
    public class NotificationService : INotificationService
    {
        public void CreateSimpleSquareTileNotifications(string text, int count)
        {
            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareBlock);
            var textElements = tileXml.GetElementsByTagName("text");  //get the tag text
            var countElement = (XmlElement)textElements[0]; // get count node
            var textElement = (XmlElement)textElements[1]; //get the text node 
            countElement.AppendChild(tileXml.CreateTextNode(count.ToString()));
            textElement.AppendChild(tileXml.CreateTextNode(text));
            var notification = new TileNotification(tileXml);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);
        }

        public void CreateSimpleSquareTileWithNameNotifications(string text, int count)
        {
            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareBlock);
            var visualElement = tileXml.GetElementsByTagName("visual")[0];
            var attribute = tileXml.CreateAttribute("branding");
            attribute.NodeValue = "name";
            visualElement.Attributes.SetNamedItem(attribute);
            var textElements = tileXml.GetElementsByTagName("text");  //get the tag text
            var countElement = (XmlElement)textElements[0]; // get count node
            var textElement = (XmlElement)textElements[1]; //get the text node 
            countElement.AppendChild(tileXml.CreateTextNode(count.ToString()));
            textElement.AppendChild(tileXml.CreateTextNode(text));
            var notification = new TileNotification(tileXml);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);
        }

        public void CreateWideTileNotifications(IList<Voucher> vouchers)
        {

        }
    }
}
