using System.ComponentModel.DataAnnotations.Schema;

namespace movies_catalogue.Models
{
    public class MoviesInFavorites
    {
        public int MovieId { get; set; }
        public int FavoriteId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("FavoriteId")]
        public Favorite Favorite { get; set; }
    }
}
