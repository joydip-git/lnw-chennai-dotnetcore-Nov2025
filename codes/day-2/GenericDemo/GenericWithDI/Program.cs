using Microsoft.Extensions.DependencyInjection;

namespace GenericWithDI
{
    class Logic
    {
        public bool IsEven(int number) => number % 2 == 0;
        public bool IsOdd(int number) => number % 2 != 0;
        public bool IsGreater(int number) => number > 4;
    }
    internal class Program
    {
        static List<int> Filter(List<int> input)
        {
            List<int> output = [];
            foreach (var item in input)
            {
                if (item % 2 == 0)
                    output.Add(item);
            }
            return output;
        }
        static void Main(string[] args)
        {
            //Collection initializer example
            //List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
            List<int> intList = [1, 2, 3, 4, 5];
            List<int> result = Filter(intList);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IRepository<Product, int>, ProductRepository>();
            services.AddScoped<IRepository<Customer, int>, CustomerRepository>();

            IServiceProvider provider = services.BuildServiceProvider();
            IRepository<Product, int> productRepo = provider.GetRequiredService<IRepository<Product, int>>();
            Console.WriteLine(productRepo.Get(1));



        }
    }
}
