﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    [Authorize(Roles = "Beheerder, Secretariaat")]
    public class KlasController : Controller
    {

        private readonly ApplicationDbContext _context;

        public KlasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klas
        public async Task<IActionResult> Index()
        {
              return _context.Klassen != null ? 
                          View(await _context.Klassen.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Klassen'  is null.");
        }

        // GET: Klas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klassen == null)
            {
                return NotFound();
            }

            var klas = await _context.Klassen
                .FirstOrDefaultAsync(m => m.KlasId == id);
            if (klas == null)
            {
                return NotFound();
            }

            return View(klas);
        }

        // GET: Klas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlasId,Naam,Verwijderd")] Klas klas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klas);
        }

        // GET: Klas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klassen == null)
            {
                return NotFound();
            }

            var klas = await _context.Klassen.FindAsync(id);
            if (klas == null)
            {
                return NotFound();
            }
            return View(klas);
        }

        // POST: Klas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlasId,Naam,Verwijderd")] Klas klas)
        {
            if (id != klas.KlasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlasExists(klas.KlasId))
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
            return View(klas);
        }

        // GET: Klas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klassen == null)
            {
                return NotFound();
            }

            var klas = await _context.Klassen
                .FirstOrDefaultAsync(m => m.KlasId == id);
            if (klas == null)
            {
                return NotFound();
            }

            return View(klas);
        }

        // POST: Klas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klassen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Klassen'  is null.");
            }
            var klas = await _context.Klassen.FindAsync(id);
            if (klas != null)
            {
                _context.Klassen.Remove(klas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlasExists(int id)
        {
          return (_context.Klassen?.Any(e => e.KlasId == id)).GetValueOrDefault();
        }
    }
}
