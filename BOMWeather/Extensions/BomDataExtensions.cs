using BOMWeather.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BOMWeather.Extensions
{
    public static class BomDataExtensions
    {
        public static string GetFirstRecordedDate(this IReadOnlyCollection<IBomData> bomData)
        {
            var firstRecordedDate = bomData.Where(data => !string.IsNullOrEmpty(data.RainFallAmount))
                .OrderBy(data => data.Year)
                .ThenBy(data => data.Month)
                .ThenBy(data => data.Day)
                .Select(data => $"{data.Year}-{data.Month}-{data.Day}").FirstOrDefault();
            return firstRecordedDate;
        }

        public static string GetLastRecordedDate(this IReadOnlyCollection<IBomData> bomData)
        {
            var lastRecordedDate = bomData.Where(data => !string.IsNullOrEmpty(data.RainFallAmount))
                .OrderByDescending(data => data.Year)
                .ThenByDescending(data => data.Month)
                .ThenByDescending(data => data.Day)
                .Select(data => $"{data.Year}-{data.Month}-{data.Day}").FirstOrDefault();
            return lastRecordedDate;
        }

        public static string GetTotalRainFall(this IReadOnlyCollection<IBomData> bomData)
        {
            var dailyRain = bomData.Where(data => !string.IsNullOrEmpty(data.RainFallAmount))
                .Select(data => data.RainFallAmount.ToFloat()).ToArray();

            return dailyRain.Any() ? dailyRain.Sum().ToString(CultureInfo.InvariantCulture) : null;
        }

        public static string AverageDailyRainFall(this IReadOnlyCollection<IBomData> bomData)
        {
            var averageRain = bomData.Where(data => !string.IsNullOrEmpty(data.RainFallAmount))
                .Select(data => data.RainFallAmount.ToFloat()).ToArray();

            return averageRain.Any() ? averageRain.Average().ToString(CultureInfo.InvariantCulture) : null;
        }

        public static string GetDaysWithRainfall(this IReadOnlyCollection<IBomData> bomData)
        {
            var daysWithRainFall = bomData.Where(data => !string.IsNullOrEmpty(data.RainFallAmount) && data.RainFallAmount.ToFloat() > 0)
                .Select(data => data.Day).ToArray();
            return daysWithRainFall.Any() ? daysWithRainFall.Length.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        public static string GetDaysWithNoRainfall(this IReadOnlyCollection<IBomData> bomData)
        {
            var daysWithNoRainFall = bomData.Where(data => string.IsNullOrEmpty(data.RainFallAmount) || data.RainFallAmount.ToFloat() == 0)
                .Select(data => data.Day).ToArray();

            return daysWithNoRainFall.Any() ? daysWithNoRainFall.Length.ToString(CultureInfo.InvariantCulture) : null;
        }

        public static string GetLongestNumberDaysRaining(this IReadOnlyCollection<IBomData> bomData)
        {
            return bomData.Where(data =>
                    !string.IsNullOrEmpty(data.PeriodOverWhichRainfallWasMeasured)
                    && data.PeriodOverWhichRainfallWasMeasured.ToFloat() > 0)
                .OrderByDescending(x => x.PeriodOverWhichRainfallWasMeasured)
                .Select(x => x.PeriodOverWhichRainfallWasMeasured).FirstOrDefault();
        }

        public static string GetMedianDailyRainFall(this IReadOnlyCollection<IBomData> bomData)
        {
            var medianDailyRainFall = bomData.Where(data => !string.IsNullOrEmpty(data.RainFallAmount)
                                                            && data.RainFallAmount.ToFloat() > 0)
                .Select(data => data.RainFallAmount.ToFloat()).ToArray();

            return medianDailyRainFall.Any() ? medianDailyRainFall.GetMedian()?.ToString(CultureInfo.InvariantCulture) : null;
        }

        public static IReadOnlyCollection<IBomData> GetFilteredYearData(this IReadOnlyCollection<IBomData> bomData, string year)
        {
            return bomData.Where(data => data.Year == year).ToList();
        }

        public static IReadOnlyCollection<IBomData> GetFilteredMonthData(this IReadOnlyCollection<IBomData> bomData, string month)
        {
            return bomData.Where(data => data.Month == month).ToList();
        }
    }
}