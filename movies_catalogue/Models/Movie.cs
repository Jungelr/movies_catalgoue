using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movies_catalogue.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string MovieName { get; set; }
        public string ImdbLink { get; set; }
        public string PictureURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<MoviesInFavorites> MoviesInFavorites { get; set; }
        public ICollection<MoviesInGenres> MoviesInGenres { get; set; } = new List<MoviesInGenres>();
        public ICollection<PeopleInMovies> PeopleInMovies { get; set; } = new List<PeopleInMovies>();
        public string TimeLeft()
        {
            TimeSpan timespan = ReleaseDate.Subtract(DateTime.Now);
            double isReleased = timespan.TotalSeconds;

            if (isReleased < 0)
                return "Already released!";
            else
                return timespan.ToString(@"d\.h\:mm\:ss") + " time left until release!";
        }

    }
}
