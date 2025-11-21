using LnW.DotNet.PmsApp.Entities;

namespace LnW.DotNet.PmsApp.Manager
{
    public class CategoryManager : IAsyncManager<Category, int>
    {
        public Task<IReadOnlyList<Category>> FetchAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> FetchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> InsertAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> ModifyAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
