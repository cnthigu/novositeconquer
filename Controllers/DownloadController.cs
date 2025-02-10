using Microsoft.AspNetCore.Mvc;

namespace ConquerSite.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
