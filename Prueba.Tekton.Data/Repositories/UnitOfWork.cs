using Prueba.Tekton.Application.Contratcs.Persistence;
using Prueba.Tekton.Infraestructure.Persistence;
using System.Collections;


namespace Prueba.Tekton.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly PruebaTektonDbContext _context;

        private IProductRepository _productRepository;


        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public UnitOfWork(PruebaTektonDbContext context)
        {
            _context = context;
        }

        public PruebaTektonDbContext pruebaTektonDbContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }

        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }


    }
}
