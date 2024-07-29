using JwtApp.Back.Core.Application.DTOs;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<List<ProductListDto>>
    {
    }
}
