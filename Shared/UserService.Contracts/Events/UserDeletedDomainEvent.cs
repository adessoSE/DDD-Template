using Kernel.Base.Events;
using Kernel.Contracts.Interfaces.Events;

namespace UserService.Contracts.Events
{
    public class UserDeletedDomainEvent : DomainEventBase, IIdDomainEvent<Guid>
    {
        public Guid Id { get; set; }
        public UserDeletedDomainEvent(
            Guid correlationId, Guid createdBy, Guid userId)
            : base(correlationId, createdBy)
        {
            Id = userId;
        }
    }
}

