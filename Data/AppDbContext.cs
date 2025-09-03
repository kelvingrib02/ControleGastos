using Microsoft.EntityFrameworkCore;
using ControleGastos.Models;

namespace ControleGastos.Data
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
