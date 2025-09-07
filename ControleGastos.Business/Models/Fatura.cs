namespace ControleGastos.ControleGastos.Business.Models
{
    public class Fatura
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataFechamento { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
