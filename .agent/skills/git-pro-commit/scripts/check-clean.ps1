# PowerShell Script: Kiểm tra độ sạch của Git trước khi commit
# Vị trí: .agents/skills/git-pro-commit/scripts/check-clean.ps1

Write-Host "==========================================" -ForegroundColor Cyan
Write-Host "   🔍 KIỂM TRA ĐỘ SẠCH CỦA KHO GIT        " -ForegroundColor Cyan
Write-Host "==========================================" -ForegroundColor Cyan

# 1. Kiểm tra git đã init chưa
if (-not (Test-Path ".git")) {
    Write-Host "⚠️ Thư mục hiện tại chưa được khởi tạo Git repository." -ForegroundColor Yellow
    Write-Host "💡 Hãy chạy 'git init' nếu bạn muốn bắt đầu quản lý phiên bản." -ForegroundColor Gray
    exit 0
}

# 2. Kiểm tra các file rác có đang nằm trong git staging không
$stagedFiles = git diff --name-only --cached
$junkPatterns = @("bin/", "obj/", ".vs/", ".zip", ".rar", ".7z")
$hasJunk = $false

foreach ($file in $stagedFiles) {
    foreach ($pattern in $junkPatterns) {
        if ($file -like "*$pattern*") {
            Write-Host "❌ PHÁT HIỆN FILE RÁC ĐANG ĐƯỢC STAGE: $file" -ForegroundColor Red
            $hasJunk = $true
        }
    }
}

if ($hasJunk) {
    Write-Host ""
    Write-Host "🛑 Vui lòng chạy lệnh sau để bỏ stage file rác:" -ForegroundColor Yellow
    Write-Host "   git rm -r --cached **/bin **/obj **/*.zip" -ForegroundColor White
} else {
    Write-Host "✅ Không phát hiện file rác trong Staged Area!" -ForegroundColor Green
}

# 3. Hiển thị tóm tắt trạng thái git
Write-Host ""
Write-Host "📋 Trạng thái thay đổi hiện tại:" -ForegroundColor Cyan
git status -s
