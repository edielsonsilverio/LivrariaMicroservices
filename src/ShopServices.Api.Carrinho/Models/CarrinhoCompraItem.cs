namespace ShopServices.Api.Carrinho.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoItemId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string ProdutoSelecionado { get; set; }
        public int CarrinhoCompraId { get; set; }
        public CarrinhoCompra Carrinho { get; set; }
    }
}
