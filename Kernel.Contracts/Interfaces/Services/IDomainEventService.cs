using Kernel.Contracts.Interfaces.Events;

namespace Kernel.Contracts.Interfaces.Services
{
    public interface IDomainEventService
    {
        Task PublishAsync(IDomainEvent domainEvent);
        void Publish(IDomainEvent domainEvent);
    }
}
