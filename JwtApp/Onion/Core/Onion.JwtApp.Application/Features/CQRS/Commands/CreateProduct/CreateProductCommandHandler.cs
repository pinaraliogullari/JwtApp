using AutoMapper;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain;
using MediatR;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Application.Features.CQRS.Commands.CreateProduct
{
    public class CreateProductCommandHandler :IRequestHandler<CreateProductCommandRequest,CreateProductCommandResponse>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var createdEntity = _mapper.Map<Product>(request);
            var data= await _repository.CreateAsync(createdEntity);
            return _mapper.Map<CreateProductCommandResponse>(data);
           
        }
    }
}
