using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using MassTransit;
using UserService.Contracts.Events;

namespace DDDTemplate.Application.EventConsumers
{
    public class UserUpdatedEventConsumer : IConsumer<UserUpdatedDomainEvent>
    {
        private readonly IUserRepository _repository;

        public UserUpdatedEventConsumer(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UserUpdatedDomainEvent> context)
        {
            // mapping
            var user = new User
            {
                FirstName = context.Message.Payload.FirstName,
                LastName = context.Message.Payload.LastName,
                Email = context.Message.Payload.Email
            };

            // update User
            await _repository.UpdateAsync(user);

        }
    }
}
