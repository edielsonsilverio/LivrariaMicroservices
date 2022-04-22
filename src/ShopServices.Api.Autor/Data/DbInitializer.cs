using Core.Data;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Data.ExecuteScript
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AutorContext _context;

        public DbInitializer(AutorContext context)
        {
            _context = context;
        }

        public async void Initialize()
        {
            if ((_context.Database.GetPendingMigrations()).Any())
                _context.Database.Migrate();
        }

        private async Task<bool> InserirAutor()
        {
            var model = new List<AutorLivro>
            {
                new (){Nome = "José",Apelido = "Zé",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Maria",Apelido = "Mara",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Joana",Apelido = "JÔ",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Pedro",Apelido = "Pedra",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Antonio",Apelido = "Tonho",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Marcio",Apelido = "Cabeça",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Ana",Apelido = "Ana",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()},
                new (){Nome = "Alessandro",Apelido = "Alex",DataNascimento = DateTime.UtcNow,AutorLivroGuid = Guid.NewGuid().ToString()}
            };

           await _context.AddRangeAsync(model);
           return (await _context.SaveChangesAsync()) > 0 ? true : false;
        }
    }
}
