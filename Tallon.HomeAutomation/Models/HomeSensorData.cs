namespace Tallon.HomeAutomation.Models
{
    public sealed class HomeSensorData
    {
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public float DewPoint { get; set; }
        public int Light { get; set; }
        public int CarbonMonoxide { get; set; }
        public int Smoke { get; set; }
    }
}
