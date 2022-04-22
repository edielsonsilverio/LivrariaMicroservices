using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Autor.Applications.Command;
using ShopServices.Api.Autor.Applications.Dtos;
using ShopServices.Api.Autor.Data;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Applications.CommandHandler
{
    public class ListaAutorCommandHandler : IRequestHandler<ListaAutorCommand, List<AutorLivroDto>>
    {
        private readonly AutorContext _context;
        private readonly IMapper _mapper;

        public ListaAutorCommandHandler(
            AutorContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AutorLivroDto>> Handle(ListaAutorCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<AutorLivro>, List<AutorLivroDto>>(await _context.AutorLivros.ToListAsync());
        }
    }
}
