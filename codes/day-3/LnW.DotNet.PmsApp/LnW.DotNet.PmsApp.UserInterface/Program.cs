using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Manager;
using LnW.DotNet.PmsApp.Repository;
using LnW.DotNet.PmsApp.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LnW.DotNet.PmsApp.UserInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var services = new ServiceCollection();

            services.Configure<FileSetting>(options => options.FilePath = configuration.GetSection("FileSetting:FilePath").Value ?? "");

            services.AddScoped<IStorage<Product>, FileStorage<Product>>();
            services.AddScoped<IStorage<Category>, FileStorage<Category>>();

            services.AddScoped<IRepository<Product, int>, ProductRepository>();
            services.AddScoped<IRepository<Category, int>, CategoryRepository>();

            services.AddScoped<IManager<Product, int>, ProductManager>();
            services.AddScoped<IManager<Category, int>, CategoryManager>();

            IServiceProvider provider = services.BuildServiceProvider();
            IManager<Product, int> productManager = provider.GetRequiredService<IManager<Product, int>>();
            productManager.FetchAll().Result.ToList().ForEach(p => Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}"));
        }
    }
}
