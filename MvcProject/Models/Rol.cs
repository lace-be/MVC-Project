using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Rol:IdentityRole
    {
        //Props
        [Required]
        public string Naam { get; set; } = default!;

        //Nav Props
        public List<GebruikerRol>? GebruikerRollen { get; set; }
    }
}
