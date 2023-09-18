using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Kernel.Contracts.Interfaces.Services;
using Kernel.Base.Repositories;
using DDDTemplate.Domain.Entities;

namespace DDDTemplate.Infrastructure.Persistence
{
    public class UserDbContext : DbContextBase<UserDbContext>
    {   
        public DbSet<User> Users { get; set; } = null!;        

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        
        public UserDbContext(DbContextOptions<UserDbContext> options, 
            IUserAccessorService userAccessorService, 
            IDateTimeService dateTimeService)
            : base(options, dateTimeService, userAccessorService)
        {
            
        }       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("User");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }               
    }
}
