using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movies_catalogue.Data;
using movies_catalogue.Models;
using movies_catalogue.Models.ViewModels;

namespace movies_catalogue.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            var allGenres = _context.Genres;
            var selectList = new List<SelectListItem>();
            foreach (var genre in allGenres)
            {
                selectList.Add(new SelectListItem(genre.GenreName, genre.ID.ToString()));
            }
            var vm = new MovieCreateViewModel()
            {
                Genres = selectList
            };
            return View(vm);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateViewModel vm)
        {
            Movie toAdd = new Movie()
            {
                MovieName = vm.MovieName,
                ImdbLink = vm.ImdbLink,
                PictureURL = vm.PictureURL,
                ReleaseDate = vm.Timestamp
            };

            foreach (var item in vm.SelectedGenres)
            {
                toAdd.MoviesInGenres.Add(new MoviesInGenres()
                {
                    GenreId = Int16.Parse(item)
                });
            }

            if (ModelState.IsValid)
            {
                _context.Add(toAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toAdd);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var movie = _context.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            var allGenres = _context.Genres;
            var selectGenres = movie.MoviesInGenres.Select(x => new Genre
            {
                ID = x.Genre.ID,
                GenreName = x.Genre.GenreName
            });

            var selectList = new List<SelectListItem>();
            await allGenres.ForEachAsync(item => selectList.Add(new SelectListItem(item.GenreName, item.ID.ToString(), selectGenres.Select(x => x.ID).Contains(item.ID))));
            MovieEditViewModel vm = new MovieEditViewModel()
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                ImdbLink = movie.ImdbLink,
                Timestamp = movie.ReleaseDate,
                Genres = selectList
            };
            return View(vm);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieEditViewModel vm)
        {
            Movie movie = _context.Movies.Where(m => m.MovieId == vm.MovieId).FirstOrDefault();
            movie.MovieName = vm.MovieName;
            movie.ImdbLink = vm.ImdbLink;
            movie.PictureURL = vm.PictureURL;
            movie.ReleaseDate = vm.Timestamp;

            var selectedGenres = vm.SelectedGenres;
            List<int> selectedGenresInt = new List<int>();
            if (selectedGenres != null)
            {
                foreach (var genre in selectedGenres)
                {
                    selectedGenresInt.Add(Int16.Parse(genre));
                }
                List<int> otherGenres = movie.MoviesInGenres.Select(x => x.GenreId).ToList();

                var toAdd = selectedGenresInt.Except(otherGenres);
                var toRemove = otherGenres.Except(selectedGenresInt);

                movie.MoviesInGenres = movie.MoviesInGenres.Where(x => !toRemove.Contains(x.GenreId)).ToList();

                foreach (var genre in toAdd)
                {
                    movie.MoviesInGenres.Add(new MoviesInGenres()
                    {
                        GenreId = genre,
                        MovieId = movie.MovieId
                    });
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
