using LnW.DotNet.PmsApp.Entities;
using LnW.DotNet.PmsApp.Storage;

namespace LnW.DotNet.PmsApp.Repository
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly IStorage storage;
        public CategoryRepository(IStorage storage)
        {
            this.storage = storage;
        }
        private bool Exists(int id)
        {
            return storage.Categories.Any(c => c.Id == id);
        }
        public Category Add(Category entity)
        {
            try
            {
                if (!Exists(entity.Id))
                {
                    storage.Categories.Add(entity);
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

        public Category Delete(int id)
        {
            try
            {
                Category entity = GetById(id);
                bool removed = storage.Categories.Remove(entity);
                return removed ? entity : throw new Exception($"Category with id:{id} could not be removed");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IReadOnlyList<Category> GetAll()
        {
            if (storage.Categories.Count == 0)
            {
                throw new Exception("No categories available");
            }
            else
                return storage.Categories;
        }

        public Category GetById(int id)
        {
            if (Exists(id))
            {
                return storage.Categories.First(c => c.Id == id);
            }
            else
                throw new Exception($"Category with id:{id} does not exist");
        }

        public Category Update(Category entity)
        {
            if (Exists(entity.Id))
            {
                Category found = GetById(entity.Id);
                int index = storage.Categories.IndexOf(found);
                storage.Categories[index] = entity;
                return entity;
            }
            else
                throw new Exception($"Category with id:{entity.Id} does not exist");
        }
    }
}
