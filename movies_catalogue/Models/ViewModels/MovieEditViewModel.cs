using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace movies_catalogue.Models.ViewModels
{
    public class MovieEditViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ImdbLink { get; set; }
        public string PictureURL { get; set; }
        public DateTime Timestamp { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public string[] SelectedGenres { get; set; }
    }
}
