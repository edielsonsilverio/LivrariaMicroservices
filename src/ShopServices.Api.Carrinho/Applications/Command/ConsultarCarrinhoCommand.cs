using MediatR;
using ShopServices.Api.Carrinho.Applications.Dtos;

namespace ShopServices.Api.Carrinho.Applications.Command
{
    public class ConsultarCarrinhoCommand : IRequest<CarrinhoCompraDto>
    {
        public int CarrinhoCompraId { get; set; }
    }
}
