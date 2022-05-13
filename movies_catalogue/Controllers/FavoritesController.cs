using Microsoft.AspNetCore.Mvc;
using movies_catalogue.Data;

namespace movies_catalogue.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
