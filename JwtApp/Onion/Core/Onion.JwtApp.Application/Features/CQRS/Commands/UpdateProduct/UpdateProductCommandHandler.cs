using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain;
using MediatR;
using Onion.JwtApp.Application.Features.CQRS.Commands.UpdateProduct;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductComandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductComandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {   
                updatedProduct.Name = request.Name;
                updatedProduct.Price = request.Price;
                updatedProduct.Stock = request.Stock;
                updatedProduct.CategoryId = request.CategoryId;
                await _repository.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
