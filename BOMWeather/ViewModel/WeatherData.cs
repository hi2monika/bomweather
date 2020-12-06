using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace BOMWeather.ViewModel
{
    public class WeatherBomData
    {
        [JsonProperty("WeatherData")]
        public WeatherData WeatherData { get; set; }
    }

    public class WeatherData
    {
        [JsonProperty("WeatherDataForYear")]
        public ConcurrentBag<WeatherDataForYear> WeatherDataForYear { get; set; }
    }
}