namespace SampleApp
{
    public class DataManager : IManager
    {
        private readonly IDataProvider _dataProvider;
        public DataManager(IDataProvider dataProvider)
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
