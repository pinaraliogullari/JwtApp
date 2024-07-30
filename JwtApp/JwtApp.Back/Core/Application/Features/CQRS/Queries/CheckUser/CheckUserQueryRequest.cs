using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.CheckUser
{
    public class CheckUserQueryRequest : IRequest<CheckUserQueryResponse>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
