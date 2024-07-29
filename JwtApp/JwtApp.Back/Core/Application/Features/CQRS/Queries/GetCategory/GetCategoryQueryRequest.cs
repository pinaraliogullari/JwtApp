using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.GetCategory
{
    public class GetCategoryQueryRequest:IRequest<GetCategoryQueryResponse>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
