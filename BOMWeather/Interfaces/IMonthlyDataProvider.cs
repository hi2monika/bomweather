using BOMWeather.Model;
using BOMWeather.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOMWeather.Interfaces
{
    public interface IMonthlyDataProvider
    {
        Task<MonthlyAggregates> GetMonthlyBomDataAsync(string month, string year, IReadOnlyCollection<IBomData> bomFilteredMonthData);
    }
}