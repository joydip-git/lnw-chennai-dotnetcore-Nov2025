using CalculationLibrary;
using CalculatorExtensionLibrary;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleCalculator calculator = new SimpleCalculator();
            Console.WriteLine(calculator.Add(5, 10));
            Console.WriteLine(calculator.Multiply(5, 10));

            ScientificCalculator sciCalculator = new ScientificCalculator();
            Console.WriteLine(sciCalculator.Subtract(10, 5));
            Console.WriteLine(sciCalculator.Multiply(10, 5));

            List<int> ints = [1, 2, 3, 4, 5];
            ints.Where(i => i % 2 == 0).ToList().ForEach(i => Console.WriteLine(i));
        }
    }
}
