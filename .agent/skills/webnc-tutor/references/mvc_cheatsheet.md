# 📖 ASP.NET Core MVC Cheatsheet — Môn Web Nâng Cao

Tài liệu tra cứu nhanh các thành phần cốt lõi trong ASP.NET Core MVC dành cho sinh viên.

---

## 1. 🏷️ Data Annotations (Kiểm Tra Dữ Liệu Model)

Khai báo trong namespace `System.ComponentModel.DataAnnotations`:

```csharp
public class UserRegistrationModel
{
    [Required(ErrorMessage = "Tên không được để trống")]
    [Display(Name = "Họ và tên")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email bắt buộc")]
    [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [Range(18, 65, ErrorMessage = "Độ tuổi phải từ {1} đến {2}")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Tối thiểu 8 ký tự, gồm cả chữ và số")]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}
```

---

## 2. 🎛️ Quản Lý Trạng Thái (State Management)

| Đối Tượng | Phạm Vi Sống (Scope) | Dùng Khi Nào? | Ví Dụ |
| :--- | :--- | :--- | :--- |
| **ViewData** | Chỉ trong Request hiện tại (Controller ➔ View). Kiểu dữ liệu Dictionary (`object`). | Truyền dữ liệu đơn giản khi không muốn tạo ViewModel. | `ViewData["Title"] = "Trang Chủ";` |
| **ViewBag** | Tương tự `ViewData` nhưng dùng cú pháp `dynamic`. | Truyền nhanh dữ liệu phụ (danh sách danh mục, message). | `ViewBag.Message = "Thành công";` |
| **TempData** | Tồn tại qua **1 lần Redirect** tiếp theo (dựa trên Cookie/Session). | Hiển thị thông báo sau khi Redirect (Flash message: Thêm mới thành công, Xóa thành công). | `TempData["Alert"] = "Đã lưu thành công!"; return RedirectToAction("Index");` |
| **Session** | Toàn bộ phiên làm việc của người dùng (lưu trên Server/Cache). | Lưu giỏ hàng (Cart), thông tin User đăng nhập đơn giản. | `HttpContext.Session.SetString("User", username);` |
| **Cookie** | Lưu trữ trên trình duyệt Client (có thời hạn). | Ghi nhớ đăng nhập ("Remember Me"), tùy chọn ngôn ngữ/giao diện. | `Response.Cookies.Append("Theme", "dark");` |

---

## 3. 🎯 Tag Helpers Trong Razor View

Khai báo `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers` trong `_ViewImports.cshtml`:

### Form & Input
```cshtml
<!-- Tạo form submit về action Create của ProductController -->
<form asp-controller="Product" asp-action="Create" method="post">
    <!-- Input liên kết chặt chẽ với thuộc tính Price của Model -->
    <label asp-for="Price" class="form-label"></label>
    <input asp-for="Price" class="form-control" />
    <span asp-validation-for="Price" class="text-danger"></span>

    <!-- Dropdown list từ danh sách SelectList -->
    <select asp-for="CategoryId" asp-items="ViewBag.Categories" class="form-select">
        <option value="">-- Chọn danh mục --</option>
    </select>
</form>
```

### Links & Buttons
```cshtml
<!-- Sinh URL: /Product/Details/12 -->
<a asp-controller="Product" asp-action="Details" asp-route-id="@item.Id" class="btn btn-info">Chi tiết</a>

<!-- Sinh URL: /Product/Edit?id=12&category=phones -->
<a asp-action="Edit" asp-route-id="@item.Id" asp-route-category="phones">Sửa</a>
```

---

## 4. 💉 Vòng Đời Dependency Injection (Service Lifetimes)

Cấu hình trong `Program.cs`:

```csharp
// 1. Transient: Tạo instance mới MỖI LẦN được yêu cầu (nhẹ, không lưu state)
builder.Services.AddTransient<IEmailSender, EmailSender>();

// 2. Scoped: Tạo 1 instance DUY NHẤT cho mỗi HTTP Request (thường dùng cho DbContext, Repository)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Singleton: Tạo 1 instance DUY NHẤT trong suốt vòng đời ứng dụng
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
```

---

## 5. 🗄️ Entity Framework Core (Thao Tác Dữ Liệu Bất Đồng Bộ)

```csharp
// Lấy danh sách kèm phân trang
public async Task<List<Product>> GetProductsAsync(int pageIndex, int pageSize)
{
    return await _context.Products
        .Include(p => p.Category)      // Eager loading nạp bảng liên kết
        .Where(p => p.IsActive)        // Lọc dữ liệu
        .OrderByDescending(p => p.Id)  // Sắp xếp
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();                // Chạy bất đồng bộ
}

// Thêm mới dữ liệu
public async Task CreateProductAsync(Product product)
{
    _context.Products.Add(product);
    await _context.SaveChangesAsync();
}
```
