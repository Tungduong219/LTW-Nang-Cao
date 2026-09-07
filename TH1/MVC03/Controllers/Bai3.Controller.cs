using Microsoft.AspNetCore.Mvc;

namespace MVC03.Controllers
{
    public class Bai3Controller : Controller
    {
        public string Multiply(int a, int b)
        {
            return $"Tích của {a} và {b} là: {a * b}";
        }

        [HttpGet]
        public IActionResult Add(int? a, int? b)
        {
            if (a.HasValue && b.HasValue)
            {
                ViewBag.A = a.Value;
                ViewBag.B = b.Value;
                ViewBag.Result = a.Value + b.Value;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Add(int a, int b)
        {
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.Result = a + b;
            return View();
        }
    }
}