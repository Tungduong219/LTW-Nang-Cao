using Microsoft.AspNetCore.Mvc;
using MVC04.Models;
using MVC04.Repositories;

namespace MVC04.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult ProductMgr()
        {
            _productRepository.SeedData();
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            TempData["SuccessMessage"] = "Đã xóa mặt hàng thành công!";
            return RedirectToAction(nameof(ProductMgr));
        }

        [HttpGet]
        public IActionResult NewProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewProduct(Product product)
        {
            if (_productRepository.IsProductNameExists(product.ProductName))
            {
                ModelState.AddModelError("ProductName", "Tên mặt hàng đã tồn tại trong cơ sở dữ liệu.");
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productRepository.AddProduct(product);

            ViewBag.Success = $"Thêm mới mặt hàng \"{product.ProductName}\" thành công!";
            ModelState.Clear();

            return View(new Product());
        }
    }
}
