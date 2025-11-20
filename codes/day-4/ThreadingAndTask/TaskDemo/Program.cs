namespace TaskDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<long> sumTask = IsEven();
            //Console.WriteLine(sumTask.Result);
            sumTask
                .ContinueWith((task) => Console.WriteLine(task.Result));
            // sumTask.Wait();
            //if(sumTask.IsCompleted)
            //{
            //    Console.WriteLine(sumTask.Result);
            //}
            DoSomethingElse();
            Thread.Sleep(1000);
        }
        static void DoSomethingElse()
        {
            Console.WriteLine("doing something...");
        }
        //static Task<int> IsEven()
        //{
        //    Task<int> sumTask = Task.Run(() =>
        //    {
        //        int sum = 0;
        //        for (int i = 0; i < 10000000; i++)
        //        {
        //            sum += i;
        //            //Thread.Sleep(100);
        //        }
        //        return sum;
        //    });
        //    return sumTask;
        //    //Task task = Task.Run(() => Console.WriteLine("joydip"));
        //}
        static async Task<long> IsEven()
        {
            long sum = 0;
            for (int i = 0; i < 10000000; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
