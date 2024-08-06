using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Commands.CreateCategory;
using Onion.JwtApp.Application.Features.CQRS.Commands.RemoveCategory;
using Onion.JwtApp.Application.Features.CQRS.Commands.UpdateCategory;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetAllCategories;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetCategory;

namespace Onion.JwtApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCategoryQueryRequest(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveCategoryCommandRequest(id));
            return Ok();
        }
    }
}
