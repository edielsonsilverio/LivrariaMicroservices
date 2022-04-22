using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Livro.Applications.Command;
using ShopServices.Api.Livro.Applications.Dtos;
using ShopServices.Api.Livro.Data;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Applications.CommandHandler
{
    public class ListaPublicacaoCommandHandler : IRequestHandler<ListaPublicacaoCommand,List<LivroPublicacaoDto>>
    {
        private readonly LivroContext _context;
        private readonly IMapper _mapper;
        public ListaPublicacaoCommandHandler(LivroContext context, 
                                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LivroPublicacaoDto>> Handle(ListaPublicacaoCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<LivroPublicacao>, List<LivroPublicacaoDto>>(await _context.Livros.ToListAsync());
        }
    }
}
