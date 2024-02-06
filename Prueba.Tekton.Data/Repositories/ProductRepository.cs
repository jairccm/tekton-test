using Microsoft.EntityFrameworkCore;
using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Domain;
using Prueba.Tekton.Infraestructure.Persistence;

namespace Prueba.Tekton.Infraestructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(PruebaTektonDbContext context) :base(context)
        {
            
        }

        public async Task<Product> GetByProductIdAsync(string productId)
        {
            return await _context.Products!.Where(p => p.ProductId.Equals(productId)).FirstOrDefaultAsync();
        }
    }
}
