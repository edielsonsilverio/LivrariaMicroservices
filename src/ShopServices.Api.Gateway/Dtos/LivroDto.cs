namespace ShopServices.Api.Gateway.Applications.Dtos
{
    public class LivroDto
    {
        public Guid? BibliotecaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Guid? AutorLivro { get; set; }
        public AutorDto Autor { get; set; }
    }
}
