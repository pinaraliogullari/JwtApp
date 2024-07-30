using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.CheckUser
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserQueryResponse>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<CheckUserQueryResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var checkUserQueryResponse = new CheckUserQueryResponse();
            var user = await _userRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
            if (user == null)
                checkUserQueryResponse.IsExist = false;
            else
            {
                checkUserQueryResponse.Username = user.UserName;
                checkUserQueryResponse.Id = user.Id;
                checkUserQueryResponse.IsExist = true;
                var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                checkUserQueryResponse.Role = role?.Definition;
            }
            return checkUserQueryResponse;
        }
    }
}
