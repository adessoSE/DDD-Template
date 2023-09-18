using Kernel.Contracts.Interfaces.Services;
using Kernel.Contracts.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kernel.Base.Repositories
{
    public class DbContextBase<TDbContext> : DbContext
        where TDbContext : DbContext
    {
        private readonly IUserAccessorService? _userService;
        private readonly IDateTimeService? _dateTimeService;
        public DbContextBase(DbContextOptions<TDbContext> options)
            : base(options)
        {
        }

        public DbContextBase(DbContextOptions<TDbContext> options, IDateTimeService dateTimeService, IUserAccessorService userService)
            : base(options)
        {
            _userService = userService;
            _dateTimeService = dateTimeService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SetAuditProperties();            

            return base.SaveChanges();
        }

        public void TrySetModified<TEntity>(TEntity entity)
            where TEntity : notnull
        {
            var entityEntry = Entry(entity);
            if (entityEntry.State != EntityState.Unchanged)
            {
                return;
            }

            entityEntry.State = EntityState.Modified;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());           

            base.OnModelCreating(modelBuilder);
        }

        private void SetAuditProperties()
        {
            if (_userService is null || _dateTimeService is null)
            {
                return;
            }

            foreach (var entry in this.ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _userService.UserId;
                        entry.Entity.Created = _dateTimeService.Now;
                        entry.Entity.LastModifiedBy = entry.Entity.CreatedBy;
                        entry.Entity.LastModified = entry.Entity.Created;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _userService.UserId;
                        entry.Entity.LastModified = _dateTimeService.Now;
                        break;

                    default:
                        // Do nothing
                        break;
                }
            }
        }        
    }
}
