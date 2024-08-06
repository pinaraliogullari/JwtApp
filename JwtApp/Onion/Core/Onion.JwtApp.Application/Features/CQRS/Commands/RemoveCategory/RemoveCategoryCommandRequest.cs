using MediatR;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.RemoveCategory
{
    public class RemoveCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
