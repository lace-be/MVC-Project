using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Areas.Identity.Pages.Account;
using MvcProject.Models;
using MvcProject.ViewModels.AccountViewModels;

namespace MvcProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public AccountController(SignInManager<Gebruiker> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LoginViewModel Input)
        {
            _logger.LogInformation(_signInManager.ToString());

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View("../Home/Index");
        }
    }
}
