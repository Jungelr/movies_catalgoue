using Microsoft.AspNetCore.Identity;

namespace movies_catalogue.Models
{
    public class MoviesCatalogueUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Favorite UserFavorites { get; set; }
    }
}
