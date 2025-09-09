using ControleGastos.ControleGastos.Business.Models;
using ControleGastos.ControleGastos.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.ControleGastos.WebApps.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly AppDbContext _context;

        public TransacaoController(AppDbContext context)
        {
            _context = context;
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
