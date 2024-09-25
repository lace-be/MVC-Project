using MvcProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.ViewModels.VakkenViewModels
{
    public class VakkenCreateViewModels
    {
        //Props
        public int VakId { get; set; }

        public string Naam { get; set; } = default!;

        public bool? Verwijderd { get; set; } = default!;

        //Nav Props
        public List<Studiebezoek>? Studiebezoeken { get; set; }
    }
}