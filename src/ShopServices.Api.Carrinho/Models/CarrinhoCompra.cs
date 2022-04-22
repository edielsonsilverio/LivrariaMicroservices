namespace ShopServices.Api.Carrinho.Models
{
    public class CarrinhoCompra
    {
        public int CarrinhoCompraId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public ICollection<CarrinhoCompraItem> ListaDetalhe { get; set; }

    }
}
