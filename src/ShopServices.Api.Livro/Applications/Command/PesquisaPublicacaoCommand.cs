using MediatR;
using ShopServices.Api.Livro.Applications.Dtos;

namespace ShopServices.Api.Livro.Applications.Command
{
    public class PesquisaPublicacaoCommand : IRequest<LivroPublicacaoDto>
    {
        public string PublicacaoId { get; set; }
    }
}
