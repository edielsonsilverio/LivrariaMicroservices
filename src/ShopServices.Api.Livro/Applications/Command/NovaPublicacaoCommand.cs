using MediatR;

namespace ShopServices.Api.Livro.Applications.Command
{
    public class NovaPublicacaoCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Guid? AutorLivro { get; set; }
    }
}
