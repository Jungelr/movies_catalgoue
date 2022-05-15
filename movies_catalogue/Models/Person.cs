using movies_catalogue.Models.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movies_catalogue.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public Role Role { get; set; }
        public ICollection<PeopleInMovies> PeopleInMovies { get; set; } = new List<PeopleInMovies>();
        public string FullName()
        {
            return Name + " " + Surname;
        }
    }
}
