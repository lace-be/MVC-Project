using Microsoft.AspNetCore.Identity;
using MvcProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MvcProject.ViewModels.GebruikerViewModels
{
    public class GebruikerEditViewModel
    {
        [Required(ErrorMessage = "Please Enter Email Address")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please Enter Surname")]
        public string Naam { get; set; } = default!;

        [Required(ErrorMessage = "Please Enter First Name")]
        public string Voornaam { get; set; } = default!;

        public List<IdentityRole>? Roles { get; set; }

        public List<string> SelectedRoles { get; set; } = default!;
    }
}