
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Prueba.Tekton.Application.Features.Products.Commands.UpdateProduct;
using Prueba.Tekton.Application.Mapping;
using Prueba.Tekton.Infraestructure.Repositories;
using Prueba.Tekton.UnitTests.Mocks;
using Xunit;

namespace Prueba.Tekton.UnitTests.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdateProductCommandHandler>> _logger;

        public UpdateProductCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            _logger = new Mock<ILogger<UpdateProductCommandHandler>>();


            MockProductRepository.AddDataProductRepository(_unitOfWork.Object.pruebaTektonDbContext);
        }

        [Fact]
        public async Task UpdateStreamerCommand_InputStreamer_ReturnsUnit()
        {
            var productInput = new UpdateProductCommand
            {
                ProductId = "PR000-1",
                Name = "Ejemplo de Producto modificado",
                Status = 1,
                Stock = 200,
                Description = "Este es un ejemplo de producto modificado",
                Price = 50.0m,
                Discount = 10.0m,
                FinalPrice = 45.0m
            };

            var handler = new UpdateProductCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            await handler.Handle(productInput, CancellationToken.None);
            Assert.True(true);
        }
    }
}
