using BOMWeather.Model;
using BOMWeather.ViewModel;
using System.Threading.Tasks;

namespace BOMWeather.Interfaces
{
    public interface IBomRainFallService
    {
        Task<WeatherBomData> GetRainFallJsonDataAsync(IBomDataCollection bomDataCollection);
    }
}