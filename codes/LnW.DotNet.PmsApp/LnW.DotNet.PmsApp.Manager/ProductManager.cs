using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Repository;

namespace LnW.DotNet.PmsApp.Manager
{
    public class ProductManager : IManager<Product, int>
    {
        private readonly IRepository<Product, int> repository;
        public ProductManager(IRepository<Product, int> repository)
        {
            this.repository = repository;
        }
        public async Task<IReadOnlyList<Product>> FetchAll()
        {
            try
            {
                return await repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Product> FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Modify(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
