using ControleGastos.Data;
using ControleGastos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar([FromForm] string Nome, [FromForm] string Email, [FromForm] string Senha, [FromForm] string ConfirmarSenha)
        {
            var existe = _context.User.Any(u => u.Email == Email);
            if (existe)
            {
                TempData["Erro"] = "Email já cadastrado";
                return RedirectToAction("Index", "Login");
            }

            var senhaCript = BCrypt.Net.BCrypt.HashPassword(Senha);

            var novoUsuario = new User
            {
                Nome = Nome,
                Email = Email,
                SenhaHash = senhaCript,
                Ativo = false
            };

            _context.User.Add(novoUsuario);
            _context.SaveChanges();

            TempData["Sucesso"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Autenticacao()
        {
            return RedirectToAction("Index");
        }
    }
}
