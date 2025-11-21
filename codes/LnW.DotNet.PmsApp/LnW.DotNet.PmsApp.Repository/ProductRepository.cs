using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Storage;

namespace LnW.DotNet.PmsApp.Repository
{
    public class ProductRepository : IRepository<Product, int>
    {
        private readonly IStorage<Product> storage;
        public ProductRepository(IStorage<Product> storage)
        {
            this.storage = storage;
        }
        private async Task<bool> Exists(int id)
        {
            var products = await storage.LoadDataAsync();
            return products.Any(p => p.Id == id);
        }
        public async Task<Product> Add(Product entity)
        {
            try
            {
                if (!await Exists(entity.Id))
                {
                    var products = await storage.LoadDataAsync();
                    products.Add(entity);
                    await storage.WriteDataAsync(products);
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

        public async Task<Product> Delete(int id)
        {

            try
            {
                Product entity = await GetById(id);
                var products = await storage.LoadDataAsync();
                bool removed = products.Remove(entity);
                return removed ? entity : throw new Exception($"Product with id:{id} could not be removed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAll()
        {
            var products = await storage.LoadDataAsync();
            if (products.Count == 0)
            {
                throw new Exception("No products available");
            }
            else
                return products;
        }

        public async Task<Product> GetById(int id)
        {
            if (await Exists(id))
            {
                var products = await storage.LoadDataAsync();
                return products.First(p => p.Id == id);
            }
            else
                throw new Exception($"Product with id:{id} does not exist");
        }

        public async Task<Product> Update(Product entity)
        {
            if (await Exists(entity.Id))
            {
                Product found = await GetById(entity.Id);
                var products = await storage.LoadDataAsync();
                int index = products.IndexOf(found);
                products[index] = entity;
                return entity;
            }
            else
                throw new Exception($"Product with id:{entity.Id} does not exist");
        }
    }
}
