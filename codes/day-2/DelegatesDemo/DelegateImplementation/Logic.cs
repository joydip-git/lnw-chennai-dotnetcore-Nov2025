namespace DelegateImplementation
{
    internal class Logic
    {
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}
