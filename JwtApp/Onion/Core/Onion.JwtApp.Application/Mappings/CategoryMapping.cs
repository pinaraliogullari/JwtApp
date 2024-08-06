using AutoMapper;
using Onion.JwtApp.Application.Features.CQRS.Commands.CreateCategory;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetAllCategories;
using Onion.JwtApp.Application.Features.CQRS.Queries.GetCategory;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandResponse>().ReverseMap();
        }
    }
}
