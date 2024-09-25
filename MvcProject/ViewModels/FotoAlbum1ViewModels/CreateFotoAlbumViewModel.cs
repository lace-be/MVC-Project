using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.ViewModels.FotoAlbum1ViewModels
{
    public class CreateFotoAlbumViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Naam { get; set; } = default!;

        [Required(ErrorMessage = "Datum is verplicht")]
        public DateTime Datum { get; set; } = default!;

        [Required(ErrorMessage = "Studiebezoek is verplicht")]
        public int StudiebezoekId { get; set; } = default!;

        public List<IFormFile>? Fotos { get; set; } // Voor het uploaden van foto's, gebruik IFormFile

        public List<SelectListItem> Studiebezoeken { get; set; } = new List<SelectListItem>(); // Voor de dropdown-lijst

        public int GebruikerId { get; set; } = default!;
    }
}
