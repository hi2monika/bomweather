using BOMWeather.Client;
using BOMWeather.Common;
using BOMWeather.DataSource;
using BOMWeather.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace BOMWeather.BOMClient
{
    public class BomClient : IBomClient
    {
        private readonly IDataSource _dataSourceReader;
        private readonly IBomRainFallService _bomRainFallService;
        private readonly IJsonParser _jsonParser;
        private readonly ILogger<BomClient> _logger;

        public BomClient(IDataSource dataSourceReader, IBomRainFallService bomRainFallService, IJsonParser jsonParser, ILogger<BomClient> logger)
        {
            _dataSourceReader = dataSourceReader;
            _bomRainFallService = bomRainFallService;
            _jsonParser = jsonParser;
            _logger = logger;
        }

        public async Task<JObject> GetRainFallJsonDataAsync(string path, AllowedFileExtensionEnum fileType)
        {
            _logger.LogDebug("Bom client invoked");

            var bomData = await _dataSourceReader.ReadDataAsync(path, fileType);
            var bomDataViewModel = await _bomRainFallService.GetRainFallJsonDataAsync(bomData);

            _logger.LogDebug("Bom client end");

            return _jsonParser.CovertDataToJsonObject(bomDataViewModel);
        }
    }
}