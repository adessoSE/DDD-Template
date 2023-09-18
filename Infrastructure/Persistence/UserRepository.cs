using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using Kernel.Base.Repositories;

namespace DDDTemplate.Infrastructure.Persistence
{
    public class UserRepository : RepositoryBase<User, Guid, UserDbContext>, IUserRepository
    {        
        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {            
        }
    }
}
