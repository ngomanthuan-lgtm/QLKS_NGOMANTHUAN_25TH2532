using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class Khuyenmais25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Khuyenmais25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: Khuyenmais25th2532
        public async Task<IActionResult> Index()
        {
            // Sửa thành Khuyenmais cho khớp DbContext
            return View(await _context.Khuyenmais.ToListAsync());
        }

        // GET: Khuyenmais25th2532/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var khuyenmai = await _context.Khuyenmais.FirstOrDefaultAsync(m => m.MaKhuyenMai == id);
            if (khuyenmai == null) return NotFound();
            return View(khuyenmai);
        }

        // GET: Khuyenmais25th2532/Create
        public IActionResult Create() => View();

        // POST: Khuyenmais25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhuyenMai,TenKhuyenMai,NgayBatDau,NgayKetThuc")] Khuyenmai25th2532 khuyenmai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khuyenmai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khuyenmai);
        }

        // GET: Khuyenmais25th2532/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var khuyenmai = await _context.Khuyenmais.FindAsync(id);
            if (khuyenmai == null) return NotFound();
            return View(khuyenmai);
        }

        // POST: Khuyenmais25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKhuyenMai,TenKhuyenMai,NgayBatDau,NgayKetThuc")] Khuyenmai25th2532 khuyenmai)
        {
            if (id != khuyenmai.MaKhuyenMai) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenmai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Khuyenmais.Any(e => e.MaKhuyenMai == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khuyenmai);
        }

        // GET: Khuyenmais25th2532/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var khuyenmai = await _context.Khuyenmais.FirstOrDefaultAsync(m => m.MaKhuyenMai == id);
            if (khuyenmai == null) return NotFound();
            return View(khuyenmai);
        }

        // POST: Khuyenmais25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khuyenmai = await _context.Khuyenmais.FindAsync(id);
            if (khuyenmai != null) _context.Khuyenmais.Remove(khuyenmai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
