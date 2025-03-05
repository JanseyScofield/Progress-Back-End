using Microsoft.EntityFrameworkCore;
using Progress.Infrastructure.Entitites;
using System.IO;

namespace Progress.Infrastructure
{
    public class ProgressDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Progress", "progress.db")}");

        }
    }
}
