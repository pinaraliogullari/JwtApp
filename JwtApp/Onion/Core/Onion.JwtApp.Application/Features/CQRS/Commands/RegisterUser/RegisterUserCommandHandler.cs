using AutoMapper;
using MediatR;
using Onion.JwtApp.Application.Enums;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.CreateAsync(new AppUser()
            {
                UserName = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });

            return _mapper.Map<RegisterUserCommandResponse>(data);
        }



    }
}
