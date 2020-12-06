using BOMWeather.Interfaces;
using BOMWeather.Model;
using BOMWeather.ViewModel;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOMWeather.Services
{
    public class BomRainFallService : IBomRainFallService
    {
        private readonly IBomDataCollection _bomDataCollection;
        private readonly IYearlyDataProvider _yearlyDataProvider;
        private readonly ILogger<BomRainFallService> _logger;

        public BomRainFallService(IBomDataCollection bomDataCollection,
                                  IYearlyDataProvider yearlyDataProvider,
                                  ILogger<BomRainFallService> logger)
        {
            _bomDataCollection = bomDataCollection;// TODO removed
            _yearlyDataProvider = yearlyDataProvider;
            _logger = logger;
        }

        private IReadOnlyCollection<IBomData> GetFilteredYearData(IReadOnlyCollection<IBomData> bomData, string year)
        {
            return bomData.Where(data => data.Year == year).ToList();
        }

        public async Task<WeatherBomData> GetRainFallJsonDataAsync(IBomDataCollection bomDataCollection)
        {
            _logger.LogDebug("GetRainFallJsonData invoked");
            var yearlyBomDataViewModel = new ConcurrentBag<WeatherDataForYear>();

            await Task.WhenAll(bomDataCollection.BomData.Select(bomData => bomData.Year).Distinct()?.Select(year => Task.Run(
                async () =>
                {
                    _logger.LogDebug($"Service invoked for {year}");
                    var filterYearData = GetFilteredYearData(bomDataCollection.BomData, year);
                    var yearlyModel = await _yearlyDataProvider.GetYearlyBomDataAsync(year, filterYearData);
                    yearlyBomDataViewModel.Add(yearlyModel);
                })));

            return new WeatherBomData()
            {
                WeatherData = new WeatherData()
                {
                    WeatherDataForYear = yearlyBomDataViewModel
                }
            };
        }
    }
}