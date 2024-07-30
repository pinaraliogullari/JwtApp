using AutoMapper;
using JwtApp.Back.Core.Application.Features.CQRS.Commands.CreateProduct;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.GetAllProduct;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.GetProduct;
using JwtApp.Back.Core.Domain;

namespace JwtApp.Back.Core.Application.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, GetProductQueryResponse>().ReverseMap();
            CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
        }
    }
}
