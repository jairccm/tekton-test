using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Prueba.Tekton.Application.Features.Products.Queries.GetProduct;
using Prueba.Tekton.Application.Mapping;
using Prueba.Tekton.Infraestructure.Cache;
using Prueba.Tekton.Infraestructure.Repositories;
using Prueba.Tekton.UnitTests.Mocks;
using Xunit;

namespace Prueba.Tekton.UnitTests.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly ProductStatusCache _statusCache;

        public GetProductByIdQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            var memoryCacheMock = new Mock<IMemoryCache>();
            var memoryCache = memoryCacheMock.Object;

            _statusCache = new ProductStatusCache(memoryCache);

            MockProductRepository.AddDataProductRepository(_unitOfWork.Object.pruebaTektonDbContext);

        }

        [Fact]
        public async Task GetProductByIdTest()
        {
            var handler = new GetProductByIdQueryHandler(_unitOfWork.Object, _mapper, _statusCache);
            var request = new GetProductByProductIdQuery() { ProductId = "P000-1"};

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsType<ProductVM>(result);
        }
    }
}
