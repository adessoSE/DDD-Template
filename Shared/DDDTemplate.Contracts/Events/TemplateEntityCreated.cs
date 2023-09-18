using DDDTemplate.Contracts.Events.Payloads;
using Kernel.Base.Events;
using Kernel.Contracts.Interfaces.Events;

namespace DDDTemplate.Contracts.Events
{
    public class TemplateEntityUpdated: DomainEventBase, IPayloadDomainEvent<TemplatePayload>
    {
        public TemplatePayload Payload { get; set; }

        public TemplateEntityUpdated(Guid correlationId, Guid createdBy, TemplatePayload payload)
            : base(correlationId, createdBy)
        {
            Payload = payload;
        }
    }
}
