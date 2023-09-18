using DDDTemplate.Contracts.Events;
using DDDTemplate.Domain.Entities;

namespace DDDTemplate.Domain.Interfaces.Factories
{
    public interface IDomainEventFactory
    {
        TemplateEntityCreated CreateTemplateEntityCreatedEvent(TemplateEntity templateEntity);
        TemplateEntityUpdated CreateTemplateEntityUpdatedEvent(TemplateEntity templateEntity);
        TemplateEntityCalculated CreateTemplateEntityCalculatedEvent(TemplateEntity templateEntity);
        TemplateEntityDeleted CreateTemplateEntityDeletedEvent(Guid id);       
    }
}
