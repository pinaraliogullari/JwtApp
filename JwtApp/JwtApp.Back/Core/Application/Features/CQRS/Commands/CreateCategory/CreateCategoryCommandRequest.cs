using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Definition { get; set; }
    }
}
