using Kernel.Base.Entities;

namespace DDDTemplate.Domain.Entities
{
    public class User : AggregateRoot
    {        
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}

