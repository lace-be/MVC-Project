using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;
using MvcProject.ViewModels;
using MvcProject.ViewModels.VakkenViewModels;

namespace MvcProject.Controllers
{
    public class VakkenController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<NavormingenController> _logger;

        public VakkenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vakken
        public async Task<IActionResult> Index()
        {
            try
            {
                var vakken = await _context.Vakken.ToListAsync();
                return View(vakken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(new List<Vak>()); // Return an empty list
            }
        }

        // GET: Vakken/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vakken/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VakkenCreateViewModels viewModel)
        {
            if (ModelState.IsValid)
            {
                await _context.Vakken.AddAsync(new Vak()
                {
                    Naam = viewModel.Naam,
                    Verwijderd = viewModel.Verwijderd
                });

                var result = _context.SaveChanges();

                return RedirectToAction("Index", "Vakken");
            }
            else
            {
                _logger.LogInformation(ModelState.IsValid.ToString());
                _logger.LogInformation($"Errors: {ModelState.ErrorCount}");
            }

            return View(viewModel);
        }

        // GET: Vak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vakken == null)
            {
                return NotFound();
            }

            var vak = await _context.Vakken.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }
            return View(vak);
        }

        // POST: Vak/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VakId,Naam,Verwijderd")] Vak vak)
        {
            if (id != vak.VakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakExists(vak.VakId))
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
            return View(vak);
        }

        // GET: Klas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vakken == null)
            {
                return NotFound();
            }

            var vak = await _context.Vakken
                .FirstOrDefaultAsync(m => m.VakId == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // GET: Vakken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vakken == null)
            {
                return NotFound();
            }

            var vak = await _context.Vakken
                .FirstOrDefaultAsync(m => m.VakId == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // POST: Vakken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vakken == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vakken'  is null.");
            }
            var vak = await _context.Vakken.FindAsync(id);
            if (vak != null)
            {
                _context.Vakken.Remove(vak);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakExists(int id)
        {
            return (_context.Vakken?.Any(e => e.VakId == id)).GetValueOrDefault();
        }
    }
}