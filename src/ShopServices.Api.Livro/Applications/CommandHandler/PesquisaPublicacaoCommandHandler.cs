using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Livro.Applications.Command;
using ShopServices.Api.Livro.Applications.Dtos;
using ShopServices.Api.Livro.Data;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Applications.CommandHandler
{
    public class PesquisaPublicacaoCommandHandler : IRequestHandler<PesquisaPublicacaoCommand, LivroPublicacaoDto>
    {
        private readonly LivroContext _context;
        private readonly IMapper _mapper;
        public PesquisaPublicacaoCommandHandler(LivroContext context,
                                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LivroPublicacaoDto> Handle(PesquisaPublicacaoCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Livros.
                    FirstOrDefaultAsync(x => x.BibliotecaId == Guid.Parse(request.PublicacaoId));
            if (model == null)
                throw new Exception("Não foi possível pesquisar a publicação");

            return _mapper.Map<LivroPublicacao, LivroPublicacaoDto>(model);
        }
    }
}
