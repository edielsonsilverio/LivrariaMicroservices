using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopServices.Api.Livro.Applications.Command;
using ShopServices.Api.Livro.Applications.Dtos;

namespace ShopServices.Api.Livro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublicacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Adicionar(NovaPublicacaoCommand data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroPublicacaoDto>>> ObterTodosAutores()
        {
            return await _mediator.Send(new ListaPublicacaoCommand());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroPublicacaoDto>> ObterAutorPorId(string id)
        {
            return await _mediator.Send(new PesquisaPublicacaoCommand { PublicacaoId = id });
        }
    }
}