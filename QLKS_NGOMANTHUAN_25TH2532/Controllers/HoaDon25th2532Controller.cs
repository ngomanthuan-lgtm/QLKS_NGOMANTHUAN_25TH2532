using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class Hoadon25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Hoadon25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // ===================================================================================
        // 1. TRANG DANH SÁCH HÓA ĐƠN
        // GET: Hoadon25th2532
        // ===================================================================================
        public async Task<IActionResult> Index()
        {
            var hoadons = _context.Hoadons
                .Include(h => h.MaChiTietDatNavigation);
            return View(await hoadons.ToListAsync());
        }

        // ===================================================================================
        // 2. CHỨC NĂNG XEM CHI TIẾT HÓA ĐƠN (ĐÃ FIX LỖI SQL)
        // GET: Hoadon25th2532/Details/5
        // ===================================================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var hoadon = await _context.Hoadons
                .Include(h => h.MaChiTietDatNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);

            if (hoadon == null) return NotFound();

            return View(hoadon);
        }

        // ===================================================================================
        // 3. CHỨC NĂNG TẠO MỚI HÓA ĐƠN
        // GET: Hoadon25th2532/Create
        // ===================================================================================
        public IActionResult Create()
        {
            ViewData["MaChiTietDat"] = new SelectList(_context.ChitietDatphongs, "MaChiTietDat", "MaChiTietDat");
            return View();
        }

        // POST: Hoadon25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDon,NgayLap,TongTienPhong,TongTienDichVu,ThanhTien,MaChiTietDat")] Hoadon25th2532 hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChiTietDat"] = new SelectList(_context.ChitietDatphongs, "MaChiTietDat", "MaChiTietDat", hoadon.MaChiTietDat);
            return View(hoadon);
        }

        // ===================================================================================
        // 4. CHỨC NĂNG SỬA THÔNG TIN HÓA ĐƠN
        // GET: Hoadon25th2532/Edit/5
        // ===================================================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon == null) return NotFound();

            ViewData["MaChiTietDat"] = new SelectList(_context.ChitietDatphongs, "MaChiTietDat", "MaChiTietDat", hoadon.MaChiTietDat);
            return View(hoadon);
        }

        // POST: Hoadon25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHoaDon,NgayLap,TongTienPhong,TongTienDichVu,ThanhTien,MaChiTietDat")] Hoadon25th2532 hoadon)
        {
            if (id != hoadon.MaHoaDon) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.MaHoaDon)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChiTietDat"] = new SelectList(_context.ChitietDatphongs, "MaChiTietDat", "MaChiTietDat", hoadon.MaChiTietDat);
            return View(hoadon);
        }

        // ===================================================================================
        // 5. CHỨC NĂNG XÓA HÓA ĐƠN
        // GET: Hoadon25th2532/Delete/5
        // ===================================================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hoadon = await _context.Hoadons
                .Include(h => h.MaChiTietDatNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);

            if (hoadon == null) return NotFound();

            return View(hoadon);
        }

        // POST: Hoadon25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon != null)
            {
                _context.Hoadons.Remove(hoadon);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Hàm bổ trợ kiểm tra sự tồn tại của hóa đơn
        private bool HoadonExists(int id)
        {
            return _context.Hoadons.Any(e => e.MaHoaDon == id);
        }
    }
}
