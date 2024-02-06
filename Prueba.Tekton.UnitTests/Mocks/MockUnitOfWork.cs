using Microsoft.EntityFrameworkCore;
using Moq;
using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Infraestructure.Persistence;
using Prueba.Tekton.Infraestructure.Repositories;

namespace Prueba.Tekton.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {


        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<PruebaTektonDbContext>()
                .UseInMemoryDatabase(databaseName: $"PruebaTektonDbContext-{dbContextId}")
                .Options;

            var pruebaTektonDbContextFake = new PruebaTektonDbContext(options);
            pruebaTektonDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(pruebaTektonDbContextFake);


            return mockUnitOfWork;
        }

    }
}
