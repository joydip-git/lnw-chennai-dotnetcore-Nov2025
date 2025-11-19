using LnW.DotNet.PmsApp.Entities;

namespace LnW.DotNet.PmsApp.Storage
{
    public interface IStorage
    {
        List<Category> Categories { get; }
        List<Product> Products { get; }
    }
}