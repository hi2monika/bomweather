using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BOMWeather.Common
{
    public static class Constants
    {
        public static class ValidationMessage
        {
            public const string FileNotFound = "File not Found {0}";
            public const string IncorrectExtension = "Incorrect extension {0}";
            public const string ParserException = "Could not parse";
        }

        public static class Logging
        {
            public static string MessageTemplate =
                $"[{{Timestamp:yyyy-MM-dd HH:mm:ss.fff}}] [{{Level}}]  :  - {{Message}}{{NewLine}}{{Exception}}";
        }

        public static readonly JsonSerializer JsonSerializerSettings = new JsonSerializer()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };
    }
}