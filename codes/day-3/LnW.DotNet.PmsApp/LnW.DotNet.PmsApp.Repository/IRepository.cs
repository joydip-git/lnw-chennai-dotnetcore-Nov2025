namespace LnW.DotNet.PmsApp.Repository
{
    public interface IRepository<T, TId> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(TId id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Update(T entity);
        Task<T> Delete(TId id);
    }
}
