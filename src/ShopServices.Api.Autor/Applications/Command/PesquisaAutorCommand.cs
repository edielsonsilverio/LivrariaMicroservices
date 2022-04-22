using MediatR;
using ShopServices.Api.Autor.Applications.Dtos;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Applications.Command
{
    public class PesquisaAutorCommand : IRequest<AutorLivroDto>
    {
        public string AutorLvroGuid { get; set; }
    }
}
