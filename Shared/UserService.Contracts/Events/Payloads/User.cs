using Kernel.Base.Entities;

namespace UserService.Contracts.Events.Payloads
{
    public class User : AggregateRoot
    {        
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string? Email { get; }
        public string?  TelefonNumber { get; }
        public IEnumerable<Address> Addresses { get; } = new List<Address>();        
        public IEnumerable<string> Roles { get; } = new List<string>();
    }
}
