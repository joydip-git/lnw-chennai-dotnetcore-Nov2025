using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IServiceCollection container = new ServiceCollection();
            IServiceProvider provider =
                container
                .AddSingleton<IDataProvider, DbDataProvider>()
                .AddSingleton<IManager, DataManager>()
                .BuildServiceProvider();
            IManager manager = provider.GetRequiredService<IManager>();
            //IManager manager = new DataManager();
            Console.WriteLine(manager.GetData());
        }
    }
}
