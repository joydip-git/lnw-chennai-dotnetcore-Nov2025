namespace SharedResourceAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ResourceUser user = new();

            Thread increaseThread = new Thread(user.IncreaseResource);
            Thread decreaseThread = new Thread(user.DecreaseResource);

            increaseThread.Start();
            decreaseThread.Start();
        }
    }
}
