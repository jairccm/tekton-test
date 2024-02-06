using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Domain;

namespace Prueba.Tekton.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _unitOfWork.ProductRepository.AddEntity(product);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de Product");
            }

            _logger.LogInformation($"Producto {request.Name} creado correctamente, id generado = {product.Id}");
            return product.Id;
        }
    }
}
