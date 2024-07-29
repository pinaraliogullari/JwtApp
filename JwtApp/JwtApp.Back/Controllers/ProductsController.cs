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
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
