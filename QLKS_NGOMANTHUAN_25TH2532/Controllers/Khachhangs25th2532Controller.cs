using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class Khachhangs25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Khachhangs25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: Khachhangs25th2532
        public async Task<IActionResult> Index()
        {
            // Sửa thành Khachhangs cho khớp DbContext
            return View(await _context.Khachhangs.ToListAsync());
        }

        // GET: Khachhangs25th2532/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var khachhang = await _context.Khachhangs.FirstOrDefaultAsync(m => m.MaKhachHang == id);
            if (khachhang == null) return NotFound();
            return View(khachhang);
        }

        // GET: Khachhangs25th2532/Create
        public IActionResult Create() => View();

        // POST: Khachhangs25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhachHang,HoTen,SoDienThoai,Email,SoCCCD")] Khachhang25th2532 khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: Khachhangs25th2532/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null) return NotFound();
            return View(khachhang);
        }

        // POST: Khachhangs25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKhachHang,HoTen,SoDienThoai,Email,SoCCCD")] Khachhang25th2532 khachhang)
        {
            if (id != khachhang.MaKhachHang) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Khachhangs.Any(e => e.MaKhachHang == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: Khachhangs25th2532/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var khachhang = await _context.Khachhangs.FirstOrDefaultAsync(m => m.MaKhachHang == id);
            if (khachhang == null) return NotFound();
            return View(khachhang);
        }

        // POST: Khachhangs25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang != null) _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
