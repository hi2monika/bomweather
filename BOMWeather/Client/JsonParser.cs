using BOMWeather.Client.Exception;
using BOMWeather.Common;
using Newtonsoft.Json.Linq;

namespace BOMWeather.Client
{
    public class JsonParser : IJsonParser
    {
        public JObject CovertDataToJsonObject<T>(T data)
        {
            try
            {
                return JObject.FromObject(data, Constants.JsonSerializerSettings);
            }
            catch
            {
                throw new ParserException("BomData");
            }
        }
    }
}