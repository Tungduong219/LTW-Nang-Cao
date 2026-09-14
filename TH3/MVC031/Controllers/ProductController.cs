using Microsoft.AspNetCore.Mvc;
using MVC031.Models;

namespace MVC031.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductModel _productModel = new ProductModel();

        // 1. Action hiển thị danh sách sản phẩm
        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productModel.GetProducts();
            return View(products);
        }

        // 2. Action hiển thị chi tiết về 1 mặt hàng khi được click
        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            var product = _productModel.GetProducts().FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm có mã ID: " + id);
            }

            return View(product);
        }
    }
}
