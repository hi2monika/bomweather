using BOMWeather.Common;
using BOMWeather.Model;
using System.Threading.Tasks;

namespace BOMWeather.DataSource
{
    public interface IDataSource
    {
        Task<IBomDataCollection> ReadDataAsync(string path, AllowedFileExtensionEnum fileType);
    }
}