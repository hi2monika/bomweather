using BOMWeather.ViewModel;
using Newtonsoft.Json.Linq;

namespace BOMWeather.Client
{
    public interface IJsonParser
    {
        JObject CovertDataToJsonObject<T>(T data);
    }
}