namespace ShopServices.Api.Carrinho.Applications.Dtos
{
    public class CarrinhoCompraItemDto
    {
        public Guid? LivroId { get; set; }
        public string TituloLivro { get; set; }
        public string AutorLivro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
