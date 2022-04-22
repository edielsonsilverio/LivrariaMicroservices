using MediatR;

namespace ShopServices.Api.Autor.Applications
{
    public class NovoAutorCommand : IRequest<bool>
    {
            public string Nome { get; set; }
            public string Apelido { get; set; }
            public DateTime? DataNascimento { get; set; }
    }
   
}
