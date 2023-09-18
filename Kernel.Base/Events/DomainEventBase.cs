using Kernel.Contracts.Interfaces.Events;

namespace Kernel.Base.Events
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid CorrelationId { get; }
        public bool IsPublished { get; private set; }
        public DateTimeOffset DateOccurred { get; }
        public Guid CreatedBy { get; }

        public DomainEventBase(Guid correlationId, Guid createdBy)
        {
            CorrelationId = correlationId;
            CreatedBy = createdBy;
            DateOccurred = DateTimeOffset.UtcNow;
            IsPublished = false;
        }

        public void SetPublish(bool published)
        {
            IsPublished = published;
        }
    }
}
