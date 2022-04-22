namespace ShopServices.Api.Carrinho.Applications.Dtos
{
    public class CarrinhoCompraDto
    {
        public int CarrinhoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<CarrinhoCompraItemDto> Produtos { get; set; }

    }
}
