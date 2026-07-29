using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKS_NGOMANTHUAN_25TH2532.Models;

namespace QLKS_NGOMANTHUAN_25TH2532.Controllers
{
    // Đã đổi tên class thành Phuthu25th2532Controller để nhận đường dẫn /Phuthu25th2532
    public class Phuthu25th2532Controller : Controller
    {
        private readonly QlksNgomanthuan25th2532Context _context;

        public Phuthu25th2532Controller(QlksNgomanthuan25th2532Context context)
        {
            _context = context;
        }

        // GET: Phuthu25th2532
        public async Task<IActionResult> Index()
        {
            // Kết nối chính xác tới tập hợp Phuthus định nghĩa trong DbContext của bạn
            return View(await _context.Phuthus.ToListAsync());
        }

        // GET: Phuthu25th2532/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var phuthu = await _context.Phuthus
                .FirstOrDefaultAsync(m => m.MaPhuThu == id);

            if (phuthu == null) return NotFound();

            return View(phuthu);
        }

        // GET: Phuthu25th2532/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phuthu25th2532/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhuThu,LyDoPhuThu,SoTienPhuThu")] Phuthu25th2532 phuthu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuthu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuthu);
        }

        // GET: Phuthu25th2532/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var phuthu = await _context.Phuthus.FindAsync(id);
            if (phuthu == null) return NotFound();

            return View(phuthu);
        }

        // POST: Phuthu25th2532/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhuThu,LyDoPhuThu,SoTienPhuThu")] Phuthu25th2532 phuthu)
        {
            if (id != phuthu.MaPhuThu) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuthu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuthuExists(phuthu.MaPhuThu)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phuthu);
        }

        // GET: Phuthu25th2532/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var phuthu = await _context.Phuthus
                .FirstOrDefaultAsync(m => m.MaPhuThu == id);

            if (phuthu == null) return NotFound();

            return View(phuthu);
        }

        // POST: Phuthu25th2532/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuthu = await _context.Phuthus.FindAsync(id);
            if (phuthu != null)
            {
                _context.Phuthus.Remove(phuthu);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuthuExists(int id)
        {
            return _context.Phuthus.Any(e => e.MaPhuThu == id);
        }
    }
}
