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
        if (string.IsNullOrWhiteSpace(model.Email))
        {
            ModelState.AddModelError("Email", "O email é obrigatório no cadastro.");
        }

        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Erro: {error.ErrorMessage}");
            }
            return View(model);
        }

        var user = new PlayerModels
        {
            Username = model.Username,
            Email = model.Email,
            Password = model.Password,
        };

        _context.accounts.Add(user);
        TempData["SuccessMessage"] = "Conta criada com sucesso! Você pode fazer login agora.";
        _context.SaveChanges();

        return RedirectToAction("", "");
    }
}
