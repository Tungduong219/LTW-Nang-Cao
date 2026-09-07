---
name: git-pro-commit
description: >-
  Quy trình commit và push mã nguồn lên GitHub một cách chuyên nghiệp theo chuẩn Conventional Commits. Hướng dẫn staging sạch (loại bỏ bin/obj/cache), chia nhỏ commit nguyên tử (atomic commits), đặt commit message chuẩn quốc tế, và push an toàn. Kích hoạt khi người dùng muốn commit, push code lên GitHub, hoặc quản lý git trong môn học.
---

# 🐙 Git Pro Commit — Quy Trình Commit GitHub Chuyên Nghiệp

Skill này hướng dẫn Agent và lập trình viên cách quản lý kho mã nguồn, stage file sạch sẽ và commit lên GitHub theo chuẩn công nghiệp **Conventional Commits 1.0.0**, đặc biệt tối ưu cho các bài tập thực hành môn học.

---

## ⚡ 5 Bước Thực Hiện Quy Trình Commit Chuyên Nghiệp

Khi người dùng yêu cầu: *"Commit code bài này lên GitHub"*, *"Lưu thay đổi vào git"*... hãy tuân thủ nghiêm ngặt 5 bước:

### Bước 1: Kiểm Tra Trạng Thái & File Thay Đổi (Inspect Status)
Chạy lệnh kiểm tra:
```powershell
git status
```
- Xem danh sách các file đang ở `Untracked` hoặc `Modified`.
- **CẢNH BÁO ĐỎ:** Nếu thấy xuất hiện các thư mục `bin/`, `obj/`, `.vs/`, hoặc file nén `.zip`, **DỪNG LẠI NGAY LẬP TỨC**. Đảm bảo file `.gitignore` đã có và chạy:
  ```powershell
  # Xóa cache git nếu lỡ add file rác từ trước
  git rm -r --cached **/bin **/obj **/*.zip
  ```

### Bước 2: Kiểm Chứng Biên Dịch (Build Verification)
Trước khi commit bất kỳ dòng code nào, phải đảm bảo code không làm gãy dự án:
```powershell
dotnet build
```
- Nếu có lỗi biên dịch (Compile Error), phải sửa dứt điểm trước khi commit. Không bao giờ commit code lỗi lên GitHub.

### Bước 3: Đưa File Vào Hàng Đợi Một Cách Chọn Lọc (Clean & Atomic Staging)
- **Tuyệt đối không dùng bừa bãi `git add .`** khi chưa rà soát danh sách file.
- Hãy chỉ stage các file thuộc về **cùng một tính năng hoặc một bài tập** (Atomic Commit):
  ```powershell
  # Ví dụ chỉ stage code của Bài 2 trong TH2:
  git add TH2/MVC02/Controllers/Bai2Controller.cs TH2/MVC02/Views/Bai2/
  ```

### Bước 4: Soạn Thảo Commit Message Chuẩn Conventional Commits
Cấu trúc chuẩn:
```text
<type>(<scope>): <tiêu đề ngắn gọn ở thể mệnh lệnh, không viết hoa chữ đầu, không chấm cuối>

[Thân commit (Body) nếu cần: Giải thích TẠI SAO và ĐÃ LÀM GÌ]

[Chân commit (Footer) nếu có liên kết Issue/Task]
```

#### Bảng Tra Cứu `<type>`:
| Type | Ý Nghĩa | Ví Dụ |
| :--- | :--- | :--- |
| `feat` | Tính năng mới hoặc hoàn thành 1 bài tập mới | `feat(th2/bai2): implement random numbers generator` |
| `fix` | Sửa lỗi logic, lỗi validate, lỗi routing | `fix(th2/bai2): validate upper bound greater than lower bound` |
| `docs` | Thêm tài liệu, hướng dẫn, README, ghi chú | `docs(readme): update assignment submission requirements` |
| `style` | Sửa format code, thụt lề, khoảng trắng | `style(controllers): format code style in Bai2Controller` |
| `refactor`| Tái cấu trúc code (tách hàm, tối ưu) mà không đổi tính năng | `refactor(th2): extract validation logic into separate helper` |
| `test` | Thêm unit test hoặc test cases | `test(bai2): add test cases for registration form validation` |
| `chore` | Cấu hình repo, thêm .gitignore, cập nhật package | `chore(repo): add standard .gitignore for dotnet projects` |

#### Quy Ước `<scope>` Cho Môn Học:
- Tên bài thực hành: `th1`, `th2`, `th2/bai1`, `th2/bai2`, `th3`...
- Tên project: `mvc01`, `mvc02`, `mvc03`...
- Tên module: `auth`, `cart`, `database`, `api`...

### Bước 5: Thực Hiện Commit & Push An Toàn
1. Commit với message đã soạn:
   ```powershell
   git commit -m "feat(th2/bai2): implement form validation and random number action"
   ```
2. Kiểm tra lại lịch sử commit vừa tạo:
   ```powershell
   git log -1 --stat
   ```
3. Push lên repository từ xa (Remote Repo):
   ```powershell
   git push origin main
   ```

---

## 🛑 Những Điều Tuyệt Đối Tránh (Anti-Patterns)

- ❌ Commit message vô nghĩa: `"update"`, `"fix bug"`, `"done"`, `"a"`, `"commit lan 1"`.
- ❌ Commit "khổng lồ" (Mega-commit): Gom toàn bộ 5 bài lab khác nhau vào đúng 1 commit duy nhất.
- ❌ Đẩy mã nhạy cảm: Password database, Secret keys, API tokens trong `appsettings.json`.
- ❌ Đẩy file nhị phân: Thư mục `bin/`, `obj/`, file `.dll`, `.exe`, `.pdb`, `.zip`.

---

## 📚 Tài Liệu Tham Khảo Nhanh

- Xem chi tiết danh sách ví dụ mẫu chuẩn Conventional Commits tại:
  [Conventional Commits Guide](./references/conventional_commits.md)
