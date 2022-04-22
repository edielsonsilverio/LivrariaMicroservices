using MediatR;

namespace ShopServices.Api.Carrinho.Applications.Command
{
    public class NovoCarrinhoCommand : IRequest<bool>
    {
        public DateTime DataCadastro { get; set; }
        public List<string> Produtos { get; set; }
    }
}
