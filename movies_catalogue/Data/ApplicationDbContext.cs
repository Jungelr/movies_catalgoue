using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movies_catalogue.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace movies_catalogue.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Person> People { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
