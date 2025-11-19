namespace LnW.DotNet.PmsApp.Repository
{
    public interface IRepository<T, TId> where T : class
    {
        T Add(T entity);
        T GetById(TId id);
        IReadOnlyList<T> GetAll();
        T Update(T entity);
        T Delete(TId id);
    }
}
