namespace SampleApp
{
    public class FileDataManager : IManager
    {
        private readonly IDataProvider _dataProvider;
        //DI through constructor
        public FileDataManager(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Console.WriteLine("file data manager created");
        }

        //DI through properties
        //private IDataProvider _dataProvider;
        //public IDataProvider DataProvider
        //{
        //    get { return _dataProvider; }
        //    set { _dataProvider = value; }
        //}

        public string GetData()
        {
            return _dataProvider.FetchData();
        }
    }
}
