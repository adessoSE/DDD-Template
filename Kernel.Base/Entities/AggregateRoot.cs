using Kernel.Contracts.Interfaces.Entities;

namespace Kernel.Base.Entities
{
    public class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public Guid? LastModifiedBy { get; set; }
    }
}
