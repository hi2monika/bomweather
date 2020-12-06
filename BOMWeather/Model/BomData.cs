using CsvHelper.Configuration.Attributes;

namespace BOMWeather.Model
{
    public class BomData : IBomData
    {
        [Name("Year")]
        public string Year { get; set; }

        [Name("Month")]
        public string Month { get; set; }

        [Name("Day")]
        public string Day { get; set; }

        [Name("Rainfall amount (millimetres)")]
        public string RainFallAmount { get; set; }

        [Name("Period over which rainfall was measured (days)")]
        public string PeriodOverWhichRainfallWasMeasured { get; set; }
    }
}