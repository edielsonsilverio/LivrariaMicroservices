using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopServices.Api.Carrinho.Applications.Command;
using ShopServices.Api.Carrinho.Applications.Dtos;

namespace ShopServices.Api.Carrinho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrinhoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoCompraDto>> ObterCarrinhoPorId(int id)
        {
            return await _mediator.Send(new ConsultarCarrinhoCommand { CarrinhoCompraId = id });
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Adicionar(NovoCarrinhoCommand data)
        {
            return await _mediator.Send(data);
        }
    }
}
