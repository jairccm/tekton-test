using AutoMapper;
using MediatR;
using Prueba.Tekton.Application.Contratcs.Cache;
using Prueba.Tekton.Application.Contratcs.Persistence;

namespace Prueba.Tekton.Application.Features.Products.Queries.GetProduct
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByProductIdQuery, ProductVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductStatusCache _productStatusCache;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductStatusCache productStatusCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productStatusCache = productStatusCache;
        }

        public async Task<ProductVM> Handle(GetProductByProductIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByProductIdAsync(request.ProductId);

            var vm =  _mapper.Map< ProductVM > (product);
            var productStatus = _productStatusCache.GetDictotionaryProductStatus();
            if(productStatus.TryGetValue(product.Status, out var statusName))
            {
                vm.StatusName = statusName;
            }

            return vm;
            
        }
    }
}
