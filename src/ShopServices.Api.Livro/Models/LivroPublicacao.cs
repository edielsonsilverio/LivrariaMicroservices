namespace ShopServices.Api.Livro.Models
{
    public class LivroPublicacao
    {
        public Guid? BibliotecaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Guid? AutorLivro { get; set; }
    }
}
