using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class GebruikerRol : IdentityUserRole<string>
    {
        //Props
        [ForeignKey("Gebruiker")]
        public string GebruikerId { get; set; } = default!;

        [ForeignKey("Rol")]
        public string RolId { get; set; } = default!;

        //Nav Props
        public Gebruiker Gebruiker { get; set; } = default!;

        public Rol Rol { get; set; } = default!;

    }
}
