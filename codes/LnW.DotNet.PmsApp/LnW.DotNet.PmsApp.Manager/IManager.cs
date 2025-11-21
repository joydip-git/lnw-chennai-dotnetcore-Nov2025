namespace LnW.DotNet.PmsApp.Manager
{
    public interface IManager<T,TId> where T : class
    {
        Task<T> Insert(T entity);
        Task<T> FetchById(TId id);
        Task<IReadOnlyList<T>> FetchAll();
        Task<T> Modify(T entity);
        Task<T> Remove(TId id);
    }
}
