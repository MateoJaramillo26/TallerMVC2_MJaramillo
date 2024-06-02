using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerMVC2_MJ.Models;

namespace TallerMVC2_MJ.Controllers
{
    public class MJBurgersController : Controller
    {
        private readonly mjburgerpersonalizado _context;

        public MJBurgersController(mjburgerpersonalizado context)
        {
            _context = context;
        }

        // GET: MJBurgers
        public async Task<IActionResult> MJIndex()
        {
            return View(await _context.MJBurger.ToListAsync());
        }

        // GET: MJBurgers/Details/5
        public async Task<IActionResult> MJDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJBurger = await _context.MJBurger
                .FirstOrDefaultAsync(m => m.MJBurgerId == id);
            if (mJBurger == null)
            {
                return NotFound();
            }

            return View(mJBurger);
        }

        // GET: MJBurgers/Create
        public IActionResult MJCreate()
        {
            return View();
        }

        // POST: MJBurgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MJCreate([Bind("MJBurgerId,MJName,MJWithCheese,MJPrecio")] MJBurger mJBurger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mJBurger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MJIndex));
            }
            return View(mJBurger);
        }

        // GET: MJBurgers/Edit/5
        public async Task<IActionResult> MJEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJBurger = await _context.MJBurger.FindAsync(id);
            if (mJBurger == null)
            {
                return NotFound();
            }
            return View(mJBurger);
        }

        // POST: MJBurgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MJEdit(int id, [Bind("MJBurgerId,MJName,MJWithCheese,MJPrecio")] MJBurger mJBurger)
        {
            if (id != mJBurger.MJBurgerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mJBurger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MJBurgerExists(mJBurger.MJBurgerId))
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
            return View(mJBurger);
        }

        // GET: MJBurgers/Delete/5
        public async Task<IActionResult> MJDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJBurger = await _context.MJBurger
                .FirstOrDefaultAsync(m => m.MJBurgerId == id);
            if (mJBurger == null)
            {
                return NotFound();
            }

            return View(mJBurger);
        }

        // POST: MJBurgers/Delete/5
        [HttpPost, ActionName("MJDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MJDeleteConfirmed(int id)
        {
            var mJBurger = await _context.MJBurger.FindAsync(id);
            if (mJBurger != null)
            {
                _context.MJBurger.Remove(mJBurger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MJIndex));
        }

        private bool MJBurgerExists(int id)
        {
            return _context.MJBurger.Any(e => e.MJBurgerId == id);
        }
    }
}
