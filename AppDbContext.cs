using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define o nome da tabela
            modelBuilder.Entity<Contato>().ToTable("contato");

            // Força todas as colunas a serem minúsculas
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }
            }

            // Configuração adicional, se houver
            modelBuilder.Entity<Contato>().HasKey(c => c.Id);
        }
    }
}
