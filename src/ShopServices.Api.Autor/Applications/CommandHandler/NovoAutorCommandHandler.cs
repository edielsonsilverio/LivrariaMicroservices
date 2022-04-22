using MediatR;
using ShopServices.Api.Autor.Data;
using ShopServices.Api.Autor.Models;
using ShopServices.Api.Autor.Validations;

namespace ShopServices.Api.Autor.Applications
{
    public class NovoAutorCommandHandler : IRequestHandler<NovoAutorCommand, bool>
    {
        private readonly AutorContext _context;

        public NovoAutorCommandHandler(AutorContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(NovoAutorCommand request, CancellationToken cancellationToken)
        {
            var autorLivro = new AutorLivro
            {
                Apelido = request.Apelido,
                DataNascimento = request.DataNascimento,
                Nome = request.Nome,
                AutorLivroGuid = Guid.NewGuid().ToString(),
            };

            var validation = new NovoAutorCommandValidation();
            if (!validation.Validate(request).IsValid) return false;

            _context.AutorLivros.Add(autorLivro);
            return (await _context.SaveChangesAsync()) > 0 ? true :
                                throw new Exception("Não foi possível inserir o autor do livro");
        }
    }
}
