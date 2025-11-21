using Microsoft.Extensions.Configuration;

namespace ConfigurationServiceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            var settings = new Dictionary<string, string?>()
            {
                ["key1"]="value1",
                ["key2"] = "value2"
            };
            builder.AddInMemoryCollection(settings);
            var config = builder.Build();

            Console.WriteLine(config["key1"]);            
        }
    }
}
