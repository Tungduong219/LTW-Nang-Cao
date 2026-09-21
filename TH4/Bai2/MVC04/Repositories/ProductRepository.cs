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
            return _context.tblProducts.OrderBy(p => p.ProductID).ToList();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.tblProducts.Find(id);
            if (product != null)
            {
                _context.tblProducts.Remove(product);
                _context.SaveChanges();
            }
        }

        public void SeedData()
        {
            if (!_context.tblProducts.Any())
            {
                var sampleProducts = new List<Product>
                {
                    new Product { ProductName = "Sản phẩm A", ProductPrice = 100000, ImageURL = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm A" },
                    new Product { ProductName = "Sản phẩm B", ProductPrice = 200000, ImageURL = "https://images.unsplash.com/photo-1546868871-7041f2a55e12?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm B" },
                    new Product { ProductName = "Sản phẩm C", ProductPrice = 300000, ImageURL = "https://images.unsplash.com/photo-1585386959984-a4155224a1ad?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm C" },
                    new Product { ProductName = "Sản phẩm D", ProductPrice = 400000, ImageURL = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm D" },
                    new Product { ProductName = "Sản phẩm E", ProductPrice = 500000, ImageURL = "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm E" },
                    new Product { ProductName = "Sản phẩm F", ProductPrice = 600000, ImageURL = "https://images.unsplash.com/photo-1572635196237-14b3f281503f?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm F" },
                    new Product { ProductName = "Sản phẩm G", ProductPrice = 700000, ImageURL = "https://images.unsplash.com/photo-1560343090-f0409e92791a?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm G" },
                    new Product { ProductName = "Sản phẩm H", ProductPrice = 800000, ImageURL = "https://images.unsplash.com/photo-1583394838336-acd977736f90?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm H" },
                    new Product { ProductName = "Sản phẩm I", ProductPrice = 900000, ImageURL = "https://images.unsplash.com/photo-1507764923504-cd90bf7da772?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm I" },
                    new Product { ProductName = "Sản phẩm J", ProductPrice = 1000000, ImageURL = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=200&auto=format&fit=crop&q=80.png", Description = "Mô tả sản phẩm J" }
                };

                _context.tblProducts.AddRange(sampleProducts);
                _context.SaveChanges();
            }
        }
    }
}
