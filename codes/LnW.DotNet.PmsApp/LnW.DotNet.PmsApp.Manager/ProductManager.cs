using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Repository;
using Microsoft.Extensions.Logging;

namespace LnW.DotNet.PmsApp.Manager
{
    public class ProductManager(IAsyncRepository<Product, int> repository, ILogger<ProductManager> logger) : IAsyncManager<Product, int>
    {

        /*
         * private readonly IAsyncRepository<Product, int> repository;
        private readonly ILogger<ProductManager> logger;

        public ProductManager(IAsyncRepository<Product, int> repository, ILogger<ProductManager> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
         */
        public async Task<IReadOnlyList<Product>> FetchAllAsync()
        {
            try
            {
                return await repository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Product> FetchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> InsertAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> ModifyAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
