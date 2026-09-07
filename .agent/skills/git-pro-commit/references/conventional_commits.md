# 📝 Hướng Dẫn Chi Tiết & Mẫu Conventional Commits

Tài liệu cung cấp các mẫu commit messages thực tế cho môn **Lập trình Web Nâng cao**.

---

## 1. 🎯 Mẫu Commit Chuẩn Cho Từng Bài Thực Hành (Labs)

### Thực Hành 1 (Làm Quen & Cấu Hình)
```text
feat(th1): setup ASP.NET Core MVC project structure and basic routes
docs(th1): add installation and running notes in README
chore(th1): configure launchSettings and default port
```

### Thực Hành 2 (Controller, Action & Form Validation)
```text
feat(th2/bai1): add basic controller and action returning simple view
feat(th2/bai2): implement user registration form with server-side validation
feat(th2/bai2): add random number generator with boundary checks
fix(th2/bai2): fix regex pattern for email validation in Receive action
refactor(th2/bai2): use ViewModel with Data Annotations instead of parameter binding
```

### Thực Hành 3 & Các Bài Tiếp Theo (Razor, Layouts, Database)
```text
feat(th3/layout): create shared layout with responsive navigation bar
feat(th3/views): implement strongly-typed views for product listing
feat(th4/efcore): configure DbContext and initial entity migrations
feat(th4/crud): implement full CRUD operations for Categories
fix(th4/efcore): resolve circular reference in JSON serialization
```

---

## 2. 🧱 Cấu Trúc Commit Message Đầy Đủ (Full Format)

Khi hoàn thành một tính năng phức tạp hoặc tái cấu trúc lớn:

```text
feat(th2/bai2): add user registration with server-side validation

- Validate non-empty username
- Enforce password policy: minimum 8 characters with at least one digit
- Validate email format using standard regular expression
- Return detailed error and success alerts in Razor View
```

---

## 3. 🔍 Lệnh Git Hữu Ích Cần Nhớ

```powershell
# Xem trạng thái ngắn gọn
git status -s

# Xem chi tiết những dòng đã thay đổi trước khi stage
git diff

# Xem những thay đổi đã stage chuẩn bị commit
git diff --staged

# Xem 5 commit gần nhất định dạng đẹp
git log -n 5 --oneline --graph --decorate

# Hủy stage 1 file nếu lỡ add nhầm
git restore --staged <file_name>

# Bỏ thay đổi chưa stage của 1 file (quay về trạng thái commit gần nhất)
git restore <file_name>
```
