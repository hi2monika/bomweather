using BOMWeather.BOMClient;
using BOMWeather.Client;
using BOMWeather.DataSource;
using BOMWeather.Interfaces;
using BOMWeather.Model;
using BOMWeather.Providers;
using BOMWeather.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BOMWeather.ServiceProvider
{
    public static class ConfigureBomService
    {
        public static void ConfigureRainFallService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBomDataCollection, BomDataCollection>();
            serviceCollection.AddSingleton<IBomData, BomData>();
            serviceCollection.AddSingleton<ICsvClient, CsvClient>();
            serviceCollection.AddSingleton<IBomClient, BomClient>();
            serviceCollection.AddSingleton<IJsonParser, JsonParser>();
            serviceCollection.AddSingleton<IDataSource, DataSource.DataSource>();

            serviceCollection.AddScoped<IBomRainFallService, BomRainFallService>();
            serviceCollection.AddScoped<IMonthlyDataProvider, MonthlyDataProvider>();
            serviceCollection.AddScoped<IYearlyDataProvider, YearlyDataProvider>();
        }
    }
}