using System;
using System.Threading.Tasks;
using BOMWeather.BOMClient;
using BOMWeather.Client;
using BOMWeather.Common;
using BOMWeather.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Constants = BOMWeather.Common.Constants;

namespace Usage
{
    public class Program
    {
        private const LogEventLevel LogLevel = LogEventLevel.Debug;

        private static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(new LoggingLevelSwitch(LogLevel))
                .MinimumLevel.Override("Microsoft", LogLevel)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: Constants.Logging.MessageTemplate)
                .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddLogging(loggingBuilder => loggingBuilder.AddSerilog(Log.Logger))
                .AddRainService()
                .BuildServiceProvider();

            var bomClient = serviceProvider.GetService<IBomClient>();

            Console.WriteLine("Please enter the file path");
            var path = Console.ReadLine();
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Please enter the file path");
            }
            else
            {
                var bomDataJson = await bomClient.GetRainFallJsonDataAsync(path, AllowedFileExtensionEnum.CSV);

                Console.WriteLine(bomDataJson);
            }

            Console.ReadLine();
        }
    }
}