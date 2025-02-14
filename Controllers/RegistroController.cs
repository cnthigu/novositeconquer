using System.Net.Mail;
using System.Net;
using ConquerSite.Data;
using ConquerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class RegistroController : Controller
{
    private readonly ApplicationDbContext _context;

    public RegistroController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }
    public IActionResult RecoverAccount()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Recover(string email, string senderName)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            ModelState.AddModelError("Email", "O email é obrigatório.");
            return View("RecoverAccount");
        }

        var user = await _context.accounts.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            ModelState.AddModelError("Email", "Nenhum usuário encontrado com esse email.");
            return View("RecoverAccount");
        }

        var token = Guid.NewGuid().ToString();
        user.RecoveryToken = token;
        await _context.SaveChangesAsync();

        var recoveryLink = Url.Action("ResetPassword", "Registro", new { token, email = user.Email }, Request.Scheme);
        var emailSent = await SendRecoveryEmail(user.Email, recoveryLink, senderName); 
        if (emailSent)
        {
            TempData["SuccessMessage"] = "Um email de recuperação foi enviado.";
        }
        else
        {
            TempData["ErrorMessage"] = "Erro ao enviar o email. Tente novamente mais tarde.";
        }

        return RedirectToAction("Index", "Home");
    }


    private async Task<bool> SendRecoveryEmail(string userEmail, string recoveryLink, string senderName)
    {
        try
        {
            var fromAddress = new MailAddress(userEmail, senderName);
            var toAddress = new MailAddress(userEmail); 
            const string fromPassword = "fLJ2Eg8C1qpSa3xm"; 
            const string subject = "Recuperação de Conta";
            string body = $"Clique no link a seguir para redefinir sua senha: <a href=\"{recoveryLink}\">Redefinir Senha</a>";


            using (var smtp = new SmtpClient("smtp-relay.brevo.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;

  
                smtp.Credentials = new NetworkCredential("85c733001@smtp-brevo.com", fromPassword);

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    await smtp.SendMailAsync(message); 
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            return false;
        }
    }




    [HttpGet]
    public IActionResult ResetPassword(string token, string email)
    {
        var model = new ResetPasswordViewModel { Token = token, Email = email };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _context.accounts.FirstOrDefaultAsync(u => u.Email == model.Email && u.RecoveryToken == model.Token);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Token inválido ou expirado.");
            return View(model);
        }

        user.Password = model.NewPassword;
        user.RecoveryToken = null;
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Sua senha foi redefinida com sucesso!";
        return RedirectToAction("Index", "Home");
    }
}
