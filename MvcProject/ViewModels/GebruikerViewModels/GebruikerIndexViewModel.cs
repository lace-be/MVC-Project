using MvcProject.Models;

namespace MvcProject.ViewModels.GebruikerViewModels
{
    public class GebruikerIndexViewModel
    {

        public string Email { get; set; } = default!;

        public string Voornaam { get; set; } = default!;

        public string Naam { get; set; } = default!;

        public string Initialen { get; set; } = default!;

        public List<Gebruiker> Gebruikers { get; set; } = default!;

    }
}
