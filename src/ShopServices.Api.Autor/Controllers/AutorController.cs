using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopServices.Api.Autor.Applications;
using ShopServices.Api.Autor.Applications.Command;
using ShopServices.Api.Autor.Applications.Dtos;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
 
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Adicionar(NovoAutorCommand data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLivroDto>>> ObterTodosAutores()
        {
            return await _mediator.Send(new ListaAutorCommand());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorLivroDto>> ObterAutorPorId(string id)
        {
            return await _mediator.Send(new PesquisaAutorCommand { AutorLvroGuid = id });   
        }
    }
}