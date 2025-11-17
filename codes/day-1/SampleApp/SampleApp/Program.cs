using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    internal class Program
    {
        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection registry = new ServiceCollection();
            IServiceProvider provider = registry
            .AddSingleton<IDataProvider, DbDataProvider>()
            .AddSingleton<IDataProvider, FileDataProvider>()
            .AddSingleton<IManager, DbDataManager>()
            .AddSingleton<IManager, FileDataManager>()
            .BuildServiceProvider();
            return provider;
        }
        static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureServices();
            Console.WriteLine("1. data from file \n2. Data from database  ");
            Console.Write("enter choice[1/2]: ");
            int choice = int.Parse(Console.ReadLine() ?? "");
            IManager? manager = null;
            switch (choice)
            {
                case 1:
                    manager = provider.GetRequiredService<FileDataManager>();
                    break;

                case 2:
                    manager = provider.GetService<DbDataManager>();
                    break;

                default:
                    break;
            }
            if (manager != null)
            {
                string data = manager.GetData();
                Console.WriteLine(data);
            }
        }
    }
}
