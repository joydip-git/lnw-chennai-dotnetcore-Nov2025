namespace GenericWithDI
{
    public interface IRepository<T, TId>
    {
        T Add(T item);
        T Get(TId id);
        List<T> GetAll();
        T Update(T item);
        T Delete(TId id);
    }
}
