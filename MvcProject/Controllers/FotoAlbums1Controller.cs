using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;
using MvcProject.ViewModels.FotoAlbum1ViewModels;

namespace MvcProject.Controllers
{
    public class FotoAlbums1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotoAlbums1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FotoAlbums1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FotoAlbums.Include(f => f.Studiebezoek);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FotoAlbums1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FotoAlbums == null)
            {
                return NotFound();
            }

            var fotoAlbum = await _context.FotoAlbums
                .Include(f => f.Studiebezoek)
                .FirstOrDefaultAsync(m => m.FotoAlbumId == id);
            if (fotoAlbum == null)
            {
                return NotFound();
            }

            return View(fotoAlbum);
        }

        // GET: FotoAlbums1/Create
        public IActionResult Create()
        {
            ViewData["StudiebezoekId"] = new SelectList(_context.Studiebezoeken, "StudiebezoekId", "GebruikerId");
            return View();
        }

        // POST: FotoAlbums1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFotoAlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hier kun je de logica toevoegen om het fotoalbum op te slaan, inclusief de geüploade foto's
                    // Bijvoorbeeld: viewModel.Fotos bevat de geüploade foto's

                    // Voorbeeld: Opslaan in de database
                    var fotoAlbum = new FotoAlbum
                    {
                        Naam = viewModel.Naam,
                        Datum = viewModel.Datum,
                        StudiebezoekId = viewModel.StudiebezoekId
                        // ... andere eigenschappen toewijzen zoals nodig
                    };

                    _context.FotoAlbums.Add(fotoAlbum);
                    await _context.SaveChangesAsync();
                    if (viewModel.Fotos != null)
                    {
                        // Voeg hier de logica toe voor het verwerken van de geüploade foto's
                        foreach (var foto in viewModel.Fotos)
                        {
                            // Bijvoorbeeld: Opslaan van de geüploade foto in een Foto-tabel
                            var fotoEntity = new Foto
                            {
                                // Vul hier de eigenschappen van de Foto-entity in op basis van de geüploade foto
                            };

                            _context.Fotos.Add(fotoEntity);
                        }
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "FotoAlbums1");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fout bij het opslaan van het fotoalbum: {ex.Message}");
                    // Log ex naar een foutlogboek of gebruik een loggingsysteem zoals Serilog
                }
            }

            // Als de ModelState niet geldig is, laad de Studiebezoeken opnieuw voor de dropdown
            viewModel.Studiebezoeken = _context.Studiebezoeken
                .Select(s => new SelectListItem {Value = s.StudiebezoekId.ToString()})
                .ToList();

            return View(viewModel);
        }



        

        // GET: FotoAlbums1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FotoAlbums == null)
            {
                return NotFound();
            }

            var fotoAlbum = await _context.FotoAlbums
                .Include(f => f.Studiebezoek)
                .FirstOrDefaultAsync(m => m.FotoAlbumId == id);
            if (fotoAlbum == null)
            {
                return NotFound();
            }

            return View(fotoAlbum);
        }

        // POST: FotoAlbums1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FotoAlbums == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FotoAlbums'  is null.");
            }
            var fotoAlbum = await _context.FotoAlbums.FindAsync(id);
            if (fotoAlbum != null)
            {
                _context.FotoAlbums.Remove(fotoAlbum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoAlbumExists(int id)
        {
          return (_context.FotoAlbums?.Any(e => e.FotoAlbumId == id)).GetValueOrDefault();
        }
    }
}
