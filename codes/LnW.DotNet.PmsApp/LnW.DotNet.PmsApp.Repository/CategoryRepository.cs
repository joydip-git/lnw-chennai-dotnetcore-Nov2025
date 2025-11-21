using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Storage;

namespace LnW.DotNet.PmsApp.Repository
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly IStorage<Category> storage;

        public CategoryRepository(IStorage<Category> storage)
        {
            this.storage = storage;
        }
        private async Task<bool> Exists(int id)
        {
            var categories = await storage.LoadDataAsync();
            return categories.Any(c => c.Id == id);
        }
        public async Task<Category> Add(Category entity)
        {
            try
            {
                if (!await Exists(entity.Id))
                {
                    (await storage.LoadDataAsync()).Add(entity);
                    return entity;
                }
                else
                    throw new Exception($"Category with same id: {entity.Id} already exists");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Category> Delete(int id)
        {
            try
            {
                Category entity = await GetById(id);
                var categories = await storage.LoadDataAsync();
                bool removed = categories.Remove(entity);
                return removed ? entity : throw new Exception($"Category with id:{id} could not be removed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IReadOnlyList<Category>> GetAll()
        {
            var categories = await storage.LoadDataAsync();
            if (categories.Count == 0)
            {
                throw new Exception("No categories available");
            }
            else
                return categories;
        }

        public async Task<Category> GetById(int id)
        {
            if (await Exists(id))
            {
                var categories = await storage.LoadDataAsync();
                return categories.First(c => c.Id == id);
            }
            else
                throw new Exception($"Category with id:{id} does not exist");
        }

        public async Task<Category> Update(Category entity)
        {
            if (await Exists(entity.Id))
            {
                Category found = await GetById(entity.Id);
                var categories = await storage.LoadDataAsync();
                int index = categories.IndexOf(found);
                categories[index] = entity;
                return entity;
            }
            else
                throw new Exception($"Category with id:{entity.Id} does not exist");
        }
    }
}
