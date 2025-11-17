using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    internal class Program
    {
        private static IKeyedServiceProvider ConfigureServices()
        {
            IServiceCollection registry = new ServiceCollection();
            IKeyedServiceProvider provider = registry
                .AddKeyedSingleton<IManager, DbDataManager>("dbmanager")
                .AddKeyedSingleton<IManager, FileDataManager>("filemanager")
            .BuildServiceProvider();
            return provider;
        }
        static void Main(string[] args)
        {
            IKeyedServiceProvider provider = ConfigureServices();
            Console.WriteLine("1. data from db \n2. Data from file  ");
            Console.Write("enter choice[1/2]: ");
            int choice = int.Parse(Console.ReadLine() ?? "");
            IManager? manager = null;
            switch (choice)
            {
                case 1:
                    manager =
     provider.GetRequiredKeyedService<IManager>("dbmanager");
                    break;

                case 2:
                    manager = provider.GetRequiredKeyedService<IManager>("filemanager");
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
