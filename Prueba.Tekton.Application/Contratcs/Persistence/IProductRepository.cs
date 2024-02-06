using Prueba.Tekton.Domain;

namespace Prueba.Tekton.Application.Contratcs.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<Product> GetByProductIdAsync(string productId);
    }
}
