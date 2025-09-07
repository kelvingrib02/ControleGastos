using Microsoft.EntityFrameworkCore;
using ControleGastos.ControleGastos.Business.Models;

namespace ControleGastos.ControleGastos.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<User> User { get; set; }
    }
}
