using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Autor.Applications.Command;
using ShopServices.Api.Autor.Applications.Dtos;
using ShopServices.Api.Autor.Data;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Applications.CommandHandler
{
    public class PesquisaAutorCommandHandler : IRequestHandler<PesquisaAutorCommand, AutorLivroDto>
    {
        private readonly AutorContext _context;
        private readonly IMapper _mapper;

        public PesquisaAutorCommandHandler(
            AutorContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AutorLivroDto> Handle(PesquisaAutorCommand message, CancellationToken cancellationToken)
        {
            var autor = await _context.AutorLivros.FirstOrDefaultAsync(x => x.AutorLivroGuid == message.AutorLvroGuid );
            if (autor == null)
                throw new Exception("Não foi possível pesquisar o autor");

            return _mapper.Map<AutorLivro,AutorLivroDto>(autor);
        }
    }
}
