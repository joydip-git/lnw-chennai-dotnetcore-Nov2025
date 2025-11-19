using LnW.DotNet.PmsApp.Entities;

namespace LnW.DotNet.PmsApp.Storage
{
    public class InMemoryStorage : IStorage
    {
        private static readonly List<Product> products = [];
        private static readonly List<Category> categories = [];

        public List<Product> Products => products;
        public List<Category> Categories => categories;
    }
}
