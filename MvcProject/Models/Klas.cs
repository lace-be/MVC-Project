using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Klas
    {
        //Props
        public int KlasId { get; set; }

        [Required]
        public string Naam { get; set; } = default!;

        [Required]
        public bool? Verwijderd { get; set; } = default!;

        //Nav Props
        public List<KlasStudiebezoek>? KlasStudiebezoeken { get; set; }
    }
}
