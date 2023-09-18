using Kernel.Base.Events;
using Kernel.Contracts.Interfaces.Events;
using UserService.Contracts.Events.Payloads;

namespace UserService.Contracts.Events
{
    public class UserCreatedDomainEvent : DomainEventBase, IPayloadDomainEvent<User>
    {        
        public User Payload { get; }

        public UserCreatedDomainEvent(
            Guid correlationId, Guid createdBy, User payload)
            : base(correlationId, createdBy)
        {            
            Payload = payload;         
        }        
    }
}
