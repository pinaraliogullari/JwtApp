using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Commands.RemoveProduct
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
            var deletedProduct = await _repository.GetByIdAsync(request.Id); //getById ct başlatıyo yani entity i izliyo.
            if (deletedProduct != null)
                await _repository.RemoveAsync(deletedProduct);
            return Unit.Value;
        }
    }
}
