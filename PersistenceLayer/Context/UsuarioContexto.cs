using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersistenceLayer.Dao;

namespace PersistenceLayer.Context
{
    public class UsuarioContexto : DbContext
    {
        private readonly IConfiguration _config;
        public UsuarioContexto(DbContextOptions<UsuarioContexto> options) : base(options)
        {
        }

        public DbSet<UsuarioDao> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDao>().HasKey(m => m.Cpf);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Usuarios.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
