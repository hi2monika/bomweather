using BOMWeather.Client;
using BOMWeather.Common;
using BOMWeather.Model;
using System.Threading.Tasks;

namespace BOMWeather.DataSource
{
    public class DataSource : IDataSource
    {
        private readonly ICsvClient _csvClient;

        public DataSource(ICsvClient csvClient)
        {
            _csvClient = csvClient;
        }

        public async Task<IBomDataCollection> ReadDataAsync(string path, AllowedFileExtensionEnum fileType)
        {
            IBomDataCollection weatherBomData = default;
            switch (fileType)
            {
                case AllowedFileExtensionEnum.CSV:
                    weatherBomData = await _csvClient.GetCsvDataAsync(path);
                    break;
            }

            return weatherBomData;
        }
    }
}