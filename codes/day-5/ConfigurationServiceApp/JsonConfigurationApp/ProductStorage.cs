using Microsoft.Extensions.Options;

namespace JsonConfigurationApp
{
    public class ProductStorage : IStorage<Product>
    {
        private readonly string productFilePath;
        public ProductStorage(IOptions<FileSetting> options)
        {
            productFilePath = options.Value.FilePath;
            
        }
        public async Task<List<Product>> GetDataAsync()
        {
            Console.WriteLine("path: " + productFilePath == string.Empty ? "NA" : productFilePath);
            return [new Product()];
        }
    }
}
