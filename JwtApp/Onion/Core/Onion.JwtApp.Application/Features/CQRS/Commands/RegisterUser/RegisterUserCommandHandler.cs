using MediatR;
using Onion.JwtApp.Application.Enums;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser()
            {
                UserName = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });

            return Unit.Value;
        }
    }
}
