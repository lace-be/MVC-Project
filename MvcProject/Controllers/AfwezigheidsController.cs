using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class AfwezigheidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfwezigheidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Afwezigheids
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Afwezigheden.Include(a => a.Gebruiker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Afwezigheids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Afwezigheden == null)
            {
                return NotFound();
            }

            var afwezigheid = await _context.Afwezigheden
                .Include(a => a.Gebruiker)
                .FirstOrDefaultAsync(m => m.AfwezigheidId == id);
            if (afwezigheid == null)
            {
                return NotFound();
            }

            return View(afwezigheid);
        }

        // GET: Afwezigheids/Create
        public IActionResult Create()
        {
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id");
            return View();
        }

        // POST: Afwezigheids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AfwezigheidId,GebruikerId,StartDatum,EindDatum")] Afwezigheid afwezigheid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afwezigheid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", afwezigheid.GebruikerId);
            return View(afwezigheid);
        }

        // GET: Afwezigheids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Afwezigheden == null)
            {
                return NotFound();
            }

            var afwezigheid = await _context.Afwezigheden.FindAsync(id);
            if (afwezigheid == null)
            {
                return NotFound();
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", afwezigheid.GebruikerId);
            return View(afwezigheid);
        }

        // POST: Afwezigheids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AfwezigheidId,GebruikerId,StartDatum,EindDatum")] Afwezigheid afwezigheid)
        {
            if (id != afwezigheid.AfwezigheidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afwezigheid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfwezigheidExists(afwezigheid.AfwezigheidId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", afwezigheid.GebruikerId);
            return View(afwezigheid);
        }

        // GET: Afwezigheids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Afwezigheden == null)
            {
                return NotFound();
            }

            var afwezigheid = await _context.Afwezigheden
                .Include(a => a.Gebruiker)
                .FirstOrDefaultAsync(m => m.AfwezigheidId == id);
            if (afwezigheid == null)
            {
                return NotFound();
            }

            return View(afwezigheid);
        }

        // POST: Afwezigheids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Afwezigheden == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Afwezigheden'  is null.");
            }
            var afwezigheid = await _context.Afwezigheden.FindAsync(id);
            if (afwezigheid != null)
            {
                _context.Afwezigheden.Remove(afwezigheid);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfwezigheidExists(int id)
        {
          return (_context.Afwezigheden?.Any(e => e.AfwezigheidId == id)).GetValueOrDefault();
        }
    }
}
