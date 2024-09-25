using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Navorming
    {
        //Props
        public int NavormingId { get; set; }

        [ForeignKey("Gebruiker")]
        public string GebruikerId { get; set; } = default!;

        [Required]
        public DateTime Datum { get; set; } = default!;

        [Required]
        [Display(Name = "Begin")]
        public DateTime StartUur { get; set; } = default!;

        [Required]
        [Display(Name = "Einde")]
        public DateTime EindUur { get; set; } = default!;

        [Required]
        public string Reden { get; set; } = default!;

        [Column(TypeName = "decimal(18,4)"), Required]
        public decimal Kostprijs { get; set; }

        [Display(Name = "Goedgekeurd Directie")]
        public bool? IsGoedgekeurdDir { get; set; } 

        [Display(Name = "Afgewezen")]
        public bool? IsAfgewezen { get; set; }

        [Display(Name = "Opmerking Afgewezen")]
        public string? OpmerkingAfgewezen { get; set; }

        [Display(Name = "Afgewerkt")]
        public bool IsAfgewerkt { get; set; }

        // Navigation Properties
        public Gebruiker Gebruiker { get; set; } = default!;

        public List<GebruikerNavorming>? GebruikerNavormingen { get; set; }
    }
}
