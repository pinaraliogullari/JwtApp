using MediatR;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.RemoveProduct
{
    public class RemoveProductCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
