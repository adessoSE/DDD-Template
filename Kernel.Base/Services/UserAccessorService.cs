using Kernel.Contracts.Interfaces.Services;
using System.Security.Claims;

namespace Kernel.Base.Services
{
    public class UserAccessorService : IUserAccessorService
    {
        // TODO!!
        public Guid UserId { get; set; }
        public ClaimsPrincipal User { get; set; } = null!;
    }
}
