using MediatR;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
