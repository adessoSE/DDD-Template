namespace Kernel.Contracts.Interfaces.Events
{
    public interface IPayloadDomainEvent<T> : IDomainEvent
        where T : class
    {
        T Payload { get; }
    }
}
