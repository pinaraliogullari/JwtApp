using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
