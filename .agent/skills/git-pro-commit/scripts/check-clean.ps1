# PowerShell Script: Kiem tra do sach cua Git truoc khi commit
# Vi tri: .agents/skills/git-pro-commit/scripts/check-clean.ps1

Write-Host "==========================================" -ForegroundColor Cyan
Write-Host "   [GIT CHECK] KIEM TRA DO SACH REPOSITORY " -ForegroundColor Cyan
Write-Host "==========================================" -ForegroundColor Cyan

# 1. Kiem tra git da khoi tao chua
if (-not (Test-Path ".git")) {
    Write-Host "[CANH BAO] Thu muc hien tai chua duoc khoi tao Git repository." -ForegroundColor Yellow
    Write-Host "[GOI Y] Hay chay 'git init' de bat dau quan ly phien ban." -ForegroundColor Gray
    exit 0
}

# 2. Kiem tra cac file rac co dang nam trong git staging khong
$stagedFiles = git diff --name-only --cached
$junkPatterns = @("bin/", "obj/", ".vs/", ".zip", ".rar", ".7z")
$hasJunk = $false

foreach ($file in $stagedFiles) {
    foreach ($pattern in $junkPatterns) {
        if ($file -like "*$pattern*") {
            Write-Host "[LOI] PHAT HIEN FILE RAC TRONG STAGING: $file" -ForegroundColor Red
            $hasJunk = $true
        }
    }
}

if ($hasJunk) {
    Write-Host ""
    Write-Host "[HUONG DAN] Chay lenh sau de bo theo doi file rac:" -ForegroundColor Yellow
    Write-Host "   git rm -r --cached **/bin **/obj **/*.zip" -ForegroundColor White
} else {
    Write-Host "[OK] Khong phat hien file rac trong Staged Area!" -ForegroundColor Green
}

# 3. Hien thi trang thai thay doi hien tai
Write-Host ""
Write-Host "[TRANG THAI] Git status:" -ForegroundColor Cyan
git status -s
