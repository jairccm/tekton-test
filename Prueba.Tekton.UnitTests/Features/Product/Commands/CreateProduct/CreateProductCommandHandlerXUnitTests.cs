using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Prueba.Tekton.Application.Features.Products.Commands.CreateProduct;
using Prueba.Tekton.Application.Mapping;
using Prueba.Tekton.Infraestructure.Repositories;
using Prueba.Tekton.UnitTests.Mocks;
using Xunit;

namespace Prueba.Tekton.UnitTests.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateProductCommandHandler>> _logger;

        public CreateProductCommandHandlerXUnitTests()
        {

            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<CreateProductCommandHandler>>();

            MockProductRepository.AddDataProductRepository(_unitOfWork.Object.pruebaTektonDbContext);
        }

        [Fact]
        public async Task CreateProductCommand_InputProduct_ReturnsGuid()
        {
            var productInput = new CreateProductCommand
            {
                ProductId = "PR000-1",
                Name = "Ejemplo de Producto",
                Status = 1,
                Stock = 100,
                Description = "Este es un ejemplo de producto",
                Price = 50.0m,
                Discount = 10.0m,
                FinalPrice = 45.0m
            };

            var handler = new CreateProductCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(productInput, CancellationToken.None);

            Assert.IsType<Guid>(result);

        }


    }
}
