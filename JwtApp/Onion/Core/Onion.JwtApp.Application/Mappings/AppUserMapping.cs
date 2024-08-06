using AutoMapper;
using JwtApp.Back.Core.Application.Features.CQRS.Commands.RegisterUser;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Mappings
{
    public class AppUserMapping:Profile

    {
        public AppUserMapping()
        {
            CreateMap<AppUser, RegisterUserCommandRequest>().ReverseMap();
        }
    }
}
