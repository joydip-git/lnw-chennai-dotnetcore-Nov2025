namespace SampleApp
{
    public class DbDataManager : IManager
    {
        private readonly IDataProvider _dataProvider;
        
        //DI through constructor
        public DbDataManager(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Console.WriteLine("data manager created");
        }
        public string GetData()
        {
            string data = _dataProvider.FetchData();
            return data;
        }
    }
}
