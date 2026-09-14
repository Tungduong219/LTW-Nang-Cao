namespace MVC031.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
