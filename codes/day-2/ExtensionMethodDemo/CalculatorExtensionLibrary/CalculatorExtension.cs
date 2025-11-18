using CalculationLibrary;

namespace CalculatorExtensionLibrary
{
    public static class CalculatorExtension
    {
        //public static int Multiply(this SimpleCalculator calc, int a, int b)
        //{
        //    return a * b;
        //}
        //public static int Multiply(this ScientificCalculator calc, int a, int b)
        //{
        //    return a * b;
        //}
        public static int Multiply(this ICalculator calc, int a, int b)
        {
            return a * b;
        }
    }
}
