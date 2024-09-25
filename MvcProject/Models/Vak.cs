using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Vak
    {
        //Props
        [Key]
        public int VakId { get; set; }

        [Required]
        public string Naam { get; set; } = default!;

        [Required]
        public bool? Verwijderd { get; set; } = default!;

        //Nav Props
        public List<Studiebezoek>? Studiebezoeken { get; set; }

    }
}
