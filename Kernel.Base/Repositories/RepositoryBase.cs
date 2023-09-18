using Kernel.Contracts.Interfaces.Entities;
using Kernel.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Base.Repositories
{
    public class RepositoryBase<T, TId, TDbContext> : IRepository<T, TId>
        where TDbContext : DbContext
        where T : class, IEntity<TId>, new()
    {
        protected TDbContext DbContext { get; private set; }

        public RepositoryBase(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<T?> AddAsync(T entity)            
        {
            var addedEntity = DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public virtual async Task DeleteAsync(TId id)           
        {
            var entity = await DbContext.Set<T>().FindAsync(id);
            if (entity is not null)
            {
                DbContext.Set<T>().Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)            
        {            
            DbContext.Set<T>().RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(TId id)            
        {
            var entity = await DbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<List<T>> GetListAsync()            
        {
            var entities = await DbContext.Set<T>().ToListAsync();
            return entities;
        }

        public virtual async Task UpdateAsync(T entity)            
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }        
    }
}
