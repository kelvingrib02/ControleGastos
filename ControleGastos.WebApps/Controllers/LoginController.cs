using ControleGastos.ControleGastos.Infra.Data;
using ControleGastos.ControleGastos.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.WebApps.Controllers
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

        [HttpPost]
        public IActionResult Cadastrar([FromForm] string Nome, [FromForm] string UserName, [FromForm] string Senha, [FromForm] string ConfirmarSenha)
        {
            var existe = _context.User.Any(u => u.UserName == UserName);
            if (existe)
            {
                TempData["Error"] = "Usuário já cadastrado";
                return RedirectToAction("Index", "Login");
            }

            var senhaCript = BCrypt.Net.BCrypt.HashPassword(Senha);

            var novoUsuario = new User
            {
                Nome = Nome,
                UserName = UserName,
                SenhaHash = senhaCript,
                Ativo = true
            };

            _context.User.Add(novoUsuario);
            _context.SaveChanges();

            TempData["Sucesso"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Autenticacao([FromForm] string UserName, [FromForm] string Senha)
        {
            var usuario = _context.User.FirstOrDefault(u => u.UserName == UserName);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(Senha, usuario.SenhaHash))
            {
                TempData["Error"] = "Usuário ou senha inválidos!";
                return RedirectToAction("Index", "Login");
            }

            if (!usuario.Ativo)
            {
                TempData["Error"] = "Usuário inativado!";
                return RedirectToAction("Index", "Login");
            }

            TempData["Success"] = "Login realizado com sucesso!";
            return RedirectToAction("Index", "DashBoard");
        }
    }
}