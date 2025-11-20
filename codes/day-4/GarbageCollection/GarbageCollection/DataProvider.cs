using System.IO;
using System.Text;

namespace GarbageCollection
{
    public class DataProvider : IDisposable
    {
        private StreamReader? _reader;

        ~DataProvider()
        {
            Console.WriteLine($"destructor being called on thread no: {Environment.CurrentManagedThreadId}...all system resources will be released...");
            if (_reader != null)
            {
                _reader.Close();
                _reader.Dispose();
            }
        }

        public void Dispose()
        {
            Console.WriteLine($"dispose being called on thread no: {Environment.CurrentManagedThreadId}...all system resources will be released...");
            if (_reader != null)
            {
                _reader.Close();
                _reader.Dispose();
            }
            GC.SuppressFinalize(this);            
        }

        public string GetData()
        {
            _reader = new StreamReader("data.txt");
            StringBuilder data = new StringBuilder();
            while (!_reader.EndOfStream)
            {
                string? line = _reader.ReadLine();
                data.AppendLine(line);
            }
            return data.ToString();
        }
    }
}
