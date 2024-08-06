using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain;
using MediatR;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedProduct = await _repository.GetByIdAsync(request.Id); 
            if (deletedProduct != null)
                await _repository.Remove(deletedProduct);
            return Unit.Value;
        }
    }
}
