using DDDTemplate.Domain.Entities;
using Kernel.Contracts.Interfaces.Repositories;

namespace DDDTemplate.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
