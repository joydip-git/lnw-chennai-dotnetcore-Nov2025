namespace SampleApp
{
    public class FileDataProvider : IDataProvider
    {
        public FileDataProvider()
        {
            Console.WriteLine("file data provider created");
        }
        public string FetchData()
        {
            return "Data from File";
        }
    }
}
