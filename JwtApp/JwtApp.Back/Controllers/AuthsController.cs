using JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.CheckUser;
using JwtApp.Back.Core.Application.Token;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenHandler _tokenHandler;

        public AuthsController(IMediator mediator, ITokenHandler tokenHandler)
        {
            _mediator = mediator;
            _tokenHandler = tokenHandler;
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
                return Created("", _tokenHandler.CreateAccessToken(5));
            else
                return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
    }
}
