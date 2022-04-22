using MediatR;
using ShopServices.Api.Carrinho.Applications.Command;
using ShopServices.Api.Carrinho.Data;
using ShopServices.Api.Carrinho.Models;

namespace ShopServices.Api.Carrinho.Applications.CommandHandler
{
    public class NovoCarrinhoCommandHandler : IRequestHandler<NovoCarrinhoCommand, bool>
    {
        private readonly CarrinhoContext _context;

        public NovoCarrinhoCommandHandler(CarrinhoContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(NovoCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = new CarrinhoCompra { DataCadastro = request.DataCadastro };

            _context.Carrinhos.Add(carrinho);
            var value = await _context.SaveChangesAsync();

            if (value == 0) throw new Exception("Não foi possível salvar o regitro.");

            foreach (var item in request.Produtos)
            {
                var carrinhoItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = carrinho.CarrinhoCompraId,
                    ProdutoSelecionado = item,
                    DataCadastro = DateTime.Now
                };
                _context.CarrinhoItens.Add(carrinhoItem);   
            }

            value = await _context.SaveChangesAsync();
            if (value == 0) throw new Exception("Não foi possível salvar os itens do carrinho");

            return true;
        }
    }
}
