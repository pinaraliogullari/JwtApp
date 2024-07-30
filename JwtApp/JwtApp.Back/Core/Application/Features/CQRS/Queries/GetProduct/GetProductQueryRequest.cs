using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.GetProduct
{
    public class GetProductQueryRequest : IRequest<GetProductQueryResponse>
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
