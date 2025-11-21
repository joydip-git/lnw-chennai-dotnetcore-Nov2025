namespace HostingApp
{
    public interface IStorage<T> where T : class
    {
        Task<List<T>> GetDataAsync();
    }
}
