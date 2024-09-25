using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;
using MvcProject.ViewModels;


namespace MvcProject.Controllers
{
   
    public class NavormingenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NavormingenController> _logger;

        public string? ViewModel { get; private set; }

        public NavormingenController(ApplicationDbContext context, ILogger<NavormingenController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Navormingen.Include(n => n.Gebruiker);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Navormingen == null)
            {
                return NotFound();
            }

            var navorming = await _context.Navormingen
                .Include(n => n.Gebruiker)
                .FirstOrDefaultAsync(m => m.NavormingId == id);
            if (navorming == null)
            {
                return NotFound();
            }

            return View(navorming);
        }


        public IActionResult Create()
        {
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NavormingCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _context.Navormingen.AddAsync(new Navorming()
                {
                    GebruikerId = viewModel.GebruikerId,
                    Datum = viewModel.Datum,
                    StartUur = viewModel.StartUur,
                    EindUur = viewModel.EindUur,
                    Reden = viewModel.Reden,
                    Kostprijs = viewModel.Kostprijs,
                    OpmerkingAfgewezen = viewModel.OpmerkingAfgewezen,
                    IsAfgewerkt = viewModel.IsAfgewerkt,
                    IsGoedgekeurdDir = viewModel.IsGoedgekeurdDir,
                    IsAfgewezen = viewModel.IsAfgewezen,
                });

                var result = _context.SaveChanges();

                return RedirectToAction("Index", "Navormingen");
            }
            else
            {
                _logger.LogInformation(ModelState.IsValid.ToString());
                _logger.LogInformation($"Errors: {ModelState.ErrorCount}");
            }

            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", viewModel.GebruikerId);

            return View(viewModel);
        }

        [Authorize(Roles = "Directie,Coördinator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navorming = await _context.Navormingen.FindAsync(id);

            if (navorming == null)
            {
                return NotFound();
            }

            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", selectedValue: navorming.GebruikerId);

            NavormingEditViewModel viewModel = new NavormingEditViewModel
            {
                NavormingId = navorming.NavormingId,
                GebruikerId = navorming.GebruikerId,
                Datum = navorming.Datum,
                StartUur = navorming.StartUur,
                EindUur = navorming.EindUur,
                Reden = navorming.Reden,
                Kostprijs = navorming.Kostprijs,
                OpmerkingAfgewezen = navorming.OpmerkingAfgewezen,
                IsGoedgekeurdDir = navorming.IsGoedgekeurdDir,
                IsAfgewezen = navorming.IsAfgewezen,
                IsAfgewerkt = navorming.IsAfgewerkt,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NavormingEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var navorming = await _context.Navormingen.FindAsync(viewModel.NavormingId);

                if (navorming != null)
                {
                    // Update properties
                    navorming.GebruikerId = viewModel.GebruikerId;
                    navorming.Datum = viewModel.Datum;
                    navorming.StartUur = viewModel.StartUur;
                    navorming.EindUur = viewModel.EindUur;
                    navorming.Reden = viewModel.Reden;
                    navorming.Kostprijs = viewModel.Kostprijs;
                    navorming.OpmerkingAfgewezen = viewModel.OpmerkingAfgewezen;
                    navorming.IsAfgewerkt = viewModel.IsAfgewerkt;
                    navorming.IsGoedgekeurdDir = viewModel.IsGoedgekeurdDir;
                    navorming.IsAfgewezen = viewModel.IsAfgewezen;
                    // Save changes
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Navormingen");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                _logger.LogInformation($"Errors: {string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");
            }

            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", viewModel.GebruikerId);

            return View(viewModel);
        }

        // GET: Navormingen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Navormingen == null)
            {
                return NotFound();
            }

            var navorming = await _context.Navormingen
                .Include(n => n.Gebruiker)
                .FirstOrDefaultAsync(m => m.NavormingId == id);
            if (navorming == null)
            {
                return NotFound();
            }

            return View(navorming);
        }

        // POST: Navormingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Navormingen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Navormingen'  is null.");
            }
            var navorming = await _context.Navormingen.FindAsync(id);
            if (navorming != null)
            {
                _context.Navormingen.Remove(navorming);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavormingExists(int id)
        {
            return (_context.Navormingen?.Any(e => e.NavormingId == id)).GetValueOrDefault();
        }
    }
}
