using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data;
using MvcProject.Models;
using MvcProject.ViewModels.StudiebezoekenViewModels;

namespace MvcProject.Controllers
{
    public class StudiebezoekenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudiebezoekenController> _logger;

        public List<string> Studenten = new List<string>();

        public StudiebezoekenController(ApplicationDbContext context, ILogger<StudiebezoekenController> logger)
        {
            Studenten.Add("Alice");
            Studenten.Add("Bob");
            Studenten.Add("Charlie");
            _context = context;
            _logger = logger;
        }

        // GET: Studiebezoeken
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Studiebezoeken.Include(s => s.Gebruiker).Include(s => s.Vak).Include(k => k.KlasStudiebezoeken);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Studiebezoeken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Studiebezoeken == null)
            {
                return NotFound();
            }

            var studiebezoek = await _context.Studiebezoeken
                .Include(s => s.Gebruiker)
                .Include(s => s.Vak)
                .FirstOrDefaultAsync(m => m.StudiebezoekId == id);
            if (studiebezoek == null)
            {
                return NotFound();
            }

            return View(studiebezoek);
        }

        //GET: Studiebezoeken/Create
        //public async Task<IActionResult> Create(StudiebezoekenCreateViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _context.Studiebezoeken.AddAsync(new Studiebezoek()
        //        {
        //            GebruikerId = viewModel.GebruikerId,
        //            Datum = viewModel.Datum,
        //            StartUur = viewModel.StartUur,
        //            EindUur = viewModel.EindUur,
        //            Reden = viewModel.Reden,
        //            AantalStudenten = viewModel.AantalStudenten,
        //            KostprijsStudiebezoek = viewModel.KostprijsStudiebezoek,
        //            VervoerBus = viewModel.VervoerBus,
        //            VervoerTram = viewModel.VervoerTram,
        //            VervoerTrein = viewModel.VervoerTrein,
        //            VervoerTeVoet = viewModel.VervoerTeVoet,
        //            VervoerAuto = viewModel.VervoerAuto,
        //            VervoerFiets = viewModel.VervoerFiets,
        //            KostprijsVervoer = viewModel.KostprijsVervoer,
        //            OpmerkingAfgewezen = viewModel.OpmerkingAfgewezen,
        //            IsAfgewerkt = viewModel.IsAfgewerkt,
        //            Vak = viewModel.Vak,
        //        });

        //        var result = _context.SaveChanges();

        //        return RedirectToAction("Index", "Studiebezoeken");
        //    }
        //    else
        //    {
        //        //    _logger.LogInformation(ModelState.IsValid.ToString());
        //        //    _logger.LogInformation($"Errors: {ModelState.ErrorCount.ToString()}");
        //    }

        //    ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", viewModel.GebruikerId);

        //    return View(viewModel);
        //}



        public IActionResult Create()
        {
            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "Naam");
            //ViewData["Studenten"] = new SelectList(Studenten);
            //ViewData["Klassen"] = new SelectList(_context.Klassen, "KlasId", "Naam");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudiebezoekenCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a new Studiebezoek based on the viewModel
                    await _context.Studiebezoeken.AddAsync(new Studiebezoek()
                    {
                        GebruikerId = viewModel.GebruikerId,
                        VakId = viewModel.VakId,
                        Datum = viewModel.Datum,
                        StartUur = viewModel.StartUur,
                        EindUur = viewModel.EindUur,
                        Reden = viewModel.Reden,
                        AantalStudenten = viewModel.AantalStudenten,
                        KostprijsStudiebezoek = viewModel.KostprijsStudiebezoek,
                        VervoerBus = viewModel.VervoerBus,
                        VervoerTram = viewModel.VervoerTram,
                        VervoerTrein = viewModel.VervoerTrein,
                        VervoerTeVoet = viewModel.VervoerTeVoet,
                        VervoerAuto = viewModel.VervoerAuto,
                        VervoerFiets = viewModel.VervoerFiets,
                        KostprijsVervoer = viewModel.KostprijsVervoer,
                        AfwezigeStudenten = viewModel.AfwezigeStudenten,
                        Opmerkingen = viewModel.Opmerkingen,
                        IsGoedgekeurdCo = viewModel.IsGoedgekeurdCo,
                        IsGoedgekeurdDir = viewModel.IsGoedgekeurdDir,
                        IsAfgewezen = viewModel.IsAfgewezen,
                        OpmerkingAfgewezen = viewModel.OpmerkingAfgewezen,
                        IsAfgewerkt = viewModel.IsAfgewerkt,
                    });

                    var result = _context.SaveChanges();
                    return RedirectToAction("Index", "studiebezoeken");
                }
                catch (Exception ex)
                {
                    // Log any unexpected exceptions
                    _logger.LogError($"Exception while creating a new Studiebezoek: {ex.Message}");
                    return StatusCode(500, "Internal Server Error");
                }
            }
            else
            {
                // Handle model validation errors, log or inspect ModelState
                LogModelStateErrors();
                _logger.LogInformation($"Errors: {ModelState.ErrorCount}");
            }

            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "Naam");
            ViewData["Studenten"] = new SelectList(Studenten);
            ViewData["Klassen"] = new SelectList(_context.Klassen, "KlasId", "Naam");

            return View(viewModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studiebezoek = await _context.Studiebezoeken
                .Include(s => s.Gebruiker)
                .Include(s => s.Vak)
                .FirstOrDefaultAsync(m => m.StudiebezoekId == id);

            if (studiebezoek == null)
            {
                return NotFound();
            }

            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", selectedValue: studiebezoek.GebruikerId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "Naam", selectedValue: studiebezoek.VakId);

            StudiebezoekenEditViewmodel viewModel = new StudiebezoekenEditViewmodel
            {

                VakId = studiebezoek.VakId,
                StudiebezoekId = studiebezoek.StudiebezoekId,
                GebruikerId = studiebezoek.GebruikerId,

                Datum = studiebezoek.Datum,
                StartUur = studiebezoek.StartUur,
                EindUur = studiebezoek.EindUur,
                Reden = studiebezoek.Reden,
                AantalStudenten = studiebezoek.AantalStudenten,
                KostprijsStudiebezoek = studiebezoek.KostprijsStudiebezoek,
                KostprijsVervoer = studiebezoek.KostprijsVervoer,
                AfwezigeStudenten = studiebezoek.AfwezigeStudenten,
                Opmerkingen = studiebezoek.Opmerkingen,

                OpmerkingAfgewezen = studiebezoek.OpmerkingAfgewezen,
        
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudiebezoekenEditViewmodel viewModel)
        {
            if (ModelState.IsValid)
            {
                var studiebezoek = await _context.Studiebezoeken
                .Include(s => s.Gebruiker)
                .Include(s => s.Vak)
                .FirstOrDefaultAsync(m => m.StudiebezoekId == viewModel.StudiebezoekId);

                if (studiebezoek != null)
                {
                    // update properties
                    studiebezoek.GebruikerId = viewModel.GebruikerId;
                    studiebezoek.VakId = viewModel.VakId;
                    studiebezoek.Datum = viewModel.Datum;
                    studiebezoek.StartUur = viewModel.StartUur;
                    studiebezoek.EindUur = viewModel.EindUur;
                    studiebezoek.Reden = viewModel.Reden;
                    studiebezoek.AantalStudenten = viewModel.AantalStudenten;
                    studiebezoek.KostprijsStudiebezoek = viewModel.KostprijsStudiebezoek;
                    studiebezoek.VervoerBus = viewModel.VervoerBus;
                    studiebezoek.VervoerTram = viewModel.VervoerTram;
                    studiebezoek.VervoerTrein = viewModel.VervoerTrein;
                    studiebezoek.VervoerTeVoet = viewModel.VervoerTeVoet;
                    studiebezoek.VervoerAuto = viewModel.VervoerAuto;
                    studiebezoek.VervoerFiets = viewModel.VervoerFiets;
                    studiebezoek.KostprijsVervoer = viewModel.KostprijsVervoer;
                    studiebezoek.AfwezigeStudenten = viewModel.AfwezigeStudenten;
                    studiebezoek.Opmerkingen = viewModel.Opmerkingen;
                    studiebezoek.IsGoedgekeurdCo = viewModel.IsGoedgekeurdCo;
                    studiebezoek.IsGoedgekeurdDir = viewModel.IsGoedgekeurdDir;
                    studiebezoek.IsAfgewezen = viewModel.IsAfgewezen;
                    studiebezoek.OpmerkingAfgewezen = viewModel.OpmerkingAfgewezen;
                    studiebezoek.IsAfgewerkt = viewModel.IsAfgewerkt;

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "studiebezoeken");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                // Log model state errors
                LogModelStateErrors();
            }

            ViewData["GebruikerId"] = new SelectList(_context.Gebruikers, "Id", "Id", selectedValue: viewModel.GebruikerId);
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "Naam", selectedValue: viewModel.VakId);
            return View(viewModel);
        }

        private void LogModelStateErrors()
        {
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    _logger.LogError($"ModelState error: {error.ErrorMessage}");
                }
            }
        }



        // GET: Studiebezoeken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studiebezoeken == null)
            {
                return NotFound();
            }

            var studiebezoek = await _context.Studiebezoeken
                .Include(s => s.Gebruiker)
                .Include(v => v.Vak)
                .FirstOrDefaultAsync(m => m.StudiebezoekId == id);
            if (studiebezoek == null)
            {
                return NotFound();
            }

            return View(studiebezoek);
        }

        // POST: Studiebezoeken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studiebezoeken == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Studiebezoeken'  is null.");
            }

            try
            {
                var studiebezoek = await _context.Studiebezoeken.FindAsync(id);
                if (studiebezoek != null)
                {
                    var relatedKlasStudiebezoeken = _context.KlasStudiebezoeken.Where(ks => ks.StudiebezoekId == id);
                    _context.KlasStudiebezoeken.RemoveRange(relatedKlasStudiebezoeken);

                    _context.Studiebezoeken.Remove(studiebezoek);

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
                await _context.SaveChangesAsync();

            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudiebezoekExists(int id)
        {
            return (_context.Studiebezoeken?.Any(e => e.StudiebezoekId == id)).GetValueOrDefault();
        }
    }
}