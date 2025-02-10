using ConquerSite.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // Usando memória para armazenar a sessão
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Definir o tempo de expiração da sessão
    options.Cookie.HttpOnly = true; // Aumentar a segurança do cookie
    options.Cookie.IsEssential = true; // Tornar o cookie essencial para o funcionamento da aplicação
});

// Configuração do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

var app = builder.Build();

// Condicional de ambiente (Desenvolvimento ou Produção)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthorization();

/// Adicionando as rotas para os controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}"); // Mapeando para o Login do AccountController

app.Run();
