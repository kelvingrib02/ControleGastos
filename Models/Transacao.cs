namespace ControleGastos.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
