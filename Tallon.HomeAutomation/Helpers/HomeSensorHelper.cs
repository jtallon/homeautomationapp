
using System.Net.Http;
using Windows.Data.Json;
using Tallon.HomeAutomation.Models;

namespace Tallon.HomeAutomation.Helpers
{
    public static class HomeSensorHelper
    {
        public static HomeSensorData GetSensorData()
        {

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://jimi.is-a-geek.net:9966/");
            var result = response.Result.Content.ReadAsStringAsync();
            var items = JsonObject.Parse(result.Result);

            var results = new HomeSensorData
            {
                CarbonMonoxide = items.ToInt("co"),
                DewPoint = items.ToFloat("dewpoint"),
                Humidity = items.ToFloat("humidity"),
                Light = items.ToInt("light"),
                Smoke = items.ToInt("smoke"),
                Temperature = items.ToFloat("temperature")
            };
            return results;
        }

//        private static void UpdateLiveTile()
//        {
//            var LiveTile = @"<tile> 
//                                <visual version=""1""> 
//                                  <binding template=""TileWideText04""> 
//                                    <text id=""1"">My first own wide tile notification!</text> 
//                                  </binding> 
//                                  <binding template=""TileSquareText05""> 
//                                    <text id=""1"">My first own small tile notification!</text> 
//                                  </binding> 
//                                </visual> 
//                              </tile>";
//
//            var tileXml = new XmlDocument();
//            tileXml.LoadXml(LiveTile);
//
//            var tileNotification = new Windows.UI.Notifications.TileNotification(tileXml);
//            Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
//        }
    }
}
