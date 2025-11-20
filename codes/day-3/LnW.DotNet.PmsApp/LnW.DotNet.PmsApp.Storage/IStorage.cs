
namespace LnW.DotNet.PmsApp.Storage
{
    public interface IStorage<T> where T : class
    {
        Task<List<T>> LoadDataAsync();
        Task WriteDataAsync(IEnumerable<T> data);
    }
}