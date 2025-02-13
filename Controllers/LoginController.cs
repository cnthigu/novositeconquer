using ConquerSite.Data;
using ConquerSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly ApplicationDbContext _context;

    public LoginController(ILogger<LoginController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Login()
    {
        _logger.LogInformation("A página de login foi acessada.");
        return View();
    }

    [HttpPost]
    public IActionResult Login(PlayerModels model)
    {
        _logger.LogInformation("Tentativa de login recebida: Username={Username}", model.Username);

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("ModelState inválido: {Errors}", string.Join(", ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)));

            return View(model);
        }

        var user = _context.accounts.SingleOrDefault(u => u.Username == model.Username);
        if (user == null)
        {
            _logger.LogWarning("Usuário não encontrado: {Username}", model.Username);
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View(model);
        }

        if (user.Password != model.Password)
        {
            _logger.LogWarning("Senha incorreta para o usuário: {Username}", model.Username);
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View(model);
        }

        // Login bem-sucedido
        HttpContext.Session.SetString("User", user.Username);
        _logger.LogInformation("Usuário logado com sucesso: {Username}", user.Username);

        return RedirectToAction("", "Pagamento");
    }

    public IActionResult Logout()
    {
        _logger.LogInformation("Usuário deslogado: {Username}", HttpContext.Session.GetString("User"));
        HttpContext.Session.Remove("User");

        return RedirectToAction("Login");
    }
}
