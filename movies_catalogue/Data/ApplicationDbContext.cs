using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movies_catalogue.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace movies_catalogue.Data
{
    public class ApplicationDbContext : IdentityDbContext<MoviesCatalogueUser>
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<MoviesInFavorites> MoviesInFavorites { get; set; }
        public virtual DbSet<MoviesCatalogueUser> MovieCatalogueUsers { get; set; }
        public virtual DbSet<MoviesInGenres> MoviesInGenres { get; set; }
        public virtual DbSet<PeopleInMovies> PeopleInMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MoviesInFavorites>().HasKey(x => new { x.MovieId, x.FavoriteId });
            builder.Entity<MoviesInGenres>().HasKey(x => new { x.MovieId, x.GenreId });
            builder.Entity<PeopleInMovies>().HasKey(x => new { x.MovieId, x.PersonId });
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
