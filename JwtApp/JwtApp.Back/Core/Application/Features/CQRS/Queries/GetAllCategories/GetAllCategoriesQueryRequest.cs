using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest:IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
