using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using MvcProject.Models;
using System.Text.Encodings.Web;
using System.Text;
using MvcProject.ViewModels.GebruikerViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MvcProject.Data.UnitOfWork;
using MvcProject.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MvcProject.Controllers
{
    [Authorize(Roles ="Beheerder")]
    public class GebruikerController : Controller
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IUserStore<Gebruiker> _userStore;
        private readonly ILogger<GebruikerController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IUserEmailStore<Gebruiker> _emailStore;
        public GebruikerController(
            UserManager<Gebruiker> userManager,
            IUserStore<Gebruiker> userStore,
            SignInManager<Gebruiker> signInManager,
            ILogger<GebruikerController> logger,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context
           )
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _context = context;
            _emailStore = GetEmailStore();

        }

        [TempData]
        public string ErrorMessage { get; set; }

        // GET: Gebruikers
        public async Task<IActionResult> Index()
        {
            var users = _context.Users.ToList();

            GebruikerIndexViewModel viewModel = new GebruikerIndexViewModel
            {
                Gebruikers = users
            };

            return View(viewModel);
        }

        public IActionResult Register()
        {
            var roles = _context.Roles.ToList();

            RegisterViewModel viewModel = new RegisterViewModel
            {
                Roles = roles
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel Input)
        {
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                user.Voornaam = Input.Voornaam;
                user.Naam = Input.Naam;
                user.Email = Input.Email;
                user.Initialen = Input.Voornaam.Substring(0, 1)+Input.Naam.Substring(0,1);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    if (Input.SelectedRoles != null && Input.SelectedRoles.Any())
                    {
                        foreach (var roleId in Input.SelectedRoles)
                        {
                            var role = await _roleManager.FindByIdAsync(roleId);

                            if (role != null)
                            {
                                await _userManager.AddToRoleAsync(user, role.Name);
                            }
                        }
                    }

                    return RedirectToAction("Index", "Gebruiker");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            var roles = _context.Roles.ToList();

            RegisterViewModel viewModel = new RegisterViewModel
            {
                Roles = roles
            };

            // If we got this far, something failed, redisplay form
            return View("../Gebruiker/Register", viewModel);
        }

        //Aangeduide rollen werkt niet
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers.FindAsync(id);
            var roles = _context.Roles.ToList();

            if (gebruiker == null)
            {
                return NotFound();
            }

            GebruikerEditViewModel viewModel = new GebruikerEditViewModel
            {
                Email = gebruiker.Email,
                Naam = gebruiker.Naam,
                Voornaam = gebruiker.Voornaam,
                Roles = roles,
            };

            return View(viewModel);
        }

        //Alleen de rollen editen werkt niet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GebruikerId,Email,Naam,Voornaam")] GebruikerEditViewModel viewModel)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View(NotFound());
            }
            else
            {
                user.Email = viewModel.Email;
                user.Naam = viewModel.Naam;
                user.Voornaam = viewModel.Voornaam;
                user.Initialen = viewModel.Voornaam.Substring(0, 1) + viewModel.Naam.Substring(0, 1);
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    if (viewModel.SelectedRoles != null && viewModel.SelectedRoles.Any())
                    {
                        foreach (var roleId in viewModel.SelectedRoles)
                        {
                            var role = await _roleManager.FindByIdAsync(roleId);

                            if (role != null)
                            {
                                await _userManager.AddToRoleAsync(user, role.Name);
                            }
                        }
                    }
                    return RedirectToAction("Index");
                }
                return View(viewModel);
            }

        }

        public async Task<IActionResult> Delete(string id, int id2)
        {
            var user = await _context.Gebruikers.FindAsync(id);

            if (id == null || user == null)
            {
                return NotFound();
            }

            var studiebezoekenToRemove = _context.Studiebezoeken.Where(sb => sb.GebruikerId == id).ToList();
            var navormingenToRemove = _context.Navormingen.Where(sb => sb.GebruikerId == id).ToList();

            // To be removed
            var klasStudiebezoekenToRemove = _context.KlasStudiebezoeken
                .Where(ks => studiebezoekenToRemove.Select(sb => sb.StudiebezoekId).Contains(ks.StudiebezoekId))
                .ToList();
            
            var gebruikerNavormingenToRemove = _context.GebruikerNavormingen
                .Where(ks => navormingenToRemove.Select(sb => sb.NavormingId).Contains(ks.NavormingId))
                .ToList();
            
            var userRolesToRemove = _context.UserRoles
                .Where(ks => ks.UserId == id)
                .ToList();

            // Remove records
            _context.KlasStudiebezoeken.RemoveRange(klasStudiebezoekenToRemove);
            _context.GebruikerNavormingen.RemoveRange(gebruikerNavormingenToRemove);
            _context.UserRoles.RemoveRange(userRolesToRemove);

            // Remove records
            _context.Studiebezoeken.RemoveRange(studiebezoekenToRemove);
            _context.Navormingen.RemoveRange(navormingenToRemove);

            // Delete the user
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            _logger.LogInformation("User with ID '{user.Id}' deleted.", user.Id);

            return RedirectToAction(nameof(Index));
        }

        private Gebruiker CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Gebruiker>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Gebruiker)}'. " +
                    $"Ensure that '{nameof(Gebruiker)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<Gebruiker> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Gebruiker>)_userStore;
        }
    }
}