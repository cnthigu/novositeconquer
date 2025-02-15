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
            Random rand = new Random();
            int avatarId = rand.Next(1, 296);  
            return avatarId.ToString("D3");  
        }
    }


}
