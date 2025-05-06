using System.Diagnostics;
using ConquerSite.Models;
using ConquerSite.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConquerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlayerService _playerService; // Adicione o serviço

        // Injete o PlayerService no construtor
        public HomeController(ILogger<HomeController> logger, PlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            // Obtém a contagem de jogadores online
            int onlinePlayers = _playerService.GetOnlinePlayersCount();
            ViewData["OnlinePlayers"] = onlinePlayers; // Passa para a view via ViewData

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}