using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class KlasStudiebezoek
    {
        //Props
        public int KlasStudiebezoekId { get; set; }

        [ForeignKey("Klas"), Required]
        public int KlasId { get; set; } = default!;

        [ForeignKey("Studiebezoek")]
        public int StudiebezoekId { get; set; } = default!;

        //Nav Props
        public Klas Klas { get; set; } = default!;

        public Studiebezoek Studiebezoek { get; set; } = default!;

    }
}
