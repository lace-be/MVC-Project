using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MvcProject.ViewModels.GebruikerViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Please Enter Confirmation Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = default!;

        [Required(ErrorMessage = "Please Enter Surname")]
        public string Naam { get; set; } = default!;

        [Required(ErrorMessage = "Please Enter First Name")]
        public string Voornaam { get; set; } = default!;

        public List<IdentityRole>? Roles { get; set; }

        public List<string> SelectedRoles { get; set; } = default!;
    }
}
