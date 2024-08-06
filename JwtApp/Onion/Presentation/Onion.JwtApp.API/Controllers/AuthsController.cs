using JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.JwtApp.Application.Features.CQRS.Queries.CheckUser;
using Onion.JwtApp.Application.Token;

namespace Onion.JwtApp.API.Controllers
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
            var result= await _mediator.Send(request);
            return Created("", result);
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
