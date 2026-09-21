using MVC04.Data;

namespace MVC04.Models
{
    public class ProductModel
    {
        private readonly AppDbContext _context;

        public ProductModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.tblProducts.OrderBy(p => p.ProductID).ToList();
        }
    }
}
