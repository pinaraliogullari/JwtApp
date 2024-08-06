using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands.CreateProduct;
using Onion.JwtApp.Application.Features.CQRS.Commands.RemoveProduct;
using Onion.JwtApp.Application.Features.CQRS.Commands.UpdateProduct;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetAllProduct;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetProduct;

namespace Onion.JwtApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, Member")]
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
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductComandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveProductCommandRequest(id));
            return Ok();
        }
    }
}
