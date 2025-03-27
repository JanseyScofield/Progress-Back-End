using Microsoft.EntityFrameworkCore;
using Progress.Infrastructure.Entitites;

namespace Progress.Infrastructure
{
    public class ProgressDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ClienteProduto> ClienteProduto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Progress", "progress.db")}");

        }
    }
}
