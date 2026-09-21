using MVC04.Models;

namespace MVC04.Repositories
{
    public interface IProductRepository
    {
        bool IsProductNameExists(string productName);
        void AddProduct(Product product);
        List<Product> GetAllProducts();
    }
}
