using Microsoft.AspNetCore.Mvc;
using MVC031.Models;

namespace MVC031.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductModel _productModel = new ProductModel();

        // 1. Action hiển thị danh sách sản phẩm theo dạng lưới (Hình 1)
        [HttpGet]
        public IActionResult ProductList()
        {
            List<Product> products = _productModel.GetProducts();
            return View(products);
        }

        // 2. Action hiển thị chi tiết một mặt hàng khi được click
        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            Product? product = _productModel.GetProducts().FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm có mã này.");
            }
            return View(product);
        }

        // 3. Action phụ xử lý khi bấm nút "Add To Cart"
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            Product? product = _productModel.GetProducts().FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                TempData["CartMessage"] = $"Đã thêm \"{product.ProductName}\" vào giỏ hàng thành công!";
            }
            return RedirectToAction(nameof(ProductList));
        }
    }
}
