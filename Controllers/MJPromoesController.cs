using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerMVC2_MJ.Models;

namespace TallerMVC2_MJ.Controllers
{
    public class MJPromoesController : Controller
    {
        private readonly mjburgerpersonalizado _context;

        public MJPromoesController(mjburgerpersonalizado context)
        {
            _context = context;
        }

        // GET: MJPromoes
        public async Task<IActionResult> MJIndex()
        {
            var mjburgerpersonalizado = _context.MJPromo.Include(m => m.MJBurger);
            return View(await mjburgerpersonalizado.ToListAsync());
        }

        // GET: MJPromoes/Details/5
        public async Task<IActionResult> MJDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJPromo = await _context.MJPromo
                .Include(m => m.MJBurger)
                .FirstOrDefaultAsync(m => m.MJPromoId == id);
            if (mJPromo == null)
            {
                return NotFound();
            }

            return View(mJPromo);
        }

        // GET: MJPromoes/Create
        public IActionResult MJCreate()
        {
            ViewData["MJBurgerId"] = new SelectList(_context.MJBurger, "MJBurgerId", "MJName");
            return View();
        }

        // POST: MJPromoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MJCreate([Bind("MJPromoId,MJPromoDescripcion,MJFechaPromocion,MJBurgerId")] MJPromo mJPromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mJPromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MJIndex));
            }
            ViewData["MJBurgerId"] = new SelectList(_context.MJBurger, "MJBurgerId", "MJName", mJPromo.MJBurgerId);
            return View(mJPromo);
        }

        // GET: MJPromoes/Edit/5
        public async Task<IActionResult> MJEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJPromo = await _context.MJPromo.FindAsync(id);
            if (mJPromo == null)
            {
                return NotFound();
            }
            ViewData["MJBurgerId"] = new SelectList(_context.MJBurger, "MJBurgerId", "MJName", mJPromo.MJBurgerId);
            return View(mJPromo);
        }

        // POST: MJPromoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MJEdit(int id, [Bind("MJPromoId,MJPromoDescripcion,MJFechaPromocion,MJBurgerId")] MJPromo mJPromo)
        {
            if (id != mJPromo.MJPromoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mJPromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MJPromoExists(mJPromo.MJPromoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MJIndex));
            }
            ViewData["MJBurgerId"] = new SelectList(_context.MJBurger, "MJBurgerId", "MJName", mJPromo.MJBurgerId);
            return View(mJPromo);
        }

        // GET: MJPromoes/Delete/5
        public async Task<IActionResult> MJDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJPromo = await _context.MJPromo
                .Include(m => m.MJBurger)
                .FirstOrDefaultAsync(m => m.MJPromoId == id);
            if (mJPromo == null)
            {
                return NotFound();
            }

            return View(mJPromo);
        }

        // POST: MJPromoes/Delete/5
        [HttpPost, ActionName("MJDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mJPromo = await _context.MJPromo.FindAsync(id);
            if (mJPromo != null)
            {
                _context.MJPromo.Remove(mJPromo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MJIndex));
        }

        private bool MJPromoExists(int id)
        {
            return _context.MJPromo.Any(e => e.MJPromoId == id);
        }
    }
}
