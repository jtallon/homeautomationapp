using Windows.Data.Json;

namespace Tallon.HomeAutomation.Helpers
{
    public static class JsonHelper
    {
        public static int ToInt(this JsonObject obj, string key)
        {
            var result = 0;
            IJsonValue value;
            if (!obj.TryGetValue(key, out value)) return result;
            return int.TryParse(value.GetNumber().ToString(), out result) ? result : result;
        }

        public static float ToFloat(this JsonObject obj, string key)
        {
            var result = 0.0f;
            IJsonValue value;
            if (!obj.TryGetValue(key, out value)) return result;
            return float.TryParse(value.GetNumber().ToString(), out result) ? result : result;
        }
    }
}
