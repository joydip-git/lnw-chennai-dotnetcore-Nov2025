namespace LnW.DotNet.PmsApp.UserInterface
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            /*
         
            //code without Host service

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

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

            IServiceProvider provider = services.BuildServiceProvider();

            IManager<Product, int> productManager = provider.GetRequiredService<IManager<Product, int>>();

            var products = await productManager.FetchAll()
            products
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}"));
            */
        }


    }
}
