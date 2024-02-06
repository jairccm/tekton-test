using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Application.Exeptions;
using Prueba.Tekton.Domain;

namespace Prueba.Tekton.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                _logger.LogError($"No se encontro el product con id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }

             _unitOfWork.ProductRepository.DeleteEntity(product);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Producto {product.Name} eliminado correctamente");
        }
    }
}
