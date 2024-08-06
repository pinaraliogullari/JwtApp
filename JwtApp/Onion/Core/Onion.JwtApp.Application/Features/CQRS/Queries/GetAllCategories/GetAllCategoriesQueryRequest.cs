using MediatR;

namespace Onion.JwtApp.Application.Features.CQRS.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
