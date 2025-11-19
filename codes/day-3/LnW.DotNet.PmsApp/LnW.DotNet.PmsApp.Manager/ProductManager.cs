using LnW.DotNet.PmsApp.Entities;

namespace LnW.DotNet.PmsApp.Manager
{
    public class ProductManager : IManager<Product, int>
    {
        public IReadOnlyList<Product> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Product FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Modify(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
