using System;
using Windows.UI.Notifications;
using Tallon.HomeAutomation.Models;

namespace Tallon.HomeAutomation.Helpers
{
    public static class TileHelper
    {
        public static void UpdateTile(HomeSensorData data)
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();

            var tile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText04);
            tile.GetElementsByTagName("text")[0].InnerText = string.Format("Temp {2}{1}DewPoint {3}{0}Humidity {4}{1}Light {5}{0}Smoke {6}{1}CO {7}{0}{8}",
                Environment.NewLine,
                "\t",
                Math.Round(data.Temperature, 2), 
                Math.Round(data.DewPoint, 3),
                data.Humidity,
                data.Light,
                data.Smoke,
                data.CarbonMonoxide,
                DateTime.Now.ToString("h:mm tt"));
            updater.Update(new TileNotification(tile));
        }
    }
}
