using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.ViewModels.StudiebezoekenViewModels
{
    public class StudiebezoekenCreateViewModel
    {
        //Props
        public int StudiebezoekId { get; set; }
        [ForeignKey("Gebruiker")]

        public string GebruikerId { get; set; } = default!;

        [ForeignKey("Vak")]
        public int VakId { get; set; } = default!;

        public DateTime Datum { get; set; } = default!;

        public DateTime StartUur { get; set; } = default!;

        public DateTime EindUur { get; set; } = default!;

        public string Reden { get; set; } = default!;

        public int? AantalStudenten { get; set; } = default!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal KostprijsStudiebezoek { get; set; } = default!;

        public bool VervoerBus { get; set; } = default!;

        public bool VervoerTram { get; set; } = default!;

        public bool VervoerTrein { get; set; } = default!;

        public bool VervoerTeVoet { get; set; } = default!;

        public bool VervoerAuto { get; set; } = default!;

        public bool VervoerFiets { get; set; } = default!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal? KostprijsVervoer { get; set; } = default!;

        public string? AfwezigeStudenten { get; set; } = default!;

        public string? Opmerkingen { get; set; } = default!;

        public bool IsGoedgekeurdCo { get; set; } = default!;

        public bool IsGoedgekeurdDir { get; set; } = default!;

        public bool IsAfgewezen { get; set; } = default!;

        public string? OpmerkingAfgewezen { get; set; } = default!;

        public bool IsAfgewerkt { get; set; } = default!;

        //NavProps
        public List<KlasStudiebezoek>? KlasStudiebezoeken { get; set; }

    }
}
