using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using S;
using B;
using S;
using git;

namespace Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(arguments).Running();
        }

	{
		Create.git.host.test(b, k);
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
#Left and Right test rebase
#More add comment
