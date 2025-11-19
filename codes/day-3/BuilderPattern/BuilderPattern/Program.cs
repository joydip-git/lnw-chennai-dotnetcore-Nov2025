namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new UserBuilder();
            User user = builder
                .SetName("Alice")
                .SetEmail("alice@gmail.com")
                .SetRole("Administrator")
                .SetAddress("123 Main St, Springfield")
                .Build();
        }
    }
}
