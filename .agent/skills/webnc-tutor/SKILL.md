---
name: webnc-tutor
description: >-
  Hướng dẫn, giải thích kiến thức, đồng hành làm bài tập thực hành (TH), lab, bài tập lớn và dự án môn Lập trình Web Nâng cao (ASP.NET Core MVC, C#, Entity Framework Core, RESTful API, Razor, SQL Server). Kích hoạt khi người dùng hỏi về kiến thức môn học, nhờ giải bài tập, debug code ASP.NET Core, hoặc cần hướng dẫn triển khai tính năng web.
---

# 🎓 WebNC Tutor — Gia Sư Đồng Hành Môn Lập Trình Web Nâng Cao

Skill này hướng dẫn Agent cách đồng hành, giải thích kiến thức và hỗ trợ người dùng thực hiện các bài tập thực hành (Lab/TH), bài tập nhóm và dự án trong môn **Lập trình Web Nâng cao** (trọng tâm là ASP.NET Core MVC & Entity Framework Core).

---

## 🧭 Nguyên Tắc Sư Phạm & Phương Pháp Làm Việc

1. **Giải thích bản chất (The "Why" Behind The Code):**
   - Không đưa ra một khối code lớn mà không giải thích.
   - Luôn làm rõ luồng dữ liệu: `User Interaction` ➔ `HTTP Request` ➔ `ASP.NET Middleware Pipeline` ➔ `Routing` ➔ `Controller Action` ➔ `Business / Model` ➔ `Razor View Engine` ➔ `HTML Response`.
2. **Tuân thủ mô hình MVC chuẩn:**
   - **Model:** Chứa thực thể dữ liệu (Entity) và `ViewModel` (dành riêng cho giao diện, tích hợp Data Annotations).
   - **View:** Chỉ hiển thị giao diện và nhận dữ liệu, sử dụng Tag Helpers (`asp-for`, `asp-action`, `asp-validation-for`). Hạn chế viết logic C# phức tạp trong View.
   - **Controller:** Đóng vai trò điều phối, nhận request, gọi service/xử lý, trả về View hoặc JSON.
3. **Phòng ngừa lỗi ngay từ đầu:**
   - Luôn kiểm tra tính hợp lệ của dữ liệu: `ModelState.IsValid` ở Server-side.
   - Kèm theo validation Client-side (`jquery.validate.unobtrusive` hoặc HTML5).
   - Nhắc nhở bảo mật: Chống CSRF (`[ValidateAntiForgeryToken]`), phòng chống SQL Injection (dùng LINQ/EF Core có tham số hóa).

---

## 📋 Quy Trình Hướng Dẫn Giải Một Bài Tập / Lab (TH)

Khi người dùng gửi đề bài hoặc yêu cầu làm một tính năng:

### Bước 1: Phân Tích Đề Bài (Requirement Breakdown)
- Xác định rõ:
  - **Input:** Dữ liệu người dùng nhập hoặc tham số trên URL (Route Data, Query String, Form Body).
  - **Processing:** Logic xử lý (Validate dữ liệu, tính toán thuật toán, truy vấn database qua EF Core).
  - **Output:** Dữ liệu trả về (View hiển thị kết quả, redirect sang trang khác, hoặc JSON response cho AJAX).

### Bước 2: Thiết Kế Model & ViewModel
- Tạo `ViewModel` phù hợp cho form/trang:
  ```csharp
  public class RegisterViewModel
  {
      [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
      [StringLength(50, MinimumLength = 3)]
      public string Username { get; set; } = string.Empty;

      [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
      [DataType(DataType.Password)]
      [RegularExpression(@"^(?=.*[0-9]).{8,}$", ErrorMessage = "Mật khẩu tối thiểu 8 ký tự và chứa ít nhất 1 chữ số")]
      public string Password { get; set; } = string.Empty;

      [Required(ErrorMessage = "Vui lòng nhập email")]
      [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
      public string Email { get; set; } = string.Empty;
  }
  ```

### Bước 3: Triển Khai Controller Action
- Tách bạch rõ 2 hành động:
  - `[HttpGet]`: Khởi tạo và trả về View ban đầu.
  - `[HttpPost]`: Nhận dữ liệu từ form, kiểm tra `ModelState.IsValid`, xử lý logic và trả về kết quả.
  ```csharp
  [HttpGet]
  public IActionResult Register()
  {
      return View(new RegisterViewModel());
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Register(RegisterViewModel model)
  {
      if (!ModelState.IsValid)
      {
          return View(model); // Trả lại form kèm thông báo lỗi
      }

      // Xử lý lưu database hoặc logic nghiệp vụ
      TempData["SuccessMessage"] = $"Đăng ký thành công tài khoản {model.Username}!";
      return RedirectToAction(nameof(RegisterSuccess));
  }
  ```

### Bước 4: Xây Dựng Razor View Với Tag Helpers
- Sử dụng Tag Helpers chuẩn thay vì HTML Helpers truyền thống:
  ```cshtml
  @model RegisterViewModel

  <form asp-action="Register" method="post">
      @Html.AntiForgeryToken()

      <div class="mb-3">
          <label asp-for="Username" class="form-label">Tên đăng nhập</label>
          <input asp-for="Username" class="form-control" />
          <span asp-validation-for="Username" class="text-danger"></span>
      </div>

      <!-- Các trường khác tương tự -->

      <button type="submit" class="btn btn-primary">Đăng Ký</button>
  </form>

  @section Scripts {
      @{ await Html.RenderPartialAsync("_ValidationScriptsPartial"); }
  }
  ```

---

## 🛠️ Runbook Debug Các Lỗi Thường Gặp Trong WebNC

| Hiện Tượng / Mã Lỗi | Nguyên Nhân Gốc Rễ | Cách Khắc Phục |
| :--- | :--- | :--- |
| **HTTP 404 Not Found** | Sai Route, tên Controller/Action không khớp, hoặc thiếu cấu hình MapControllerRoute trong `Program.cs`. | Kiểm tra route pattern: `{controller=Home}/{action=Index}/{id?}`. Kiểm tra tiền tố của Controller (ví dụ `Bai2Controller` thì URL là `/Bai2/...`). |
| **NullReferenceException** | Model truyền sang View bị `null`, hoặc ViewBag/ViewData gọi đến key chưa được gán. | Luôn khởi tạo model rỗng `new MyViewModel()` ở action `[HttpGet]`. Dùng toán tử null-conditional `?.` hoặc null-coalescing `??`. |
| **ModelState luôn IsValid = false** | Thuộc tính kiểu Non-nullable reference types (`string` không có `?`) bị rỗng. | Đổi thành `string?` hoặc gắn giá trị mặc định `= string.Empty;` hoặc điều chỉnh thuộc tính `<Nullable>enable</Nullable>`. |
| **Lỗi EF Core Migration / Database** | Chưa chạy `Add-Migration` / `Update-Database`, hoặc chuỗi kết nối (`ConnectionString`) trong `appsettings.json` bị sai. | Kiểm tra `DefaultConnection` trong `appsettings.json`, kiểm tra service SQL Server / LocalDB có đang chạy không. |
| **Form submit nhưng dữ liệu = null** | Tên thuộc tính trong Model không khớp với thuộc tính `name` trong thẻ `<input>` (hoặc thiếu `asp-for`). | Dùng Tag Helper `asp-for="PropertyName"` để ASP.NET Core tự sinh `name` và `id` khớp 100% với Model. |

---

## 📚 Tài Liệu Tham Khảo Nhanh

Xem chi tiết bảng tổng hợp cú pháp, Tag Helpers, Data Annotations, và Dependency Injection tại:
- [ASP.NET Core MVC Cheatsheet](./references/mvc_cheatsheet.md)
