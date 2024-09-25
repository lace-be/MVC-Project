using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class FotoAlbum
    {
        //Props
        public int FotoAlbumId { get; set; }

        [ForeignKey("Studiebezoek")]
        public int StudiebezoekId { get; set; } = default!;

        [Required]
        public string Naam { get; set; } = default!;

        [Required]
        public DateTime Datum { get; set; } = default!;

        //Nav Props
        public List<Foto>? Fotos { get; set; }

        public Studiebezoek Studiebezoek { get; set; } = default!;

    }
}
