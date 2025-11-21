namespace LnW.DotNet.PmsApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        //Navigation property (one to one)
        public Category? Category { get; set; }
    }
}
