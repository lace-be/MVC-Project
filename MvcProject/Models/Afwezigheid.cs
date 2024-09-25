using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Afwezigheid
    {
        //Props
        public int AfwezigheidId { get; set; }

        [ForeignKey("Gebruiker")]
        public string GebruikerId { get; set; } = default!;

        [Required]
        public DateTime? StartDatum { get; set; } = default!;

        [Required]
        public DateTime? EindDatum { get; set; } = default!;

        //Nav Props
        public Gebruiker Gebruiker { get; set; } = default!;    
    }
}
