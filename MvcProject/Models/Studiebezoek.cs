using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Studiebezoek
    {
        //Props
        public int StudiebezoekId { get; set; }
        [ForeignKey("Gebruiker")]

        public string GebruikerId { get; set; } = default!;

        [ForeignKey("Vak")]
        public int VakId { get; set; } = default!;

        [Required]
        public DateTime Datum { get; set; } = default!;

        [Required]
        public DateTime StartUur { get; set; } = default!;

        [Required]
        public DateTime EindUur { get; set; } = default!;

        [Required]
        public string Reden { get; set; } = default!;
        public int? AantalStudenten { get; set; } = default!;

        [Column(TypeName = "decimal(18,4)"), Required]
        public decimal KostprijsStudiebezoek { get; set; } = default!;

        public bool? VervoerBus { get; set; } = default!;

        public bool? VervoerTram { get; set; } = default!;

        public bool? VervoerTrein { get; set; } = default!;

        public bool? VervoerTeVoet { get; set; } = default!;

        public bool? VervoerAuto { get; set; } = default!;

        public bool? VervoerFiets { get; set; } = default!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal? KostprijsVervoer { get; set; } = default!;

        public string? AfwezigeStudenten { get; set; } = default!;

        public string? Opmerkingen { get; set; } = default!;

        public bool? IsGoedgekeurdCo { get; set; } = default!;

        public bool? IsGoedgekeurdDir { get; set; } = default!;

        public bool? IsAfgewezen { get; set; } = default!;

        public string? OpmerkingAfgewezen { get; set; } = default!;

        public bool? IsAfgewerkt { get; set; } = default!;

        //Nav Props
        public List<KlasStudiebezoek>? KlasStudiebezoeken { get; set; }

        public List<Begeleiding>? Begeleidingen { get; set; }

        public Vak Vak { get; set; } = default!;

        public List<Bijlage>? Bijlagen { get; set; } = default!;

        public List<FotoAlbum>? FotoAlbums { get; set; } = default!;

        public Gebruiker Gebruiker { get; set; } = default!;
    }
}
