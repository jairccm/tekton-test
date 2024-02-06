namespace Prueba.Tekton.Application.Contratcs.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository ProductRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Complete();
    }
}
