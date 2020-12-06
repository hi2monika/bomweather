using System;
using System.Collections.Generic;
using System.Text;
using BOMWeather.ServiceProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Usage
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRainService(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureRainFallService();
            return serviceCollection;
        }
    }
}