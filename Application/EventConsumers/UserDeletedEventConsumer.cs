using DDDTemplate.Domain.Interfaces.Repositories;
using MassTransit;
using UserService.Contracts.Events;

namespace DDDTemplate.Application.EventConsumers
{
    public class UserDeletedEventConsumer : IConsumer<UserDeletedDomainEvent>
    {
        private readonly IUserRepository _repository;

        public UserDeletedEventConsumer(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UserDeletedDomainEvent> context)
        {
            // delete User
            await _repository.DeleteAsync(context.Message.Id);

        }
    }
}
