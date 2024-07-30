using JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.CheckUser;
using JwtApp.Back.Infrastructure.Token;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsExist)
            {
                JwtGenerator jwtGenerator = new(_configuration);
                return Created("", jwtGenerator.CreateAccessToken(response));
            }
            else
            {
                return BadRequest("Kullanıcı adi veya sifre hatali");
            }
        }
    }
}
