using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser
{
    public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
