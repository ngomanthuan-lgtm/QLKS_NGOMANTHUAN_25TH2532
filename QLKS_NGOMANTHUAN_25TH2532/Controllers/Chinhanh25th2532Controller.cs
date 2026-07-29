using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class Chinhanh25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Chinhanh25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: Chinhanh25th2532
        public async Task<IActionResult> Index()
        {
            // Sửa từ Chinhanh25th2532s thành Chinhanhs cho khớp DbContext
            return View(await _context.Chinhanhs.ToListAsync());
        }

        // GET: Chinhanh25th2532/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var chinhanh = await _context.Chinhanhs.FirstOrDefaultAsync(m => m.MaChiNhanh == id);
            if (chinhanh == null) return NotFound();
            return View(chinhanh);
        }

        // GET: Chinhanh25th2532/Create
        public IActionResult Create() => View();

        // POST: Chinhanh25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChiNhanh,TenChiNhanh,DiaChi,SoDienThoai")] Chinhanh25th2532 chinhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chinhanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chinhanh);
        }

        // GET: Chinhanh25th2532/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var chinhanh = await _context.Chinhanhs.FindAsync(id);
            if (chinhanh == null) return NotFound();
            return View(chinhanh);
        }

        // POST: Chinhanh25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaChiNhanh,TenChiNhanh,DiaChi,SoDienThoai")] Chinhanh25th2532 chinhanh)
        {
            if (id != chinhanh.MaChiNhanh) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chinhanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Chinhanhs.Any(e => e.MaChiNhanh == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chinhanh);
        }

        // GET: Chinhanh25th2532/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var chinhanh = await _context.Chinhanhs.FirstOrDefaultAsync(m => m.MaChiNhanh == id);
            if (chinhanh == null) return NotFound();
            return View(chinhanh);
        }

        // POST: Chinhanh25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chinhanh = await _context.Chinhanhs.FindAsync(id);
            if (chinhanh != null) _context.Chinhanhs.Remove(chinhanh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
