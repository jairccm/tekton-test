using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Application.Exeptions;
using Prueba.Tekton.Domain;

namespace Prueba.Tekton.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if(product == null)
            {
                _logger.LogError($"No se encontro el product con id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }
                
            _mapper.Map(request, product,typeof(UpdateProductCommand), typeof(Product));
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            _logger.LogInformation($"Producto {request.Name} actualizado correctamente");
            
        }
    }
}
