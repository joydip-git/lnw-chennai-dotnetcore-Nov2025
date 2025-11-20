using LnW.DotNet.PmsApp.Entities;

namespace LnW.DotNet.PmsApp.Manager
{
    public class CategoryManager : IManager<Category, int>
    {
        public Task<IReadOnlyList<Category>> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Modify(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
