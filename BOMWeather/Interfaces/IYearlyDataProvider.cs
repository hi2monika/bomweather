using BOMWeather.Model;
using BOMWeather.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOMWeather.Interfaces
{
    public interface IYearlyDataProvider
    {
        Task<WeatherDataForYear> GetYearlyBomDataAsync(string year, IReadOnlyCollection<IBomData> bomFilteredYearData);
    }
}