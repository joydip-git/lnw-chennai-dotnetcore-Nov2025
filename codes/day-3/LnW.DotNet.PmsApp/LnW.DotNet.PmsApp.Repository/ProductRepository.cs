using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Storage;

namespace LnW.DotNet.PmsApp.Repository
{
    public class ProductRepository : IRepository<Product, int>
    {
        private readonly IStorage storage;
        public ProductRepository(IStorage storage)
        {
            this.storage = storage;
        }
        private bool Exists(int id)
        {
            return storage.Products.Any(p => p.Id == id);
        }
        public Product Add(Product entity)
        {
            try
            {
                if (!Exists(entity.Id))
                {
                    storage.Products.Add(entity);
                    return entity;
                }
                else
                    throw new Exception($"Product with same id: {entity.Id} already exists");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product Delete(int id)
        {

            try
            {
                Product entity = GetById(id);
                bool removed = storage.Products.Remove(entity);
                return removed ? entity : throw new Exception($"Product with id:{id} could not be removed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IReadOnlyList<Product> GetAll()
        {
            if (storage.Products.Count == 0)
            {
                throw new Exception("No products available");
            }
            else
                return storage.Products;
        }

        public Product GetById(int id)
        {
            if (Exists(id))
            {
                return storage.Products.First(p => p.Id == id);
            }
            else
                throw new Exception($"Product with id:{id} does not exist");
        }

        public Product Update(Product entity)
        {
            if (Exists(entity.Id))
            {
                Product found = GetById(entity.Id);
                int index = storage.Products.IndexOf(found);
                storage.Products[index] = entity;
                return entity;
            }
            else
                throw new Exception($"Product with id:{entity.Id} does not exist");
        }
    }
}
