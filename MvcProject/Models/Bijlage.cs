using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Bijlage
    {
        //Props
        public int BijlageId { get; set; }

        [ForeignKey("Studiebezoek")]
        public int? StudiebezoekId { get; set; }

        [Required]
        public string BestandsNaam { get; set; } = default!;

        //Nav Props
        public Studiebezoek Studiebezoek { get; set; } = default!;

    }
}
