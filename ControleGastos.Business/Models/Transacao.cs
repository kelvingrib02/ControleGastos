using ControleGastos.ControleGastos.Business.Enums;

namespace ControleGastos.ControleGastos.Business.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int CategoriaId { get; set; }
        public DateTime Data { get; set; }
        public Guid UserId { get; set; }
    }

}
