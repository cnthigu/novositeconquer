using Microsoft.AspNetCore.Mvc;
using ConquerSite.Data;
using System.Linq;
using ConquerSite.Models;

namespace ConquerSite.Controllers
{
    public class MarketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarketController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.marketitems.ToList();
            return View(items);
        }

        public string GetRandomAvatar()
        {
            // Gera um número aleatório entre 1 e 295
            Random rand = new Random();
            int avatarId = rand.Next(1, 296);  // 296 porque o intervalo é exclusivo no número superior
            return avatarId.ToString("D3");  // Retorna o número com 3 dígitos (001, 002, ... 295)
        }
    }


}
