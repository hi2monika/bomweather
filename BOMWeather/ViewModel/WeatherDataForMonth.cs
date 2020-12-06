using Newtonsoft.Json;

namespace BOMWeather.ViewModel
{
    public class WeatherDataForMonth : BaseDataAttributes
    {
        [JsonProperty("Month")]
        public string Month { get; set; }

        [JsonProperty("MedianDailyRainfall")]
        public string MedianDailyRainfall { get; set; }
    }
}