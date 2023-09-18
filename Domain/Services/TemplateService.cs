using Microsoft.Extensions.Logging;

using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Domain.Interfaces.Services;
using Kernel.Contracts.Interfaces.Services;
using Kernel.Contracts.Exceptions;
using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Factories;

namespace DDDTemplate.Domain.Services
{ 
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repository;
        private readonly IDomainEventService _domainEventService;
        private readonly IDomainEventFactory _domainEventFactory;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _notificationService;
        private readonly ILogger<TemplateService> _logger;
      
        public TemplateService(
            ITemplateRepository repository,            
            IDomainEventService domainEventService,
            IDomainEventFactory domainEventFactory,
            IEmailService notificationService,
            IUserRepository userRepository,            
            ILogger<TemplateService> logger)
        {
            _repository = repository;            
            _domainEventService = domainEventService;
            _userRepository = userRepository;
            _domainEventFactory = domainEventFactory;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task<TemplateEntity> CreateTemplateEntityAsync(TemplateEntity templateEntity)
        {
            try
            {                
                var addedTemplateEntity = await _repository.AddAsync(templateEntity);

                if (addedTemplateEntity is not null)
                {
                    // send event
                    var templateEntityCreatedEvent = _domainEventFactory.CreateTemplateEntityCreatedEvent(addedTemplateEntity);
                    await _domainEventService.PublishAsync(templateEntityCreatedEvent);

                    return addedTemplateEntity;
                }

                throw new InvalidOperationException($"Error occurs by creating of entity '{templateEntity.Name}'");
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurs by creating of entity: {ex.Message}");
                throw;
            }
        }

        public async Task<TemplateEntity> UpdateTemplateEntityAsync(TemplateEntity templateEntity)
        {
            try
            {                
                await _repository.UpdateAsync(templateEntity);

                // send event
                var templateEntityUpdatedEvent = _domainEventFactory.CreateTemplateEntityUpdatedEvent(templateEntity);
                await _domainEventService.PublishAsync(templateEntityUpdatedEvent);

                return templateEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurs by updating of entity: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteTemplateEntityAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);

                // send event
                var templateEntityDeletedEvent = _domainEventFactory.CreateTemplateEntityDeletedEvent(id);
                await _domainEventService.PublishAsync(templateEntityDeletedEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurs by removing of entity with id={id}: {ex.Message}");
                throw;
            }
        }

        public async Task<TemplateEntity?> GetTemplateEntityAsync(Guid id)
        {
            var templateEntity = await _repository.GetByIdAsync(id);
            return templateEntity;
        }

        public async Task<TemplateEntity?> GetTemplateEntityDetailsAsync(Guid id)
        {
            var templateEntity = await _repository.GetTemplateDetailsByIdAsync(id);
            return templateEntity;
        }

        public async Task<TemplateEntity> CalculateTemplateEntityAsync(Guid id)
        {
            var templateEntity = await _repository.GetTemplateDetailsByIdAsync(id);
            if (templateEntity is null)
            {
                var ex = new NotFoundException($"Entity with Id '{id}' could not be found!");
                _logger.LogError(ex.Message, ex);
                throw ex;
            }

            var price = await CalculatePriceAsync(templateEntity);
            templateEntity.Price = price;

            await _repository.UpdateAsync(templateEntity);

            // send event
            var templateEntityCalculatedEvent = _domainEventFactory.CreateTemplateEntityCalculatedEvent(templateEntity);
            await _domainEventService.PublishAsync(templateEntityCalculatedEvent);

            return templateEntity;
        }

        public async Task<IEnumerable<TemplateEntity>> GetTemplateEntityListAsync()
        {
            var templateEntities = await _repository.GetListAsync();
            return templateEntities.ToList();
        }

        public async Task ConfirmPriceTemplateEntityAsync(Guid entityId, Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var entity = await _repository.GetByIdAsync(entityId);

            if (user is null)
            {
                throw new NotFoundException($"User with id={userId} is not found");
            }

            if (entity is null)
            {
                throw new NotFoundException($"Template entity with id={entityId} is not found");
            }

            entity.Confirmed = true;
            await _repository.UpdateAsync(entity);

            var subject = $"Template entity {entity.Name} is confirmed";
            var content = $"Template entity {entity.Name} is confirmed";
            _notificationService.SendEMail(subject, content, user);
        }

        private async Task<double> CalculatePriceAsync(TemplateEntity templateEntity)
        {
            // calculate price            
            return await Task.FromResult(123.45) ;
        }           
    }
}
