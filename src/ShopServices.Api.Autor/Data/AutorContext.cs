using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Data;

public class AutorContext : DbContext
{
    //public AutorContext() { }
    public AutorContext(DbContextOptions<AutorContext> options) : base(options) { }

    public DbSet<AutorLivro> AutorLivros { get; set; }
    public DbSet<GrauAcademico> GrauAcademicos { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(false).HaveColumnType("character varying");
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //var conn = "Server=127.0.0.1;Database=ShopLivroAutor;Port=15432;User Id=postgres;Password=MeuDb@123";
    //optionsBuilder.UseNpgsql(conn);
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutorContext).Assembly);
    }

    
}

//Instalar o Postgres no docker
// docker run --name docker-postgres -e POSTGRES_PASSWORD=MeuDb@123 -d postgres
// docker run --name docker-postgres -e POSTGRES_PASSWORD=MeuDb@123 -e POSTGRES_USER=postgres   -p 5442:5432 -v /data:/var/lib/postgresql/data -d postgres


