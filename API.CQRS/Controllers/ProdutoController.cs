using Application.CQRS.ProdutosCases.ProdutosCommands;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var query = new ProdutoGetByIdQuery { ProdutoId = id };
            var produto  = await _mediator.Send(query);

            return produto != null ? Ok(produto) : NotFound("Produto not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto(ProdutoCreateCommand command)
        {
            var createdProduto = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProduto), new { id = createdProduto.ProdutoId }, createdProduto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var command = new ProdutoDeleteCommand { Id = id };
            var deletedproduto = await _mediator.Send(command);

            return deletedproduto != null ? Ok(deletedproduto) : NotFound("Produto not found.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, ProdutoUpdateCommand command)
        {
            command.Id = id;
            var updatedMember = await _mediator.Send(command);

            return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found.");
        }

    }
}
