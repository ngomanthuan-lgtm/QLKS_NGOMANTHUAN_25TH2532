using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình dịch vụ kết nối Database SQL Server (Thủ công)
builder.Services.AddDbContext<QlksNgomanthuan25th2532Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Thêm các dịch vụ hỗ trợ kiến trúc MVC (Controllers với Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Cấu hình đường ống xử lý HTTP Request (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // HSTS bảo mật cho môi trường Production
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4. Cấu hình Định tuyến đường dẫn mặc định (Route) của ứng dụng
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Tự động chạy vào trang danh sách phòng khi mở web

app.Run();
