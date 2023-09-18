using DDDTemplate.Contracts.Events.Payloads;
using Kernel.Base.Events;
using Kernel.Contracts.Interfaces.Events;

namespace DDDTemplate.Contracts.Events
{
    public class TemplateEntityCalculated: DomainEventBase, IPayloadDomainEvent<TemplatePayload>
    {
        public TemplatePayload Payload { get; set; }

        public TemplateEntityCalculated(Guid correlationId, Guid createdBy, TemplatePayload payload)
            : base(correlationId, createdBy)
        {
            Payload = payload;
        }
    }
}
