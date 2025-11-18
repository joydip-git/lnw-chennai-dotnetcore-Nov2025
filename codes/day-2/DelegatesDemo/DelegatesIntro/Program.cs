using System.Reflection;

namespace DelegatesIntro
{
    //1. Define a delegate type
    delegate void MathDel(int a, int b);

    /*
    class MathDel:MulticastDelegate:Delegate:Object
    {
        private MethodInfo method;
        private Object? target;

        public MathDel(Object? target, MethodInfo method)
        {
            this.target = target;
            this.method = method;
        }

        public MethodInfo Method 
        { get => method; set => method = value; }
        public object? Target 
        { get => target; set => target = value; }

        public void Invoke(int a, int b)
        {
            method.Invoke(target, new Object?[] { a, b });
        }
    }
    */
    class MathOperations
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine($"Sum: {a + b}");
        }
        public void Subtract(int a, int b)
        {
            Console.WriteLine($"Difference: {a - b}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //2. Instantiate the delegate
            //MathDel addDel = new MathDel(MathOperations.Add);
            MathDel addDel = MathOperations.Add; // Simplified instantiation

            MathOperations ops = new();
            MathDel subDel = ops.Subtract;

            InvokeDelegate(addDel, 5, 10);
            InvokeDelegate(subDel, 10, 5);

        }
        static void InvokeDelegate(MathDel del, int x, int y)
        {
            //3. Invoke the delegate
            //del(x, y);
            del.Invoke(x, y);
        }
    }
}
