namespace LnW.DotNet.PmsApp.Manager
{
    public interface IManager<T,TId> where T : class
    {
        T Insert(T entity);
        T FetchById(TId id);
        IReadOnlyList<T> FetchAll();
        T Modify(T entity);
        T Remove(TId id);
    }
}
