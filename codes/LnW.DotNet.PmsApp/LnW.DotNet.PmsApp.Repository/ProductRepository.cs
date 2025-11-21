using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Storage;
using Microsoft.Extensions.Logging;

namespace LnW.DotNet.PmsApp.Repository
{
    public class ProductRepository(IStorage<Product> storage, ILogger<ProductRepository> _logger) : IAsyncRepository<Product, int>
    {      

        /*
         * private readonly IStorage<Product> storage;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IStorage<Product> storage,ILogger<ProductRepository> _logger)
        {
            this.storage = storage;
            this._logger = _logger;
        }
         */

        private async Task<bool> ExistsAsync(int id)
        {
            var products = await storage.LoadDataAsync();
            return products.Any(p => p.Id == id);
        }
        public async Task<Product> AddAsync(Product entity)
        {
            try
            {
                if (!await ExistsAsync(entity.Id))
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

        public async Task<Product> DeleteAsync(int id)
        {

            try
            {
                Product entity = await GetByIdAsync(id);
                var products = await storage.LoadDataAsync();
                bool removed = products.Remove(entity);
                return removed ? entity : throw new Exception($"Product with id:{id} could not be removed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var products = await storage.LoadDataAsync();
            if (products.Count == 0)
            {
                throw new Exception("No products available");
            }
            else
                return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (await ExistsAsync(id))
            {
                var products = await storage.LoadDataAsync();
                return products.First(p => p.Id == id);
            }
            else
                throw new Exception($"Product with id:{id} does not exist");
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            if (await ExistsAsync(entity.Id))
            {
                Product found = await GetByIdAsync(entity.Id);
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
