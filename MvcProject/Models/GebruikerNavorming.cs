using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class GebruikerNavorming
    {
        //Props
        public int GebruikerNavormingId { get; set; }

        [ForeignKey("Gebruiker")]
        public string GebruikerId { get; set; } = default!;

        [ForeignKey("Navorming")]
        public int NavormingId { get; set; } = default!;

        //Nav Props
        public Gebruiker Gebruiker { get; set; } = default!;

        public Navorming Navorming { get; set; } = default!;    
    }
}
