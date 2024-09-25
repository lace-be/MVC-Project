using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Foto
    {
        //Props
        public int FotoId { get; set; }

        [ForeignKey("FotoAlbum")]
        public int FotoAlbumId { get; set; } = default!;

        [Required]
        public string NaamFoto { get; set; } = default!;

        [Required]
        public string Thumbnail { get; set; } = default!;

        //Nav Props
        public FotoAlbum FotoAlbum { get; set; } = default!;
        
    }
}
