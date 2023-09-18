using DDDTemplate.Contracts.Events.Payloads;
using Kernel.Base.Events;
using Kernel.Contracts.Interfaces.Events;

namespace DDDTemplate.Contracts.Events
{
    public class TemplateEntityCreated: DomainEventBase, IPayloadDomainEvent<TemplatePayload>
    {
        public TemplatePayload Payload { get; set; }

        public TemplateEntityCreated(Guid correlationId, Guid createdBy, TemplatePayload payload)
            : base(correlationId, createdBy)
        {
            Payload = payload;
        }
    }
}
