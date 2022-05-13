namespace movies_catalogue.Models
{
    public class Actor : Person
    {
        public List<Movie> actingMovies { get; set; }

    }
}
