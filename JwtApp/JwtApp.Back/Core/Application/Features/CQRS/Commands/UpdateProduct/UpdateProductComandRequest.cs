using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.UpdateProduct
{
    public class UpdateProductComandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
