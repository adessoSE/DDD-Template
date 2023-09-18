using System.Security.Claims;

namespace Kernel.Contracts.Interfaces.Services
{
    public interface IUserAccessorService
    {
        Guid UserId { get; }
        ClaimsPrincipal User { get; }
    }
}
