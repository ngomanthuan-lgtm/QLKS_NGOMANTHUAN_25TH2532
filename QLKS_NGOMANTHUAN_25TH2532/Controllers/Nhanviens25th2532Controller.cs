using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    public class Nhanviens25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Nhanviens25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: Nhanviens25th2532
        public async Task<IActionResult> Index()
        {
            // Sửa thành Nhanviens cho khớp DbContext
            return View(await _context.Nhanviens.ToListAsync());
        }

        // GET: Nhanviens25th2532/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var nhanvien = await _context.Nhanviens.FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanvien == null) return NotFound();
            return View(nhanvien);
        }

        // GET: Nhanviens25th2532/Create
        public IActionResult Create() => View();

        // POST: Nhanviens25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,HoTen,ChucVu,Luong")] Nhanvien25th2532 nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        // GET: Nhanviens25th2532/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null) return NotFound();
            return View(nhanvien);
        }

        // POST: Nhanviens25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNhanVien,HoTen,ChucVu,Luong")] Nhanvien25th2532 nhanvien)
        {
            if (id != nhanvien.MaNhanVien) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Nhanviens.Any(e => e.MaNhanVien == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        // GET: Nhanviens25th2532/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var nhanvien = await _context.Nhanviens.FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanvien == null) return NotFound();
            return View(nhanvien);
        }

        // POST: Nhanviens25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null) _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
