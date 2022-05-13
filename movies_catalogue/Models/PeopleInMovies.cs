﻿using System.ComponentModel.DataAnnotations.Schema;

namespace movies_catalogue.Models
{
    public class PeopleInMovies
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

    }
}
