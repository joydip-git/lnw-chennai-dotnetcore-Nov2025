namespace SharedResourceAccess
{
    public class Resource
    {
        public static Mutex ValueController = new Mutex();
        public static int Value = 0;
    }
    public class ResourceUser
    {
        public void IncreaseResource()
        {
            Resource.ValueController.WaitOne();
            Console.WriteLine($"IR thread id: {Environment.CurrentManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                Resource.Value++;
                Console.WriteLine("IR increased the value to " + Resource.Value);
                Thread.Sleep(1000);
            }
            Resource.ValueController.ReleaseMutex();
        }
        public void DecreaseResource()
        {
            Resource.ValueController.WaitOne();
            Console.WriteLine($"DR thread id: {Environment.CurrentManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                Resource.Value--;
                Console.WriteLine("DR decreased the value to " + Resource.Value);
                Thread.Sleep(1000);
            }
            Resource.ValueController.ReleaseMutex();
        }
    }
}
