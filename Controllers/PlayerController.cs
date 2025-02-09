using Microsoft.AspNetCore.Mvc;
using ConquerSite.Data;
using ConquerSite.Models;
using System.Linq;

namespace SeuProjeto.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var players = _context.accounts.ToList();
            return View(players);
        }
    }
}
