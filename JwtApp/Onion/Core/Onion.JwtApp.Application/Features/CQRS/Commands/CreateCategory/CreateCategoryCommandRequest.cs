using MediatR;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string? Definition { get; set; }
    }
}
