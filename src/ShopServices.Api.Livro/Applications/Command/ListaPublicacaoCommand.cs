using MediatR;
using ShopServices.Api.Livro.Applications.Dtos;

namespace ShopServices.Api.Livro.Applications.Command
{
    public class ListaPublicacaoCommand : IRequest<List<LivroPublicacaoDto>> {}

   
}
