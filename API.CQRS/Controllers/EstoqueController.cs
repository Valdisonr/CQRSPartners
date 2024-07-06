using Application.CQRS.EstoqueCases;
using Application.CQRS.ProdutosCases.ProdutosCommands;
using Application.CQRS.ProdutosCases.ProdutosQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;


        }




        [HttpGet]

        public async Task<IActionResult> GetEstoques()
        {
            var query = new EstoqueGetQuery();
            var estoques= await _mediator.Send(query);
            return Ok(estoques);
        }


    }
}
