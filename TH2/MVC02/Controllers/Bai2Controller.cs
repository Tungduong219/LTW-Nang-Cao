using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MVC02.Controllers
{
    public class Bai2Controller : Controller
    {
        // ==================== BÀI 2.1 ====================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Receive(string username, string password, string email)
        {
            // Kiểm tra điều kiện server-side:
            // (1) username không rỗng
            bool isUsernameValid = !string.IsNullOrWhiteSpace(username);

            // (2) password có từ 8 ký tự, chứa ít nhất 1 chữ số
            bool isPasswordValid = !string.IsNullOrEmpty(password) 
                                   && password.Length >= 8 
                                   && password.Any(char.IsDigit);

            // (3) email đúng định dạng
            bool isEmailValid = !string.IsNullOrEmpty(email) 
                                && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (isUsernameValid && isPasswordValid && isEmailValid)
            {
                ViewBag.Success = true;
                ViewBag.Message = $"Xin chào {username}, Bạn đã đăng ký thành công";
            }
            else
            {
                ViewBag.Success = false;
                ViewBag.Message = "Đăng ký thất bại! Dữ liệu không hợp lệ.";
            }

            return View();
        }
    }
}
