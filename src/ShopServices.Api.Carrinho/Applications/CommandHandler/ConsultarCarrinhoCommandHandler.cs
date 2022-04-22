using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Carrinho.Applications.Command;
using ShopServices.Api.Carrinho.Applications.Dtos;
using ShopServices.Api.Carrinho.Data;
using ShopServices.Api.Carrinho.Services;

namespace ShopServices.Api.Carrinho.Applications.CommandHandler
{
    public class ConsultarCarrinhoCommandHandler : IRequestHandler<ConsultarCarrinhoCommand, CarrinhoCompraDto>
    {
        private readonly CarrinhoContext _context;
        private readonly ILivroService _livroService;

        public ConsultarCarrinhoCommandHandler(CarrinhoContext context, ILivroService livroService)
        {
            _context = context;
            _livroService = livroService;
        }

        public async Task<CarrinhoCompraDto> Handle(ConsultarCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = await _context.Carrinhos.FirstOrDefaultAsync(x => x.CarrinhoCompraId == request.CarrinhoCompraId);
         
            if (carrinho == null) return new CarrinhoCompraDto();   

            var carrinhoItens = await _context.CarrinhoItens.Where(x => x.CarrinhoCompraId == request.CarrinhoCompraId).ToListAsync();
            var carrinhoItemDto = new List<CarrinhoCompraItemDto>();

            foreach (var livro in carrinhoItens)
            {
                var response = await _livroService.ObterLivro(Guid.Parse(livro.ProdutoSelecionado));
                if (response.resultado)
                {
                    var model = response.livros;
                    var carrinhoItem = new CarrinhoCompraItemDto
                    {
                        TituloLivro = model.Titulo,
                        LivroId = model.BibliotecaId,
                        DataCadastro = model.DataPublicacao.GetValueOrDefault()
                    };
                    carrinhoItemDto.Add(carrinhoItem);
                }
            }
            var carrinhoDto = new CarrinhoCompraDto
            {
                CarrinhoId = carrinho.CarrinhoCompraId,
                DataCadastro = carrinho.DataCadastro.GetValueOrDefault(),
                Produtos = carrinhoItemDto
            };

            return carrinhoDto; 
        }
    }
}
