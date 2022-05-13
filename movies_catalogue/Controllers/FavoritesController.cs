using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies_catalogue.Data;
using movies_catalogue.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
