using movies_catalogue.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace movies_catalogue.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; } 
        [Required]
        public Role Role { get; set; }
    }
}
