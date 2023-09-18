using System.Reflection;

using Microsoft.EntityFrameworkCore;

using DDDTemplate.Domain.Entities;
using Kernel.Contracts.Interfaces.Services;
using Kernel.Base.Repositories;

namespace DDDTemplate.Infrastructure.Persistence
{
    public class TemplateDbContext : DbContextBase<TemplateDbContext>
    {        
        public DbSet<TemplateEntity> TemplateEntities { get; set; } = null!;        
        public DbSet<TemplatePosition> TemplatePosition { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
        }
        
        public TemplateDbContext(
            DbContextOptions<TemplateDbContext> options, IUserAccessorService userAccessorService, IDateTimeService dateTimeService)
            : base(options, dateTimeService, userAccessorService)
        {
            
        }       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }               
    }
}
