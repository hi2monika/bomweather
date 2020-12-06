using Newtonsoft.Json;

namespace BOMWeather.ViewModel
{
    public class BaseDataAttributes
    {
        [JsonProperty("FirstRecordedDate")]
        public string FirstRecordedDate { get; set; }

        [JsonProperty("LastRecordedDate")]
        public string LastRecordedDate { get; set; }

        [JsonProperty("TotalRainfall")]
        public string TotalRainfall { get; set; }

        [JsonProperty("AverageDailyRainfall")]
        public string AverageDailyRainfall { get; set; }

        [JsonProperty("DaysWithNoRainfall")]
        public string DaysWithNoRainfall { get; set; }

        [JsonProperty("DaysWithRainfall")]
        public string DaysWithRainfall { get; set; }
    }
}