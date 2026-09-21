using Microsoft.AspNetCore.Mvc;
using MVC04.Models;
using MVC04.Repositories;

namespace MVC04.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductModel _productModel;

        public ProductController(IProductRepository productRepository, ProductModel productModel)
        {
            _productRepository = productRepository;
            _productModel = productModel;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            _productRepository.SeedData();
            var products = _productModel.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            var product = _productModel.GetProducts().FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound("Không tìm thấy sản phẩm.");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _productModel.GetProducts().FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                TempData["CartMessage"] = $"Đã thêm \"{product.ProductName}\" vào giỏ hàng!";
            }
            return RedirectToAction(nameof(ProductList));
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
