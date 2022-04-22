using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopServices.Api.Carrinho.Data.ExecuteScript
{
    public class DbInitializer : IDbInitializer
    {
        private readonly CarrinhoContext _context;

        public DbInitializer(CarrinhoContext context)
        {
            _context = context;
        }

        public  void Initialize()
        {
            if (_context.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();
 
        }
    }
}
