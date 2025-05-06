using ConquerSite.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConquerSite.ViewComponents
{
    public class OnlinePlayersViewComponent : ViewComponent
    {
        private readonly PlayerService _playerService;

        public OnlinePlayersViewComponent(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int onlinePlayers = _playerService.GetOnlinePlayersCount();
            return View("~/Views/Shared/OnlinePlayers/Default.cshtml", onlinePlayers);
        }
    }
}
