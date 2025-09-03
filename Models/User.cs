namespace ControleGastos.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
    }

}
