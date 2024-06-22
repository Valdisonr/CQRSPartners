using Application.CQRS.ProdutosCases.ProdutosQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]

        public async Task<IActionResult> GetProdutos()
        {
            var query =new ProdutoGetQuery();
            var produtos=await _mediator.Send(query);
            return Ok(produtos);
        }



    }
}
