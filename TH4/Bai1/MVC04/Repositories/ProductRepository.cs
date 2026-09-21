using MVC04.Data;
using MVC04.Models;

namespace MVC04.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool IsProductNameExists(string productName)
        {
            return _context.tblProducts.Any(p => p.ProductName.ToLower() == productName.Trim().ToLower());
        }

        public void AddProduct(Product product)
        {
            _context.tblProducts.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.tblProducts.ToList();
        }
    }
}
