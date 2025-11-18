
namespace GenericWithDI
{
    public class ProductRepository : IRepository<Product, int>
    {
        public ProductRepository()
        {
            Console.WriteLine("product repo created");
        }
        public Product Add(Product item)
        {
            return item;
        }

        public Product Delete(int id)
        {
            return new Product();
        }

        public Product Get(int id)
        {
            //Product p = new Product();
            //p.Id = 1;
            //p.Name = "Sample Product";
            //p.Price = 1000m;

            //object initialization syntax
            //Product p = new Product { Id = 1, Price = 1000m, Name = "Sample" };

            Product p = new() { Id = 1, Price = 1000m, Name = "Sample" };
            return p;
        }

        public List<Product> GetAll()
        {
            return new List<Product>();
        }

        public Product Update(Product item)
        {
            return new Product();
        }
    }
}
