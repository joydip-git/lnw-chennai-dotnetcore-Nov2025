namespace DIWithReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceRegistry registry = new ServiceRegistry();
            IProvider provider = registry
                .Add<ICalculations, Calculator>()
                .Build();

            ICalculations calculations = provider.GetService<ICalculations>();
            Console.WriteLine(calculations.Add(10, 20));
        }
    }
}
