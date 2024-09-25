using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Gebruiker : IdentityUser
    {
        // Properties
        public string Naam { get; set; } = default!;

        public string Voornaam { get; set; } = default!;

        //[Required, PersonalData]
        //public string Wachtwoord { get; set; } = default!;
        [Required, PersonalData]
        public string Email { get; set; } = default!;

        public bool? Verwijderd { get; set; } = default!;

        public string? Initialen { get; set; } = default!;

        // Navigation Properties
        public List<Begeleiding>? Begeleidingen { get; set; }

        public List<Studiebezoek>? Studiebezoeken { get; set; }

        public List<GebruikerNavorming>? GebruikerNavormingen { get; set; }

        public List<Navorming>? Navormingen { get; set; }

        public List<FotoAlbum>? FotoAlbums { get; set; }

        public List<GebruikerRol>? GebruikerRollen { get; set; }

        public List<Afwezigheid>? Afwezigheden { get; set; }

    }
}
