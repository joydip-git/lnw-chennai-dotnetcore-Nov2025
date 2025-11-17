using MessengerLibrary;

namespace MessengerClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Messenger messenger = new Messenger();
            string message = messenger.GetMessage("Joydip");
            Console.WriteLine(message);
            Console.WriteLine("press any button to terminate the app: ");
            Console.ReadKey();
        }
    }
}
