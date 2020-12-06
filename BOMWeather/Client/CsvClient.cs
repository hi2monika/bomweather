using BOMWeather.Client.Exception;
using BOMWeather.Common;
using BOMWeather.Model;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BOMWeather.Client
{
    public class CsvClient : ICsvClient
    {
        private readonly ILogger<CsvClient> _logger;

        public CsvClient(ILogger<CsvClient> logger)
        {
            _logger = logger;
        }

        public async Task<IBomDataCollection> GetCsvDataAsync(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new InValidFilePathException(path);
            }
            else if (!File.Exists(path))
            {
                throw new System.IO.FileNotFoundException(path);
            }

            var filExtension = Path.GetExtension(path).Remove(0, 1);

            if (!Enum.GetNames(typeof(AllowedFileExtensionEnum)).Contains(filExtension.ToUpper()))
            {
                throw new InValidFilePathException(filExtension);
            }
            _logger.LogDebug($"Fetching data for file : {path}");

            Stream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(stream);

            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture, false);
            csv.Configuration.HasHeaderRecord = true;

            var records = csv.GetRecordsAsync<BomData>();

            return new BomDataCollection()
            {
                BomData = await records.ToListAsync()
            };
        }
    }
}