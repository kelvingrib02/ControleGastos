using ControleGastos.ControleGastos.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Adicione o DbContext aqui, antes do Build
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=KELVIN-DESKTOP;Database=ControleGastosDB;Trusted_Connection=True;TrustServerCertificate=True"));

// Outros serviços
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Clear();
        options.ViewLocationFormats.Add("/ControleGastos.WebApps/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/ControleGastos.WebApps/Views/Shared/{0}.cshtml");
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


// Pipeline de requisição
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DashBoard}/{action=Index}/{id?}");

app.Run();
