using BOMWeather.Common;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BOMWeather.BOMClient
{
    public interface IBomClient
    {
        Task<JObject> GetRainFallJsonDataAsync(string path, AllowedFileExtensionEnum fileType);
    }
}