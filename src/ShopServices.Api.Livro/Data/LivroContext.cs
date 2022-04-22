using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext() { }
        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }

        public virtual DbSet<LivroPublicacao> Livros { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().AreUnicode(false).HaveColumnType("varchar");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var conn = "Server=127.0.0.1,11433;Database=ShopLivro;User=sa;Password=MeuDb@123";
        //    optionsBuilder.UseSqlServer(conn);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivroContext).Assembly);
        }


    }
}

//Instalar o SqlServer no docker
// docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MeuDb@123" -p 14433:1433 --name docker-sqlserver --hostname docker-sql -d mcr.microsoft.com/mssql/server:2019-latest

