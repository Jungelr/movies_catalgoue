using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movies_catalogue.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public string ApplicationUserId { get; set; }
        public ICollection<MoviesInFavorites> MoviesInFavorites { get; set; }

    }
}
