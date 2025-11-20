using System.Diagnostics;

namespace GarbageCollection
{
    internal class Program
    {
        static void Swap(out int a)
        {
            a = 6;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread No: " + Environment.CurrentManagedThreadId);
            int x;
            Swap(out x);
            Console.WriteLine(x);
            string data = UseDataProvider();
            Console.WriteLine(data);
            //WeakReference<DataProvider> providerRef = UseDataProvider();            
            //Console.WriteLine(GC.GetGeneration(providerRef));
            //GC.Collect();
            //Console.WriteLine(GC.GetGeneration(providerRef));
            //GC.Collect();
            //Console.WriteLine(GC.GetGeneration(providerRef));

            //DataProvider? provider;
            //bool doesExist = providerRef.TryGetTarget(out provider);
            //if (doesExist)
            //{
            //    Console.WriteLine(provider?.GetData());
            //}

            GC.Collect();
            //Console.WriteLine(GC.GetGeneration(providerRef));
            GC.Collect();
            //Console.WriteLine(GC.GetGeneration(providerRef));
            GC.Collect();
            //Console.WriteLine(GC.GetGeneration(providerRef));
        }
        //static WeakReference<DataProvider> UseDataProvider()
        //{
        //    DataProvider provider = new DataProvider();
        //    string data = provider.GetData();
        //    Console.WriteLine(data);
        //    return new WeakReference<DataProvider>(provider);
        //}
        static string UseDataProvider()
        {
            string data = string.Empty;
            using (DataProvider provider = new DataProvider())
            {
                data = provider.GetData();
            }
            //using DataProvider provider = new DataProvider();
            //data = provider.GetData();

            return data;
        }
    }
}
