﻿using AutoMapper;
using JwtApp.Back.Core.Application.DTOs;
using JwtApp.Back.Core.Domain;

namespace JwtApp.Back.Core.Application.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
