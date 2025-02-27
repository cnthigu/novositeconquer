using Microsoft.AspNetCore.Mvc;

namespace ConquerSite.Controllers
{
    public class WikiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
