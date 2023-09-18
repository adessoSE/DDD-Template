using DDDTemplate.Contracts.Events;
using DDDTemplate.Contracts.Events.Payloads;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Factories;
using Kernel.Contracts.Interfaces.Services;

namespace DDDTemplate.Domain.Factories
{
    public class DomainEventFactory: IDomainEventFactory
    {
        private readonly IUserAccessorService _userService;
        public DomainEventFactory(IUserAccessorService userService)
        {
            _userService = userService;
        }

        public TemplateEntityCreated CreateTemplateEntityCreatedEvent(TemplateEntity templateEntity)
        {
            var templatePayload = CreatePayloadFromEntity(templateEntity);
            return new TemplateEntityCreated(Guid.NewGuid(), _userService.UserId, templatePayload);         
        }

        public TemplateEntityUpdated CreateTemplateEntityUpdatedEvent(TemplateEntity templateEntity)
        {
            var templatePayload = CreatePayloadFromEntity(templateEntity);
            return new TemplateEntityUpdated(Guid.NewGuid(), _userService.UserId, templatePayload);
        }

        public TemplateEntityCalculated CreateTemplateEntityCalculatedEvent(TemplateEntity templateEntity)
        {
            var templatePayload = CreatePayloadFromEntity(templateEntity);
            return new TemplateEntityCalculated(Guid.NewGuid(), _userService.UserId, templatePayload);
        }

        public TemplateEntityDeleted CreateTemplateEntityDeletedEvent(Guid id)
        {
            return new TemplateEntityDeleted(Guid.NewGuid(), _userService.UserId, id);
        }

        private TemplatePayload CreatePayloadFromEntity(TemplateEntity templateEntity)
        {
            var templatePayload = new TemplatePayload();
            // TODO Mapping
            return templatePayload;
        }
    }
}
