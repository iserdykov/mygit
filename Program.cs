using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(arguments).Running();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHostTest
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(cb =>
                {
                    var sources = cb.Sources;
                    sources.Insert(3, new Microsoft.Extensions.Configuration.Json.JsonConfigurationSource()
                    {
                        Optional = true,
                        Path = "appsettings.localhost.json",
                        ReloadOnChange = true
                    });
                })
                .UseStartup<Startup>()
                .UseSerilog((builderContext, config) =>
                {
                    config
                        .MinimumLevel.Information()
                        .Enrich.FromLogContext()
                        .WriteTo.Console();
                })
                .Build();

    }
}

