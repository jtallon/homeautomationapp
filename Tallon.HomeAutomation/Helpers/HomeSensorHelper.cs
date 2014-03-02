
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Data.Json;
using Newtonsoft.Json.Linq;
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
    }
}
