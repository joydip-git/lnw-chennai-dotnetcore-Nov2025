namespace LnW.DotNet.PmsApp.Repository
{
    public interface IAsyncRepository<T, TId> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(TId id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(TId id);
    }
}
