using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;

namespace JsonConfigurationApp
{
    public class DatabaseSetting
    {
        public string? Server { get; set; }
        public string? DbName { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
    }
    public class FileSetting
    {
        public string? FilePath { get; set; }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false, true);

            IConfigurationRoot config = builder.Build();
            IConfigurationSection section = config.GetRequiredSection("filePath");
            Console.WriteLine(section.Value);

            Console.WriteLine(config["databaseSetting:server"]);

            DatabaseSetting? setting = config.GetRequiredSection("databaseSetting").Get<DatabaseSetting>();
            Console.WriteLine(setting?.DbName + " " + setting?.UserId);


            IServiceCollection registry = new ServiceCollection();

            registry.Configure<FileSetting>(
                (options) => config.GetRequiredSection("fileSetting").Bind(options)
                );

            registry.AddScoped<IStorage<Product>, ProductStorage>();
            IServiceProvider provider = registry.BuildServiceProvider();
            IStorage<Product> storage = provider.GetRequiredService<IStorage<Product>>();
            Console.WriteLine(await storage.GetDataAsync());
        }
    }
}
