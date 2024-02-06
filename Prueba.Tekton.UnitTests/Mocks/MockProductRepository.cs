using AutoFixture;
using Prueba.Tekton.Domain;
using Prueba.Tekton.Infraestructure.Persistence;

namespace Prueba.Tekton.UnitTests.Mocks
{
    public class MockProductRepository
    {
        public static void AddDataProductRepository(PruebaTektonDbContext pruebaTektonDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var products = fixture.CreateMany<Product>().ToList();

            products.Add(fixture.Build<Product>()
               .With(tr => tr.Id, new Guid())
               .Create()
           );

            pruebaTektonDbContextFake.Products!.AddRange(products);
            pruebaTektonDbContextFake.SaveChanges();

        }
    }
}
