namespace LnW.DotNet.PmsApp.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Navigation property (one-to-many)
        public List<Product> Products { get; set; } = [];
    }
}
