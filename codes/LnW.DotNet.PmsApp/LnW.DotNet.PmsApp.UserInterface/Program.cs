using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Manager;
using LnW.DotNet.PmsApp.Repository;
using LnW.DotNet.PmsApp.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace LnW.DotNet.PmsApp.UserInterface
{
    internal class Program
    {
        static IHost CreateHost(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            //Configuration settings
            ConfigurationManager configManager = builder.Configuration;

            configManager
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false, true);

            //service registration
            IServiceCollection registry = builder.Services;


            //registering IOptions<IFilePathSetting> types
            //if fetching data from products.json file
            registry.Configure<FilePathSetting>(
                fs =>
                {
                    fs.FilePath = configManager.GetRequiredSection("filePathSetting:productFilePath").Value ?? "products.json";
                }
                );

            //if fetching data from categories.json file
            //registry.Configure<FilePathSetting>(
            //    fs =>
            //    {
            //        fs.FilePath = configManager.GetRequiredSection("fileList:categoryFilePath").Value ?? "categories.json";
            //    }
            //    );

            //registering storages
            //storage objects are dependent on IOptions<FilePathSetting> type objects
            registry.AddScoped<IStorage<Product>, FileStorage<Product>>();
            registry.AddScoped<IStorage<Category>, FileStorage<Category>>();

            //IRepository objects are dependent on IStorage type objects
            registry.AddScoped<IRepository<Product, int>, ProductRepository>();
            registry.AddScoped<IRepository<Category, int>, CategoryRepository>();

            //IManager type objects are dependent on IRepository type objects
            registry.AddScoped<IManager<Product, int>, ProductManager>();
            registry.AddScoped<IManager<Category, int>, CategoryManager>();

            //configuring logger
            ILoggingBuilder loggerBuilder = builder.Logging;
            loggerBuilder
                .AddSimpleConsole(
                    (buildOptions) =>
                    {
                        buildOptions.SingleLine = true;
                        buildOptions.ColorBehavior = LoggerColorBehavior.Enabled;
                        buildOptions.IncludeScopes = true;
                    }
                );

            //finally creating host which is configured with required configuration providers, services for dependency injection and logger
            IHost host = builder.Build();
            return host;

        }
        private static async Task GetProducts(IServiceProvider provider)
        {
            IManager<Product, int> productManager = provider.GetRequiredService<IManager<Product, int>>();
            IReadOnlyList<Product> products = await productManager.FetchAll();

            products
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}"));
        }
        static async Task Main(string[] args)
        {
            /* code with Hosting service*/
            using IHost host = CreateHost(args);
            await GetProducts(host.Services);
            await host.RunAsync();

            /*
         
            //code without Host service

            //configring a configuration provider
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            //configring services
            var services = new ServiceCollection();

            services.Configure<FilePathSetting>(filePathSetting => 
                {
                    filePathSetting.FilePath = configuration.GetRequiredSection("filePathSetting:productFilePath").Value ?? "";
                    //for categories
                    //filePathSetting.CategoryFilePath = configuration.GetRequiredSection("filePathSetting:categoryFilePath").Value??"";
                }
            );

            services.AddScoped<IStorage<Product>, FileStorage<Product>>();
            services.AddScoped<IStorage<Category>, FileStorage<Category>>();

            services.AddScoped<IRepository<Product, int>, ProductRepository>();
            services.AddScoped<IRepository<Category, int>, CategoryRepository>();

            services.AddScoped<IManager<Product, int>, ProductManager>();
            services.AddScoped<IManager<Category, int>, CategoryManager>();

            //configuraing logger by register logging service
            services.AddLogging(
                loggerBuilder => loggerBuilder.AddSimpleConsole(
                    options =>
                    {
                        options.SingleLine = true;
                        options.ColorBehavior = LoggerColorBehavior.Enabled;
                        options.IncludeScopes = true;
                    })
                );

            IServiceProvider provider = services.BuildServiceProvider();

            IManager<Product, int> productManager = provider.GetRequiredService<IManager<Product, int>>();

            var products = await productManager.FetchAll()
            products
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}"));
            */

            /*
            //manual creation of logger

            ILoggerFactory factory = LoggerFactory
                .Create(loggerBuilder => loggerBuilder.AddSimpleConsole(options =>
                {
                    options.SingleLine = true;
                    options.ColorBehavior = LoggerColorBehavior.Enabled;
                    options.IncludeScopes = true;
                }));
            ILogger programClsLogger = factory.CreateLogger(nameof(Program));
            programClsLogger.LogInformation("main running...");
            */

        }
    }
}
