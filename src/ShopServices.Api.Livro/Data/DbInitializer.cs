using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopServices.Api.Livro.Data.ExecuteScript
{
    public class DbInitializer : IDbInitializer
    {
        private readonly LivroContext _context;

        public DbInitializer(LivroContext context)
        {
            _context = context;
        }

        public async void Initialize()
        {
            if (_context.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();

        }
    }    
}
