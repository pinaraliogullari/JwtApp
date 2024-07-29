using JwtApp.Back.Core.Application.Features.CQRS.Commands.CreateProduct;
using JwtApp.Back.Core.Application.Features.CQRS.Commands.RemoveProduct;
using JwtApp.Back.Core.Application.Features.CQRS.Commands.UpdateProduct;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.GetAllProduct;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveProductCommandRequest(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductComandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
