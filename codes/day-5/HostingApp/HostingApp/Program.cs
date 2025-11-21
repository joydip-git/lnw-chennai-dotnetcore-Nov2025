using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace HostingApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            //configure the builder for a customized host
            //ILoggerFactory loggerFactory =
            //     LoggerFactory
            //     .Create(builder => builder.AddSimpleConsole(options => options.SingleLine = true));
            //ILogger logger = loggerFactory.CreateLogger<Program>();
            //logger.LogInformation("");

            builder
                .Logging
                .AddSimpleConsole(options => options.SingleLine = true);

            ConfigurationManager configManager = builder
                .Configuration;

            configManager
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false, true);

            IServiceCollection registry = builder.Services;
            registry.Configure<ApiUrl>(apiurlObj => builder.Configuration.GetRequiredSection("apiUrl").Bind(apiurlObj));
            registry.AddScoped<IStorage<Post>, PostStorage>();


            IHost host = builder.Build();

            //get services, configuration , logger factory etc.
            IServiceProvider provider = host.Services;
            IStorage<Post> storageService = provider.GetRequiredService<IStorage<Post>>();
            List<Post> posts = await storageService.GetDataAsync();
            posts.ForEach(p => Console.WriteLine(p.Title));

            await host.RunAsync();
        }
    }
}
