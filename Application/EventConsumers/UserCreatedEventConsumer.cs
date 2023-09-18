using DDDTemplate.Domain.Entities;
using DDDTemplate.Domain.Interfaces.Repositories;
using MassTransit;
using UserService.Contracts.Events;

namespace DDDTemplate.Application.EventConsumers
{
    public class UserCreatedEventConsumer : IConsumer<UserCreatedDomainEvent>
    {
        private readonly IUserRepository _repository;

        public UserCreatedEventConsumer(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<UserCreatedDomainEvent> context)
        {
            var user = new User
            {
                FirstName = context.Message.Payload.FirstName,
                LastName = context.Message.Payload.LastName,
                Email = context.Message.Payload.Email
            };

            // save User
            var addedUser = await _repository.AddAsync(user);

        }
    }
}
