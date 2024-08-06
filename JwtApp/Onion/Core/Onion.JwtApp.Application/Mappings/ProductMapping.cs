using AutoMapper;
using Onion.JwtApp.Application.Features.CQRS.Commands.CreateProduct;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetAllProduct;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetProduct;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductQueryResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommandResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
        }
    }
}
