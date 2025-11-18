namespace DelegateImplementation
{
    //delegate bool LogicDel(int a);
    delegate bool LogicDel<in T>(T a);

    internal class Logic
    {
        public static bool IsEven(int number) => number % 2 == 0;
        public bool IsOdd(int number) => number % 2 != 0;
        public bool Contains(string name) => name.ToLower().StartsWith("a");
    }
}
