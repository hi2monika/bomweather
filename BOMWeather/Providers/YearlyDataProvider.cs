using BOMWeather.Common;
using BOMWeather.Extensions;
using BOMWeather.Interfaces;
using BOMWeather.Model;
using BOMWeather.ViewModel;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BOMWeather.Providers
{
    public class YearlyDataProvider : IYearlyDataProvider
    {
        private readonly IMonthlyDataProvider _monthlyDataProvider;
        private readonly ILogger<YearlyDataProvider> _logger;

        public YearlyDataProvider(IBomDataCollection bomDataCollection, IMonthlyDataProvider monthlyDataProvider, ILogger<YearlyDataProvider> logger)
        {
            _monthlyDataProvider = monthlyDataProvider;
            _logger = logger;
        }

        public async Task<WeatherDataForYear> GetYearlyBomDataAsync(string year, IReadOnlyCollection<IBomData> bomFilteredYearData)
        {
            var monthlyAggregates = new ConcurrentBag<MonthlyAggregates>();
            await Task.WhenAll(bomFilteredYearData.Select(bomData => bomData.Month).Distinct()?.Select(filteredMonth => Task.Run(
                async () =>
                {
                    if (!DateTimeHelper.IsCurrentMonth(filteredMonth, year))
                    {
                        var bomFilteredYearAndMonthData = bomFilteredYearData.GetFilteredMonthData(filteredMonth);
                        var monthViewModel = await _monthlyDataProvider.GetMonthlyBomDataAsync(filteredMonth, year, bomFilteredYearAndMonthData);
                        monthlyAggregates.Add(monthViewModel);
                    }
                    else
                    {
                        _logger.LogInformation($"Data Ignore for current {filteredMonth} {year}");
                    }
                })));

            return new WeatherDataForYear()
            {
                Year = year,
                FirstRecordedDate = bomFilteredYearData.GetFirstRecordedDate(),
                LastRecordedDate = bomFilteredYearData.GetLastRecordedDate(),
                TotalRainfall = bomFilteredYearData.GetTotalRainFall(),
                AverageDailyRainfall = bomFilteredYearData.AverageDailyRainFall(),
                DaysWithRainfall = bomFilteredYearData.GetDaysWithRainfall(),
                DaysWithNoRainfall = bomFilteredYearData.GetDaysWithNoRainfall(),
                LongestNumberOfDaysRaining = bomFilteredYearData.GetLongestNumberDaysRaining(),
                MonthlyAggregates = monthlyAggregates
            };
        }
    }
}