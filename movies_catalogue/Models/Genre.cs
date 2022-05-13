using System.ComponentModel.DataAnnotations;

namespace movies_catalogue.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
