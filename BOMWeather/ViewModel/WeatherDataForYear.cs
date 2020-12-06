using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace BOMWeather.ViewModel
{
    public class WeatherDataForYear : BaseDataAttributes
    {
        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("LongestNumberOfDaysRaining")]
        public string LongestNumberOfDaysRaining { get; set; }

        [JsonProperty("MonthlyAggregates")]
        public ConcurrentBag<MonthlyAggregates> MonthlyAggregates { get; set; }
    }

    public class MonthlyAggregates
    {
        [JsonProperty("WeatherDataForMonth")]
        public WeatherDataForMonth WeatherDataForMonth { get; set; }
    }
}