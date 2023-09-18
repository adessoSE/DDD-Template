using Kernel.Contracts.Interfaces.Events;
using Kernel.Contracts.Interfaces.Services;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Kernel.Base.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public DomainEventService(ILogger<DomainEventService> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync(IDomainEvent domainEvent)
        {
            _logger.LogInformation($"Publishing domain event. Event - {domainEvent}", domainEvent.GetType().FullName);

            try
            {
                await _publishEndpoint.Publish(domainEvent);
                domainEvent.SetPublish(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception while publishing domain event.");
            }
        }

        public void Publish(IDomainEvent domainEvent)
        {
            _logger.LogInformation($"Publishing domain event. Event - {domainEvent}", domainEvent.GetType().FullName);

            try
            {
                _publishEndpoint.Publish(domainEvent);
                domainEvent.SetPublish(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception while publishing domain event.");
            }
        }
    }
}
