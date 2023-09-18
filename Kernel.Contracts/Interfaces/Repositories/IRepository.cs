using Kernel.Contracts.Interfaces.Entities;

namespace Kernel.Contracts.Interfaces.Repositories
{   
    public interface IRepository<T, TId>
        where T : class, IEntity<TId>, new()
    {
        Task<T?> GetByIdAsync(TId id);
        Task<List<T>> GetListAsync();
        Task<T?> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TId id);
        Task DeleteRangeAsync(IEnumerable<T> entities);            
    }
}
