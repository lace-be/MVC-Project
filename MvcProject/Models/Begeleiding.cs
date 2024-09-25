using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Begeleiding
    {
        //Props
        public int  BegeleidingId { get; set; }

        [ForeignKey("Studiebezoek")]
        public int StudiebezoekId { get; set; } = default!;

        [ForeignKey("Gebruiker"), Required]
        public string GebruikerId { get; set; } = default!;

        //Nav Props
        public Gebruiker Gebruiker { get; set; } = default!;
        public Studiebezoek Studiebezoek { get; set; } = default!;

    }
}
