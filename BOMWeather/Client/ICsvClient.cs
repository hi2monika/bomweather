using BOMWeather.Model;
using System.Threading.Tasks;

namespace BOMWeather.Client
{
    public interface ICsvClient
    {
        Task<IBomDataCollection> GetCsvDataAsync(string path);
    }
}