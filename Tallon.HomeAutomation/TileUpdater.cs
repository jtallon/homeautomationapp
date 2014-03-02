using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace Tallon.HomeAutomation
{
    public sealed class TileUpdater : IBackgroundTask 
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var defferal = taskInstance.GetDeferral();

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();

            for (var i = 1; i < 6; i++)
            {
                var tile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText04);
                tile.GetElementsByTagName("text")[0].InnerText = "Tile " + i;
                tile.GetElementsByTagName("text")[1].InnerText = DateTime.Now.ToString("hh-mm");
                updater.Update(new TileNotification(tile));
            }

            defferal.Complete(); 
        }
    }
}
