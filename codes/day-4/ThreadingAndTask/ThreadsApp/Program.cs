namespace ThreadsApp
{
    internal class Program
    {       
        static void Run()
        {
            Console.WriteLine($"Run w/o args thread running in thread id: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Run w/o args thread: {i}");
                //Thread.Sleep(1000);
            }
        }
        static void Run(object count)
        {
            Console.WriteLine($"Run with args thread running in thread id: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < (int)count; i++)
            {
                Console.WriteLine($"Run with args thread: {i}");
                //Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Main thread running in thread id: {Environment.CurrentManagedThreadId}");
            
            ThreadStart runNoArgsDel = new ThreadStart(Run);
            ParameterizedThreadStart runArgsDel = new ParameterizedThreadStart(Run);

            Thread threadNoArgsRun = new Thread(runNoArgsDel);
            Thread threadArgsRun = new Thread(runArgsDel);

            threadNoArgsRun.Start();
            threadArgsRun.Start(5);

            threadNoArgsRun.Join();
            threadArgsRun.Join();

            //Thread.Sleep(500);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main thread: {i}");
            }
        }
    }
}
