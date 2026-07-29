using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class Phong25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Phong25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // ===================================================================================
        // 1. TRANG DANH SÁCH PHÒNG
        // GET: Phong25th2532
        // ===================================================================================
        public async Task<IActionResult> Index()
        {
            var phongs = _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation);
            return View(await phongs.ToListAsync());
        }

        // ===================================================================================
        // 2. CHỨC NĂNG XEM CHI TIẾT PHÒNG
        // GET: Phong25th2532/Details/5
        // ===================================================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var phong = await _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.MaPhong == id);

            if (phong == null) return NotFound();

            return View(phong);
        }

        // ===================================================================================
        // 3. CHỨC NĂNG THÊM MỚI PHÒNG
        // GET: Phong25th2532/Create
        // ===================================================================================
        public IActionResult Create()
        {
            ViewData["MaLoaiPhong"] = new SelectList(_context.Loaiphongs, "MaLoaiPhong", "TenLoaiPhong");
            ViewData["MaTrangThai"] = new SelectList(_context.Trangthaiphongs, "MaTrangThai", "TenTrangThai");
            return View();
        }

        // POST: Phong25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhong,SoPhong,MaLoaiPhong,MaTrangThai")] Phong25th2532 phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiPhong"] = new SelectList(_context.Loaiphongs, "MaLoaiPhong", "TenLoaiPhong", phong.MaLoaiPhong);
            ViewData["MaTrangThai"] = new SelectList(_context.Trangthaiphongs, "MaTrangThai", "TenTrangThai", phong.MaTrangThai);
            return View(phong);
        }

        // ===================================================================================
        // 4. CHỨC NĂNG CHỈNH SỬA THÔNG TIN PHÒNG
        // GET: Phong25th2532/Edit/5
        // ===================================================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null) return NotFound();

            ViewData["MaLoaiPhong"] = new SelectList(_context.Loaiphongs, "MaLoaiPhong", "TenLoaiPhong", phong.MaLoaiPhong);
            ViewData["MaTrangThai"] = new SelectList(_context.Trangthaiphongs, "MaTrangThai", "TenTrangThai", phong.MaTrangThai);
            return View(phong);
        }

        // POST: Phong25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhong,SoPhong,MaLoaiPhong,MaTrangThai")] Phong25th2532 phong)
        {
            if (id != phong.MaPhong) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.MaPhong)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiPhong"] = new SelectList(_context.Loaiphongs, "MaLoaiPhong", "TenLoaiPhong", phong.MaLoaiPhong);
            ViewData["MaTrangThai"] = new SelectList(_context.Trangthaiphongs, "MaTrangThai", "TenTrangThai", phong.MaTrangThai);
            return View(phong);
        }

        // ===================================================================================
        // 5. CHỨC NĂNG XÓA PHÒNG
        // GET: Phong25th2532/Delete/5
        // ===================================================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var phong = await _context.Phongs
                .Include(p => p.MaLoaiPhongNavigation)
                .Include(p => p.MaTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.MaPhong == id);

            if (phong == null) return NotFound();

            return View(phong);
        }

        // POST: Phong25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            if (phong != null)
            {
                _context.Phongs.Remove(phong);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Hàm bổ trợ kiểm tra sự tồn tại của phòng
        private bool PhongExists(int id)
        {
            return _context.Phongs.Any(e => e.MaPhong == id);
        }
    }
}
