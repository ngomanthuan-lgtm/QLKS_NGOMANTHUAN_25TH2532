using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class DichVu25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public DichVu25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: DichVu25th2532
        public async Task<IActionResult> Index()
        {
            // Sửa thành Dichvus cho khớp DbContext
            return View(await _context.Dichvus.ToListAsync());
        }

        // GET: DichVu25th2532/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var dichvu = await _context.Dichvus.FirstOrDefaultAsync(m => m.MaDichVu == id);
            if (dichvu == null) return NotFound();
            return View(dichvu);
        }

        // GET: DichVu25th2532/Create
        public IActionResult Create() => View();

        // POST: DichVu25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDichVu,TenDichVu,GiaDichVu")] Dichvu25th2532 dichvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dichvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dichvu);
        }

        // GET: DichVu25th2532/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var dichvu = await _context.Dichvus.FindAsync(id);
            if (dichvu == null) return NotFound();
            return View(dichvu);
        }

        // POST: DichVu25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDichVu,TenDichVu,GiaDichVu")] Dichvu25th2532 dichvu)
        {
            if (id != dichvu.MaDichVu) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Dichvus.Any(e => e.MaDichVu == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dichvu);
        }

        // GET: DichVu25th2532/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var dichvu = await _context.Dichvus.FirstOrDefaultAsync(m => m.MaDichVu == id);
            if (dichvu == null) return NotFound();
            return View(dichvu);
        }

        // POST: DichVu25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dichvu = await _context.Dichvus.FindAsync(id);
            if (dichvu != null) _context.Dichvus.Remove(dichvu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
