using System.Text.Json;

namespace ReadingDataFromFileApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main Thread: {Environment.CurrentManagedThreadId}");
            try
            {
                List<Person>? people = await ReadPersonDataAsync();
                people?.ForEach(p => Console.WriteLine(p));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static async Task<List<Person>?> ReadPersonDataAsync()
        {
            Console.WriteLine($"Read Thread: {Environment.CurrentManagedThreadId}");
            try
            {
                Stream stream = File.OpenRead("data.json");
                JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
                List<Person>? people = await JsonSerializer.DeserializeAsync<List<Person>>(stream, options);
                return people;
            }
            catch (Exception)
            {
                throw;
            }

            //Task<string> task = File.ReadAllTextAsync("data.json");
            //task.Wait();
            //string result = task.Result;
            //JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            //List<Person>? people = JsonSerializer.Deserialize<List<Person>>(result, options);
            //people?.ForEach(person => Console.WriteLine(person));

            //Stream stream = File.OpenRead("data.json");
            //JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            //ValueTask<List<Person>?> peopleTask = JsonSerializer.DeserializeAsync<List<Person>>(stream, options);
            //var people =  peopleTask.Result;
            //people?.ForEach(person => Console.WriteLine(person));
        }
    }
}
