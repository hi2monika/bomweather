using CsvHelper.Configuration.Attributes;

namespace BOMWeather.Model
{
    public interface IBomData
    {
        [Name("Year")]
        string Year { get; set; }

        [Name("Month")]
        string Month { get; set; }

        [Name("Day")]
        string Day { get; set; }

        [Name("Rainfall amount (millimetres)")]
        string RainFallAmount { get; set; }

        [Name("Period over which rainfall was measured (days)")]
        string PeriodOverWhichRainfallWasMeasured { get; set; }
    }
}