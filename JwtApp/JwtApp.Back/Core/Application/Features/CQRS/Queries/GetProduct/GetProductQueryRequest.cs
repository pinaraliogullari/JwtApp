using JwtApp.Back.Core.Application.DTOs;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.GetProduct
{
    public class GetProductQueryRequest:IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
