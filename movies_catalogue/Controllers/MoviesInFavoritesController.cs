using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movies_catalogue.Data;
using movies_catalogue.Models;

namespace movies_catalogue.Controllers
{
    public class MoviesInFavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesInFavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoviesInFavorites
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId)
                .Include("UserFavorites.MoviesInFavorites")
                .Include("UserFavorites.MoviesInFavorites.Movie")
                .FirstOrDefault();
            var userFavorites = user.UserFavorites;

            var applicationDbContext = _context.MoviesInFavorites
                .Where(m => m.FavoriteId == userFavorites.FavoriteId);

            return View(await applicationDbContext.ToListAsync());
        }

        public ActionResult AddToFavorites(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId)
                .Include("UserFavorites.MoviesInFavorites")
                .Include("UserFavorites.MoviesInFavorites.Movie")
                .FirstOrDefault();

            var movie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();

            var userFavorites = user.UserFavorites;
            var movieInFavorites = new MoviesInFavorites
            {
                Movie = movie,
                MovieId = movie.MovieId,
                Favorite = userFavorites,
                FavoriteId = userFavorites.FavoriteId
            };
            _context.Add(movieInFavorites);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromFavorites(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId)
                .Include("UserFavorites.MoviesInFavorites")
                .Include("UserFavorites.MoviesInFavorites.Movie")
                .FirstOrDefault();

            var favorite = user.UserFavorites;
            var forRemoval = favorite.MoviesInFavorites.Where(m => m.MovieId == movieId).FirstOrDefault();
            favorite.MoviesInFavorites.Remove(forRemoval);

            _context.Update(favorite);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: MoviesInFavorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesInFavorites = await _context.MoviesInFavorites
                .Include(m => m.Favorite)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (moviesInFavorites == null)
            {
                return NotFound();
            }

            return View(moviesInFavorites);
        }

        // GET: MoviesInFavorites/Create
        public IActionResult Create()
        {
            ViewData["FavoriteId"] = new SelectList(_context.Favorites, "FavoriteId", "FavoriteId");
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieName");
            return View();
        }

        // POST: MoviesInFavorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,FavoriteId")] MoviesInFavorites moviesInFavorites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesInFavorites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FavoriteId"] = new SelectList(_context.Favorites, "FavoriteId", "FavoriteId", moviesInFavorites.FavoriteId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieName", moviesInFavorites.MovieId);
            return View(moviesInFavorites);
        }

        // GET: MoviesInFavorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesInFavorites = await _context.MoviesInFavorites.FindAsync(id);
            if (moviesInFavorites == null)
            {
                return NotFound();
            }
            ViewData["FavoriteId"] = new SelectList(_context.Favorites, "FavoriteId", "FavoriteId", moviesInFavorites.FavoriteId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieName", moviesInFavorites.MovieId);
            return View(moviesInFavorites);
        }

        // POST: MoviesInFavorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,FavoriteId")] MoviesInFavorites moviesInFavorites)
        {
            if (id != moviesInFavorites.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesInFavorites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesInFavoritesExists(moviesInFavorites.MovieId))
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
            ViewData["FavoriteId"] = new SelectList(_context.Favorites, "FavoriteId", "FavoriteId", moviesInFavorites.FavoriteId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieName", moviesInFavorites.MovieId);
            return View(moviesInFavorites);
        }

        // GET: MoviesInFavorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesInFavorites = await _context.MoviesInFavorites
                .Include(m => m.Favorite)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (moviesInFavorites == null)
            {
                return NotFound();
            }

            return View(moviesInFavorites);
        }

        // POST: MoviesInFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesInFavorites = await _context.MoviesInFavorites.FindAsync(id);
            _context.MoviesInFavorites.Remove(moviesInFavorites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesInFavoritesExists(int id)
        {
            return _context.MoviesInFavorites.Any(e => e.MovieId == id);
        }
    }
}
