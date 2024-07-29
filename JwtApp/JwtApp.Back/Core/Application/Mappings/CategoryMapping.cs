using AutoMapper;
using JwtApp.Back.Core.Application.Features.CQRS.Commands.CreateCategory;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.GetAllCategories;
using JwtApp.Back.Core.Application.Features.CQRS.Queries.GetCategory;
using JwtApp.Back.Core.Domain;

namespace JwtApp.Back.Core.Application.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            //CreateMap<Category,CategoryListDto>().ReverseMap();
            CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
        }
    }
}
