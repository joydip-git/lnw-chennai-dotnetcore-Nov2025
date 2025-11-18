namespace DelegateImplementation
{
    internal class Program
    {
        //static List<int> Filter(List<int> input, LogicDel logicDel)
        //{
        //    List<int> result = [];
        //    foreach (var item in input)
        //    {
        //        bool isTrue = logicDel(item);
        //        if (isTrue)
        //            result.Add(item);
        //    }
        //    return result;
        //}

        //static List<int> Filter(List<int> input, LogicDel logicDel)
        //static List<int> Filter(List<int> input, LogicDel<int> logicDel)
        //{
        //    List<int> result = [];
        //    foreach (var item in input)
        //    {
        //        bool isTrue = logicDel(item);
        //        if (isTrue)
        //            result.Add(item);
        //    }
        //    return result;
        //}
        static List<T> Filter<T>(List<T> input, LogicDel<T> logicDel)
        {
            List<T> result = [];
            foreach (T item in input)
            {
                bool isTrue = logicDel(item);
                if (isTrue)
                    result.Add(item);
            }
            return result;
        }
        static void Main(string[] args)
        {
            //source of data
            List<int> numbers = [1, 3, 2, 5, 4, 8, 6, 0, 7, 9];

            //logic to filter even numbers
            //LogicDel evenDel = Logic.IsEven;
            LogicDel<int> evenDel = Logic.IsEven;

            List<int> evenNumbers = Filter(numbers, evenDel);
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n");

            //logic to filter odd numbers
            Logic logic = new();
            //LogicDel oddDel = logic.IsOdd;
            LogicDel<int> oddDel = logic.IsOdd;

            List<int> oddNumbers = Filter(numbers, oddDel);
            foreach (var item in oddNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
