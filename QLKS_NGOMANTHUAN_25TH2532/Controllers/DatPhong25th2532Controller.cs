using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class DatPhong25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public DatPhong25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // ===================================================================================
        // 1. TRANG DANH SÁCH ĐẶT PHÒNG
        // GET: DatPhong25th2532
        // ===================================================================================
        public async Task<IActionResult> Index()
        {
            var datphongs = _context.Datphongs.Include(d => d.MaPhongNavigation);
            return View(await datphongs.ToListAsync());
        }

        // ===================================================================================
        // 2. CHỨC NĂNG THÊM MỚI PHIẾU ĐẶT PHÒNG
        // GET: DatPhong25th2532/Create
        // ===================================================================================
        public IActionResult Create()
        {
            var dynamicPhongList = _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation)
                .Select(p => new
                {
                    MaPhong = p.MaPhong,
                    DisplayInfo = $"Phòng {p.SoPhong} - {p.MaLoaiPhongNavigation.TenLoaiPhong} [{p.MaTrangThaiNavigation.TenTrangThai}]"
                }).ToList();

            ViewData["MaPhongList"] = new SelectList(dynamicPhongList, "MaPhong", "DisplayInfo");
            return View();
        }

        // POST: DatPhong25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDatPhong,NgayDat,TinhTrangDat,HoTenNguoiDat,NgaySinh,DiaChi,SoDienThoai,Email,TienDatCoc,MaPhong")] Datphong25th2532 datphong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datphong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var dynamicPhongList = _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation)
                .Select(p => new {
                    MaPhong = p.MaPhong,
                    DisplayInfo = $"Phòng {p.SoPhong} - {p.MaLoaiPhongNavigation.TenLoaiPhong} [{p.MaTrangThaiNavigation.TenTrangThai}]"
                }).ToList();
            ViewData["MaPhongList"] = new SelectList(dynamicPhongList, "MaPhong", "DisplayInfo", datphong.MaPhong);
            return View(datphong);
        }

        // ===================================================================================
        // 3. CHỨC NĂNG XEM CHI TIẾT
        // GET: DatPhong25th2532/Details/5
        // ===================================================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var datphong = await _context.Datphongs
                .Include(d => d.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaDatPhong == id);

            if (datphong == null) return NotFound();

            return View(datphong);
        }

        // ===================================================================================
        // 4. CHỨC NĂNG SỬA THÔNG TIN
        // GET: DatPhong25th2532/Edit/5
        // ===================================================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var datphong = await _context.Datphongs.FindAsync(id);
            if (datphong == null) return NotFound();

            var dynamicPhongList = _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation)
                .Select(p => new {
                    MaPhong = p.MaPhong,
                    DisplayInfo = $"Phòng {p.SoPhong} - {p.MaLoaiPhongNavigation.TenLoaiPhong} [{p.MaTrangThaiNavigation.TenTrangThai}]"
                }).ToList();

            ViewData["MaPhongList"] = new SelectList(dynamicPhongList, "MaPhong", "DisplayInfo", datphong.MaPhong);
            return View(datphong);
        }

        // POST: DatPhong25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDatPhong,NgayDat,TinhTrangDat,HoTenNguoiDat,NgaySinh,DiaChi,SoDienThoai,Email,TienDatCoc,MaPhong")] Datphong25th2532 datphong)
        {
            if (id != datphong.MaDatPhong) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datphong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatphongExists(datphong.MaDatPhong)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            var dynamicPhongList = _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation)
                .Select(p => new {
                    MaPhong = p.MaPhong,
                    DisplayInfo = $"Phòng {p.SoPhong} - {p.MaLoaiPhongNavigation.TenLoaiPhong} [{p.MaTrangThaiNavigation.TenTrangThai}]"
                }).ToList();
            ViewData["MaPhongList"] = new SelectList(dynamicPhongList, "MaPhong", "DisplayInfo", datphong.MaPhong);
            return View(datphong);
        }

        // ===================================================================================
        // 5. CHỨC NĂNG XÓA PHIẾU ĐẶT PHÒNG
        // GET: DatPhong25th2532/Delete/5
        // ===================================================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var datphong = await _context.Datphongs
                .Include(d => d.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaDatPhong == id);

            if (datphong == null) return NotFound();

            return View(datphong);
        }

        // POST: DatPhong25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datphong = await _context.Datphongs.FindAsync(id);
            if (datphong != null)
            {
                _context.Datphongs.Remove(datphong);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Hàm bổ trợ kiểm tra sự tồn tại trong Cơ sở dữ liệu
        private bool DatphongExists(int id)
        {
            return _context.Datphongs.Any(e => e.MaDatPhong == id);
        }
    }
}
