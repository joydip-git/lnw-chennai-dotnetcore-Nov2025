namespace DelegateImplementation
{
    internal class Program
    {
        static List<int> Filter(List<int> input)
        {
            List<int> result = [];
            foreach (var item in input)
            {
                if (item % 2 == 0)
                    result.Add(item);
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> numbers = [1, 3, 2, 5, 4, 8, 6, 0, 7, 9];
            List<int> evenNumbers = Filter(numbers);
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
