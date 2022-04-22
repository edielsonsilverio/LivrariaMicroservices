using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Carrinho.Models;

namespace ShopServices.Api.Carrinho.Data
{
    public class CarrinhoContext : DbContext
    {
        public CarrinhoContext(DbContextOptions<CarrinhoContext> options) : base(options) { }

        public DbSet<CarrinhoCompra> Carrinhos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoItens { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().AreUnicode(false).HaveColumnType("varchar");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var conn = "Server = 127.0.0.1;Port=13306; Database = ShopCarrinho; Uid = root; Pwd = MeuDb@123";
        //    optionsBuilder.UseMySql(conn);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarrinhoContext).Assembly);
        }


    }
}

//Instalar o MySQl no docker
// docker run -d -p 13306:3306 --name docker-mysql -e MYSQL_ROOT_PASSWORD=MeuDb@123 -e MYSQL_DATABASE=ShopCarrinho -e MYSQL_USER=admin -e MYSQL_PASSWORD=MeuDb@123 mysql:latest



