using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.ViewModels
{
    public class NavormingEditViewModel
    {
        
            public int NavormingId { get; set; }

            [ForeignKey("Gebruiker")]
            public string GebruikerId { get; set; } = default!;

            [Required]
            public DateTime Datum { get; set; } = default!;

            [Required]
            public DateTime StartUur { get; set; } = default!;

            [Required]
            public DateTime EindUur { get; set; } = default!;

            [Required]
            public string Reden { get; set; } = default!;

            [Column(TypeName = "decimal(18,4)"), Required]
            public decimal Kostprijs { get; set; }

            public bool? IsGoedgekeurdDir { get; set; }

            public bool? IsAfgewezen { get; set; }

            public string? OpmerkingAfgewezen { get; set; }

            public bool IsAfgewerkt { get; set; }


    }


}
