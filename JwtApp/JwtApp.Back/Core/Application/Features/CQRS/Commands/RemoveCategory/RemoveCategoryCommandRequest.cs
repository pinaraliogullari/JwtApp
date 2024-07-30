using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.RemoveCategory
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
