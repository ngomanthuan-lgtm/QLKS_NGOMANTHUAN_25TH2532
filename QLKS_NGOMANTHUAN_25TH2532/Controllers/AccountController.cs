using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class AccountController : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public AccountController(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login() => View();

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string hoten, string manhanvien)
        {
            // Ép kiểu chuỗi nhập vào sang số nguyên để kiểm tra mã nhân viên
            if (!int.TryParse(manhanvien, out int maNV))
            {
                ViewBag.Error = "Mã nhân viên phải là định dạng số!";
                return View();
            }

            // Đăng nhập bằng cách đối chiếu: Họ tên và Mã nhân viên trùng khớp trong DB
            var nhanvien = await _context.Nhanviens
                .FirstOrDefaultAsync(u => u.MaNhanVien == maNV && u.HoTen == hoten);

            if (nhanvien != null)
            {
                // Chuẩn hóa chức vụ trong DB sang phân quyền hệ thống (Admin / Staff)
                // Giả định nếu ChucVu chứa chữ "Quản lý" hoặc "Giám đốc" -> Admin, ngược lại -> Staff
                string role = "Staff";
                if (!string.IsNullOrEmpty(nhanvien.ChucVu) &&
                    (nhanvien.ChucVu.Contains("Quản lý") || nhanvien.ChucVu.Contains("Giám đốc") || nhanvien.ChucVu.ToLower() == "admin"))
                {
                    role = "Admin";
                }

                // Thiết lập danh tính phiên đăng nhập
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, nhanvien.HoTen),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("MaNV", nhanvien.MaNhanVien.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Đăng nhập thành công, điều hướng về trang chủ dự án
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Thông tin Họ tên hoặc Mã nhân viên không chính xác!";
            return View();
        }

        // GET: /Account/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // GET: /Account/AccessDenied
        public IActionResult AccessDenied() => View();
    }
}
