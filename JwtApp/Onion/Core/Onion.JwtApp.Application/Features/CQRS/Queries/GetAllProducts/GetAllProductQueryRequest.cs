using MediatR;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
