using Kernel.Base.Events;
using Kernel.Contracts.Interfaces.Events;

namespace DDDTemplate.Contracts.Events
{
    public class TemplateEntityDeleted: DomainEventBase, IIdDomainEvent<Guid>
    {
        public Guid Id { get; set; }

        public TemplateEntityDeleted(Guid correlationId, Guid createdBy, Guid id)
            : base(correlationId, createdBy)
        {
            Id = id;
        }
    }
}
