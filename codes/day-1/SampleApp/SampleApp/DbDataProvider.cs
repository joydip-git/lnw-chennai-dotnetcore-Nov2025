namespace SampleApp
{
    public class DbDataProvider : IDataProvider
    {
        public DbDataProvider()
        {
            Console.WriteLine("database data provider created");
        }
        public string FetchData()
        {
            return "Data from Database";
        }
    }
}
