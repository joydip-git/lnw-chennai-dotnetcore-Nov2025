namespace LnW.DotNet.PmsApp.Manager
{
    public interface IAsyncManager<T,TId> where T : class
    {
        Task<T> InsertAsync(T entity);
        Task<T> FetchByIdAsync(TId id);
        Task<IReadOnlyList<T>> FetchAllAsync();
        Task<T> ModifyAsync(T entity);
        Task<T> RemoveAsync(TId id);
    }
}
