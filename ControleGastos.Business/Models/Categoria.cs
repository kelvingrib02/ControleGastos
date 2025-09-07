namespace ControleGastos.ControleGastos.Business.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
    }
}
