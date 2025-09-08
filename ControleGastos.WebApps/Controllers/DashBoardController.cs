using ControleGastos.ControleGastos.Infra.Data;
using ControleGastos.ControleGastos.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.WebApps.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly AppDbContext _context;

        public DashBoardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarGasto([FromBody] Transacao tr)
        {
            var transacao = new Transacao
            {
                Descricao = tr.Descricao,
                Valor = tr.Valor,
                Tipo = tr.Tipo,
                FormaPagamento = tr.FormaPagamento,
                CategoriaId = tr.CategoriaId,
                Data = DateTime.Now,
                UserId = tr.UserId
            };

            _context.Transacao.Add(transacao);
            _context.SaveChanges();

            return Ok(new { mensagem = "Transação registrada com sucesso!" });
        }

    }
}
