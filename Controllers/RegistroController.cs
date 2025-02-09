using ConquerSite.Data;
using ConquerSite.Models;
using Microsoft.AspNetCore.Mvc;

public class RegistroController : Controller
{
    private readonly ApplicationDbContext _context;

    public RegistroController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(PlayerModels model)
    {
        if (ModelState.IsValid)
        {
            var user = new PlayerModels
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,

            };
            _context.accounts.Add(user);
            _context.SaveChanges();

            return RedirectToAction("", "");
        }

        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Erro: {error.ErrorMessage}");
            }
            return View(model);
        }

        Console.WriteLine("Modelo inválido");
        return View(model);
    }
}
