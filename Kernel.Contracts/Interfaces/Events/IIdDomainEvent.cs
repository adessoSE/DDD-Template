namespace Kernel.Contracts.Interfaces.Events
{
    public interface IIdDomainEvent<TId> : IDomainEvent
    {
        TId Id { get; }
    }
}
