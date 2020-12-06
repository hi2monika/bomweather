using BOMWeather.Common;
using BOMWeather.Extensions;
using BOMWeather.Interfaces;
using BOMWeather.Model;
using BOMWeather.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOMWeather.Providers
{
    public class MonthlyDataProvider : IMonthlyDataProvider
    {
        private readonly ILogger<MonthlyDataProvider> _logger;

        public MonthlyDataProvider(ILogger<MonthlyDataProvider> logger)
        {
            _logger = logger;
        }

        public async Task<MonthlyAggregates> GetMonthlyBomDataAsync(string month, string year, IReadOnlyCollection<IBomData> bomFilteredMonthData)
        {
            _logger.LogDebug($"GetMonthlyBomData Invoked For Month {month}, Year {year}");

            var monthlyAggregates = new MonthlyAggregates()
            {
                WeatherDataForMonth = new WeatherDataForMonth
                {
                    Month = DateTimeHelper.GetMonthName(Convert.ToInt16(month)),
                    FirstRecordedDate = bomFilteredMonthData.GetFirstRecordedDate(),
                    LastRecordedDate = bomFilteredMonthData.GetLastRecordedDate(),
                    TotalRainfall = bomFilteredMonthData.GetTotalRainFall(),
                    AverageDailyRainfall = bomFilteredMonthData.AverageDailyRainFall(),
                    MedianDailyRainfall = bomFilteredMonthData.GetMedianDailyRainFall(),
                    DaysWithRainfall = bomFilteredMonthData.GetDaysWithRainfall(),
                    DaysWithNoRainfall = bomFilteredMonthData.GetDaysWithNoRainfall(),
                }
            };
            return await Task.FromResult(monthlyAggregates);
        }
    }
}