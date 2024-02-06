using System.Linq.Expressions;

namespace Prueba.Tekton.Application.Contratcs.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        void AddEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);
    }
}
